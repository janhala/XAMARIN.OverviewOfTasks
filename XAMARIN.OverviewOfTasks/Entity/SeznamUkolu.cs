using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XAMARIN.OverviewOfTasks.Entity
{
    public class SeznamUkolu
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string NazevUkolu { get; set; }
        public string PopisUkolu { get; set; }
        public int UmisteniUkolu { get; set; }
    }
}
