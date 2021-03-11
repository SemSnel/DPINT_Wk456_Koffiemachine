using System;
using System.Collections.Generic;
using KoffieMachineDomain.Common.Interfaces;

namespace KoffieMachineDomain.Entities.Payment
{
    public class CardPayment : IPayment
    {
        private double remainingPriceToPay;
        private Dictionary<string, double> _cashOnCards;

        public CardPayment()
        {
            _cashOnCards = new Dictionary<string, double>();
            _cashOnCards["Arjen"] = 5.0;
            _cashOnCards["Bert"] = 3.5;
            _cashOnCards["Chris"] = 7.0;
            _cashOnCards["Daan"] = 6.0;
        }

        public double RemainingPriceToPay { get => remainingPriceToPay; set => remainingPriceToPay = value; }

        public double Pay(double insertedMoney)
        {
            throw new NotImplementedException();
        }
    }
}
