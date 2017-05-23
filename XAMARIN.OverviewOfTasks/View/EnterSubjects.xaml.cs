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
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnterSubjects : ContentPage
    {
        public EnterSubjects()
        {
            InitializeComponent();

            AddHour();
        }

        public void AddHour()
        {
            // Add created button to a previously created container.
            //myStackPanel.Children.Add(myButton);
            //StackLayoutMap.Children.Add(myButton);
            //<Entry Placeholder="Zadejte název či zkratku hodiny" />

            Entry entry = new Entry();
            entry.Placeholder = "Zadejte název a poté klikněte na Enter";
            entry.Completed += SaveHours;
            //entry.TextChanged += SaveHours;
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

            /*var dbConnection = App.Database;
            //tst ulozeni itemu do db
            TodoItemDatabase todoItemDatabase = App.Database;
            TodoItem item = new TodoItem();
            item.Name = "item";
            item.Text = "item text";
            App.Database.SaveItemAsync(item);
            */



            ((Entry)sender).IsEnabled = false;

            AddHour();
        }

        private void NextPage(object sender, EventArgs e)
        {
            //EnterSchoolTimetable = new NavigationPage(new EnterSchoolTimetable());
            Navigation.PushAsync(new EnterSchoolTimetable());
        }
    }
}
