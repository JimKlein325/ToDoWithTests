using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelBlog.Models
{
    [Table("Suggestions")]
    public class Suggestion
    {
        [Key]
        public int Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }


        public override bool Equals(System.Object otherSuggestion)
        {
            if (!(otherSuggestion is Suggestion))
            {
                return false;
            }
            else
            {
                Suggestion newSuggestion = (Suggestion)otherSuggestion;
                return this.Id.Equals(newSuggestion.Id);
            }
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
