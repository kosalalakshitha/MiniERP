using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Forms;
using MiniERP.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Configuration;

namespace MiniERP.Classes
{
    internal class DBConnect
    {
        private MySqlConnection connection;
        private string database;
        private string password;
        private string server;
        private string uid;

        public DBConnect()
        {
            Initializer();
        }

        private void Initializer()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            connection = new MySqlConnection(connectionString);
        }

        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException e)
            {
                switch (e.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server. Contact administrator");
                        break;
                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        internal bool NewPurchaseOrder(PurchaseOrder purchOrder)
        {
            if (!PurchaseOrderCheckExist(purchOrder.OrderNo))
            {
                string stmt = "INSERT INTO purchase_order_tab VALUES ('" + purchOrder.OrderNo + "', '" +
                    StringManipulation.GetDBDate(purchOrder.Date) + "', '" + purchOrder.Remarks + "', " +
                    purchOrder.InvoiceVal + ", '" + purchOrder.status + "')";
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(stmt, connection);
                    cmd.ExecuteNonQuery();
                    CloseConnection();
                    IncreaseSequence("purch_order_no_sequence", "P");
                    return true;
                }
            }
            else
                MessageBox.Show("Purchase Order number already exist. Cannot add order.");
            return false;
        }

        internal void SavePurchaseOrder(PurchaseOrder purchOrder)
        {
            if (!PurchaseOrderCheckExist(purchOrder.OrderNo))
                NewPurchaseOrder(purchOrder);
            else
                UpdatePurchaseOrder(purchOrder);
        }

        private bool PurchaseOrderCheckExist(string orderNo)
        {
            string stmt = "SELECT 1 FROM purchase_order_tab WHERE order_no = '" + orderNo + "'";
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(stmt, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    CloseConnection();
                    return true;
                }
                else
                {
                    CloseConnection();
                    return false;
                }
            }
            return false;
        }

        internal bool Authenticate(string UserId, string password, out bool isSuperUser, out string userName)
        {
            string HashCode;
            SHA256 shaM = new SHA256Managed();
            HashCode = Encoding.ASCII.GetString(shaM.ComputeHash(Encoding.ASCII.GetBytes(password)));
            
            var query = "SELECT user_id, super_user FROM authentication_tab where user_id = @UserId AND password = @HashCode";

            isSuperUser = false;
            bool result = false;
            userName = "";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.Add("@UserId", MySqlDbType.VarChar);
            command.Parameters["@UserId"].Value = UserId;
            command.Parameters.Add("@HashCode", MySqlDbType.VarChar);
            command.Parameters["@HashCode"].Value = HashCode;

            try
            {
                if (OpenConnection())
                {
                    var dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        isSuperUser = dataReader["super_user"].ToString().Equals("TRUE");
                        userName = dataReader["user_id"].ToString();
                        result = true;
                    }
                    CloseConnection();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        internal bool SaveUseDetail(string userName, string oldPass, string newPass, bool superUser)
        {
            if (CheckUser(userName))
                return ChangePassword(userName, oldPass, newPass);
            else
                return NewUser(userName, superUser);
        }

        internal PurchaseOrder GetPurchaseOrder(string orderNo)
        {
            PurchaseOrder order = new PurchaseOrder();
            string stmt = "SELECT * FROM purchase_order_tab WHERE order_no = '" + orderNo + "'";
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(stmt, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    order.OrderNo = orderNo;
                    order.Date = StringManipulation.GetClientDate(dataReader["date"].ToString());
                    order.Remarks = dataReader["remarks"].ToString();
                    order.InvoiceVal = double.Parse(dataReader["inv_value"].ToString());
                    order.status = (Status)Enum.Parse(typeof(Status), dataReader["status"].ToString());
                }
                CloseConnection();
            }

            return order;
        }

        private bool NewUser(string userName, bool superUser)
        {
            string HashCode;
            SHA256 shaM = new SHA256Managed();
            HashCode = Encoding.ASCII.GetString(shaM.ComputeHash(Encoding.ASCII.GetBytes("password")));

            string stmt = "INSERT INTO authentication_tab (user_id, password, super_user) VALUES (@userName, @HashCode, @superUser)";
            
            MySqlCommand cmd = new MySqlCommand(stmt, connection);
            cmd.Parameters.Add("@userName", MySqlDbType.VarChar);
            cmd.Parameters["@userName"].Value = userName;
            cmd.Parameters.Add("@HashCode", MySqlDbType.VarChar);
            cmd.Parameters["@HashCode"].Value = HashCode;
            cmd.Parameters.Add("@superUser", MySqlDbType.VarChar);
            cmd.Parameters["@superUser"].Value = superUser.ToString().ToUpper();

            if (userName.Equals(string.Empty))
            {
                MessageBox.Show("Please enter a user name");
                return false;
            }
            if (OpenConnection())
            {
                cmd.ExecuteNonQuery();
                CloseConnection();
                return true;
            }
            return false;
        }

        private bool CheckUser(string userName)
        {
            string stmt = "SELECT 1 FROM authentication_tab WHERE user_id = '" + userName + "'";
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(stmt, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    CloseConnection();
                    return true;
                }
                else
                {
                    CloseConnection();
                    return false;
                }
            }
            return false;
        }

        private bool ChangePassword(string userName, string oldPass, string newPass)
        {
            int result;
            string oldHashCode, newHashCode;
            SHA256 shaM = new SHA256Managed();

            oldHashCode = Encoding.ASCII.GetString(shaM.ComputeHash(Encoding.ASCII.GetBytes(oldPass)));
            newHashCode = Encoding.ASCII.GetString(shaM.ComputeHash(Encoding.ASCII.GetBytes(newPass)));

            string stmt = "UPDATE authentication_tab SET password = @newHashCode WHERE user_id = @userName AND password = @oldHashCode";

            MySqlCommand command = new MySqlCommand(stmt, connection);
            command.Parameters.Add("@userName", MySqlDbType.VarChar);
            command.Parameters["@userName"].Value = userName;
            command.Parameters.Add("@oldHashCode", MySqlDbType.VarChar);
            command.Parameters["@oldHashCode"].Value = oldHashCode;
            command.Parameters.Add("@newHashCode", MySqlDbType.VarChar);
            command.Parameters["@newHashCode"].Value = newHashCode;


            if (OpenConnection())
            {
                result = command.ExecuteNonQuery();
                CloseConnection();
                if (result != 1)
                {
                    MessageBox.Show("Authentication failed", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
            return false;
        }

        internal bool DeleteUser(string userName, string password)
        {
            string HashCode;
            SHA256 shaM = new SHA256Managed();

            HashCode = Encoding.ASCII.GetString(shaM.ComputeHash(Encoding.ASCII.GetBytes(password)));

            if (CheckUser(userName))
            {
                string stmt = "DELETE FROM authentication_tab WHERE user_id = @userName AND password = @HashCode";

                MySqlCommand cmd = new MySqlCommand(stmt, connection);
                cmd.Parameters.Add("@userName", MySqlDbType.VarChar);
                cmd.Parameters["@userName"].Value = userName;
                cmd.Parameters.Add("@HashCode", MySqlDbType.VarChar);
                cmd.Parameters["@HashCode"].Value = HashCode;

                if (OpenConnection())
                {
                    cmd.ExecuteNonQuery();
                    CloseConnection();
                    return true;
                }
                return false;
            }
            else
            {
                MessageBox.Show("User not found.");
                return false;
            }
        }

        internal bool IsSuperUser(string userName)
        {
            bool result = false;
            string stmt = "SELECT super_user FROM authentication_tab WHERE user_id = '" + userName + "'";
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(stmt, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                    result = dataReader["super_user"].ToString().Equals("TRUE");
                CloseConnection();
            }
            return result;
        }

        internal TableData GetTableDetails(string tableName)
        {
            var tableData = new TableData(tableName);
            var query =
                @"SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, COLUMN_COMMENT FROM INFORMATION_SCHEMA.COLUMNS WHERE table_name = '" +
                tableName + "' AND table_schema = 'mini_erp'";
            var size = 0;

            if (OpenConnection())
            {
                var cmd = new MySqlCommand(query, connection);
                var dataReader = cmd.ExecuteReader();
                ColumnData column;
                while (dataReader.Read())
                {
                    column = new ColumnData();
                    column.Column = dataReader["COLUMN_NAME"].ToString();
                    switch (dataReader["DATA_TYPE"].ToString())
                    {
                        case "int":
                            column.ColumnType = columnType.INT;
                            break;
                        case "varchar":
                            column.ColumnType = columnType.VARCHAR;
                            break;
                        case "datetime":
                            column.ColumnType = columnType.DATETIME;
                            break;
                        case "decimal":
                            column.ColumnType = columnType.DECIMAL;
                            break;
                    }
                    int.TryParse(dataReader["CHARACTER_MAXIMUM_LENGTH"].ToString(), out size);
                    column.Length = size;
                    column.ColumnComment = dataReader["COLUMN_COMMENT"].ToString();
                    tableData.Columns.Add(column);
                }
                CloseConnection();
            }

            return tableData;
        }

        internal List<string> SearchTable(string stmt, string tableName, List<string> keys)
        {
            List<string> data = new List<string>();
            string values;
            if (OpenConnection())
            {
                var cmd = new MySqlCommand(stmt, connection);
                var dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    values = "";
                    for (int i = 0; i < keys.Count; i++)
                    {
                        values = values + keys[i] + "=" + dataReader[keys[i]] + "^";
                    }
                    data.Add(values);
                }
                CloseConnection();
            }
            return data;
        }

        public Part GetPart(string partNo)
        {
            Part part = new Part();
            string stmt = "SELECT * FROM part_tab WHERE part_id = '" + partNo + "'";
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(stmt, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    part.PartNo = partNo;
                    part.PartDescription = dataReader["description"].ToString();
                    part.Catagory = dataReader["catogory"].ToString();
                    part.Size = double.Parse(dataReader["size"].ToString());
                    part.UOM = dataReader["uom"].ToString();
                    part.QtyInStock = int.Parse(dataReader["qty_in_stock"].ToString());
                    part.Price = double.Parse(dataReader["price"].ToString());
                    part.Discount = double.Parse(dataReader["discount"].ToString());
                }
                CloseConnection();
            }

            return part;
        }

        public bool AddPart(Part part)
        {
            if (!PartCheckExist(part.PartNo))
            {
                string stmt = "INSERT INTO part_tab VALUES ('" + part.PartNo + "', '" + part.PartDescription + "', '" +
                              part.Catagory + "', " + part.Size + ", '" + part.UOM + "', " + part.QtyInStock + ", " +
                              part.Price + ", " + part.Discount + ")";
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(stmt, connection);
                    cmd.ExecuteNonQuery();
                    CloseConnection();
                    return true;
                }
            }
            else
            {
                MessageBox.Show("Part number already exist. Cannot add part.");
            }
            return false;
        }

        internal bool UpdatePart(Part part)
        {
            bool result = false;
            if (!DeletePart(part.PartNo))
            {
                return false;
            }
            result = AddPart(part);
            return result;
        }

        internal bool DeletePart(string partNo)
        {
            if (PartCheckExist(partNo))
            {
                string stmt = "DELETE FROM part_tab WHERE part_id = '" + partNo + "'";
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(stmt, connection);
                    cmd.ExecuteNonQuery();
                    CloseConnection();
                    return true;
                }
            }
            else
            {
                MessageBox.Show("Part not found.");
            }
            return false;
        }

        internal List<Part> RunQueryForParts(string searchQuery)
        {
            List<Part> parts = new List<Part>();
            Part part = new Part();
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(searchQuery, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    part.PartNo = dataReader["part_id"].ToString();
                    part.PartDescription = dataReader["description"].ToString();
                    part.Catagory = dataReader["catogory"].ToString();
                    part.Size = double.Parse(dataReader["size"].ToString());
                    part.UOM = dataReader["uom"].ToString();
                    part.QtyInStock = int.Parse(dataReader["qty_in_stock"].ToString());
                    part.Price = double.Parse(dataReader["price"].ToString());
                    part.Discount = double.Parse(dataReader["discount"].ToString());
                    parts.Add(part);
                }
                CloseConnection();
            }
            return parts;
        }

        public bool PartCheckExist(string partNo)
        {
            string stmt = "SELECT 1 FROM part_tab WHERE part_id = '" + partNo + "'";
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(stmt, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    CloseConnection();
                    return true;
                }
                else
                {
                    CloseConnection();
                    return false;
                }
            }
            return false;
        }

        public bool CustomerCheckExist(string customerNo)
        {
            string stmt = "SELECT 1 FROM customer_tab WHERE customer_id = '" + customerNo + "'";
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(stmt, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    CloseConnection();
                    return true;
                }
                else
                {
                    CloseConnection();
                    return false;
                }
            }
            return false;
        }

        public List<string> GetCategories()
        {
            List<string> categories = new List<string>();
            string stmt = "SELECT category_name FROM category_tab";
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(stmt, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    categories.Add(dataReader["category_name"].ToString());
                }
                CloseConnection();
                return categories;
            }
            return categories;
        }

        internal bool AddCustomer(Customer customer)
        {
            if (!CustomerCheckExist(customer.CustomerNo))
            {
                string stmt = "INSERT INTO customer_tab VALUES ('" + customer.CustomerNo + "', '" +
                              customer.CustomerName + "', '" + customer.Address + "', '" + customer.AccountNo + "', '" +
                              customer.Bank + "', '" + customer.Branch + "')";
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(stmt, connection);
                    cmd.ExecuteNonQuery();
                    CloseConnection();
                    return true;
                }
            }
            else
            {
                MessageBox.Show("Part number already exist. Cannot add part.");
            }
            return false;
        }

        internal bool UpdateCustomer(Customer customer)
        {
            bool result = false;
            if (!DeletePart(customer.CustomerNo))
            {
                return false;
            }
            result = AddCustomer(customer);
            return result;
        }

        internal bool DeleteCustomer(string customerNo)
        {
            if (CustomerCheckExist(customerNo))
            {
                string stmt = "DELETE FROM customer_tab WHERE customer_id = '" + customerNo + "'";
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(stmt, connection);
                    cmd.ExecuteNonQuery();
                    CloseConnection();
                    return true;
                }
            }
            else
            {
                MessageBox.Show("Part not found.");
            }
            return false;
        }

        public Customer GetCustomer(string customerNo)
        {
            Customer customer = new Customer();
            string stmt = "SELECT * FROM customer_tab WHERE customer_id = '" + customerNo + "'";
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(stmt, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    customer.CustomerNo = customerNo;
                    customer.CustomerName = dataReader["name"].ToString();
                    customer.Address = dataReader["address"].ToString();
                    customer.AccountNo = dataReader["bank_account_no"].ToString();
                    customer.Bank = dataReader["bank"].ToString();
                    customer.Branch = dataReader["branch"].ToString();
                }
                CloseConnection();
            }

            return customer;
        }

        private bool CategoryCheckExist(string category)
        {
            string stmt = "SELECT 1 FROM category_tab WHERE category_name = '" + category + "'";
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(stmt, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    CloseConnection();
                    return true;
                }
                else
                {
                    CloseConnection();
                    return false;
                }
            }
            return false;
        }

        public bool AddCategory(string category)
        {
            string stmt = "INSERT INTO category_tab (category_name) VALUES ('" + category + "')";
            if (category.Equals(string.Empty))
            {
                MessageBox.Show("Please enter a category");
                return false;
            }
            if (!CategoryCheckExist(category))
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(stmt, connection);
                    cmd.ExecuteNonQuery();
                    CloseConnection();
                    return true;
                }
                return false;
            }
            MessageBox.Show("Category '" + category + "' already exist.");
            return false;
        }

        public string GetCategory(int index)
        {
            string stmt = "SELECT category_name FROM category_tab WHERE category_no = " + index;
            string result;
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(stmt, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    result = dataReader["category_name"].ToString();
                    CloseConnection();
                    return result;
                }
                CloseConnection();
            }
            return null;
        }

        internal bool DeleteCategory(string category)
        {
            if (CategoryCheckExist(category))
            {
                string stmt = "DELETE FROM category_tab WHERE category_name = '" + category + "'";
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(stmt, connection);
                    cmd.ExecuteNonQuery();
                    CloseConnection();
                    return true;
                }
            }
            else
            {
                MessageBox.Show("Category not found.");
            }
            return false;
        }

        internal bool CheckForeCategoryDelete(string category)
        {
            string stmt = "SELECT 1 FROM part_tab WHERE catogory = '" + category + "'";
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(stmt, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    CloseConnection();
                    return false;
                }
                else
                {
                    CloseConnection();
                    return true;
                }
            }
            return false;
        }

        internal bool NewCustomerOrder(CustomerOrder order, bool update)
        {
            if (!CustomerOrderCheckExist(order.OrderNo))
            {
                string stmt = "INSERT INTO customer_order_tab VALUES ('" + order.OrderNo + "', '" + order.CustomerNo +
                              "', '" + order.CustomerName + "', '" + order.DelAddress + "', '" +
                              StringManipulation.GetDBDate(order.DelDate) + "', " + order.NetAmount + ", " +
                              order.DiscAmount + ", " + order.InvoiceVal + ", '" + order.Status + "', '" +
                              order.PaymentType + "', '" + order.ChequeNo + "')";
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(stmt, connection);
                    cmd.ExecuteNonQuery();
                    CloseConnection();
                    return true;
                }
            }
            else
            {
                if (update)
                    UpdateCustomerOrder(order);
                else
                    MessageBox.Show("Customer Order number already exist. Cannot add oder.");
            }
            return false;
        }

        internal bool UpdateCustomerOrder(CustomerOrder order)
        {
            if (CustomerOrderCheckExist(order.OrderNo))
            {
                string stmt = "UPDATE customer_order_tab SET customer_no = '" + order.CustomerNo +
                                                        "', customer_name = '" + order.CustomerName +
                                                        "', delivery_add = '" + order.DelAddress +
                                                        "', delivary_date = '" + StringManipulation.GetDBDate(order.DelDate) +
                                                        "', total_net_ammount = " + order.NetAmount +
                                                        ", total_discount_ammount = " + order.DiscAmount +
                                                        ", invoiced_value = " + order.InvoiceVal +
                                                        ", status = '" + order.Status +
                                                        "', payment_type = '" + order.PaymentType +
                                                        "', cheque_no = '" + order.ChequeNo +
                                                        "' WHERE order_no = '" + order.OrderNo + "'";

                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(stmt, connection);
                    cmd.ExecuteNonQuery();
                    CloseConnection();
                    return true;
                }
            }
            return true;
        }

        internal bool UpdatePurchaseOrder(PurchaseOrder order)
        {
            if (CustomerOrderCheckExist(order.OrderNo))
            {
                string stmt = "UPDATE customer_order_tab SET date = '" + StringManipulation.GetDBDate(order.Date) +
                                                        "', remarks = '" + order.Remarks +
                                                        "', inv_value = " + order.InvoiceVal +
                                                        ", status = '" + order.status +
                                                        "' WHERE order_no = '" + order.OrderNo + "'";

                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(stmt, connection);
                    cmd.ExecuteNonQuery();
                    CloseConnection();
                    return true;
                }
            }
            return true;
        }

        internal bool UpdateCustomerOrderLine(OrderLine orderLine)
        {
            if (CustomerOrderLineCheckExist(orderLine.OrderNo, orderLine.LineNo))
            {
                string stmt = "UPDATE customer_order_line_tab SET part_no = '" + orderLine.PartNo +
                                                            "', qty = '" + orderLine.Qty +
                                                            "', unit_price = '" + orderLine.UnitPrice +
                                                            "', discount = '" + orderLine.Discount +
                                                            "', discounted_price = " + orderLine.DiscountedPrice +
                                                            "' WHERE order_no = '" + orderLine.OrderNo +
                                                            "' AND line_no = '" + orderLine.LineNo + "'";

                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(stmt, connection);
                    cmd.ExecuteNonQuery();
                    CloseConnection();
                    return true;
                }
            }
            return true;
        }

        internal bool NewCustomerOrderLine(OrderLine orderLine)
        {
            if (!CustomerOrderLineCheckExist(orderLine.OrderNo, orderLine.LineNo))
            {
                string stmt = "INSERT INTO customer_order_line_tab VALUES ('" + orderLine.OrderNo + "', " + orderLine.LineNo +
                                  ", '" + orderLine.PartNo + "', " + orderLine.Qty + ", " + +orderLine.UnitPrice + ", " +
                                  +orderLine.Discount + ", " + +orderLine.DiscountedPrice + ")";
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(stmt, connection);
                    cmd.ExecuteNonQuery();
                    CloseConnection();
                    return true;
                }
            }
            else
            {
                UpdateCustomerOrderLine(orderLine);
            }
            return false;
        }

        private bool CustomerOrderCheckExist(string orderNo)
        {
            string stmt = "SELECT 1 FROM customer_order_tab WHERE order_no = '" + orderNo + "'";
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(stmt, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    CloseConnection();
                    return true;
                }
                else
                {
                    CloseConnection();
                    return false;
                }
            }
            return false;
        }

        internal string GetNextOrderNo(string tableName, bool onlyNumber)
        {
            string orderNo = "";
            string letter = "P";
            string stmt = "SELECT MAX(val) AS val FROM " + tableName + " WHERE letter = '" + letter + "'";

            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(stmt, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    orderNo = dataReader["val"].ToString();
                    CloseConnection();
                }
                else
                {
                    CloseConnection();
                    orderNo = "0";
                }
                if (onlyNumber)
                {
                    return orderNo;
                }
                for (int i = 0; i < 9 - orderNo.Length; i++)
                {
                    orderNo = "0" + orderNo;
                }
                orderNo = letter + orderNo;

            }
            return orderNo;
        }

        public void IncreaseSequence(string tableName, string letter)
        {
            int orderNo = int.Parse(GetNextOrderNo(tableName, true)) + 1;

            string stmt = "UPDATE " + tableName + " SET val = " + orderNo + " WHERE letter = '" + letter + "'";//"INSERT INTO " + sequence + " (letter) VALUES ('" + letter + "')";
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(stmt, connection);
                cmd.ExecuteNonQuery();
                CloseConnection();
            }
        }

        public CustomerOrder GetCustomerOrder(string orderNo)
        {
            CustomerOrder order = new CustomerOrder();
            string stmt = "SELECT * FROM customer_order_tab WHERE order_no = '" + orderNo + "'";
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(stmt, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    order.OrderNo = orderNo;
                    order.CustomerNo = dataReader["customer_no"].ToString();
                    order.CustomerName = dataReader["customer_name"].ToString();
                    order.DelAddress = dataReader["delivery_add"].ToString();
                    order.DelDate = StringManipulation.GetClientDate(dataReader["delivary_date"].ToString());
                    order.NetAmount = double.Parse(dataReader["total_net_ammount"].ToString());
                    order.DiscAmount = double.Parse(dataReader["total_discount_ammount"].ToString());
                    order.InvoiceVal = double.Parse(dataReader["invoiced_value"].ToString());
                    order.Status = dataReader["status"].ToString();
                    order.PaymentType = dataReader["payment_type"].ToString();
                    order.ChequeNo = dataReader["cheque_no"].ToString();
                }
                CloseConnection();
            }

            return order;
        }

        public List<OrderLine> GetCustomerOrderLines(string orderNo)
        {
            List<OrderLine> orderLines = new List<OrderLine>();
            OrderLine orderLine;
            string stmt = "SELECT * FROM customer_order_line WHERE order_no = '" + orderNo + "'";
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(stmt, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    orderLine = new OrderLine();
                    orderLine.OrderNo = orderNo;
                    orderLine.LineNo = int.Parse(dataReader["line_no"].ToString());
                    orderLine.PartNo = dataReader["part_no"].ToString();
                    orderLine.PartDescription = dataReader["part_description"].ToString();
                    orderLine.partCategory = dataReader["part_category"].ToString();
                    orderLine.Qty = int.Parse(dataReader["qty"].ToString());
                    orderLine.UnitPrice = double.Parse(dataReader["unit_price"].ToString());
                    orderLine.Discount = double.Parse(dataReader["discount"].ToString());
                    orderLine.DiscountedPrice = double.Parse(dataReader["discounted_price"].ToString());
                    orderLines.Add(orderLine);
                }
                CloseConnection();
            }

            return orderLines;
        }

        public bool DeleteCustomerOrderLine(string orderNo, int lineNo)
        {
            if (CustomerOrderLineCheckExist(orderNo, lineNo))
            {
                string stmt = "DELETE FROM customer_order_line_tab WHERE order_no = '" + orderNo + "' AND line_no =" + lineNo;
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(stmt, connection);
                    cmd.ExecuteNonQuery();
                    CloseConnection();
                    return true;
                }
            }
            else
            {
                MessageBox.Show("Customer order line not found.");
            }
            return false;
        }

        private bool CustomerOrderLineCheckExist(string orderNo, int lineNo)
        {
            string stmt = "SELECT 1 FROM customer_order_line_tab WHERE order_no = '" + orderNo + "' AND line_no =" + lineNo;
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(stmt, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    CloseConnection();
                    return true;
                }
                else
                {
                    CloseConnection();
                    return false;
                }
            }
            return false;
        }

        internal List<Customer> RunQueryForCustomer(string query)
        {
            List<Customer> customers = new List<Customer>();
            Customer customer = new Customer();

            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    customer.CustomerNo = dataReader["customer_id"].ToString();
                    customer.CustomerName = dataReader["name"].ToString();
                    customer.Address = dataReader["address"].ToString();
                    customer.AccountNo = dataReader["bank_account_no"].ToString();
                    customer.Bank = dataReader["bank"].ToString();
                    customer.Branch = dataReader["branch"].ToString();
                    customers.Add(customer);
                }
                CloseConnection();
            }

            return customers;
        }
    }
}