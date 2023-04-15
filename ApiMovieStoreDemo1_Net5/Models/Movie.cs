using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiMovieStoreDemo1_Net5.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string PathImage { get; set; }
        public string Description { get; set; }
        public string MovieLength { get; set; }
        public enum ClasificationType { siete, Trece, Dieciseis, Dieciocho }
        public ClasificationType Clasification { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category MovieCategory { get; set; }
    }
}
