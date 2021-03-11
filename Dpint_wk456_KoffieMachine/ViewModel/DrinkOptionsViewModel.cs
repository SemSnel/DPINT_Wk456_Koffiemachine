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
using KoffieMachineDomain.Enums;

namespace Dpint_wk456_KoffieMachine.ViewModel
{
    public class DrinkOptionsViewModel : ViewModelBase
    {
        private IDrinkFactory _drinkFactory;
        private IDrink _selectedDrink;
        private Strength _coffeeStrength;
        private Amount _sugarAmount;
        private Amount _milkAmount;

        public DrinkOptionsViewModel(MainViewModel mainViewModel)
        {
            _drinkFactory = new DrinkFactory();
            MainViewModel = mainViewModel;

            _coffeeStrength = Strength.Normal;
            _sugarAmount = Amount.Normal;
            _milkAmount = Amount.Normal;
        }

        public  MainViewModel MainViewModel { get; }
        public ObservableCollection<string> LogText => MainViewModel.LogText;

        public ICommand DrinkCommand => new RelayCommand<string>(Drink);

        private void Drink(string name)
        {
            if (!_drinkFactory.AvailableDrinksNames.Contains(name))
            {
                LogText.Add("Couldn't make this drink" + name);
                return;
            }

            _selectedDrink = _drinkFactory.GetDrink(name, _coffeeStrength, _sugarAmount, _milkAmount);

            LogText.Add(_selectedDrink.Name + " " + _selectedDrink.GetPrice());

            MainViewModel.PaymentViewModel.RemainingPriceToPay = _selectedDrink.GetPrice();

            RaisePropertyChanged(() => SelectedDrinkName);
            RaisePropertyChanged(() => SelectedDrinkPrice);
        }

        public string SelectedDrinkName => _selectedDrink?.Name;

        public double? SelectedDrinkPrice => _selectedDrink?.GetPrice();

        
        public Strength CoffeeStrength
        {
            get { return _coffeeStrength; }
            set { _coffeeStrength = value; RaisePropertyChanged(() => CoffeeStrength); }
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
            get { return _sugarAmount; }
            set { _sugarAmount = value; RaisePropertyChanged(() => SugarAmount); }
        }

        public Amount MilkAmount
        {
            get { return _milkAmount; }
            set { _milkAmount = value; RaisePropertyChanged(() => MilkAmount); }
        }
    }
}
