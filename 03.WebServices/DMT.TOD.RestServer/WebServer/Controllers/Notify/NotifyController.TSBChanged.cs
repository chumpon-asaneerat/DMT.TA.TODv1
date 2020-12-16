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
        [ActionName(RouteConsts.Notify.TSBChanged.Name)]
        //[AllowAnonymous]
        public NDbResult TSBChanged()
        {
            NDbResult result = new NDbResult();
            result.Success();
            //TODO: Fixed TODNofifyService
            //TODNofifyService.Instance.RaiseTSBChanged();
            return result;
        }
    }
}
