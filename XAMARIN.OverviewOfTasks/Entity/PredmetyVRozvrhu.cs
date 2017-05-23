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
        //int den (po = 1, pá = 5), int sudy/lichy (0/1), int hodina, string nazevUkolu, string popisUkolu
        //public int SudyLichy { get; set; }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int NazevPredmetu_ID { get; set; }
        public int Den { get; set; }
        public int Hodina { get; set; }
    }
}
