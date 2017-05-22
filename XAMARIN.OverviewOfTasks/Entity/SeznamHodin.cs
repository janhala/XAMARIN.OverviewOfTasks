using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace XAMARIN.OverviewOfTasks.Entity
{
    public class SeznamHodin
    {
        //Rozvrh (PO-NE x 1-10) - int den (po = 1, pá = 5), int sudy/lichy (0/1), int hodina, string nazevPredmetu
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        /*public int Den { get; set; }
        public int SudyLichy { get; set; }
        public int Hodina { get; set; }*/
        public string NazevPredmetu { get; set; }

        public override string ToString()
        {
            return "ID - " + ID + " Název předmětu - " + NazevPredmetu;
        }
    }
}
