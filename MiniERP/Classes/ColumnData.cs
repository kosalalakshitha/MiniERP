using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniERP.Classes
{
    class ColumnData
    {
        private string column;

        public string Column
        {
            get { return column; }
            set { column = value; }
        }
        private columnType columnTypes;

        public columnType ColumnType
        {
            get { return columnTypes; }
            set { columnTypes = value; }
        }

	    private int length;

        public int Length
        {
            get { return length; }
            set { length = value; }
        }

	    private string columnComment;
        public string ColumnComment
        {
            get { return columnComment; }
            set { columnComment = value; }
        }
    }
}
