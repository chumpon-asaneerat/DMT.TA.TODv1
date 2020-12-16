#region Using

using System;
using System.Web.Http;
using DMT.Models;

#endregion

namespace DMT.Services
{
    partial class NotifyController
    {
        [HttpPost]
        [ActionName(RouteConsts.Notify.ShiftChanged.Name)]
        //[AllowAnonymous]
        public NDbResult ShiftChanged()
        {
            NDbResult result = new NDbResult();
            result.Success();
            TANofifyService.Instance.RaiseShiftChanged();
            return result;
        }
    }
}
