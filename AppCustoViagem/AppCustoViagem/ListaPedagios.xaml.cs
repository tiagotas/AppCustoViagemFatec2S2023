using AppCustoViagem.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCustoViagem
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaPedagios : ContentPage
    {
        ObservableCollection<Pedagio> lista_pedagios = 
            new ObservableCollection<Pedagio> ();

        public ListaPedagios()
        {
            InitializeComponent();

            lst_pedagios.ItemsSource = lista_pedagios;

            // Obtendo as propriedades declaradas no arquivo
            // App.xaml.cs
            App PropriedadesApp = (App)Application.Current;

            // Adicionando cada item da List que está no
            // arquivo App.xaml.cs para a ObservableCollection
            // que criamos nesta classe, para exibir os pedágios
            // inseridos
            PropriedadesApp.ArrayPedagios.ForEach(p =>
            { lista_pedagios.Add(p); });
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            // Obtendo as propriedades declaradas no arquivo
            // App.xaml.cs
            App PropriedadesApp = (App)Application.Current;

            double valor_total =
                PropriedadesApp.ArrayPedagios.Sum(i => i.Valor);

            DisplayAlert("Valor total é:",
                         valor_total.ToString("C"), "OK");
        }
    }
}