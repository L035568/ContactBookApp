using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ContactBookApp.Models;
using SQLite;
using ContactBookApp.ViewModels;

namespace ContactBookApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactDetailsPage : ContentPage
	{
		public ContactDetailsPage (ContactDetailsPageViewModel viewModel)
		{
			InitializeComponent ();

            BindingContext = viewModel;
		}
    }
}