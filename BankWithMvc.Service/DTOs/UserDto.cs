using BankWithMvc.Domain.Commons;

namespace BankWithMvc.Service.DTOs;
public class UserDto : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
}
