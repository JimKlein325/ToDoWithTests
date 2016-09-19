using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelBlog.Models;


namespace TravelBlog.Models
{
    public class EFSuggestionRepository : ISuggestionRepository
    {
        private TravelBlogDbContext db;

        public EFSuggestionRepository(TravelBlogDbContext connection = null)
        {
            if (connection == null)
            {
                this.db = new TravelBlogDbContext();
            }
            else
            {
                this.db = connection;
            }
        }
       
        public List<Suggestion> AllSuggestions
        {
            get
            {
                return db.Suggestions.ToList();
            }
        }

        

        public void DeleteSuggestions()
        {
            var l = AllSuggestions;
            db.Suggestions.RemoveRange(l);
            db.SaveChanges();
        }
        public void Add(Suggestion suggestion)
        {
            db.Add(suggestion);
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}