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
    public class TSBController : ApiController
    {
        #region TSB

        /// <summary>
        /// Gets all TSBs.
        /// </summary>
        /// <returns>Returns list of all TSBs.</returns>
        [HttpPost]
        [ActionName(RouteConsts.TSB.GetTSBs.Name)]
        public NDbResult<List<TSB>> GetTSBs()
        {
            var results = TSB.GetTSBs();
            return results;
        }
        /// <summary>
        /// Gets Current TSB.
        /// </summary>
        /// <returns>Returns Active TSB.</returns>
        [HttpPost]
        [ActionName(RouteConsts.TSB.GetCurrent.Name)]
        public NDbResult<TSB> GetCurrent()
        {
            var result = TSB.GetCurrent();
            return result;
        }
        /// <summary>
        /// Set Active TSB.
        /// </summary>
        /// <returns>Returns NDbResult instance.</returns>
        [HttpPost]
        [ActionName(RouteConsts.TSB.SetActive.Name)]
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
        /// <summary>
        /// Save TSB.
        /// </summary>
        /// <returns>Returns Save TSB.</returns>
        [HttpPost]
        [ActionName(RouteConsts.TSB.SaveTSB.Name)]
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

        #region PlazaGroup

        /// <summary>
        /// Gets TSB's Plaza Groups
        /// </summary>
        /// <param name="value">The target TSB instance.</param>
        /// <returns>Returns List of Plaza Groups of specificed TSB.</returns>
        [HttpPost]
        [ActionName(RouteConsts.TSB.GetTSBPlazaGroups.Name)]
        public NDbResult<List<PlazaGroup>> GetTSBPlazaGroups([FromBody] TSB value)
        {
            NDbResult<List<PlazaGroup>> result;
            if (null == value)
            {
                result = new NDbResult<List<PlazaGroup>>();
                result.ParameterIsNull();
            }
            else
            {
                result = PlazaGroup.GetTSBPlazaGroups(value);
            }
            return result;
        }
        /// <summary>
        /// Save PlazaGroup.
        /// </summary>
        /// <param name="value">The plaza group instance.</param>
        /// <returns>Returns Save plaza group instance.</returns>
        [HttpPost]
        [ActionName(RouteConsts.TSB.SavePlazaGroup.Name)]
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

        #region Plaza

        /// <summary>
        /// Gets PlazaGroup Plazas.
        /// </summary>
        /// <param name="value">The PlazaGroup instance.</param>
        /// <returns>Returns List of Plaza in specificed PlazaGroup.</returns>
        [HttpPost]
        [ActionName(RouteConsts.TSB.GetPlazaGroupPlazas.Name)]
        public NDbResult<List<Plaza>> GetPlazaGroupPlazas([FromBody] PlazaGroup value)
        {
            NDbResult<List<Plaza>> result;
            if (null == value)
            {
                result = new NDbResult<List<Plaza>>();
                result.ParameterIsNull();
            }
            else
            {
                result = Plaza.GetPlazaGroupPlazas(value);
            }
            return result;
        }
        /// <summary>
        /// Save Plaza.
        /// </summary>
        /// <param name="value">The Plaza Instance.</param>
        /// <returns>Returns save plaza instance.</returns>
        [HttpPost]
        [ActionName(RouteConsts.TSB.SavePlaza.Name)]
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

        #region Lane

        /// <summary>
        /// Gets PlazaGroup's Lanes.
        /// </summary>
        /// <param name="value">The PlazaGroup instance.</param>
        /// <returns>Returnsl Lane list in PlazaGroup.</returns>
        [HttpPost]
        [ActionName(RouteConsts.TSB.GetPlazaGroupLanes.Name)]
        public NDbResult<List<Lane>> GetPlazaGroupLanes([FromBody] PlazaGroup value)
        {
            NDbResult<List<Lane>> result;
            if (null == value)
            {
                result = new NDbResult<List<Lane>>();
                result.ParameterIsNull();
            }
            else
            {
                result = Lane.GetPlazaGroupLanes(value);

            }
            return result;
        }
        /// <summary>
        /// Gets Plaza's Lanes.
        /// </summary>
        /// <param name="value">The Plaza instance.</param>
        /// <returns>Returnsl Lane list in Plaza.</returns>
        [HttpPost]
        [ActionName(RouteConsts.TSB.GetPlazaLanes.Name)]
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
        /// <summary>
        /// Save Lane.
        /// </summary>
        /// <param name="value">The Lane Instance.</param>
        /// <returns>Returns save Lane instance.</returns>
        [HttpPost]
        [ActionName(RouteConsts.TSB.SaveLane.Name)]
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
    }
}
