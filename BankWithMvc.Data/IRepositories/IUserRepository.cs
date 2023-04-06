using BankWithMvc.Domain.Entities;

namespace BankWithMvc.Data.IRepositories;
public interface IUserRepository
{
    public Task<User> InsertAsync(User user);
    public Task<User> UpdateAsync(User user);
    public Task<bool> DeleteAsync(Predicate<User> user);
    public List<User> SelectAllAsync(Predicate<User> predicate = null);
    public User SelectAsync(Predicate<User> predicate = null);
}
