using System;
using System.ComponentModel.DataAnnotations;

namespace EntityDemo.Types
{
    public class Address
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(600)]
        public string StreetAddress { get; set; }

        [Required]
        [StringLength(150)]
        public string City { get; set; }

        [Required]
        [StringLength(60)]
        public string State { get; set; }

        [Required]
        public string ZipCode { get; set; }
    }
}
