using BankWithMvc.Domain.Commons;
using System.Security.AccessControl;

namespace BankWithMvc.Domain.Entities;
public class User : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
}
