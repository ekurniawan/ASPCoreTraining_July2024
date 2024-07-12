namespace ASPCoreTraining.Web.Services
{
    public interface ICrud<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(string id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task Delete(string id);
    }
}
