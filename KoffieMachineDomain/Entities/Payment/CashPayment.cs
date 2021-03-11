using System;
using System.Collections.ObjectModel;
using KoffieMachineDomain.Common.Interfaces;

namespace KoffieMachineDomain.Entities.Payment
{
    public class CashPayment : IPayment
    {
        private ObservableCollection<string> _logText;
        private double _insertedMoney;

        public CashPayment(ObservableCollection<string> logText)
        {
            _logText = logText;
        }

        public double InsertCoin(double insertedMoney)
        {
            return _insertedMoney += insertedMoney;
        }

        public double InsertedMoney => _insertedMoney;

        public double RetrieveInsertedMoney()
        {
            var retrievedMoney = _insertedMoney;

            _insertedMoney = 0;

            return retrievedMoney;
        }


        public double Pay(double remainingPriceToPay)
        {
            if (remainingPriceToPay > _insertedMoney)
            {
                _insertedMoney = 0;

                return remainingPriceToPay -= _insertedMoney;
            }

            _insertedMoney -= remainingPriceToPay;

            remainingPriceToPay = 0;

            return remainingPriceToPay;
        }
    }
}
