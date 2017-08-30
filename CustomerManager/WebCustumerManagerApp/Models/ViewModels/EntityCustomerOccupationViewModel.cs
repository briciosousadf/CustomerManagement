using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCustumerManagerApp.Models.ViewModels
{
    public class EntityCustomerOccupationViewModel
    {
        public EntityCustomer EntityCustomer { get; set; }
        public IEnumerable <EntityOccupationGroup> OccupationGroupList { get; set; }
    }
}