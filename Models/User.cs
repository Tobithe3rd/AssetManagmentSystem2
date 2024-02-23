﻿using System.ComponentModel.DataAnnotations;

namespace AssetManagmentSystem2.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        public string Email  { get; set; }
        [Phone]
        public string PhoneNo {  get; set; }
    }
}
