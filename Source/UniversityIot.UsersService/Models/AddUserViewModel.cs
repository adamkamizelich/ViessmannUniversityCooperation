namespace UniversityIot.UsersService.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AddUserViewModel
    {
        public string Name { get; set; }

        public string CustomerNumber { get; set; }

        public string Password { get; set; }
    }
}