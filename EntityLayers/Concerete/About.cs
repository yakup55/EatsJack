using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayers.Concerete
{
    public class About
    {
        [Key]
        public int AboutİD { get; set; }
        [StringLength(1000)]
        public string AboutDetails { get; set; }
        [StringLength(200)]
        public string AboutImage { get; set; }
    }
}
