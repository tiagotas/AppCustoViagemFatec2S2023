using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppCustoViagem
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                string origem = txt_origem.Text;
                string destino = txt_destino.Text;
                double distancia = Convert.ToDouble(txt_distancia.Text);
                double preco_gas = Convert.ToDouble(txt_preco_gas.Text);
                double rendimento = Convert.ToDouble(txt_rendimento.Text);

                double litros = (distancia / rendimento);
                double custo = litros * preco_gas;

                App PropriedadesApp = (App)Application.Current;

                double valor_total =
                    PropriedadesApp.ArrayPedagios.Sum(i => i.Valor);

                string msg =  $"Sua viagem de {origem} até {destino} ";
                       msg += $"irá custar {custo} e de pedágios ";
                       msg += valor_total;

                DisplayAlert("Valor total:", msg, "OK");

            } catch (Exception ex)
            {
                DisplayAlert("Ops", ex.Message, "OK");
            }
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new AddPedagio());

            } catch (Exception ex) {
                DisplayAlert("Ops", ex.Message, "OK");                
            }
        }
    }
}
