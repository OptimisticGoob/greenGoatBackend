using Microsoft.AspNetCore.Identity;

namespace GreenGoat.Core.Entities;

public class User : IdentityUser {
   
    public ICollection<User> Following {get; set;} = new List<User>();
    public ICollection<User> Followers {get; set;} = new List<User>();
    
}