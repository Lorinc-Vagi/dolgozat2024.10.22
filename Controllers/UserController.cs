using Dolgozat2024._10._22.DbContext;
using Dolgozat2024._10._22.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Dolgozat2024._10._22.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            var usersss = _context.Users.ToList();
            return Ok(usersss);
        }





        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // 1. Felhasználó regisztrációja
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    Password=model.Password
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return Ok("User created successfully");
                }

                return BadRequest(result.Errors);
            }

            return BadRequest(ModelState);
        }

        // 2. Felhasználó bejelentkezése
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, isPersistent: false, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return Ok("Login successful");
                }

                return Unauthorized("Invalid login attempt");
            }

            return BadRequest(ModelState);
        }

        // 3. Felhasználói adatok frissítése
        //[HttpPut("update")]
        //public async Task<IActionResult> UpdateUser([FromBody] UpdateUserModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = await _userManager.FindByIdAsync(model.Id);
        //        if (user != null)
        //        {
        //            user.Password=model.Password,
        //            user.Email = model.Email;

        //            var result = await _userManager.UpdateAsync(user);
        //            if (result.Succeeded)
        //            {
        //                return Ok("User updated successfully");
        //            }

        //            return BadRequest(result.Errors);
        //        }

        //        return NotFound("User not found");
        //    }

        //    return BadRequest(ModelState);
        //}

        // 4. Jelszó módosítása
        //[HttpPost("change-password")]
        //public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = await _userManager.FindByIdAsync(model.UserId);
        //        if (user != null)
        //        {
        //            var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
        //            if (result.Succeeded)
        //            {
        //                return Ok("Password changed successfully");
        //            }

        //            return BadRequest(result.Errors);
        //        }

        //        return NotFound("User not found");
        //    }

        //    return BadRequest(ModelState);
        //}
    }

    // Modellek a különböző akciókhoz
    public class RegisterUserModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class LoginUserModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class UpdateUserModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }

    public class ChangePasswordModel
    {
        public string UserId { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }

}
