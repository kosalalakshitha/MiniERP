using MiniERP.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniERP.Forms
{
    public partial class Search : Form
    {
        DBConnect dbConnection;
        TableData tableData;
        List<string> keys = new List<string>();
        static List<string> result = new List<string>();
        bool lovSearch = false;

        public Search(string tableName)
        {
            dbConnection = new DBConnect();
            tableData = new TableData(tableName);
            InitializeComponent();
            LoadTableData(tableName);
        }

        public static List<string> ShowAndReturnObject(string tableName)
        {
            Search dlg = new Search(tableName);

            result.Clear();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public static List<string> ShowAndReturnObject(string tableName, bool lovSearch)
        {
            Search dlg = new Search(tableName);

            result.Clear();
            dlg.lovSearch = lovSearch;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        private void LoadTableData(string tableName)
        {
            tableData = dbConnection.GetTableDetails(tableName);
            for (int i = 0; i < tableData.Count; i++)
            {
                if (tableData.Columns[i].ColumnComment.Contains("QRY"))
                {
                    dataGridView1.Rows.Add(StringManipulation.getDisplayString(tableData.Columns[i].Column), "");
                }
            }
        }

        private string CreateQuery()
        {
            string query = "SELECT ";
            bool firstTime = true;
            string quotes;

            if (lovSearch)
            {
                query += "*";
            }
            else
            {
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
            }

            firstTime = true;
            query = query + " FROM " + tableData.TableName;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                var value = dataGridView1["Value", i].Value.ToString();
                quotes = AddQuotes(tableData.Columns[i]);
                if (!value.Equals(string.Empty))
                {
                    var operation = GetOperator(value);
                    if (!(operation.Equals("=") || operation.Equals("LIKE")))
                    {
                        value = value.Replace(operation, "");
                    }
                    if (firstTime)
                    {
                        firstTime = false;
                        query = query + " WHERE " + StringManipulation.GetDbName(dataGridView1["Attribute", i].Value.ToString()) +
                                " " + operation + " " + quotes + value + quotes;
                    }
                    else
                    {
                        query = query + " AND " +
                                StringManipulation.GetDbName(dataGridView1["Attribute", i].Value.ToString()) + " " +
                                operation + " " + quotes + value + quotes;
                    }
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string stmt = CreateQuery();
            if (lovSearch)
                result.Add(stmt);
            else
                result = dbConnection.SearchTable(stmt, tableData.TableName, keys);
        }
    }
}
