﻿using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Customer : BaseEntity
    {

        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(20)]
        [Phone]
        public string CustomerPhone { get; set; }

        [MaxLength(100)]
        [EmailAddress]

        public string CustomerEmail { get; set; }

        public Office Office { get; set; }

        public List<CustomerCase> CustomerCases { get; set; }
    }
}