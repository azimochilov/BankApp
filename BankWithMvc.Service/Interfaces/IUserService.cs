﻿using BankWithMvc.Service.DTOs;
using BankWithMvc.Service.Helpers;

namespace BankWithMvc.Service.Interfaces;
public interface IUserService
{
    ValueTask<Response<UserDto>> AddAsync(UserCreationDto model);
    ValueTask<Response<bool>> DeleteAsync(long id);
    ValueTask<Response<UserDto>> UpdateAsync(long id, UserCreationDto model);
    ValueTask<Response<UserDto>> GetByIdAsync(long id);
    ValueTask<Response<UserDto>> LoginAsync(string username, string password);
    ValueTask<Response<List<UserDto>>> GetAllAsync();
}
