using Dinero.Data;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace Dinero
{
	public partial class App : Application
	{
        //Dichiarazione variabili globali
        static DatabaseHelperContanti databaseContanti;
        static DatabaseHelperCarta databaseCarta;
        public static int whatDo = 0; //0 = Tutto, 1 = Ultima Settimana, 2 = Ultimo Mese
        public static int whatDoCarta = 0; //Vedi sopra
        public static int addType; //1 = Entrata contanti, 2 = Uscita contanti, 3 = Entrata carta, 4 = Uscita carta

        public App ()
		{
			InitializeComponent();

			MainPage = new MDPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

        //Se non esiste un database per i contanti, crealo
        public static DatabaseHelperContanti DatabaseContanti
        {
            get
            {
                if (databaseContanti == null)
                {
                    databaseContanti = new DatabaseHelperContanti();
                }
                return databaseContanti;
            }
        }

        //Se non esiste un database per le carte, crealo
        public static DatabaseHelperCarta DatabaseCarta
        {
            get
            {
                if (databaseCarta == null)
                {
                    databaseCarta = new DatabaseHelperCarta();
                }
                return databaseCarta;
            }
        }
    }
}
