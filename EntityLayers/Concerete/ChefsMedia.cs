using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayers.Concerete
{
    public class ChefsMedia
    {
        [Key]
        public int MediaId { get; set; }
        [StringLength(300)]
        public string MedidInstagram { get; set; }
        [StringLength(300)]
        public string MedidFacebook { get; set; }
        [StringLength(300)]
        public string MedidLinkedin { get; set; }

    }
}
