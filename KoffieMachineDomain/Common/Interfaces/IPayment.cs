using System;
namespace KoffieMachineDomain.Common.Interfaces
{
    public interface IPayment
    {
        double Pay(double insertedMoney);
    }
}
