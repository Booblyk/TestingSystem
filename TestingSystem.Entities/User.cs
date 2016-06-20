using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace TestingSystem.Entities
{
    public class User : IBaseEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Email adress is required")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
       [DataType(DataType.Password)]
        [StringLength(255, MinimumLength = 1)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        //[Required(ErrorMessage = "First Name is required")]
       // [DataType(DataType.Text)]
       // [StringLength(30, MinimumLength = 3)]
        public string FirstName { get; set; }
       // [DataType(DataType.Text)]
        //[StringLength(30, MinimumLength = 1)]
        //[Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }
        //[Required(ErrorMessage = "Role is required")]
        public string Role { get; set; }


        //only for student
        public ICollection<Mark> Marks { get; set; }


    }
}
