using System;
using XAMARIN.OverviewOfTasks.Entity;
using XAMARIN.OverviewOfTasks.Controls;
using Xamarin.Forms;
using System.Collections;

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
            int den = 5;
            int hodina = 0;
            foreach (object child in PatekStackLayout.Children)
            {
                int pickerSelectedItem = 0;
                if (child is BindablePicker)
                {
                    hodina = hodina + 1;
                    pickerSelectedItem = ((SeznamPredmetu)((child as BindablePicker).SelectedItem)).ID;

                    PredmetyVRozvrhu predmetyVRozvrhu = new PredmetyVRozvrhu();
                    predmetyVRozvrhu.NazevPredmetu_ID = pickerSelectedItem;
                    predmetyVRozvrhu.Den = den;
                    predmetyVRozvrhu.Hodina = hodina;
                    App.Database.SaveItemAsync(predmetyVRozvrhu);

                    Navigation.PushAsync(new ViewSchoolTimetable());
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
