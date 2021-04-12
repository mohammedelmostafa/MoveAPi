using MoviesAPI.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Entites
{
    public class Genre
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="The field name {0} is required")]
        [StringLength(50)]
        [FirstLetterUppercase]
        public string Name { get; set; }


        //For model validation custmize
        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //   if (!string.IsNullOrEmpty(Name))
        //    {
        //        var firstLetter = Name[0].ToString();
        //        if (firstLetter != firstLetter.ToUpper())
        //        {
        //            yield return new ValidationResult("First letter should be uppercase");
        //        }
        //    }
        //}
    }
}
