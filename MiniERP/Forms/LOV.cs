using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniERP.Classes;

namespace MiniERP.Forms
{
    public partial class LOV : Form
    {
        DBConnect dbConnect = new DBConnect();
        private TableData tableData;
        static List<string> result = new List<string>();
        List<string> keys = new List<string>();

        public LOV(string tableName, bool lov, string keyValue)
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            LoadData(tableName, lov, keyValue);
        }

        private void LoadData(string tableName, bool lov, string keyValue)
        {
            string query = "";
            tableData = new TableData(tableName);
            tableData = dbConnect.GetTableDetails(tableName);
            for (int i = 0; i < tableData.Count; i++)
            {
                if (tableData.Columns[i].ColumnComment.Contains("QRY") || !lov)
                {
                    dataGridView1.Columns.Add(new DataGridViewColumn()
                    {
                        HeaderText = StringManipulation.getDisplayString(tableData.Columns[i].Column),
                        Name = tableData.Columns[i].Column,
                        CellTemplate = new DataGridViewTextBoxCell()
                    });
                }
                if (tableData.Columns[i].ColumnComment.Contains("KEY"))
                {
                    keys.Add(tableData.Columns[i].Column);
                }
            }

            query = CreateQuery(keyValue);
            result = dbConnect.SearchTable(query, tableData.TableName, keys);
            foreach (string keyVal in result)
            {
                if (tableData.TableName.Equals("customer_tab"))
                {
                    Customer customer = dbConnect.GetCustomer(keyVal.Split('^')[0].Split('=')[1]);
                    dataGridView1.Rows.Add(customer.CustomerNo, customer.CustomerName, customer.Address,
                        customer.AccountNo, customer.Bank, customer.Branch);
                }
                else if (tableData.TableName.Equals("part_tab"))
                {
                    Part part = dbConnect.GetPart(keyVal.Split('^')[0].Split('=')[1]);
                    dataGridView1.Rows.Add(part.PartNo, part.PartDescription, part.Catagory, part.Size, part.UOM,
                        part.Price, part.Discount);
                }
            }

        }


        public static string ShowAndReturnObject(string tableName, bool lov, string text)
        {
            LOV dlg = new LOV(tableName, lov, text);
            if (dlg.ShowDialog() == DialogResult.OK && result.Count > 0)
            {
                return result[0];
            }
            else
            {
                return null;
            }
        }

        private string CreateQuery(string keyValue)
        {
            string query = "SELECT ";
            bool firstTime = true;
            string quotes;
            List<string> keys = new List<string>();

            for (int i = 0; i < tableData.Count; i++)
            {
                if (tableData.Columns[i].ColumnComment.Contains("KEY"))
                {
                    if (firstTime)
                    {
                        firstTime = false;
                        query = query + tableData.Columns[i].Column;
                    }
                    else
                    {
                        query = query + ", " + tableData.Columns[i].Column;
                    }
                    keys.Add(tableData.Columns[i].Column);
                }
            }

            query = query + " FROM " + tableData.TableName;

            if (keyValue.Length > 0)
            {
                string[] temp = keyValue.Split('^');
                string col = temp[0];
                string value = temp[1];
                int index = -1;

                for (int i = 0; i < tableData.Columns.Count; i++)
                {
                    if (tableData.Columns[i].Column.Equals(col))
                    {
                        index = i;
                        break;
                    }
                }

                quotes = AddQuotes(tableData.Columns[index]);
                if (!value.Equals(string.Empty))
                {
                    var operation = GetOperator(value);
                    if (!(operation.Equals("=") || operation.Equals("LIKE")))
                    {
                        value = value.Replace(operation, "");
                    }
                    query = query + " WHERE " + col + " " + operation + " " + quotes + value + quotes + " LIMIT 100";
                }
            }

            return query;
        }

        private string GetOperator(string value)
        {
            string operation;

            if (value.Contains("%"))
            {
                operation = "LIKE";
            }
            else if (value.Contains(">"))
            {
                operation = ">";
                if (value.Contains("="))
                {
                    operation = operation + "=";
                }
            }
            else if (value.Contains("<"))
            {
                operation = "<";
                if (value.Contains("="))
                {
                    operation = operation + "=";
                }
            }
            else
            {
                operation = "=";
            }

            return operation;
        }

        private string AddQuotes(ColumnData column)
        {
            switch (column.ColumnType)
            {
                case columnType.VARCHAR:
                case columnType.DATETIME:
                    return "'";
                default:
                    return "";
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            bool found = false;

            if (dataGridView1.RowCount > 0)
            {
                foreach (string keyVals in result)
                {
                    string[] keys = keyVals.Split('^');
                    foreach (string keyVal in keys)
                    {
                        if (keyVal.Length > 0)
                        {
                            if (dataGridView1.SelectedRows[0].Cells[keyVal.Split('=')[0]].Value.ToString().Equals(keyVal.Split('=')[1]))
                            {
                                result.Clear();
                                result.Add(keyVals);
                                found = true;
                            }
                        }
                    }
                    if (found)
                    {
                        break;
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchQuery = "";

            dataGridView1.Rows.Clear();
            searchQuery = Search.ShowAndReturnObject(tableData.TableName, true)[0];
            switch (tableData.TableName.ToLower())
            {
                case "customer_tab":
                    List<Customer> customers = dbConnect.RunQueryForCustomer(searchQuery);
                    foreach (Customer customer in customers)
                    {
                        dataGridView1.Rows.Add(customer.CustomerNo, customer.CustomerName, customer.Address,
                                        customer.AccountNo, customer.Bank, customer.Branch);
                    }
                    break;
                case "part_tab":
                    List<Part> parts = dbConnect.RunQueryForParts(searchQuery);
                    foreach (Part part in parts)
                    {
                        dataGridView1.Rows.Add(part.PartNo, part.PartDescription, part.Catagory, part.Size, part.UOM,
                            part.Price, part.Discount);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
