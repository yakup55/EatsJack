using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayers.Concerete
{
    public class Chefs
    {
        [Key]
        public int ChefsId { get; set; }
        [StringLength(50)]
        public string ChefsName { get; set; }
        [StringLength(200)]
        public string ChefsMail { get; set; }
        [StringLength(200)]
        public string ChefsAbout { get; set; }
        [StringLength(200)]
        public string ChefsImage { get; set; }
        [StringLength(50)]
        public string ChefsPassword { get; set; }
        public bool ChefsStatus { get; set; }
        [StringLength(300)]
        public string MedidInstagram { get; set; }
        [StringLength(300)]
        public string MedidFacebook { get; set; }
        [StringLength(300)]
        public string MedidLinkedin { get; set; }

        public ICollection<Eats> Eats { get; set; }
    }
}
