using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniERP.Classes
{
    class TableData
    {
        public TableData(string tableName)
        {
            this.tableName = tableName;
        }

        private string tableName;

        public string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }

	    public List<ColumnData> Columns
	    {
		    get { return columns; }
		    set { columns = value; }
	    }

	    private List<ColumnData> columns = new List<ColumnData>();

        public columnType getColumnType(string columnName)
        {
            int index = 0;
	        for (int i = 0; i < Count; i++)
	        {
		        if (columns[i].Column.Equals(columnName))
		        {
			        index = i;
			        break;
		        }
	        }
            return columns[index].ColumnType;
        }

        public int getLength(string columnName)
        {
            int index = 0;
            for (int i = 0; i < Count; i++)
            {
                if (columns[i].Column.Equals(columnName))
                {
                    index = i;
                    break;
                }
            }
            return columns[index].Length;
        }

        public int Count
        {
            get { return Columns.Count; }
        }
    }
}
