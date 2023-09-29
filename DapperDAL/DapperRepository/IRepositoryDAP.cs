namespace BusinessLayer.DapperRepository
{
    public interface IRepositoryDAP<T>
    {
        Task<IEnumerable<T>> GetAll();


       bool Insert(T t);
        /*Task<int> Update(T entity);*/
        Queue<string> GetColumnNames();

        Task<T> GetById(Guid id);

        Task<bool> Delete(Guid id);

    }
}
