using GeekShopping.ProductAPI.Model.Base;

namespace GeekShopping.ProductApi.DataBase.Interface
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Add(T item);
        T GetById(long id);
        List<T> GetAll();
        T Update(T item);
        void Delete(long id);
        bool Exists(long? id);
    }
}