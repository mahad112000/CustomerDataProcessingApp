using System.ComponentModel.DataAnnotations;

namespace CustomerDataProcessingApp.Web.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }

    }
}
