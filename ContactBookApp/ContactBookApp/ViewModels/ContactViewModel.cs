using ContactBookApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactBookApp.ViewModels
{
    public class ContactViewModel:BaseViewModel
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool Blocked { get; set; }

        public ContactViewModel(){}
        public ContactViewModel(Contact contact)
        {
            Id = contact.Id;
            _firstName = contact.FirstName;
            _lastName = contact.LastName;
            PhoneNumber = contact.PhoneNumber;
            Email = contact.Email;
            Blocked = contact.Blocked;
        }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                SetValue(ref _firstName, value);
                OnPropertyChanged(nameof(FullName));
            }
        }
        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                SetValue(ref _lastName, value);
                OnPropertyChanged(nameof(FullName));
            }
        }


        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }
    }
}
