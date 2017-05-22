using System;
using XAMARIN.OverviewOfTasks.Entity;
using Xamarin.Forms;

namespace XAMARIN.OverviewOfTasks
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.Master = new Master();
            this.Detail = new NavigationPage(new EnterSubjects());
            App.MasterDetail = this;
            MasterBehavior = MasterBehavior.Popover;
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}
