using LibApp_Gr3.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibApp_Gr3.ViewModels
{
    public class CustomerFormViewModel
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Please provide customer's name")]
        [StringLength(255)]
        public string Name { get; set; }
        public bool HasNewsletterSubscribed { get; set; }
        [Required(ErrorMessage = "Please select Membership Type")]
        [Display(Name = "Membership Type")]
        public byte? MembershipTypeId { get; set; }
        [Display(Name = "Date of Birth")]
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Customer" : "New Cusomter";
            }
        }

        public CustomerFormViewModel()
        {
            Id = 0;
        }

        public CustomerFormViewModel(Customer customer)
        {
            Id = customer.Id;
            Name = customer.Name;
            MembershipTypeId = customer.MembershipTypeId;
            HasNewsletterSubscribed = customer.HasNewsletterSubscribed;
        }
    }
}
