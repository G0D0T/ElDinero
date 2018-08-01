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
	public partial class Nuovo : ContentPage
	{

        /*private string vartemp1 = DateTime.Today.AddDays(-15).ToString("yyyy-MM-dd");
        private string vartemp2 = DateTime.Today.AddDays(-150).ToString("yyyy-MM-dd");*/

        private int valor;

		public Nuovo ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked (object sender, EventArgs e)
        {
            Transazione tr = new Transazione();
            if (!double.TryParse(impEntry.Text, out double d))
            {
                DisplayAlert("Error", "You inserted a not numeric value!", "OK");
            }
            else {
                tr.Importo = d;
                tr.Descrizione = descEntry.Text;
                tr.Quando = DateTime.Today.ToString("yyyy-MM-dd");

                switch (App.addType)
                {
                case 1:
                        valor = App.DatabaseContanti.AddTransazione(tr);
                        Validazione(valor);
                        break;

                case 2:
                        tr.Importo = -1.0 * tr.Importo;
                        valor = App.DatabaseContanti.AddTransazione(tr);
                        Validazione(valor);
                        break;

                case 3:
                        valor = App.DatabaseCarta.AddTransazione(tr);
                        Validazione(valor);
                        break;

                case 4:
                        tr.Importo = -1.0 * tr.Importo;
                        valor = App.DatabaseCarta.AddTransazione(tr);
                        Validazione(valor);
                        break;

                default:
                    Console.WriteLine("ERROREEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
                    break;
                }
            }

            Navigation.PopAsync();

        }

        private void Validazione(int param)
        {
            if (param > 0)
            {
                DisplayAlert("Insert", "Success!", "OK");
            }
            else
            {
                DisplayAlert("Insert", "Oops! That's embarassing", "OK");
            }
        }
	}
}