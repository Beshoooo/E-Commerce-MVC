﻿using Microsoft.AspNetCore.Identity;

namespace Final_Project.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string? Address { get; set; }
    }
}
