
using Xamarin.Forms;
using Xamarin.Forms.Maps;

using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace mapTest
{
	public partial class PopUpPage : ContentPage
	{
		public PopUpPage()
		{
			var button = new Button
			{
				Text = "Open popup"
			};

			var popup = new XLabs.Forms.Controls.PopupLayout
			{
				Content = new StackLayout
				{
					VerticalOptions = LayoutOptions.Center,
					Children =
				{
					button
				}
				}
			};

			var label = new Label()
			{
				HeightRequest = 100,
				WidthRequest = 200
			};

			button.Clicked += async (sender, e) =>
				{
					button.IsEnabled = false;
					popup.ShowPopup(label);
					for (var i = 0; i < 5; i++)
					{
						label.Text = string.Format("Disappearing in {0}s...", 5 - i);
						await Task.Delay(1000);
					}
					popup.DismissPopup();
					button.IsEnabled = true;
				};

			// The root page of your application
			//Content = new PopUpPage
			//{
			//	Content = popup
			//};
		}
	}
}
