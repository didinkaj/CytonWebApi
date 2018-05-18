using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CytonInterview.Models
{
    public class SystemUser: IdentityUser
    {
        public bool IsDriver { get; set; }

    }
}
