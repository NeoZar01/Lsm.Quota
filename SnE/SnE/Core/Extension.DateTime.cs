using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsm.Generics.Core
{
    public  static class DateTimeExtensionMethods
    {

        public enum ConditionFlavor
        {
            Null,
            IsEqual,
            IsGreaterThan
        }

        public static bool IsEffective(this DateTime x, DateTime y, ConditionFlavor conditionFlavor)
        {
            switch (conditionFlavor)
            {
                case ConditionFlavor.IsGreaterThan:
                 if (x > y)
                    return false;
                 break;
                case ConditionFlavor.IsEqual:
                    if (x == y)
                        return false;
                 break;

                default:
                    return false;
            }

            return true;
        }


    }
}
