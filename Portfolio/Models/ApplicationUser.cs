﻿using System;
using Microsoft.AspNetCore.Identity;

namespace Portfolio.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string FullName { get; set; }
    }
}
