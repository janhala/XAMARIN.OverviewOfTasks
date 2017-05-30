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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTask : ContentPage
    {
        public IEnumerable SubjectList { get; set; }
        public DateTime date { get; set; }
        public BindablePicker picker = new BindablePicker();
        public int UmisteniUkolu_ID_fromPicker { get; set; }
        public AddTask()
        {
            InitializeComponent();


            //addTaskLayout.Children.Add(new Controls.BindablePicker { ItemsSource = SubjectList });
            //refreshPicker();
        }

        private void SaveTask(object sender, EventArgs e)
        {
            SeznamUkolu seznamUkolu = new SeznamUkolu();
            seznamUkolu.Name = nazevUkolu.Text;
            seznamUkolu.Comment = popisUkolu.Text;
            //int umisteniUkolu = (UmisteniUkolu_ID_fromPicker as PredmetyVRozvrhu).ID;
            seznamUkolu.UmisteniUkolu_ID = UmisteniUkolu_ID_fromPicker;
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
            //test.Text = dayInWeekNumber.ToString();
            refreshPicker(dayInWeekNumber);
        }

        private void refreshPicker(int denVtydnu)
        {
            if (picker != null)
            {
                addTaskLayout.Children.Remove(picker);
            }
            var subjectsFromDb = App.Database.GetItemsNotDoneAsyncPredmetyVRozvrhu(denVtydnu).Result;
            if (subjectsFromDb != null)
            {
                SubjectList = subjectsFromDb;
                picker.ItemsSource = SubjectList;
                picker.ItemSelected += PickerSelected;
                addTaskLayout.Children.Add(picker);
            }
            
        }

        private void PickerSelected(object sender, EventArgs e)
        {
            //PredmetyVRozvrhu predmety = sender as PredmetyVRozvrhu;
            //UmisteniUkolu_ID_fromPicker = int.Parse((sender as BindablePicker).SelectedItem.ToString());
            UmisteniUkolu_ID_fromPicker = ((sender as BindablePicker).SelectedItem as PredmetyVRozvrhu).ID;
            //UmisteniUkolu_ID_fromPicker = (tst as PredmetyVRozvrhu).ID;
        }
    }
}