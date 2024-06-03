namespace MembershipsDemo.Interfaces
{
    public interface ICrudBase<T> where T : class
    {
        Task<List<T>> AllAsync { get; }
        Task<bool> AddAsync(T model);
        Task<T> FindByIdAsync(int _id);
        Task<bool> DeleteAsync(int _id);
        Task<bool> UpdateAsync(T model);
    }
}
