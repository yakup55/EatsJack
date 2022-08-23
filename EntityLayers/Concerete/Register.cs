using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayers.Concerete
{
    public class Register
    {
        [Key]
        public int RegisterId { get; set; }
        [StringLength(50)]
        public string RegisterMail { get; set; }
        [StringLength(50)]
        public string RegisterPassword { get; set; }
        [StringLength(50)]
        public string RegisterPasswordAgain { get; set; }
    }
}
