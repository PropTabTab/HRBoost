﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBoost.Entity
{
	public class Role : IdentityRole<Guid>
	{
        public Role() : base() { }
        public Role(string roleName) : base(roleName) { }
    }
}
