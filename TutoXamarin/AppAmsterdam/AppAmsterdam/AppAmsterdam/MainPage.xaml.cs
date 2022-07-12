using AppAmsterdam.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppAmsterdam
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();


            // Affectation d'une clef/valeur dans le dictionnaire statique de l'app
            Application.Current.Properties["MainPageID"] = "M01";


            // Instantiation d'un bouton
            var button = new Button
            {
                Text = "Nouveau Bouton",
                BackgroundColor = Color.Yellow,
                WidthRequest = 100,
                HeightRequest=50
            };
            button.Pressed += OnPressedNewButton;
            //Content = button;


            // Génération dynamique de contenu
            // ==================================================================================================
            StackLayout stackLayout = new StackLayout
            {
                BackgroundColor = Color.Gray,
                Margin = new Thickness(10),
                Padding = new Thickness(10)
            };

            Frame frame;

            for(int i = 0; i < 5; i++)
            {
                stackLayout.Children.Add(frame = new Frame
                {
                    BorderColor = Color.Black,
                    Padding = new Thickness(5),
                    Content = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        Children =
                        {
                            new BoxView { Color = Color.Red },
                            new Label 
                            { 
                                Text = "Red",
                                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                                VerticalOptions = LayoutOptions.Center
                            }
                        }
                    }
                });
            }
            //Content = stackLayout;
            // ==================================================================================================
        }

        private void OnPressedNewButton(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Text = "Pressed Button !";
        }

        private void OnClick(object sender, EventArgs e)
        {
            // On récupère l'objet Button
            Button button = (Button)sender;

            // On change les attributs
            button.Text = "Clicked !";                         // Via l'objet
            BtnConfirm.BackgroundColor = Color.Blue;           // Via le nom du boutton depuis le fichier .xaml
        }

        private void OnPressed(object sender, EventArgs e)
        {
            MainLabel.Text = "Pressed Button";
        }

        private void OnReleased(object sender, EventArgs e)
        {
            MainLabel.Text = "Released Button";
        }

        private void OnEditorCompleted(object sender, EventArgs e)
        {
            var editor = (Editor)sender;
            MainLabel.Text = editor.Text;
        }

        private void OnEditorChanged(object sender, TextChangedEventArgs e)
        {
            var editor = (Editor)sender;
            MainLabel.Text = editor.Text;
        }

        private async void GoToNextPage(object sender, EventArgs e)
        {
            var date = DateTime.Now.ToString("F");
            await Navigation.PushAsync(new FirstPage(date));
        }

        private async void AddUser_Clicked(object sender, EventArgs e)
        {
            StatusMessage.Text = "";
            await App.UserRepository.AddNewUserAsync(NewUser.Text);

            StatusMessage.Text = App.UserRepository.StatusMessage;
        }

        private async void GetUsers_Clicked(object sender, EventArgs e)
        {
            StatusMessage.Text = "";

            List<User> users = await App.UserRepository.GetUsersAsync();

            foreach(User user in users)
            {
                Console.WriteLine("User " + user.Id + " : " + user.Name);
            }

            StatusMessage.Text = App.UserRepository.StatusMessage;
        }
    }
}
