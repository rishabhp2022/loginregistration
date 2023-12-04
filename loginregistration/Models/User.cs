using System.ComponentModel.DataAnnotations;

namespace loginregistration.Models
{
    public class User
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Field is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Field is required")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Field is required")]
        public string Password { get; set; }

        //public string Confirmpassword { get; set; }      


        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int IsActive { get; set; }


    }
    //public class RegisterUser
    //{
    //    public bool IsSucess { get; set; }

    //    public string Message { get; set; }
    //}
}
