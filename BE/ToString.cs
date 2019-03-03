using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    class ToString
    {
        public static string ToStringProperty<T>(T t)
        {
            string str = "";
            try
            {
                foreach (PropertyInfo item in t.GetType().GetProperties())
                    if (item.GetType() != typeof(Array))
                        str += "\n" + item.Name + ": " + item.GetValue(t, null);// the name of tipe (id, adress.. ) and the value
            }
            catch { }
            return str + "\n";
        }
    }
}
