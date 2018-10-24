using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetProject.Models
{
    public class BlogModel
    {
        public string Username { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Body { get; set; }

        public DateTime TimeStamp { get; set; }

        public BlogModel()
        {
            TimeStamp = DateTime.Now;
        }
    }
}
