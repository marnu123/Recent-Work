using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Utils
    {
        public static T[] JoinArrays<T>(T[] arr1, T[] arr2)
        {
            T[] result = new T[arr1.Length + arr2.Length];

            for (int i = 0; i < arr1.Length; i++)
            {
                result[i] = arr1[i];
            }

            for (int i = 0; i < arr2.Length; i++)
            {
                result[arr1.Length + i] = arr2[i];
            }

            return result;
        }

        public static bool IsEmpty(string str)
        {
            return str == null || str.Trim() == String.Empty;
        }

        public static bool IsZeroOrEmpty(int? val)
        {
            return val == null || val == 0;
        }
    }
}
