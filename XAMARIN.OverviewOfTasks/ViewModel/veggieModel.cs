using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XAMARIN.OverviewOfTasks.Entity;

namespace XAMARIN.OverviewOfTasks.ViewModel
{
    public class ViewModelUkolu
    {
        public string NazevUkolu { get; set; }
        public string PopisUkolu { get; set; }
        public string NazevPredmetu { get; set; }
        public int Den { get; set; }
        public int Hodina { get; set; }

        public ViewModelUkolu()
        {
        }
    }
    
    public class GroupedViewModelUkolu : ObservableCollection<ViewModelUkolu>
    {
        public string LongName { get; set; }
        public string ShortName { get; set; }
    }
}
