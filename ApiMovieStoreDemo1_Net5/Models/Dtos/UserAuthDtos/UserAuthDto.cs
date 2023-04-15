using System;

namespace ApiMovieStoreDemo1_Net5.Models.Dtos.UserAuthDtos
{
    public class UserAuthDto
    {
        public int Id { get; set; }
        public string AliasUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
