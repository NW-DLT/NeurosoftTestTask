using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionsListApp.Models
{
    public class Value
    {
        [Key]
        public int ValueID { get; set; }
        [Required]
        public string ValueName { get; set; }
        [Required]
        public MoreOption moreOption { get; set; }

        [Required]
        public int MoreOptionID { get; set; }
    }
}
