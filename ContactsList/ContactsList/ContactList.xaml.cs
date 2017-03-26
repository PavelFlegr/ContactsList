using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Xamarin.Forms;
using PCLStorage;

namespace ContactsList
{
    public partial class ContactList : ContentPage
    {
        public ObservableCollection<Contact> Contacts { get; set; } = new ObservableCollection<Contact>();
        public ContactList()
        {

            InitializeComponent();
            LoadContacts();
            BindingContext = this;
            
        }

        public void ShowDetail(object s, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new ContactDetail((Contact)e.Item));
        }

        //Načte kontakty z db
        void LoadContacts()
        {
            var db = new ContactDatabase("contacts");

            var contacts = db.GetContacts();
            foreach (Contact c in contacts)
            {
                Contacts.Add(c);
            }
        }

        private void addContactButton_Clicked(object sender, EventArgs e)
        {
            var contact = new Contact();
            var page = new EditContact(contact);
            page.Saved += (o, ev) => Contacts.Add(contact);
            Navigation.PushAsync(page);
        }
    }
}
