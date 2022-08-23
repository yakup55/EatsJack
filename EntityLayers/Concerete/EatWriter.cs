using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayers.Concerete
{
    public class EatWriter
    {
        [Key]
        public int WriterId { get; set; }
        [StringLength(100)]
        public string WriterNameSurname { get; set; }
        [StringLength(100)]
        public string WriterMail { get; set; }
        [StringLength(400)]
        public string WriterAbout { get; set; }
        [StringLength(300)]
        public string WriterImage { get; set; }
        [StringLength(100)]
        public string WriterTitle { get; set; }
        [StringLength(200)]
        public string WriterPassword { get; set; }
        public bool WriterStatus { get; set; }

    }
}
