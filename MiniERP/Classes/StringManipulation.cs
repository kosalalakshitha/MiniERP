using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniERP.Classes
{
    class StringManipulation
    {
        public static string getDisplayString(string input)
        {
            input = input.Replace("_", " ");
            return UppercaseFirstEach(input);
        }

        public static string UppercaseFirstEach(string s)
        {
            char[] a = s.ToLower().ToCharArray();
            for (int i = 0; i < a.Count(); i++)
            {
                a[i] = i == 0 || a[i - 1] == ' ' ? char.ToUpper(a[i]) : a[i];
            }
            return new string(a);
        }

        public static string GetDbName(string input)
        {
            return input.Replace(" ", "_");
        }

        public static string GetDBDate(DateTime date)
        {
            return date.Year + "-" + date.Month + "-" + date.Day;
        }


        public static DateTime GetClientDate(string date)
        {
            if (date.Length > 0)
            {
                string[] data = date.Split('-');//[0].Split('/');
                return new DateTime(int.Parse(data[0]), int.Parse(data[1]), int.Parse(data[2]));
            }
            else
            {
                return new DateTime();
            }
        }
    }
}
