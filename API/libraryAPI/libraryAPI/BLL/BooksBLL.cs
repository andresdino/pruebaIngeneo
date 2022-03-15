using libraryAPI.Data;
using libraryAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace libraryAPI.BLL
{
    public class BooksBLL
    {

        internal void Insert(List<Books> lstBooks)
        {
            try
            {
                foreach (var book in lstBooks)
                {
                    BooksDAL booksDAL = new BooksDAL();
                    booksDAL.Insert(book);
                }
            }
            catch (Exception ex)
            {
                var err = ex.Message;
            }
        }

        internal List<Books> Get()
        {
            List<Books> books = new List<Books>();
            try
            {
                BooksDAL booksDAL = new BooksDAL();
                books = booksDAL.GetList();
            }
            catch (Exception ex)
            {
                var err = ex.Message;
            }
            return books;
        }

        internal Books Get(int id)
        {
            Books book = new Books();
            BooksDAL booksDAL = new BooksDAL();
            try
            {
                book = booksDAL.GetById(id);
            }
            catch (Exception ex)
            {
                var err = ex.Message;
            }
            return book;
        }
    }
}
