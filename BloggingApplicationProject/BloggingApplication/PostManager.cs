using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BloggingApplication
{
    public class PostManager
    {   
       ApplicationContext _Db;
        public PostManager(ApplicationContext Db)
        {
            _Db = Db;
        }
        public void CreatePost(Post PostToBeAdded)
        {   
            // using var transaction = _Db.Database.BeginTransaction();
            try
            {
            Post PostInDb = _Db.Post.Where(p  => p.Title == PostToBeAdded.Title).FirstOrDefault()!;
                if (PostInDb == null)
                {
                    _Db.Post.Add(PostToBeAdded); 
                    _Db.SaveChanges();
                    // transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                // transaction.Rollback();
            }         
        }
        public List<Post> GetPosts()
        {   
            return _Db.Post.ToList();
        }
        public void UpdatePost(Post UpdateInfo)
        {   
            
            var QueryString = from post in _Db.Post where post.Title == UpdateInfo.Title select post;
            Post PostToBeUpdated = QueryString.First();

            if (PostToBeUpdated != null)
            {
                if (PostToBeUpdated.Title != null)
                {
                    PostToBeUpdated.Title = UpdateInfo.Title;
                }

                if (PostToBeUpdated.Content != null)
                {
                    PostToBeUpdated.Content = UpdateInfo.Content;
                }
                _Db.SaveChanges();
            } 

            else
            {
                Console.WriteLine("The entered post doesn't exist");
            }

        }
        public void DeletePost(string Title)
        {   
             var QueryString = from post in _Db.Post where post.Title == Title select post;
             Post PostToBeDeleted = QueryString.First();

             if (PostToBeDeleted != null)
            {
                _Db.Post.Remove(PostToBeDeleted);
                _Db.SaveChanges();
            }
            else
            {
                Console.WriteLine("The entered post doesn't exist");
            }
        }  

        public static void PrintPost(Post PostToBePrinted)
        {
            Console.WriteLine($"Title -------------------------------{PostToBePrinted.Title}");
            Console.WriteLine($"Content -------------------------------{PostToBePrinted.Content}");
            Console.WriteLine($"CreatedAt -------------------------------{PostToBePrinted.CreatedAt}");
        }
        public static void PrintComment(Comment CommentToBePrinted)
        {
            Console.WriteLine($"Text -------------------------------{CommentToBePrinted.Text}");
            Console.WriteLine($"CreatedAt -------------------------------{CommentToBePrinted.CreatedAt}");
        }
        public void DisplayPost(string Title) 
        {
             var QueryString = from post in _Db.Post where post.Title == Title select post;
             if(QueryString != null)
             {
                Post PostToBeDisplayed = QueryString.First();
                PrintPost(PostToBeDisplayed);
             }
            
            else
            {
                Console.WriteLine("No posts here");
            }
        }   

        public void DisplayPostDetail(string Title)
        {
            var QueryString = from post in _Db.Post where post.Title == Title select post;
            if(QueryString != null)
            {
                Post PostToBeDisplayed = QueryString.First();
                
                foreach(Comment comment in PostToBeDisplayed.ListOfComments)
                {
                    PrintComment(comment);
                }    
            }

        }
    }
}