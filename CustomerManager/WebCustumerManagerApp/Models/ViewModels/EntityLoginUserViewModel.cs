using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebCustumerManagerApp.Models.ViewModels
{
    public class EntityLoginUserViewModel
    {
        [StringLength(50)]
        [Display(Name = "Login")]
        [Required(ErrorMessage = "Inform your user name", AllowEmptyStrings = false)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Inform your password", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}