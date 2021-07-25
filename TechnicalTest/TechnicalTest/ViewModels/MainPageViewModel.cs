using Domain.TechnicalTest.Tips;
using Infrastructure.TechnicalTest.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TechnicalTest.ViewModels.Base;
using TechnicalTest.Views;
using Xamarin.Forms;

namespace TechnicalTest.ViewModels
{
    public class MainPageViewModel :  ViewModelBase
    {
        private readonly ITip _tip;
        private ObservableCollection<TipModel> _ListTips;
        public Command NewTipCommand { get; }
        public Command<TipModel> EditarTipCommand { get; }
        public Command<TipModel> DeleteTipCommand { get; }

        public ObservableCollection<TipModel> ListTips
        {
            get => _ListTips;
            set
            {
                _ListTips = value;
                RaisePropertyChanged(() => ListTips);
            }
        }

        public MainPageViewModel(ITip tip)
        {
            _tip = tip;
            NewTipCommand  = new Command(async () =>
            {
                await NavigationService.NavigateToAsync<SaveTipPageViewModel>();
            });
            EditarTipCommand = new Command<TipModel>(EditarTip);
            DeleteTipCommand = new Command<TipModel>(DeleteTip);
            GetTipsAll();
        }

        private async void GetTipsAll()
        {
                ListTips = new ObservableCollection<TipModel>();
            List<TipModel> tips = await _tip.GetAllTip();
            foreach (TipModel item in tips) ListTips.Add(item);
        }
        private async void EditarTip(TipModel tip)
        {
            await NavigationService.NavigateToAsync<SaveTipPageViewModel>(tip);
        }
        private async void DeleteTip(TipModel tip)
        {
            await _tip.DeleteTip(tip);
            ListTips.Remove(tip);
        }
    }
}
