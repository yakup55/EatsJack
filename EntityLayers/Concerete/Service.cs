using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayers.Concerete
{
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }
        [StringLength(50)]
        public string ServiceName { get; set; }
        [StringLength(300)]
        public string ServiceContents { get; set; }
    }
}
