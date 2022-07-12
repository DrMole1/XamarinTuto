using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppAmsterdam
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstPage : ContentPage
    {
        public FirstPage(String _date)
        {
            InitializeComponent();
            CurrentDate.Text = _date;
        }

        private async void GoToPreviousPage(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void GoToNextPage(object sender, EventArgs e)
        {
            var contact = new Contact
            {
                Name ="Prob",
                Occupation="Dev"
            };

            var secondPage = new SecondPage();
            secondPage.BindingContext = contact;
            await Navigation.PushAsync(secondPage);
        }
    }
}