using System;
using Xamarin.Essentials; //pacote que unifica muuitas funcionalidades 
using Xamarin.Forms;
using Xamarin.Forms.Core;

namespace AppWorkshop
{
	public class MainPage : ContentPage
	{

		Entry phoneNumberText; //tipo Entry é um campo onde é adicionado o texto
		Button translateButton; //botao pra fazer a acao de enviar o numero de telefone
		Button callButton; //
		String translatedNumber; //vai exibir o número q vai ligar

		public MainPage ()
		{
			this.Padding = new Thickness(20, 44, 20, 20); //margen pra nao ficar tao nas bordas

			StackLayout panel = new StackLayout //empilhar os componentes
            { 
				Spacing = 15
            };

			panel.Children.Add(new Label
			{
				Text = "Digite aqui a phoneword:",
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
			});

			panel.Children.Add(phoneNumberText = new Entry
			{
				Text = "1-855-XAMARIN",
			});

			panel.Children.Add(translateButton = new Button
			{
				Text = "Translate"
			});

			panel.Children.Add(callButton = new Button
			{
				Text = "Call",
				IsEnabled = false
			});

			translateButton.Clicked += OnTranslate;
			callButton.Clicked += OnCall;
			this.Content = panel;
		}

        async void OnCall(object sender, EventArgs e) //metodo que é chamado pelo botao //async pra q a tela nao fique travada  
        {
			if(await this.DisplayAlert(
				"Dial a number",
				"Would you like to call " + translatedNumber + "?",
				"Yes", "No")){
				try
				{
					PhoneDialer.Open(translatedNumber);
				}
				catch(ArgumentNullException)
				{
					await DisplayAlert("Unable to dial", "Phone number was not valid.", "Ok");
				}
                catch (FeatureNotSupportedException)
                {
                    await DisplayAlert("Unable to dial", "Phone dialing not supported.", "Ok");
                }
                catch (Exception)
                {
                    await DisplayAlert("Unable to dial", "Phone dialing failed.", "Ok");
                }
            }
        }

        private void OnTranslate(object sender, EventArgs e)
        {
			String enteredNumber = phoneNumberText.Text;
			translatedNumber = PhonewordTranslator.toNumber(enteredNumber);

			if (!String.IsNullOrEmpty(translatedNumber))
			{
				callButton.IsEnabled = true;
				callButton.Text = "Call " + translatedNumber;
			}
			else
			{
                callButton.IsEnabled = false;
                callButton.Text = "Call";
            }
        }
    }
}


