using libraryAPI.Data;
using libraryAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace libraryAPI.BLL
{
    public class AuthorsBLL
    {
        internal void Insert(List<Authors> lstAuthors)
        {
            try
            {
                foreach (var author in lstAuthors)
                {
                    AuthorsDAL authorsDAL = new AuthorsDAL();
                    authorsDAL.Insert(author);
                }
            }
            catch (Exception ex) 
            {
                var err = ex.Message;
            }

        }

        internal List<Authors> Get()
        {
            List<Authors> authors = new List<Authors>();           
            try
            {
                AuthorsDAL authorsDAL = new AuthorsDAL();
                authors = authorsDAL.GetList();
               
            }
            catch (Exception ex) 
            {
                var err = ex.Message;
            }
            return authors;
        }

        internal Authors Get(int id)
        {
            Authors author = new Authors();
            AuthorsDAL authorsDAL = new AuthorsDAL();
            try
            {
                author = authorsDAL.GetById(id);
            }
            catch (Exception ex) 
            {
                var err = ex.Message;
            }
            return author;
        }
    }
}
