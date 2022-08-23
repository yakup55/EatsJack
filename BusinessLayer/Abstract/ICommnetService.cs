using EntityLayers.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommnetService
    {
        List<Comment> GetList();
        void CommentAdd(Comment comment);   
        void CommentDelete(Comment comment);
        void CommentUpdate(Comment comment);
        Comment GetCommentById(int id); 
    }
}
