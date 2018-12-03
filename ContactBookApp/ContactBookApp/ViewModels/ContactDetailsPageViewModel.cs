using ContactBookApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ContactBookApp.ViewModels
{
    public class ContactDetailsPageViewModel
    {
        private readonly IContactStore _contactStore;
        private readonly IPageService _pageService;

        public event EventHandler<Contact> ContactAdded;
        public event EventHandler<Contact> ContactUpdated;

        public Contact Contact { get; private set; }

        public ICommand SaveCommand { get; private set; }

        public ContactDetailsPageViewModel(ContactViewModel viewModel,IContactStore contactStore,IPageService pageService)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            _pageService = pageService;
            _contactStore = contactStore;

            SaveCommand = new Command(async () => await Save());

            Contact = new Contact
            {
                Id = viewModel.Id,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                PhoneNumber = viewModel.PhoneNumber,
                Email = viewModel.Email,
                Blocked = viewModel.Blocked
            };
        }

        async Task Save()
        {
            if(string.IsNullOrWhiteSpace(Contact.FirstName) &&
                string.IsNullOrWhiteSpace(Contact.LastName))
            {
                await _pageService.DisplayAlert("Error", "Please enter the name.", "OK");
                return;
            }

            if(Contact.Id == 0)
            {
                await _contactStore.AddContact(Contact);

                ContactAdded?.Invoke(this, Contact);
            }
            else
            {
                await _contactStore.UpdateContact(Contact);
                ContactUpdated?.Invoke(this,Contact);
            }

            await _pageService.PopAsync();
        }
    }
}
