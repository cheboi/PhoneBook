using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Domain
{
    public class Contacts: BaseEntity
    {
        public int Id { get; set; }
        [Display(Name ="Name")]
        [Required (ErrorMessage ="{0} is required.")]
        public string Name { get; set; }
        [Display(Name ="Phone number")]
        [RegularExpression(@"^[\+]?[(]?[0 - 9]{3}[)]?[-\s\.]?[0 - 9]{3}[-\s\.]?[0 - 9]{ 4,6}$", ErrorMessage = "Please enter valid phone no.")]
        public string PhoneNumber { get; set; }
    }
}
