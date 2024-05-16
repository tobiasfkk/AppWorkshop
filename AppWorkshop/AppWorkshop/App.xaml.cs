using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppWorkshop
{
    public partial class App : Application
    {
        public App ()
        {
            InitializeComponent(); //inicia componentes do xaml

            MainPage = new MainPage();
        }

        // Método chamado quando a aplicação inicia
        protected override void OnStart ()
        {
        }

        // Método chamado quando a aplicação entra em modo de suspensão
        protected override void OnSleep ()
        {
        }

        // Método chamado quando a aplicação volta do modo de suspensão
        protected override void OnResume ()
        {
        }
    }
}

