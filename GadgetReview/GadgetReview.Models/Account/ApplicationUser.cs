﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GadgetReview.Models.Account
{
    public class ApplicationUser
    {
        public int ApplicationUserId { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
