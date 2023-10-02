namespace BusinessLayer.DapperRepository
{
    public interface IRepositoryDAP<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T?> GetById(string id);
        Task<int> Delete(string id);
        Task<int> Insert(T entity);
        Task<bool> Update(T entity);
       

    }
}
