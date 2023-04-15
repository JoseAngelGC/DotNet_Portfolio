using System;
using System.ComponentModel.DataAnnotations;

namespace ApiMovieStoreDemo1_Net5.Models.Dtos.CategoryDtos
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
