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
	public partial class Impostazioni : ContentPage
	{
		public Impostazioni ()
		{
			InitializeComponent ();
		}

        private void Cancella_Contanti (object sender, EventArgs e)
        {
            App.DatabaseContanti.DropContanti();
            DisplayAlert("Delete", "CASH table dropped", "OK");
        }

        private void Cancella_Carta(object sender, EventArgs e)
        {
            App.DatabaseCarta.DropCarta();
            DisplayAlert("Delete", "CARD table dropped", "OK");
        }

        async private void Cancella_Tutto(object sender, EventArgs e)
        {
            var scelta = await DisplayAlert("Delete", "Are you sure about THAT?", "YES", "NO");
            if (scelta)  //SI
            {
                App.DatabaseContanti.DropContanti();
                App.DatabaseCarta.DropCarta();
            }
        }
    }
}