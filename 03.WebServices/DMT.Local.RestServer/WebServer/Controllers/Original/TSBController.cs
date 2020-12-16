#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using DMT.Models;
//using DMT.Models.ExtensionMethods;

#endregion

namespace DMT.Services
{
    /// <summary>
    /// The controller for manage common data on TSB, Plaza and Lane.
    /// </summary>
    [Authorize]
    public class TSBController : ApiController
    {
        #region TSB

        #region GetTSBs

        /// <summary>
        /// Gets all TSBs.
        /// </summary>
        /// <returns>Returns list of all TSBs.</returns>
        //[AllowAnonymous]
        [HttpPost]
        [ActionName(RouteConsts.TSB.TSBs.GetTSBs.Name)]
        public NDbResult<List<TSB>> GetTSBs()
        {
            var results = TSB.GetTSBs();
            return results;
        }

        #endregion

        #region GetCurrent

        /// <summary>
        /// Gets Current TSB.
        /// </summary>
        /// <returns>Returns Active TSB.</returns>
        //[AllowAnonymous]
        [HttpPost]
        [ActionName(RouteConsts.TSB.TSBs.GetCurrent.Name)]
        public NDbResult<TSB> GetCurrent()
        {
            var result = TSB.GetCurrent();
            return result;
        }

        #endregion

        #region SetActive

        /// <summary>
        /// Set Active TSB.
        /// </summary>
        /// <returns>Returns NDbResult instance.</returns>
        //[AllowAnonymous]
        [HttpPost]
        [ActionName(RouteConsts.TSB.TSBs.SetActive.Name)]
        public NDbResult SetActive([FromBody] TSB value)
        {
            NDbResult result;
            if (null == value)
            {
                result = new NDbResult();
                result.ParameterIsNull();
            }
            else
            {
                result = TSB.SetActive(value.TSBId);
                //TODO: Refactor
                // Raise event.
                //LocalDbServer.Instance.ActiveTSBChanged();
            }
            return result;
        }

        #endregion

        #region SaveTSB

        /// <summary>
        /// Save TSB.
        /// </summary>
        /// <returns>Returns Save TSB.</returns>
        //[AllowAnonymous]
        [HttpPost]
        [ActionName(RouteConsts.TSB.TSBs.SaveTSB.Name)]
        public NDbResult<TSB> SaveTSB([FromBody] TSB value)
        {
            NDbResult<TSB> result;
            if (null == value)
            {
                result = new NDbResult<TSB>();
                result.ParameterIsNull();
            }
            else
            {
                result = TSB.Save(value);
            }
            return result;
        }

        #endregion

        #endregion

        #region PlazaGroup

        #region SearchByTSB

        /// <summary>
        /// Search PlazaGroup(s) by TSB.
        /// </summary>
        /// <param name="value">The target TSB instance.</param>
        /// <returns>Returns List of Plaza Groups of specificed TSB.</returns>
        [HttpPost]
        [ActionName(RouteConsts.TSB.PlazaGroups.Search.ByTSB.Name)]
        public NDbResult<List<PlazaGroup>> SearchPlazaGroupByTSB([FromBody] TSB value)
        {
            NDbResult<List<PlazaGroup>> result;
            if (null == value)
            {
                result = new NDbResult<List<PlazaGroup>>();
                result.ParameterIsNull();
            }
            else
            {
                result = PlazaGroup.SearchByTSB(value);
            }
            return result;
        }

        #endregion

        #region SavePlazaGroup

        /// <summary>
        /// Save PlazaGroup.
        /// </summary>
        /// <param name="value">The plaza group instance.</param>
        /// <returns>Returns Save plaza group instance.</returns>
        [HttpPost]
        [ActionName(RouteConsts.TSB.PlazaGroups.SavePlazaGroup.Name)]
        public NDbResult<PlazaGroup> SavePlazaGroup([FromBody] PlazaGroup value)
        {
            NDbResult<PlazaGroup> result;
            if (null == value)
            {
                result = new NDbResult<PlazaGroup>();
                result.ParameterIsNull();
            }
            else
            {
                result = PlazaGroup.Save(value);
            }
            return result;
        }

        #endregion

        #endregion

        #region Plaza

        #region SearchPlazaByPlazaGroup

        /// <summary>
        /// Search Plaza(s) By PlazaGroup.
        /// </summary>
        /// <param name="value">The PlazaGroup instance.</param>
        /// <returns>Returns List of Plaza in specificed PlazaGroup.</returns>
        [HttpPost]
        [ActionName(RouteConsts.TSB.Plazas.Search.ByPlazaGroup.Name)]
        public NDbResult<List<Plaza>> SearchPlazaByPlazaGroup([FromBody] PlazaGroup value)
        {
            NDbResult<List<Plaza>> result;
            if (null == value)
            {
                result = new NDbResult<List<Plaza>>();
                result.ParameterIsNull();
            }
            else
            {
                result = Plaza.SearchByPlazaGroup(value);
            }
            return result;
        }

        #endregion

        #region SavePlaza

        /// <summary>
        /// Save Plaza.
        /// </summary>
        /// <param name="value">The Plaza Instance.</param>
        /// <returns>Returns save plaza instance.</returns>
        [HttpPost]
        [ActionName(RouteConsts.TSB.Plazas.SavePlaza.Name)]
        public NDbResult<Plaza> SavePlaza([FromBody] Plaza value)
        {
            NDbResult<Plaza> result;
            if (null == value)
            {
                result = new NDbResult<Plaza>();
                result.ParameterIsNull();
            }
            else
            {
                result = Plaza.Save(value);
            }
            return result;
        }

        #endregion

        #endregion

        #region Lane

        #region SearchLaneByPlazaGroup

        /// <summary>
        /// Search Lane(s) By PlazaGroup.
        /// </summary>
        /// <param name="value">The PlazaGroup instance.</param>
        /// <returns>Returnsl Lane list in PlazaGroup.</returns>
        [HttpPost]
        [ActionName(RouteConsts.TSB.Lanes.Search.ByPlazaGroup.Name)]
        public NDbResult<List<Lane>> SearchLaneByPlazaGroup([FromBody] PlazaGroup value)
        {
            NDbResult<List<Lane>> result;
            if (null == value)
            {
                result = new NDbResult<List<Lane>>();
                result.ParameterIsNull();
            }
            else
            {
                result = Lane.SearchByPlazaGroup(value);

            }
            return result;
        }

        #endregion

        #region GetPlazaLanes - Comment out
        /*
        /// <summary>
        /// Gets Plaza's Lanes.
        /// </summary>
        /// <param name="value">The Plaza instance.</param>
        /// <returns>Returnsl Lane list in Plaza.</returns>
        [HttpPost]
        [ActionName(RouteConsts.TSB.Lanes.GetPlazaLanes.Name)]
        public NDbResult<List<Lane>> GetPlazaLanes([FromBody] Plaza value)
        {
            NDbResult<List<Lane>> result;
            if (null == value)
            {
                result = new NDbResult<List<Lane>>();
                result.ParameterIsNull();
            }
            else
            {
                result = Lane.GetPlazaLanes(value);
            }
            return result;
        }
        */
        #endregion

        #region SaveLane

        /// <summary>
        /// Save Lane.
        /// </summary>
        /// <param name="value">The Lane Instance.</param>
        /// <returns>Returns save Lane instance.</returns>
        [HttpPost]
        [ActionName(RouteConsts.TSB.Lanes.SaveLane.Name)]
        public NDbResult<Lane> SaveLane([FromBody] Lane value)
        {
            NDbResult<Lane> result;
            if (null == value)
            {
                result = new NDbResult<Lane>();
                result.ParameterIsNull();
            }
            else
            {
                result = Lane.Save(value);
            }
            return result;
        }

        #endregion

        #endregion
    }
}
