using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XAMARIN.OverviewOfTasks.Entity;
using XAMARIN.OverviewOfTasks.ViewModel;

namespace XAMARIN.OverviewOfTasks.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewSchoolTimetable : ContentPage
    {
        public DateTime selectedDate { get; set; }
        private ObservableCollection<GroupedViewModelUkolu> grouped { get; set; }
        public ViewSchoolTimetable()
        {
            InitializeComponent();

            

            System.DateTime datimeToday = DateTime.Today;
            System.DateTime datimeFirstDayInWeek = GetFirstDayOfWeek(datimeToday);
            selectedDateLabel.Text = String.Format("{0:d.M.yyyy}", datimeFirstDayInWeek);
            selectedDate = datimeFirstDayInWeek;


            grouped = new ObservableCollection<GroupedViewModelUkolu>();
            var pondeliGroup = new GroupedViewModelUkolu() { LongName = "Pondělí", ShortName = "Pondělí" };
            var uteryGroup = new GroupedViewModelUkolu() { LongName = "Úterý", ShortName = "Úterý" };
            var stredaGroup = new GroupedViewModelUkolu() { LongName = "Středa", ShortName = "Středa" };
            var ctvrtekGroup = new GroupedViewModelUkolu() { LongName = "Čtvrtek", ShortName = "Čtvrtek" };
            var patekGroup = new GroupedViewModelUkolu() { LongName = "Pátek", ShortName = "Pátek" };
            //pondeliGroup.Add(new ViewModelUkolu() { Name = "Nazev ukolu", IsReallyAVeggie = true, Comment = "kometar........." });
            //patekGroup.Add(new SeznamUkolu() { NazevUkolu = "test", PopisUkolu = "popis.." });

            grouped.Add(pondeliGroup); grouped.Add(uteryGroup); grouped.Add(stredaGroup); grouped.Add(ctvrtekGroup); grouped.Add(patekGroup);
            lstView.ItemsSource = grouped;
        }

        public static DateTime GetFirstDayOfWeek(DateTime dayInWeek)
        {
            CultureInfo defaultCultureInfo = CultureInfo.CurrentCulture;
            return GetFirstDayOfWeek(dayInWeek, defaultCultureInfo);
        }

        public static DateTime GetFirstDayOfWeek(DateTime dayInWeek, CultureInfo cultureInfo)
        {
            DayOfWeek firstDay = cultureInfo.DateTimeFormat.FirstDayOfWeek;
            DateTime firstDayInWeek = dayInWeek.Date;
            while (firstDayInWeek.DayOfWeek != firstDay)
                firstDayInWeek = firstDayInWeek.AddDays(-1);
            firstDayInWeek = firstDayInWeek.AddDays(1);
            return firstDayInWeek;
        }

        private void PredchoziTyden(object sender, EventArgs e)
        {
            selectedDate = selectedDate.AddDays(-7);
            RefreshView(selectedDate);
        }

        private void DalsiTyden(object sender, EventArgs e)
        {
            selectedDate = selectedDate.AddDays(7);
            RefreshView(selectedDate);
        }

        public void RefreshView(DateTime selectedDate)
        {
            selectedDateLabel.Text = String.Format("{0:d.M.yyyy}", selectedDate);
        }

        private void AddTaskFunction(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddTask());
        }
    }
}