using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class VideoDTO
    {
        public int ID { get; set; }
        
        public string VideoPath { get; set; }
        [Required(ErrorMessage = "Please fill the title field.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please fill the video path field.")]
        public string OriginalVideoPath { get; set; }

        public DateTime AddDate { get; set; }

        public int AddUserID { get; set; }
    }
}
