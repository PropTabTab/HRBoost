﻿using HRBoost.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace HRBoost.Services.Abstracts
{
    public interface IPermissionRequestService : IService<PermissionRequest>
    {
        Task<bool> ApproveRequest(PermissionRequest request);
        Task<bool> RejectRequest(PermissionRequest request);
    }
}
