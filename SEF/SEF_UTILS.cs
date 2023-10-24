using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynox.SEF.UTILS
{
    public class SEF_UTILS
    {

        public static T ToEnum<T>(string name)
        {

            return (T)Enum.Parse(typeof(T), name);

        }
        //public static T ToEnum<T>(string value) where T : struct, IConvertible
        //{
        //    foreach (T item in Enum.GetValues(typeof(T)))
        //    {
        //        if (item.ToString().ToLower() == value.Trim().ToLower())
        //        {
        //            return item;
        //        }
        //    }

        //    throw new ArgumentException($"'{value}' is not a valid name of {typeof(T)}");
        //}


    }
}
