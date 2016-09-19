using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelBlog.Models
{
    public interface ISuggestionRepository
    {
        List<Suggestion> AllSuggestions { get; }
    }

}
