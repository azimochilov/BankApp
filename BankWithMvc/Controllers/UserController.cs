using BankWithMvc.Service.DTOs;
using BankWithMvc.Service.Interfaces;
using BankWithMvc.Service.Services;
using Microsoft.AspNetCore.Mvc;
namespace BankWithMvc.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService = new UserService();
        public async Task<IActionResult> Index()
        {
            var users = await this.userService.GetAllAsync();
            return View(users.Value);
        }



        [HttpPost]
        public async Task<IActionResult> Create(UserCreationDto userCreationDto)
        {
            await this.userService.AddAsync(userCreationDto);
            return View("Home");
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Home()
        {
            return View();
        }



        
        public async Task<IActionResult> Remove(long id)
        {
            var res = await this.userService.GetByIdAsync(id);
            return View(res.Value);
        }


        [ActionName("Remove")]
        [HttpPost]
        public async Task<IActionResult> RemoveAsync(long id)
        {
            var isDeleted = await this.userService.DeleteAsync(id);

            if (isDeleted.Value)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }



        
        public async Task<IActionResult> Update(long id)
        {
            var entity = await this.userService.GetByIdAsync(id);
            return View(entity.Value);
        }
        [ActionName("Update")]
        [HttpPost]
        public async Task<IActionResult> UpdateAsync(long id, UserCreationDto dto)
        {
            var updatedEntity = await this.userService.UpdateAsync(id,dto);

            if (updatedEntity.Value is null)
            {
                return View(updatedEntity.Value);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }



        public async Task<IActionResult> Details(long id)
        {
            var entity = await userService.GetByIdAsync(id);

            return View(entity.Value);
        }

    }
}
