namespace WebCustumerManagerApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Security.Cryptography;


    public partial class EntityLoginUser
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Display(Name ="Login")]
        [Required(ErrorMessage ="Inform your user name", AllowEmptyStrings =false)]
        public string Username { get; set; }

        [Required(ErrorMessage ="Inform your password", AllowEmptyStrings =false)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string VCodePassword { get; set; }

        public DateTime RegDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }
                
    }

    
}
