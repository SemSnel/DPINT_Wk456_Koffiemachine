using System;
namespace KoffieMachineDomain.Common.Interfaces
{
    public interface IPayment
    {
        public double RemainingPriceToPay { get; set; }

        double Pay(double insertedMoney);
    }
}
