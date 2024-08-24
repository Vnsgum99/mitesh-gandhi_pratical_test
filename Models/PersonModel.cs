using System.ComponentModel.DataAnnotations;

namespace mitesh_gandhi_pratical_test.Models
{
    public class PersonModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string PhoneNo { get; set; }

        public string Address { get; set; }
        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }
        [Required(ErrorMessage = "You must agree to terms")]
        public bool Agree { get; set; }
    }
}
