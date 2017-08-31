using Xamarin.Forms;

namespace FetchContactsDemo
{
	public partial class FetchContactsDemoPage : ContentPage
	{
		public FetchContactsDemoPage()
		{
			try
			{
				InitializeComponent();
				BindingContext = new FetchContactsViewModel();
			}
			catch (System.Exception ex)
			{

			}
		}

	}
}
