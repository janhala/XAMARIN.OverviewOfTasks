using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XAMARIN.OverviewOfTasks.Entity;
using XAMARIN.OverviewOfTasks.Controls;
using XAMARIN.OverviewOfTasks.Model;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using static Java.Util.Jar.Attributes;
using System.Collections;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace XAMARIN.OverviewOfTasks.View
{
    public partial class EnterSchoolTimetable : TabbedPage
    {
        public int HodinVPondeli { get; set; }
        public int HodinVUtery { get; set; }
        public int HodinVeStredu { get; set; }
        public int HodinVeCtvrtek { get; set; }
        public int HodinVPatek { get; set; }
        public IEnumerable HoursList { get; set; }

        public EnterSchoolTimetable()
        {
            InitializeComponent();

            HodinVPondeli = 0;
            HodinVUtery = 0;
            HodinVeStredu = 0;
            HodinVeCtvrtek = 0;
            HodinVPatek = 0;

            var hoursFromDb = App.Database.GetItemsAsync().Result;
            HoursList = hoursFromDb;
        }

        private void AddHourMonday(object sender, EventArgs e)
        {
            HodinVPondeli = HodinVPondeli + 1;
            PondeliStackLayout.Children.Add(new Label { Text = HodinVPondeli + ".hodina : " });
            PondeliStackLayout.Children.Add(new Controls.BindablePicker { ItemsSource = HoursList });
        }

        private void AddHourUtery(object sender, EventArgs e)
        {
            HodinVUtery = HodinVUtery + 1;
            UteryStackLayout.Children.Add(new Label { Text = HodinVUtery + ".hodina : " });
            UteryStackLayout.Children.Add(new Controls.BindablePicker { ItemsSource = HoursList });
        }

        private void AddHourStreda(object sender, EventArgs e)
        {
            HodinVeStredu = HodinVeStredu + 1;
            StredaStackLayout.Children.Add(new Label { Text = HodinVeStredu + ".hodina : " });
            StredaStackLayout.Children.Add(new Controls.BindablePicker { ItemsSource = HoursList });
        }

        private void AddHourCtvrtek(object sender, EventArgs e)
        {
            HodinVeCtvrtek = HodinVeCtvrtek + 1;
            CtvrtekStackLayout.Children.Add(new Label { Text = HodinVeCtvrtek + ".hodina : " });
            CtvrtekStackLayout.Children.Add(new Controls.BindablePicker { ItemsSource = HoursList });
        }

        private void AddHourPatek(object sender, EventArgs e)
        {
            HodinVPatek = HodinVPatek + 1;
            PatekStackLayout.Children.Add(new Label { Text = HodinVPatek + ".hodina : " });
            PatekStackLayout.Children.Add(new Controls.BindablePicker { ItemsSource = HoursList });
        }

        private void SaveAll(object sender, EventArgs e)
        {
            foreach (object child in PatekStackLayout.Children)
            {
                string childname = "no name";
                if (child is BindablePicker)
                {
                    childname = ((SeznamHodin)((child as BindablePicker).SelectedItem)).NazevPredmetu;

         
                    testtttt.Text = childname;
                }
            }
        }
    }

    /*public class EnterSchoolTimetableViewModel : ObservableObject
    {
        ObservableCollection<SeznamHodin> _hoursList;
        public ObservableCollection<SeznamHodin> HoursList
        {
            get { return _hoursList; }
            set
            {
                _hoursList = value;
            }
        }

        public EnterSchoolTimetableViewModel()
        {
            var itemsFromDb = App.Database.GetItemsAsync().Result;
            this.HoursList = new ObservableCollection<SeznamHodin>(itemsFromDb);
        }

    }*/
}
