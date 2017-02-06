using System;
using System.Collections.Generic;


using Xamarin.Forms;
using Xamarin.Forms.Maps;


namespace mapTest
{
	public partial class GeocoderPage : ContentPage
	{
		Geocoder geoCoder;
		Label l = new Label();

		public GeocoderPage()
		{
			InitializeComponent();


			geoCoder = new Geocoder();

			var b1 = new Button { Text = "Reverse geocode '37.808, -122.432'" };
			b1.Clicked += async (sender, e) =>
			{
				var fortMasonPosition = new Position(37.8044866, -122.4324132);
				var possibleAddresses = await geoCoder.GetAddressesForPositionAsync(fortMasonPosition);
				foreach (var a in possibleAddresses)
				{
					l.Text += a + "\n";
				}
			};

			var b2 = new Button { Text = "Geocode '我家地址'" };
			b2.Clicked += async (sender, e) =>
			{
				//var xamarinAddress = "394 Pacific Ave, San Francisco, California";
				var xamarinAddress = "台北市文山區辛亥路四段77巷92弄9號";

				//景點無法
				//var xamarinAddress = "阿里山";


				var approximateLocation = await geoCoder.GetPositionsForAddressAsync(xamarinAddress);
				foreach (var p in approximateLocation)
				{
					l.Text += p.Latitude + ", " + p.Longitude + "\n";
				}
			};

			// Put the page together
			Content = new StackLayout
			{
				Padding = new Thickness(0, 20, 0, 0),
				Children = {
					b2,
					b1,
					l
				}
			};
		}
	}
}
