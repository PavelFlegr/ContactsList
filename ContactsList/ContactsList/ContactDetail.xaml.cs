using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Messaging;

using Xamarin.Forms;

namespace ContactsList
{
    public partial class ContactDetail : ContentPage
    {
        Contact _contact;
        public ContactDetail(Contact contact)
        {           
            InitializeComponent();
            BindingContext = contact;
            _contact = contact;
        }

        public async void MakeCall(object o, EventArgs e)
        {
            IPhoneCallTask phone = MessagingPlugin.PhoneDialer;
            if (!phone.CanMakePhoneCall)
            {
                await DisplayAlert("Call not supported", "Device does not support calls", "ok");
                return;
            }
            phone.MakePhoneCall(_contact.Number, _contact.Name);
        }

        private void EditContactButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditContact(_contact));
        }
    }
}
