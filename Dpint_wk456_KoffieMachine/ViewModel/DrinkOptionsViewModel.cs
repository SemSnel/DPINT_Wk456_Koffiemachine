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
using KoffieMachineDomain.Config;
using KoffieMachineDomain.Entities;
using KoffieMachineDomain.Enums;
using KoffieMachineDomain.Util;
using TeaAndChocoLibrary;

namespace Dpint_wk456_KoffieMachine.ViewModel
{
    public class DrinkOptionsViewModel : ViewModelBase
    {
        private TeaBlendRepository _teaBlendRepository;
        private IDrinkFactory _drinkFactory;

        private DrinkOptions _options;
        private IDrink _selectedDrink;

        public DrinkOptionsViewModel(MainViewModel mainViewModel)
        {
            _options = new DrinkOptions();

            _teaBlendRepository = new TeaBlendRepository();
            SelectedTeaBlend = TeaBlendNames.First();

            JsonCoffees = new ObservableCollection<JsonCoffee>(JsonCoffeeLoader.GetCoffees());
            SelectedJsonCoffee = JsonCoffees.First();

            _drinkFactory = new DrinkFactory(_teaBlendRepository);

            MainViewModel = mainViewModel;

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
            
            MainViewModel.PaymentViewModel.RemainingPriceToPay = _selectedDrink.GetPrice();

            LogText.Add($"Selected {_selectedDrink.Name}, price: €{_selectedDrink.GetPrice():N2} Euro");

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

        public IEnumerable<string> TeaBlendNames => _teaBlendRepository.BlendNames;

        public string SelectedTeaBlend
        {
            get { return _options.TeaBlend; } set{ _options.TeaBlend = value; RaisePropertyChanged(() => SelectedTeaBlend); }
        }

        public ObservableCollection<JsonCoffee> JsonCoffees { get; set; }

        public JsonCoffee SelectedJsonCoffee { get { return _options.JsonCoffee; } set { _options.JsonCoffee = value; RaisePropertyChanged(() => SelectedJsonCoffee); } }

        internal void MakeDrink()
        {
            _selectedDrink.LogDrinkMaking(LogText);
            LogText.Add($"Finished making {SelectedDrinkName}");
            LogText.Add("------------------");

            _selectedDrink = null;
            RaisePropertyChanged(() => SelectedDrinkName);
            RaisePropertyChanged(() => SelectedDrinkPrice);
        }

    }
}
