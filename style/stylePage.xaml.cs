using System;
using Xamarin.Forms;

namespace style
{
	public partial class stylePage : ContentPage
	{
		public stylePage()
		{
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			change.Clicked += Change_Clicked;
		}

		protected override void OnDisappearing()
		{
			change.Clicked -= Change_Clicked;
			base.OnDisappearing();
		}

		void Change_Clicked(object sender, System.EventArgs e)
		{
			ChangeColor();
			ChangeSize();
			ChangeMode();

			App.Current.Resources["buttonHeight"] = (double)App.Current.Resources["buttonHeight"] * 1.2;
		}

		void ChangeMode()
		{
			var m = lineEndMode.Text;

		}

		void ChangeSize()
		{
			var s = fontSize.Text;
			var f = new FontSizeConverter();
			try
			{
				App.Current.Resources["titleSize"] = f.ConvertFrom(s);
			}
			catch (Exception e) { System.Diagnostics.Debug.WriteLine("titleSize: " + e.Message); }
		}

		void ChangeColor()
		{
			var c = color.Text;
			if (c == null)
			{
				return;
			}
			Color result = (Color)App.Current.Resources["titleColor"];
			var converter = new ColorTypeConverter();
			if (c.StartsWith("#"))
			{
				result = Color.FromHex(c);
			}
			else {
				try
				{
					result = (Color)converter.ConvertFrom(c);
				}
				catch { return; }
			}
			if (result != null)
			{
				App.Current.Resources["titleColor"] = result;
			}
		}
	}
}

