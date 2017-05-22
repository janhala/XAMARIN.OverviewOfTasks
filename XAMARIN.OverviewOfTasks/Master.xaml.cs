using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XAMARIN.OverviewOfTasks.View;

namespace XAMARIN.OverviewOfTasks
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : ContentPage
    {
        public Master()
        {
            InitializeComponent();

            EnterSubjects.Clicked += async (sender, e) =>
            {
                App.MasterDetail.IsPresented = false;
                await App.MasterDetail.Detail.Navigation.PushAsync(new EnterSubjects());
            };

            EnterSchoolTimetable.Clicked += async (sender, e) =>
            {
                App.MasterDetail.IsPresented = false;
                await App.MasterDetail.Detail.Navigation.PushAsync(new EnterSchoolTimetable());
            };
        }
    }
}
