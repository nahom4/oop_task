using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BloggingApplication
{
    public class PostManager
    {
        readonly ApplicationContext _Db;
        public PostManager(ApplicationContext Db)
        {
            _Db = Db;
        }
        public async Task CreatePost(Post PostToBeAdded)
        {   
            try
            {
            Post PostInDb = _Db.Post.Where(p  => p.Title == PostToBeAdded.Title).FirstOrDefault()!;
                if (PostInDb == null)
                {
                    await _Db.Post.AddAsync(PostToBeAdded); 
                    await _Db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }         
        }
        public async Task<List<Post>> GetPosts()
        {   
            try
            {
                return await _Db.Post.ToListAsync();
            }

            catch
            {
                return new List<Post>();
            }
        }
        public async Task UpdatePost(Post UpdateInfo)
        {   
            
            try
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
                    await _Db.SaveChangesAsync();
                } 

                else
                {
                    Console.WriteLine("The entered post doesn't exist");
                }
            }

            catch
            {
                Console.WriteLine("Unable to Update Posts");
            }

        }
        public async Task DeletePost(int Id)
        {   

            try
            {
                var QueryString = from post in _Db.Post where post.PostId == Id select post;
                Post PostToBeDeleted = QueryString.First();

                if (PostToBeDeleted != null)
                {
                    _Db.Post.Remove(PostToBeDeleted);
                    await _Db.SaveChangesAsync();
                }
                else
                {
                    Console.WriteLine("The entered post doesn't exist");
                }
            }

            catch
            {
                Console.WriteLine("Unable to Delete Posts");
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
             
             try
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

             catch
             {
                Console.WriteLine("No Posts to Display");
             }
        }   

        public void DisplayPostDetail(string Title)
        {
            try
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

            catch
            {
                Console.WriteLine("Unable to display details");
            }

        }
    }
}