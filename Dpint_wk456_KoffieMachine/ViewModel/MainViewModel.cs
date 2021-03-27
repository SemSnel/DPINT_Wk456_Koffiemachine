using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using KoffieMachineDomain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;
using KoffieMachineDomain.Common.Abstractions;
using KoffieMachineDomain.Common.Factories;
using KoffieMachineDomain.Common.Interfaces;
using KoffieMachineDomain.Entities.Payment;
using KoffieMachineDomain.Enums;

namespace Dpint_wk456_KoffieMachine.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public PaymentViewModel PaymentViewModel { get; set; }
        public DrinkOptionsViewModel DrinkOptionsViewModel { get; set; }

        public ObservableCollection<string> LogText { get; private set; }

        public MainViewModel()
        {
            LogText = new ObservableCollection<string>();

            LogText.Add("Starting up...");
            LogText.Add("Done, what would you like to drink?");

            DrinkOptionsViewModel = new DrinkOptionsViewModel(this);

            var cashPayment = new CashPayment(LogText);
            var cardPayment = new CardPayment(LogText);
            PaymentViewModel = new PaymentViewModel(this, cashPayment, cardPayment);
        }
    }
}