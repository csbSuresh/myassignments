using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Notification.API.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [RegularExpression("^((?!00000000-0000-0000-0000-000000000000).)*$", ErrorMessage = "Cannot use default Guid")]
        public Guid EntityId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [MaxLength(10, ErrorMessage = "Only 10 charectors are allowed")]
        [RegularExpression(@"^[0-9&-]+$", ErrorMessage = "Only number and symbols -,& are allowed")]
        public string Number { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Market { get; set; }
        public DateTime Created { get; set; }
    }
}