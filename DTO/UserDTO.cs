using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DTO
{
    public class UserDTO
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please fill the Username field.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please fill the Password field.")]
        public string Password { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public bool isAdmin { get; set; }
        public bool isDeleted { get; set; }

        [Display(Name = "User Image")]
        public HttpPostedFileBase UserImage { get; set; }

    }
}
