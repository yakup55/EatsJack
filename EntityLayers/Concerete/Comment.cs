    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayers.Concerete
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [StringLength(50)]
        public string CommentName { get; set; }
        [StringLength(100)]
        public string CommentMail { get; set; }
        [StringLength(500)]
        public string CommentMessage { get; set; }
        public bool CommentStatus { get; set; }

        public int EatsId { get; set; }
        public virtual Eats Eats { get; set; }
    }
}
