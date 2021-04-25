using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionsListApp.Models
{
    public class MoreOptionType
    {
        [Key]
        public int MoreOptionTypeID { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual List<MoreOption> MoreOptions { get; set; }

    }
}
