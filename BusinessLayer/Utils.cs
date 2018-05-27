using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace BusinessLayer
{
    public static class Utils
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

        public static bool IsUpAlphabeticChar(char c)
        {
            return c > 64 && c < 91;
        }

        public static bool IsZeroOrEmpty(int? val)
        {
            return val == null || val == 0;
        }

        public static void DeepCopyInto<T>(this T obj1, ref T obj2)
        {
            using (var ms = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj1);
                ms.Position = 0;
                obj2 = (T)formatter.Deserialize(ms);
            }
        }

        public static bool IsDateTimeEmpty(DateTime dateTime)
        {
            return dateTime == null;
        }
    }
}
