using SmokeyLibrarian.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SmokeyLibrarian
{
    public static class DataLayer
    {
        public static bool AddBook(string title, string author)
        {
            using(var db = new BooksContext())
            {
                var sameBooks = from book in db.Books
                                where book.Author.Equals(author)&&book.Title.Equals(title)
                                select book;
                if (sameBooks.Any())
                    return false;
                db.Books.Add(new Book { Author = author, Title = title });
                db.SaveChanges();
                return true;
            }
        }

        public static int GetBookId(string title, string author)
        {
            using (var db = new BooksContext())
            {
                var IdToReturn = from book in db.Books
                                 where book.Author.Equals(author) && book.Title.Equals(title)
                                 select book.BookId;
                if (IdToReturn.Any())
                    return IdToReturn.FirstOrDefault();
                return -1;
            }
        }

        public static bool DeleteBook(int bookId)
        {
            using(var db=new BooksContext())
            {
                Book bookToDelete = db.Books.Find(bookId);
                if(bookToDelete != null)
                {
                    db.Books.Remove(bookToDelete);
                    if(db.Entry(bookToDelete).State != System.Data.Entity.EntityState.Deleted)
                    {
                        throw new Exception("Unable to delete record");
                    }
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public static bool AddUser(string username)
        {
            using (var db = new BooksContext())
            {
                foreach (var user in db.Users)
                {
                    if (user.Username.Equals(username))
                        return false;
                }
                var userWithSameUsername = from user in db.Users
                                           where user.Username.Equals(username)
                                           select user;
                if (userWithSameUsername.Any())
                    return false;
                db.Users.Add(new User { Username = username, DateOfCreation = DateTime.Now});
                db.SaveChanges();
                return true;
            }
        }

        public static int GetUserId(string username)
        {
            using (var db = new BooksContext())
            {
                var idToReturn = from user in db.Users
                                 where user.Username.Equals(username)
                                 select user.UserId;
                if (idToReturn.Any())
                    return idToReturn.FirstOrDefault();
                else return -1;
            }
        }

        public static List<User> GetAllUsers()
        {
            using (var db = new BooksContext())
            {
                IEnumerable<User> users = from user in db.Users select user;
                return users.ToList();
            }
            
        }

        public static bool DeleteUser(int userId)
        {
            using (var db = new BooksContext())
            {
                User userToDelete = db.Users.Find(userId);
                if (userToDelete != null)
                {
                    db.Users.Remove(userToDelete);
                    if (db.Entry(userToDelete).State != System.Data.Entity.EntityState.Deleted)
                    {
                        throw new Exception("Unable to delete record");
                    }
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public static void UpdateStatus(int userId, int bookId, ReadingStatus readingStatus)
        { 
            using(var db = new BooksContext())
            {
                var StatusInDb = from status in db.Statuses
                                   where status.Book.BookId == bookId && status.User.UserId == userId
                                   select status;
                if(StatusInDb.Any())
                    StatusInDb.FirstOrDefault().ReadingStatus = (int)readingStatus;
                else
                    db.Statuses.Add(new Status { BookId = bookId, UserId = userId, ReadingStatus =(int) readingStatus });
                db.SaveChanges();
            }
        }
    }
}
