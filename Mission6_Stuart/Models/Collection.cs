using System.ComponentModel.DataAnnotations;

namespace Mission6_Stuart.Models
{
    public class Collection
    {
        [Key]
        public int MovieId { get; set; }  // Ensure this is correctly named as "MovieID"

        [Required(ErrorMessage = "Sorry, you need to enter a movie title")]
        public string Title { get; set; }

        public int? CategoryId { get; set; }  // Foreign key for Category

        public Category? Category { get; set; } // Navigation property for Category

        [Required(ErrorMessage = "Sorry, you need to enter a year.")]
        [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later.")]
        public int Year { get; set; } = 2000;

       
        public string? Director  { get; set; }

        
        public string? Rating { get; set; }

        public string? LentTo { get; set; }

        [Required]
        public bool Edited { get; set; }

        [MaxLength(25)]
        public string? Notes { get; set; }

        [Required]
        public bool CopiedToPlex { get; set; }
    }
}


//Do not allow a movie to be entered into the database unless has all these required
//fields
//(Title,
//Year
//, Edited
//, CopiedToPlex).
//The user should also not be allowed to enter a year lower than 1888 (the year the first movie came out.)