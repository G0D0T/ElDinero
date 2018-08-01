using Dinero.Model;
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
	public partial class Trasferimento : ContentPage
	{
        private int valor;
        //private bool flag = true;

		public Trasferimento ()
		{
			InitializeComponent ();
		}

        //Da Contante a Carta
        private void Button_Clicked1 (object sender, EventArgs e)
        {
            Transazione tr1 = new Transazione();
            Transazione tr2 = new Transazione();

            if (!double.TryParse(concarEntry.Text, out double d))
            {
                DisplayAlert("Error", "You inserted a not numeric value!", "OK");
            }
            else
            {
                tr1.Importo = d;
                tr2.Importo = -1.0 * d;
                tr1.Descrizione = "CASH to CARD";
                tr2.Descrizione = "CASH to CARD";
                tr1.Quando = DateTime.Today.ToString("yyyy-MM-dd");
                tr2.Quando = DateTime.Today.ToString("yyyy-MM-dd");

                valor = App.DatabaseCarta.AddTransazione(tr1);
                if (valor > 0)
                {
                    DisplayAlert("Transfer", "Success! (CONTANTI a CARTA)", "OK");
                }
                else
                {
                    DisplayAlert("Error", "Oops! That's embarassing", "OK");
                }
                valor = App.DatabaseContanti.AddTransazione(tr2);
            }

        }

        //Da carta a contante
        private void Button_Clicked2(object sender, EventArgs e)
        {
            Transazione tr1 = new Transazione();
            Transazione tr2 = new Transazione();

            if (!double.TryParse(carconEntry.Text, out double d))
            {
                DisplayAlert("Error", "You inserted a not numeric value!", "OK");
            }
            else
            {
                tr1.Importo = d;
                tr2.Importo = -1.0 * d;
                tr1.Descrizione = "CARD to CASH";
                tr2.Descrizione = "CARD to CASH";
                tr1.Quando = DateTime.Today.ToString("yyyy-MM-dd");
                tr2.Quando = DateTime.Today.ToString("yyyy-MM-dd");
                
                valor = App.DatabaseContanti.AddTransazione(tr1);
                if (valor > 0)
                {
                    DisplayAlert("Transfer", "Success! (CARTA a CONTANTI)", "OK");
                }
                else
                {
                    DisplayAlert("Error", "Oops! That's embarassing", "OK");
                }
                App.DatabaseCarta.AddTransazione(tr2);
            }

        }
    }
}