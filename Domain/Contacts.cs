using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Domain
{
    public class Contacts: BaseEntity
    {
        [Display(Name ="Name")]
        [Required (ErrorMessage ="{0} is required.")]
        public string Name { get; set; }
        [Key]
        [Display(Name ="Phone number")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone no.")]
        public int PhoneNumber { get; set; }
    }
}
