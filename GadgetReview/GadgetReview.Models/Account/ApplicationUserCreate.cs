﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GadgetReview.Models.Account
{
    public class ApplicationUserCreate: ApplicationUserLogin
    {
        [MinLength(10, ErrorMessage = "Must be atleast 10-30 characters")]
        [MaxLength(30, ErrorMessage = "Must be atleast 10-30 characters")]
        public string Fullname { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [MaxLength(30, ErrorMessage = "Must be below 30 characters")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email{ get; set; }
    }
}
