using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelBlog.Models
{
    public interface ISuggestionRepository
    {
        List<Suggestion> AllSuggestions { get; }
        void Add(Suggestion suggestion);
        Suggestion Find(int id);
        void Delete(int id);
        void Edit(Suggestion suggestion);
    }

}
