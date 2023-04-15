using System.ComponentModel.DataAnnotations;

namespace ApiMovieStoreDemo1_Net5.Models.Dtos.UserAuthDtos
{
    public class UserAuthLoginDto
    {
        [Required(ErrorMessage = "El usuario es requerido.")]
        public string UserAlias { get; set; }
        [Required(ErrorMessage = "El password es requerido")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "La contraseña debe estar entre 4 y 10 caracteres.")]
        public string Password { get; set; }
    }
}
