using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayers.Concerete
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        [StringLength(50)]
        public string ContactName { get; set; }
        [StringLength(100)]
        public string ContactMail { get; set; }
        [StringLength(100)]
        public string ContactSubject { get; set; }
        [StringLength(500)]
        public string ContactMessage { get; set; }
        [StringLength(11)]
        public string ContactNumber { get; set; }
    }
}
