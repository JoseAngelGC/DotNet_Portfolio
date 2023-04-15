using System;
using System.ComponentModel.DataAnnotations;

namespace ApiMovieStoreDemo1_Net5.Models
{
    public class UserAuth
    {
        [Key]
        public int Id { get; set; }
        public string AliasUser { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
