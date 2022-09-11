using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Book Title is mandatory")]
        public string Title { get; set; }
        [MinLength(length:5,ErrorMessage ="Description must be at least 5 characters long")]
        public string Description { get; set; }
    }
}
