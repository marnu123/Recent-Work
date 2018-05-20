using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataLayer;
using DataLayer.Attributes;

namespace BusinessLayer.Classes
{
    [Table("tblcity")]
    public class City: DataObject
    {
        private int id;
        private string name;

        public City(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public City(DataRow dataRow)
        {
            Id = Convert.ToInt32(dataRow["PK_CityID"]);
            Name = dataRow["CityName"].ToString();
        }

        [Key]
        [Column("PK_CityID")]
        public int Id { get => id; set => id = value; }
        [Column("CityName")]
        public string Name { get => name; set => name = value; }

        public static List<City> Select(params Expression<Func<City, object>>[] expression)
        {
            //DataTable dt = DataHandler.GetInstance().Select(expression);
            /*DataTable dt = new DataTable();
            List<City> result = new List<City>();

            foreach (DataRow dr in dt.Rows)
            {
                result.Add(new City(dr));
            }

            return result;*/
            return DataObjectFactory.Select<City>(expression);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
