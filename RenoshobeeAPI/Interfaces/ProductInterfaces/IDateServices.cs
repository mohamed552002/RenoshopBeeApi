using RenoshopBee.Models;

namespace RenoshopBee.Interfaces.ProductInterfaces
{
    public interface IDateServices<in T> where T : class
    {
        public void SetDateToNow(T model);
        public void SetUpdatedAtNow(T model);
    }
}
