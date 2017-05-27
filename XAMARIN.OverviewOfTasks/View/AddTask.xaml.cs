using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XAMARIN.OverviewOfTasks.Entity;
using XAMARIN.OverviewOfTasks.Controls;
using System.Collections;

namespace XAMARIN.OverviewOfTasks.View
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTask : ContentPage
    {
        public IEnumerable SubjectList { get; set; }
        public DateTime date { get; set; }
        public BindablePicker picker = new BindablePicker();
        public AddTask()
        {
            InitializeComponent();


            //addTaskLayout.Children.Add(new Controls.BindablePicker { ItemsSource = SubjectList });
            refreshPicker();
        }

        private void SaveTask(object sender, EventArgs e)
        {
            SeznamUkolu seznamUkolu = new SeznamUkolu();
            seznamUkolu.NazevUkolu = nazevUkolu.ToString();
            seznamUkolu.PopisUkolu = popisUkolu.ToString();

            App.Database.SaveItemAsync(seznamUkolu);
        }

        private void datepicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            date = e.NewDate;
            int dayInWeekNumber = (int)date.DayOfWeek;
            if (dayInWeekNumber == 0)
            {
                dayInWeekNumber = 7;
            }
            test.Text = dayInWeekNumber.ToString();

            refreshPicker();
            /*var subjectsFromDb = App.Database.GetItemsAsync().Result;
            SubjectList  = subjectsFromDb;
            hourSelect.ItemsSource = SubjectList;*/


            /*var subjectsFromDb = App.Database.GetItemsAsync().Result;
            SubjectList = subjectsFromDb;
            addTaskLayout.Children.Add(new Controls.BindablePicker { ItemsSource = SubjectList });*/
        }

        private void refreshPicker()
        {
            if (picker != null)
            {
                addTaskLayout.Children.Remove(picker);
            }
            var subjectsFromDb = App.Database.GetItemsAsyncPredmetyVRozvrhu().Result;
            if (subjectsFromDb != null)
            {
                SubjectList = subjectsFromDb;
                picker.ItemsSource = SubjectList;
                addTaskLayout.Children.Add(picker);
            }
            
        }
    }
}