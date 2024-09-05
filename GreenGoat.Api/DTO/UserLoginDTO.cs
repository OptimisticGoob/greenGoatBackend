using System.ComponentModel.DataAnnotations;

namespace GreenGoat.Api.DTO;
public class UserLoginDTO
{
    public string UserName {get; set;}
    public string Email {get; set;}
    public string Password {get; set;}
}