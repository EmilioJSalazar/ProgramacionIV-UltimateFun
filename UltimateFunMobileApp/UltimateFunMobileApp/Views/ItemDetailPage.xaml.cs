using System.ComponentModel;
using UltimateFunMobileApp.ViewModels;
using Xamarin.Forms;

namespace UltimateFunMobileApp.Views
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