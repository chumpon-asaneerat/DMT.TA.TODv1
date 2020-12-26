﻿#region Using

using System;
using System.Web.Http;
using DMT.Models;

#endregion

namespace DMT.Services
{
    partial class NotifyController
    {
        [HttpPost]
        [ActionName(RouteConsts.TA.Notify.ShiftChanged.Name)]
        //[AllowAnonymous]
        public NDbResult ShiftChanged()
        {
            NDbResult result = new NDbResult();
            result.Success();
            TANotifyService.Instance.RaiseShiftChanged();
            return result;
        }
    }
}
