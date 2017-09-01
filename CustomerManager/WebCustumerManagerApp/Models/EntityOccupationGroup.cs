using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebCustumerManagerApp.Models
{
    public class EntityOccupationGroup
    {
        [Key]
        public int OccupationGroupId { get; set; }

        [Display(Name ="Occupation")]
        public string OccupationGroupTitle { get; set; }

        public virtual ICollection<EntityCustomer> ListOfCustomers { get; set; }
    }
}