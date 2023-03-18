using AppCustoViagem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCustoViagem
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPedagio : ContentPage
    {
        public AddPedagio()
        {
            InitializeComponent();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new ListaPedagios());

            }
            catch (Exception ex)
            {
                DisplayAlert("Ops", ex.Message, "OK");
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            // Obtendo as propriedades declaradas no arquivo
            // App.xaml.cs
            App PropriedadesApp = (App) Application.Current;

            // Montando o objeto pedágio que será salvo
            // no Array Pedagios
            Pedagio p = new Pedagio();
            p.Valor = Convert.ToDouble(txt_valor.Text);
            p.Localizacao = txt_localizacao.Text;
            p.Num = PropriedadesApp.ArrayPedagios.Count + 1;

            // Adicionando o Pedágio criado no ArrayPedagios
            PropriedadesApp.ArrayPedagios.Add(p);

            await DisplayAlert("Sucesso!", "Pedágio adicionado!", "OK");

            await Navigation.PushAsync(new ListaPedagios());
        }
    }
}