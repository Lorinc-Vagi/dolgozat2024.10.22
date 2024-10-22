using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Dolgozat2024._10._22.Entities
{
    public class User : IdentityUser
    {
        [Required]
        public string Password { get; set; }
        //public int Id { get; set; }
        //public string Name { get; set; }
        //public string Email { get; set; }
        //public string Password { get; set; }

    }
}
