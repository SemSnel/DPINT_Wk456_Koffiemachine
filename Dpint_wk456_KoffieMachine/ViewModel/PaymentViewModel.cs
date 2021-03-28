using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using KoffieMachineDomain.Common.Interfaces;
using KoffieMachineDomain.Entities.Payment;

namespace Dpint_wk456_KoffieMachine.ViewModel
{
    public class PaymentViewModel : ViewModelBase
    {
        private MainViewModel _mainViewModel;
        private ObservableCollection<string> _logText;

        private double _remainingPriceToPay;

        private CashPayment _cashPayment;
        private CardPayment _cardPayment;

        private ObservableCollection<string> _paymentCardUsernames;

        private string _selectedPaymentCardUsername;

        public PaymentViewModel(MainViewModel mainViewModel, CashPayment cashPayment, CardPayment cardPayment)
        {
            _mainViewModel = mainViewModel;

            _logText = _mainViewModel.LogText;

            _cashPayment = cashPayment;
            _cardPayment = cardPayment;

            _selectedPaymentCardUsername = _cardPayment.PaymentCardUserNames.First();
        }

        #region PayDrinkCommands

        public ICommand PayByCoinCommand => new RelayCommand<double>(PayWithCash);

        public ICommand PayWithCardCommand => new RelayCommand(PayWithCard);
        #endregion PayDrinkCommands

        private void PayWithCash(double insertedMoney)
        {
            _cashPayment.InsertCoin(insertedMoney);

            Pay(_cashPayment);

            RetrieveCoin();
        }

        private void RetrieveCoin()
        {
            if (_cashPayment.InsertedMoney > 0)
            {
                var retrievedMoney = _cashPayment.RetrieveInsertedMoney();
                _logText.Add("Je kreeg " + retrievedMoney + " terug");
            }
        }

        private void PayWithCard()
        {
            Pay(_cardPayment);
        }

        private void Pay(IPayment payment)
        {
            if (_mainViewModel.DrinkOptionsViewModel.SelectedDrinkName == null)
            {
                return;
            }

            RemainingPriceToPay = payment.Pay(RemainingPriceToPay);

            RaisePropertyChanged(() => PaymentCardRemainingAmount);

            if (RemainingPriceToPay > 0)
            {
                var drinkName = _mainViewModel.DrinkOptionsViewModel.SelectedDrinkName;
                _logText.Add($"Selected {drinkName}, price: €{RemainingPriceToPay:N2} Euro");
                return;
            }

            _mainViewModel.DrinkOptionsViewModel.MakeDrink();
        }

        public ObservableCollection<string> PaymentCardUsernames =>
            _paymentCardUsernames ??= new ObservableCollection<string>(_cardPayment.PaymentCardUserNames);

        public double PaymentCardRemainingAmount => _cardPayment.CashOnCards.ContainsKey(SelectedPaymentCardUsername ?? "") ? _cardPayment.CashOnCards[SelectedPaymentCardUsername] : 0;


        public string SelectedPaymentCardUsername
        {
            get { return _cardPayment.SelectedPaymentCardUserName; }
            set
            {
                _cardPayment.SelectedPaymentCardUserName = value;
                RaisePropertyChanged(() => SelectedPaymentCardUsername);
                RaisePropertyChanged(() => PaymentCardRemainingAmount);
            }
        }

        public double RemainingPriceToPay
        {
            get { return _remainingPriceToPay; }
            set { _remainingPriceToPay = value; RaisePropertyChanged(() => RemainingPriceToPay); }
        }
    }
}
