using System;
using KoffieMachineDomain.Common.Interfaces;

namespace KoffieMachineDomain.Entities.Payment
{
    public class CashPayment : IPayment
    {
        private double remainingPriceToPay;

        public CashPayment()
        {

        }

        public double RemainingPriceToPay { get => remainingPriceToPay; set => remainingPriceToPay = value; }

        public double Pay(double insertedMoney)
        {
            return RemainingPriceToPay;
        }
    }
}
