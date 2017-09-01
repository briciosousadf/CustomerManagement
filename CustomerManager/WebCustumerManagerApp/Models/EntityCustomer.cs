using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebCustumerManagerApp.Models
{
    public class EntityCustomer
    {
        [Key]
        public int CustomerId { get; set; }

        [Display(Name ="First Name")]
        public string CustomerFirstName { get; set; }

        [Display(Name = "Last Name")]
        public string CustomerLastName { get; set; }

        [ForeignKey("OccupationGroup")]
        [Column("OccupationGroup_OccupationGroupId")]
        public int OccupationGroupId { get; set; }

        public virtual EntityOccupationGroup OccupationGroup { get; set; }

    }
}