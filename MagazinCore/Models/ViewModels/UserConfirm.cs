using System.ComponentModel.DataAnnotations;

namespace MagazinCore.Models.ViewModels
{
    public class UserConfirm : Utilizatori
    {
        [Required(ErrorMessage = "Parolele nu corespund!")]
        //[StringLength(4, ErrorMessage ="Prea lung!", MinimumLength =3)]
        //[Compare("Parola")]
        public int ConfirmPassword { get; set; }
    }
}
