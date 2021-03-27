using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using KoffieMachineDomain.Common.Factories;
using KoffieMachineDomain.Common.Interfaces;
using KoffieMachineDomain.Entities;
using KoffieMachineDomain.Enums;

namespace Dpint_wk456_KoffieMachine.ViewModel
{
    public class DrinkOptionsViewModel : ViewModelBase
    {
        private IDrinkFactory _drinkFactory;

        private DrinkOptions _options;
        private IDrink _selectedDrink;

        public DrinkOptionsViewModel(MainViewModel mainViewModel)
        {
            _drinkFactory = new DrinkFactory();
            MainViewModel = mainViewModel;

            _options = new DrinkOptions();
        }

        public  MainViewModel MainViewModel { get; }
        public ObservableCollection<string> LogText => MainViewModel.LogText;

        public ICommand DrinkCommand => new RelayCommand<string>(Drink);

        private void Drink(string name)
        {
            _options.Name = name;

            if (!_drinkFactory.IsExistingDrink(name))
            {
                LogText.Add("Couldn't make this drink" + name);
                return;
            }

            _selectedDrink = _drinkFactory.GetDrink(_options);

            LogText.Add(_selectedDrink.Name + " " + _selectedDrink.GetPrice());

            MainViewModel.PaymentViewModel.RemainingPriceToPay = _selectedDrink.GetPrice();

            RaisePropertyChanged(() => SelectedDrinkName);
            RaisePropertyChanged(() => SelectedDrinkPrice);
        }

        public string SelectedDrinkName => _selectedDrink?.Name;

        public double? SelectedDrinkPrice => _selectedDrink?.GetPrice();

        
        public Strength CoffeeStrength
        {
            get { return _options.Strength; }
            set { _options.Strength = value; RaisePropertyChanged(() => CoffeeStrength); }
        }

        internal void MakeDrink()
        {
            LogText.Add("Aan het maken...");
            _selectedDrink.LogDrinkMaking(LogText);

            _selectedDrink = null;
            RaisePropertyChanged(() => SelectedDrinkName);
            RaisePropertyChanged(() => SelectedDrinkPrice);
        }

        public Amount SugarAmount
        {
            get { return _options.SugarAmount; }
            set { _options.SugarAmount = value; RaisePropertyChanged(() => SugarAmount); }
        }

        public Amount MilkAmount
        {
            get { return _options.MilkAmount; }
            set { _options.MilkAmount = value; RaisePropertyChanged(() => MilkAmount); }
        }
    }
}
