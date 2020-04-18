using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App1.Models
{
    public class UserViewModel : IValidatableObject
    {
        [Display(Name = "Sıra No")]
        public int Id { get; set; }

        [Display(Name = "Adı")]
        [Required(ErrorMessage = "İsim alanı zorunludur.")]
        [StringLength(25, ErrorMessage = "Maksimum 25 karakter olmalıdır.")]
        public string Name { get; set; }
        [Display(Name = "Soyadı")]
        public string Surname { get; set; }

        [Display(Name = "Github hesabı")]
        [Url(ErrorMessage = "Url formatı hatalıdır.")]
        [Required]
        public string GithubAccountUrl { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Email formatı hatalı.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız.")]
        [Display(Name = "Doğum Tarihi")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Cinsiyet bilgisi seçiniz.")]
        [Display(Name = "Cinsiyet")]
        public string Gender { get; set; }

        public IEnumerable<SelectListItem> GenderSelectList { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //gender bilgisinin kontrolü ("Female", "Male")
            if (Gender != "Female" && Gender != "Male")
            {
                yield return new ValidationResult("Cinsiyet Tercihi Yapınız.", new[] { nameof(Gender) });
            }

            //18 yaşından küçükleri kullanıcı olarak eklememe
            if (BirthDate > DateTime.Now.AddYears(-18))
            {
                yield return new ValidationResult("Yaşınız 18'den Büyük Olmalıdır.", new[] { nameof(BirthDate) });
            }
        }
    }
}
