using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayers.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Conceret
{
    public class CommentManager:ICommnetService
    {
        ICommentDal commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            this.commentDal = commentDal;
        }

        public void CommentAdd(Comment comment)
        {
            commentDal.Add(comment);
        }

        public void CommentDelete(Comment comment)
        {
           commentDal.Delete(comment);
        }

        public void CommentUpdate(Comment comment)
        {
             commentDal.Update(comment);
        }

        public Comment GetCommentById(int id)
        {
            return commentDal.Get(x => x.CommentId == id);
        }

        public List<Comment> GetList()
        {
            return commentDal.List();
        }
    }
}
