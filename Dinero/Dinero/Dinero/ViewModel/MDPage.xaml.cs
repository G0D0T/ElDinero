using Dinero.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dinero
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MDPage : MasterDetailPage
    {
        public MDPage()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MDPageMenuItem;
            if (item == null)
                return;

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            switch (page.Title)
            {
                case "Cash":
                    Detail = new NavigationPage(new Contanti());
                    break;
                case "Card":
                    Detail = new NavigationPage(new Carta());
                    break;
                case "Transfer":
                    Detail = new NavigationPage(new Trasferimento());
                    break;
                case "Settings":
                    Detail = new NavigationPage(new Impostazioni());
                    break;
                default:
                    throw new Exception(String.Format("Unknown state: {0}", page.Title)); //da commentare o modificare
            }
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }
    }
}