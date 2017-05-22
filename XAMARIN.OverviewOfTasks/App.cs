using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XAMARIN.OverviewOfTasks.View;
using System.Windows;
using XAMARIN.OverviewOfTasks.Entity;

namespace XAMARIN.OverviewOfTasks
{
    public class App : Application
    {
        public static MainPage MasterDetail { get; internal set; }

        public App()
        {
            MainPage = new NavigationPage(new MainPage());

            /*TabbedPageMenu = new TabbedPage
            {
                Children = {
                    new EnterSubjects(),
                    new EnterSchoolTimetable()
                }
            };*/
        }

        internal static Task NavigationMasterDetail(EnterSubjects enterSubjects)
        {
            throw new NotImplementedException();
        }

        internal static Task NavigationMasterDetail(EnterSchoolTimetable enterSchoolTimetable)
        {
            throw new NotImplementedException();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        private static TodoItemDatabase _database;

        public static TodoItemDatabase Database
        {
            get
            {
                if (_database == null)
                {
                    _database = new TodoItemDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("TodoSQLite.db3"));
                }
                return _database;
            }
        }
    }
}
