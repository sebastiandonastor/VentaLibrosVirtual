using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Entities
{
    public class RegisterInfo
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El {0} tiene que tener por lo menos {6} caracteres de largo.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "La confirmacion de contrasena no son iguales.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El {0} tiene que tener por lo menos {3} caracteres de largo.", MinimumLength = 3)]
        [Display(Name = "Username")]

        public string Username { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El {0} tiene que tener por lo menos {3} caracteres de largo.", MinimumLength = 3)]
        [Display(Name = "Nombres")]

        public string Nombres { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El {0} tiene que tener por lo menos {3} caracteres de largo.", MinimumLength = 3)]
        [Display(Name = "Apellidos")]

        public string Apellidos { get; set; }


    }
}
