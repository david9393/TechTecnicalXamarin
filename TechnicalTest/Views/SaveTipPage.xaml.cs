using Domain.TechnicalTest.Tips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTest.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechnicalTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SaveTipPage : ContentPage
    {
        public SaveTipPage()
        {
            InitializeComponent();
         
        }
        void OnTapGestureRecognizerTapped(object sender, EventArgs args)
        {
            myPicker.Focus();
        }
    }
}