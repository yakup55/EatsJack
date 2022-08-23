using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayers.Concerete
{
    public class Eats
    {
        [Key]
        public int EatsId { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "BU ALANI BOŞ BIRAKAMASSINIZ")]
        [MinLength(2, ErrorMessage = "En az 2 karakter olmalı")]
        public string EatsName { get; set; }
       
        public DateTime EatsDate { get; set; }

        [StringLength(300)]
        [Required(ErrorMessage = "BU ALANI BOŞ BIRAKAMASSINIZ")]
        public string EatsImage { get; set; }

        [StringLength(10000)]
        [Required(ErrorMessage = "BU ALANI BOŞ BIRAKAMASSINIZ")]
        [MinLength(576, ErrorMessage = "En az 576 karakter olmalı")]
        public string EatsSpecification { get; set; }

        [StringLength(1000)]
        [Required(ErrorMessage = "BU ALANI BOŞ BIRAKAMASSINIZ")]
        [MinLength(50,ErrorMessage ="En az 50 karakter olmalı")]
        public string EatsIngredients { get; set; }
        public bool EatsStatus { get; set; }

        //ilişki
        public int Categoryid { get; set; }
        public virtual Category Category { get; set; }

        public int chefsid { get; set; }
        public virtual Chefs Chefss { get; set; }

        public ICollection <Comment> comments { get; set; }

    }
}
