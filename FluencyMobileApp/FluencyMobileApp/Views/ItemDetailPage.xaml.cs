using System.ComponentModel;
using Xamarin.Forms;
using FluencyMobileApp.ViewModels;

namespace FluencyMobileApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}