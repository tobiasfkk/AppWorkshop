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
		Button callButton; //botao que vai fazer a ligacao
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
				Text = "Digite o número ou nome do telefone:",
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
			});

			panel.Children.Add(phoneNumberText = new Entry
			{
				Text = "1Elian2Jao3Tobi",
			});

			panel.Children.Add(translateButton = new Button
			{
				Text = "Traduzir"
			});

			panel.Children.Add(callButton = new Button
			{
				Text = "Ligar para",
				IsEnabled = false
			});

			translateButton.Clicked += OnTranslate;
			callButton.Clicked += OnCall;
			this.Content = panel;
		}

        async void OnCall(object sender, EventArgs e) //metodo que é chamado pelo botao //async pra q a tela nao fique travada  
        {
			if(await this.DisplayAlert(
				"Ligar para número",
				"Você quer ligar para " + translatedNumber + "?",
				"Sim", "Não")){
				try
				{
					PhoneDialer.Open(translatedNumber);
				}
				catch(ArgumentNullException)
				{
					await DisplayAlert("Erro", "Número de telefone inválido.", "Ok");
				}
                catch (FeatureNotSupportedException)
                {
                    await DisplayAlert("Erro", "Ligação não suportada para este dispositivo.", "Ok");
                }
                catch (Exception)
                {
                    await DisplayAlert("Erro", "Ligação falhou.", "Ok");
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
				callButton.Text = "Ligar " + translatedNumber;
			}
			else
			{
                callButton.IsEnabled = false;
                callButton.Text = "Ligar";
            }
        }
    }
}


