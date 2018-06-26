using MarketingManager.Container;
using MarketingManager.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace MarketingManager
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();
            new ProgramController();
            MainPage = new NavigationPage(new ProcessPage());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
