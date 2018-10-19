using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lottie.Forms;
using Xamarin.Forms;

namespace Xamarin.Forms.LottieDemo.Views
{
	public partial class MainPage : ContentPage
	{
		public float progress { get; set; }

		public MainPage()
		{
			InitializeComponent();
			BindingContext = this;
		}

		void Handle_ValueChanged(object sender, Xamarin.Forms.ValueChangedEventArgs e)
		{
			progress = (float)e.NewValue;
		}

		void Handle_Clicked(object sender, System.EventArgs e)
		{
			animationView.Play();
		}
	}
}