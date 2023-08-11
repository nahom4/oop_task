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
        public async Task UpdatePost(Post PostToBeUpdated,Post UpdateInfo)
        {   
            
            try{
            
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

            catch
            {
                Console.WriteLine("Unable to Update Posts");
            }

        }
        public async Task DeletePost(Post PostToBeDeleted)
        {   

            try
            {
                _Db.Post.Remove(PostToBeDeleted);
                await _Db.SaveChangesAsync();
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
        public void DisplayPost(Post PostToBeDisplayed) 
        {
             PrintPost(PostToBeDisplayed);
        }   

        public void DisplayPostDetail(Post PostToBeDisplayed)
        {
            try
            {   Console.WriteLine("gets here");
                foreach(Comment comment in PostToBeDisplayed.ListOfComments)
                {
                    PrintComment(comment);
                }       
            }

            catch
            {
                Console.WriteLine("Unable to display details");
            }

        }

         public async Task<Post>? DataPointExists(int Id)
        {
            return await _Db.Post.FirstOrDefaultAsync(x => x.PostId == Id);
        }
    }
}