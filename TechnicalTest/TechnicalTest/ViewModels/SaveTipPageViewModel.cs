using Domain.TechnicalTest.Tips;
using Infrastructure.TechnicalTest.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechnicalTest.ViewModels.Base;
using Xamarin.Forms;

namespace TechnicalTest.ViewModels
{
    public class SaveTipPageViewModel : ViewModelBase
    {
        private readonly ITip _tip;
        private DateTime _Fecha;
        private string _Titulo;
        private string _Descripcion;
        private string _NamePage;
        private string _NameButton;
        private int IdTip;
        public Command SaveTipCommand { get; }
        public DateTime Fecha 
        {
            get => _Fecha;
            set
            {
                _Fecha = value;
                RaisePropertyChanged(() => Fecha);
            }
        }
        public string Titulo
        {
            get => _Titulo;
            set
            {
                _Titulo = value;
                RaisePropertyChanged(() => Titulo);
            }
        }
        public string Descripcion
        {
            get => _Descripcion;
            set
            {
                _Descripcion = value;
                RaisePropertyChanged(() => Descripcion);
            }
        }
        public string NamePage
        {
            get => _NamePage;
            set
            {
                _NamePage = value;
                RaisePropertyChanged(() => NamePage);
            }
        }
        public string NameButton
        {
            get => _NameButton;
            set
            {
                _NameButton = value;
                RaisePropertyChanged(() => NameButton);
            }
        }
        public SaveTipPageViewModel(ITip tip)
        {
            _tip = tip;
            SaveTipCommand = new Command(Guardar);
        }
        public override Task InitializeAsync(object navigationData)
        {
            TipModel tip = (TipModel)navigationData ;
            if (tip != null)
            {
                Titulo = tip.Titulo;
                Fecha = tip.Fecha;
                Descripcion = tip.Descripcion;
                IdTip = tip.Id;
                NamePage = "Modificar Tip";
                NameButton = "Modificar";
            }
            else
            {
                NamePage = "Nuevo Tip";
                NameButton = "Crear";
                Fecha = DateTime.Now;
            }
            return base.InitializeAsync(navigationData);
        }

        private  void Guardar()
        {

            TipModel tipModel = new TipModel 
            { 
                Id=IdTip,
                Fecha = Fecha,
                Titulo=Titulo,
                Descripcion = Descripcion
            };
            BaseOut baseOut=  _tip.AddNewTip(tipModel);
            if (!baseOut.Status)
            {
                Application.Current.MainPage.DisplayAlert(
                    "Alerta",
                     baseOut.Error,
                    "Accept");
                return;
            }
            NavigationService.NavigateToAsync<MainPageViewModel>();
        }
    }
}
