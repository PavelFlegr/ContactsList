using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactsList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditContact : ContentPage
    {
        Contact _contact;
        Contact orig;
        public EditContact(Contact contact)
        {
            InitializeComponent();
            BindingContext = contact;
            _contact = contact;
            orig = new Contact { Name = contact.Name, Number = contact.Number };
        }

        private void CancelButton_Clicked(object sender, EventArgs e)
        {
            _contact.Name = orig.Name;
            _contact.Number = orig.Number;
            Navigation.PopAsync();
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            var db = new ContactDatabase("contacts");
            db.SaveItem(_contact);
            RaiseSaved();
            Navigation.PopAsync();
        }

        public event EventHandler Saved;

        void RaiseSaved()
        {
            Saved?.Invoke(this, EventArgs.Empty);
        }
    }
}
