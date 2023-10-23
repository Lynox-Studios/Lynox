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

            return (T)Enum.Parse(typeof(T),name);

        }

    }
}
