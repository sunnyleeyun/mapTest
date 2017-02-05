using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace mapTest
{
	public partial class mapPage : ContentPage
	{
		
		public mapPage()
		{
			InitializeComponent();

			map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(25.0436439, 121.525664), Distance.FromMeters(500)));


			var position1 = new Position(25.0436439, 121.525664); // Latitude, Longitude
			var pin1 = new Pin
			{
				Type = PinType.SavedPin,
				Position = position1,

				Label = "座標測試1",
				Address = "這裡是25.0436439, 121.525664"
			};
			map.Pins.Add(pin1);
			//
			pin1.Clicked += async (sender, e) =>
			{
				await DisplayAlert("可以做出Alert了！", "太好啦～", "確定");
			};









			// add the slider
			var slider = new Slider(1, 18, 1);
			slider.ValueChanged += (sender, e) =>
			{
				var zoomLevel = e.NewValue; // between 1 and 18
				var latlongdegrees = 360 / (Math.Pow(2, zoomLevel));
				Debug.WriteLine(zoomLevel + " -> " + latlongdegrees);
				if (map.VisibleRegion != null)
					map.MoveToRegion(new MapSpan(map.VisibleRegion.Center, latlongdegrees, latlongdegrees));
			};

			// create map style buttons
			var street = new Button { Text = "街道" };
			var hybrid = new Button { Text = "混合" };
			var satellite = new Button { Text = "衛星" };
			street.Clicked += HandleClicked;
			hybrid.Clicked += HandleClicked;
			satellite.Clicked += HandleClicked;
			var segments = new StackLayout
			{
				Spacing = 30,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Orientation = StackOrientation.Horizontal,
				Children = { street, hybrid, satellite }
			};


			// put the page together
			var stack = new StackLayout { Spacing = 0 };
			stack.Children.Add(map);
			stack.Children.Add(slider);
			stack.Children.Add(segments);
			Content = stack;


			// for debugging output only
			map.PropertyChanged += (sender, e) =>
			{
				Debug.WriteLine(e.PropertyName + " just changed!");
				if (e.PropertyName == "VisibleRegion" && map.VisibleRegion != null)
					CalculateBoundingCoordinates(map.VisibleRegion);
			};



		}



		void HandleClicked(object sender, EventArgs e)
		{
			var b = sender as Button;
			switch (b.Text)
			{
				case "街道":
					map.MapType = MapType.Street;
					break;
				case "混合":
					map.MapType = MapType.Hybrid;
					break;
				case "衛星":
					map.MapType = MapType.Satellite;
					break;
			}
		}



		static void CalculateBoundingCoordinates(MapSpan region)
		{
			// WARNING: I haven't tested the correctness of this exhaustively!
			var center = region.Center;
			var halfheightDegrees = region.LatitudeDegrees / 2;
			var halfwidthDegrees = region.LongitudeDegrees / 2;

			var left = center.Longitude - halfwidthDegrees;
			var right = center.Longitude + halfwidthDegrees;
			var top = center.Latitude + halfheightDegrees;
			var bottom = center.Latitude - halfheightDegrees;

			// Adjust for Internation Date Line (+/- 180 degrees longitude)
			if (left < -180) left = 180 + (180 + left);
			if (right > 180) right = (right - 180) - 180;
			// I don't wrap around north or south; I don't think the map control allows this anyway

			Debug.WriteLine("Bounding box:");
			Debug.WriteLine("                    " + top);
			Debug.WriteLine("  " + left + "                " + right);
			Debug.WriteLine("                    " + bottom);
		}
	}
}
