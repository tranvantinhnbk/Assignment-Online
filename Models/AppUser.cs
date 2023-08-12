using Microsoft.AspNetCore.Identity;
namespace Assignment_Online.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }

    }
}
