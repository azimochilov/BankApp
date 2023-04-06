using BankWithMvc.Data.AppDbContext;
using BankWithMvc.Data.IRepositories;
using BankWithMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace BankWithMvc.Data.Repositories;
public class UserRepository : IUserRepository
{
    private readonly BankDbContext context = new BankDbContext();

    public async Task<bool> DeleteAsync(Predicate<User> user)
    {
        if(user == null)
        {
            user = x => true;
        }

        var delation = this.context.Users.ToList().Where(x => user(x));
        if (delation ==null)
        {
            return false; 
        }
        context.Users.RemoveRange(delation);
        await context.SaveChangesAsync();
        return true;

    }

    public async Task<User> InsertAsync(User user)
    {
        var entity = await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return entity.Entity;
    }

    public List<User> SelectAllAsync(Predicate<User> predicate = null)
    {
        if (predicate == null)
        {
            predicate = x => true;
        }
        return this.context.Users.ToList().Where(x =>predicate(x)).ToList();
    }

    public User SelectAsync(Predicate<User> predicate = null)
    {
        if (predicate == null)
        {
            predicate = x => true;
        }                
        return context.Users.ToList().FirstOrDefault(x => predicate(x));
    }

    public async Task<User> UpdateAsync(User user)
    {
        if (await context.Users.FirstOrDefaultAsync(e => e.Id == user.Id) is not null)
        {
            var updatedEntity = (context.Users.Update(user)).Entity;
            context.SaveChanges();
            return updatedEntity;
        }
        return null;
    }
}
