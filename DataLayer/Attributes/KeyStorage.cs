using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Attributes
{
    /// <summary>
    /// Used in generic update command to help the database find old primary key values
    /// These values are used in the Where clause of an SQL statement
    /// </summary>
    public class KeyStorage : Attribute
    {
        public string StoredFieldName { get; private set; }

        /// <summary>
        /// Used to identify properties used to store old primary key values.
        /// </summary>
        /// <param name="storedFieldName">The name of the property that stored the old value</param>
        public KeyStorage(string storedFieldName)
        {
            StoredFieldName = storedFieldName;
        }
    }
}
