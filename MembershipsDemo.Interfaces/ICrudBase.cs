namespace MembershipsDemo.Interfaces
{
    public interface ICrudBase<T> where T : class
    {
        List<T> All { get; }
        Task<bool> AddAsync(T model);
        Task<List<T>> FindAllAsync();
        Task<T> FindByIdAsync(int _id);
        Task<bool> DeleteAsync(int _id);
        Task<bool> UpdateAsync(T model);
    }
}
