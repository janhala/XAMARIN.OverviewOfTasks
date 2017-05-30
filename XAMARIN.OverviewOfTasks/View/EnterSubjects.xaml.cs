using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XAMARIN.OverviewOfTasks.Entity;
using XAMARIN.OverviewOfTasks.View;

namespace XAMARIN.OverviewOfTasks
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnterSubjects : ContentPage
    {
        public int firstSubjectSaved { get; set; }
        public EnterSubjects()
        {
            InitializeComponent();

            firstSubjectSaved = 0;

            var volnaHodina = App.Database.GetItemsNotDoneAsyncVolnaHodina().Result;
            if (volnaHodina.Count == 0)
            {
                SeznamPredmetu hodina = new SeznamPredmetu();
                hodina.NazevPredmetu = "--volná hodina--";
                App.Database.SaveItemAsync(hodina);
            }

            AddHour();
        }

        public void AddHour()
        {
            warningText.IsVisible = false;

            Entry entry = new Entry();
            entry.Placeholder = "Zadejte název a poté klikněte na Enter";
            entry.Completed += SaveHours;
            StackLayoutMap.Children.Add(entry);
        }

        void SaveHours(object sender, EventArgs e)
        {
            var text = ((Entry)sender).Text;
            Label label = new Label();
            label.Text = "Předmět " + text + " byl úspěšně uložen";
            StackLayoutMap.Children.Add(label);

            SeznamPredmetu hodina = new SeznamPredmetu();
            hodina.NazevPredmetu = text;
            App.Database.SaveItemAsync(hodina);

            firstSubjectSaved = 1;

            ((Entry)sender).IsEnabled = false;

            AddHour();
        }

        private void NextPage(object sender, EventArgs e)
        {
            if (firstSubjectSaved == 1)
            {
                Navigation.PushAsync(new EnterSchoolTimetable());
            } else
            {
                warningText.IsVisible = true;
            }
        }
    }
}
