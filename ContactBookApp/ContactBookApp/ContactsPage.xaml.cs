using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ContactBookApp.Models;
using System.Collections.ObjectModel;
using SQLite;
using ContactBookApp.ViewModels;
using ContactBookApp.Persistence;
using Xamarin.Forms.Xaml;

namespace ContactBookApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactsPage : ContentPage
    {
        public ContactsPage()
        {
            var contactStore = new ContactStore(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();
            ViewModel = new ContactsPageViewModel(contactStore, pageService);

            InitializeComponent();

            
        }

        protected override void OnAppearing()
        {
            ViewModel.LoadDataCommand.Execute(null);
            base.OnAppearing();
        }

        public ContactsPageViewModel ViewModel
        {
            get { return BindingContext as ContactsPageViewModel; }
            set { BindingContext = value; }
        }

        private void OnContactSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.SelectContactCommand.Execute(e.SelectedItem);
        }
    }
}
