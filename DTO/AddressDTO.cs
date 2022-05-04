using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AddressDTO
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please fill address field.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please fill email field.")] 
        public string Email { get; set; }
        [Required(ErrorMessage = "Please fill phone field.")]
        public string Phone { get; set; }
    
        public string Phone2 { get; set; }
        public string Fax { get; set; }
        [Required(ErrorMessage = "Please fill map field.")]
        public String MapPathLarge { get; set; }
        [Required(ErrorMessage = "Please fill phone field.")]
        public String MapPathSmall { get; set; }
    }
}
