using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace XAMARIN.OverviewOfTasks.Entity
{
    public class PredmetyVRozvrhu
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int NazevPredmetu_ID { get; set; }
        public int Den { get; set; }
        public int Hodina { get; set; }
    }
}
