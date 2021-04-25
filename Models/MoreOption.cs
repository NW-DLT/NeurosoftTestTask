using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionsListApp.Models
{
    public class MoreOption
    {
        [Key]
        public int MoreOptionID { get; set; }

        public string Title { get; set; }

        public int MoreOptionTypeID { get; set; }
        public MoreOptionType MoreOptionType { get; set; }

        public virtual List<Value> Values { get; set; }

        [NotMapped]
        public MoreOptionType MoreOptionTypeName
        {
            get
            {
                return DataWorker.GetMoreOptionTypeByID(MoreOptionID);
            }
        }
    }
}
