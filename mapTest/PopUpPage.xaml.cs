
using Xamarin.Forms;
using Xamarin.Forms.Maps;

using System;
using System.Collections.Generic;

using System.Threading.Tasks;
using XLabs;

namespace mapTest
{
	public partial class PopUpPage : ContentPage
	{
		public PopUpPage()
		{

			InitializeComponent();
		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
		}

		// Method for animation child in PopupPage
		// Invoced after custom animation end
		protected virtual Task OnAppearingAnimationEnd()
		{
			return Content.FadeTo(0.5);
		}

		// Method for animation child in PopupPage
		// Invoked before custom animation begin
		protected virtual Task OnDisappearingAnimationBegin()
		{
			return Content.FadeTo(1); ;
		}

		protected override bool OnBackButtonPressed()
		{
			// Prevent hide popup
			//return base.OnBackButtonPressed();
			return true;
		}

	}



}
}

