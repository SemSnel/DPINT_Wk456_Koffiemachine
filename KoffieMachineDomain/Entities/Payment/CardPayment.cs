using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using KoffieMachineDomain.Common.Interfaces;

namespace KoffieMachineDomain.Entities.Payment
{
    public class CardPayment : IPayment
    {
        public Dictionary<string, double> CashOnCards { get; }

        public ObservableCollection<string> _logText;

        public CardPayment(ObservableCollection<string> logText)
        {
            _logText = logText;

            CashOnCards = new Dictionary<string, double>();
            CashOnCards["Arjen"] = 5.0;
            CashOnCards["Bert"] = 3.5;
            CashOnCards["Chris"] = 7.0;
            CashOnCards["Daan"] = 6.0;

            SelectedPaymentCardUserName = CashOnCards.Keys.First();
        }

        public ICollection<string> PaymentCardUserNames => CashOnCards.Keys;

        public string SelectedPaymentCardUserName { get; set; }

        public ObservableCollection<string> LogText => _logText;

        public double Pay(double remainingPriceToPay)
        {
            var insertedMoney = CashOnCards[SelectedPaymentCardUserName];

            if (remainingPriceToPay > insertedMoney)
            {
                remainingPriceToPay -= insertedMoney;

                LogText.Add($"Inserted €{insertedMoney:N2} Euro, Remaining: €{remainingPriceToPay:N2} Euro.");

                CashOnCards[SelectedPaymentCardUserName] = 0;

                return remainingPriceToPay;
            }

            CashOnCards[SelectedPaymentCardUserName] -= remainingPriceToPay;

            remainingPriceToPay = 0;

            LogText.Add($"Inserted €{insertedMoney:N2} Euro, Remaining: €{remainingPriceToPay:N2} Euro.");

            return remainingPriceToPay;
        }
    }
}
