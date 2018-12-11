using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetProject.Models
{
    public class APIListModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "API Name")]
        public String APIName {get; set; }
    }
}
