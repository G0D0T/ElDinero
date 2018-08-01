using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dinero.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Carta : ContentPage
	{
		public Carta ()
		{
			InitializeComponent ();
		}

        //Viene richiamato al caricamento della schermata
        protected override void OnAppearing()
        {
            Inizializza(App.whatDoCarta);
        }

        //Viene richiamato quando l'utente seleziona un oggetto dal Picker
        private void OnPicker(object sender, EventArgs e)
        {
            var pick = picker.Items[picker.SelectedIndex];

            switch (pick)
            {
                case "All":
                    App.whatDoCarta = 0;
                    Inizializza(App.whatDoCarta);
                    break;

                case "Last Week":
                    App.whatDoCarta = 1;
                    Inizializza(App.whatDoCarta);
                    break;

                case "Last Month":
                    App.whatDoCarta = 2;
                    Inizializza(App.whatDoCarta);
                    break;

                default:
                    Console.WriteLine("ERROREEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
                    break;
            }
        }

        //Viene richiamato quando l'utente selezione un oggetto dalla Listview
        async private void OnSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem;
            if (item == null) //La funzione viene richiamata anche quando un oggetto viene "deselezionato", quindi bisogna controllare se è null o meno
            {
                return;
            }
            var scelta = await DisplayAlert("Selection", "Do you wish to delete this transaction?", "YES", "NO");
            if (scelta)  //SI
            {
                /*using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_CONTANTI))
                {
                    conn.Delete(item);
                }*/
                App.DatabaseCarta.DeleteTransazione(item);

                Inizializza(App.whatDoCarta);
            }
            ((ListView)sender).SelectedItem = null; //deseleziono l'oggetto
        }

        //Entrata per carta
        private void Button_Clicked_Carta1(object sender, EventArgs e)
        {
            App.addType = 3;
            Navigation.PushAsync(new Nuovo());
        }

        //Uscita per carta
        private void Button_Clicked_Carta2(object sender, EventArgs e)
        {
            App.addType = 4;
            Navigation.PushAsync(new Nuovo());
        }

        //Funzione per aggiornare i dati in base alle azioni dell'utente
        private void Inizializza(int filtro)
        {
            var entrate = App.DatabaseCarta.QueryEntrata(filtro);
            entrateLabel.Text = entrate.ToString();

            var uscite = App.DatabaseCarta.QueryUscita(filtro);
            usciteLabel.Text = uscite.ToString();

            var saldo = Convert.ToDouble(usciteLabel.Text) + Convert.ToDouble(entrateLabel.Text);
            saldo = Math.Round(saldo, 2);
            saldoLabel.Text = saldo.ToString();

            var trlistcont = App.DatabaseCarta.GetTransazioni(filtro);
            cartaLw.ItemsSource = trlistcont.ToList();
        }
    }
}
