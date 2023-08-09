using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingApplication
{
    public class CommentManager
    {
        ApplicationContext _Db;
        public CommentManager(ApplicationContext Db)
        {
            _Db = Db;
        }
        public void CreateComment(Comment CommentToBeAdded)
        {   
            using var transaction = _Db.Database.BeginTransaction();    
            try
            {
                _Db.Comment.Add(CommentToBeAdded); 
                _Db.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                
            }         
        }
        public List<Comment> GetComments()
        {   
            return _Db.Comment.ToList();
        }
        public void UpdateComment(Comment UpdateInfo)
        {   
            var QueryString = from Comment in _Db.Comment where Comment.CommentId == UpdateInfo.CommentId 
            select Comment;
            Comment CommentToBeUpdated = QueryString.First();

            if (CommentToBeUpdated != null)
            {
                if (CommentToBeUpdated.Text != null)
                {
                    CommentToBeUpdated.Text = UpdateInfo.Text;
                }
                _Db.SaveChanges();
            }

            else 
            {
                Console.WriteLine("No such Post Exists");   
            }             
        }
        public void DeleteComment(int Id)
        {   
             var QueryString = from comment in _Db.Comment where comment.CommentId == Id select comment;
             Comment CommentToBeDeleted = QueryString.First();

             if (CommentToBeDeleted != null)
             {
                _Db.Comment.Remove(CommentToBeDeleted);
                _Db.SaveChanges();
             }

             else
             {
                Console.WriteLine("No such Post Exists");
             }


        }
    }
}