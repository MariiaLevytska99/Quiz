using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using QuizzeryDB;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Quizz
{
    public partial class App : Application
    {
        QuizzeryDB.QuizzeryEntities context = new QuizzeryEntities();
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
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
    }
}
