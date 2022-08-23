using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayers.Concerete
{
    public class ImageFile
    {
        [Key]
        public int FileId { get; set; }
        [StringLength(50)]
        public string FileName { get; set; }
        [StringLength(250)]
        public string FilePath { get; set; }
    }
}
