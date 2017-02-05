using Xamarin.Forms;

namespace mapTest
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			var tabs = new TabbedPage();

			// demonstrates the map control with zooming and map-types
			tabs.Children.Add(new mapPage { Title = "地圖縮放"});

			// demonstrates the map control with zooming and map-types
			tabs.Children.Add(new PinPage { Title = "位置標示"});

			// demonstrates the Geocoder class
			tabs.Children.Add(new GeocoderPage { Title = "定位反查" });



			tabs.Children.Add(new PopUpPage { Title = "跳出畫面" });

			// opens the platform's native Map app
			// tabs.Children.Add(new MapAppPage { Title = "外部地圖", Icon = "glyphish_103_map.png" });

			MainPage = tabs;

			//MainPage = new mapTestPage();
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
