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
    /// The controller for manage users and roles.
    /// </summary>
    [Authorize]
    public class UserController : ApiController
    {
        #region Role

        #region GetRole

        /// <summary>
        /// Gets Role By Rold Id.
        /// </summary>
        /// <param name="value">The search instance.</param>
        /// <returns>Returns instance of Role.</returns>
        //[AllowAnonymous]
        [HttpPost]
        [ActionName(RouteConsts.User.GetRole.Name)]
        public NDbResult<Role> GetRole([FromBody] Search.Roles.ById value)
        {
            NDbResult<Role> result;
            if (null == value)
            {
                result = new NDbResult<Role>();
                result.ParameterIsNull();
            }
            else
            {
                result = Role.GetRole(value.RoleId);
            }
            return result;
        }

        #endregion

        #region GetRoles

        /// <summary>
        /// Gets Roles.
        /// </summary>
        /// <returns>Returns list of Role.</returns>
        //[AllowAnonymous]
        [HttpPost]
        [ActionName(RouteConsts.User.GetRoles.Name)]
        public NDbResult<List<Role>> GetRoles()
        {
            NDbResult<List<Role>> result = Role.GetRoles();
            return result;
        }

        #endregion

        #region SaveRole

        /// <summary>
        /// Save Role.
        /// </summary>
        /// <param name="value">The Role instance.</param>
        /// <returns>Returns save Role instance.</returns>
        [HttpPost]
        [ActionName(RouteConsts.User.SaveRole.Name)]
        public NDbResult<Role> SaveRole([FromBody] Role value)
        {
            NDbResult<Role> result;
            if (null == value)
            {
                result = new NDbResult<Role>();
                result.ParameterIsNull();
            }
            else
            {
                result = Role.Save(value);
            }
            return result;
        }

        #endregion

        #endregion

        #region User

        #region GetUsers

        /// <summary>
        /// Gets Users by Role.
        /// </summary>
        /// <param name="value">The Role instance.</param>
        /// <returns>Returns list of User that match specificed Role.</returns>
        [HttpPost]
        [ActionName(RouteConsts.User.GetUsers.Name)]
        public NDbResult<List<User>> GetUsers(Role value)
        {
            int status = 1; // active only
            NDbResult<List<User>> result;

            if (null == value)
            {
                result = new NDbResult<List<User>>();
                result.ParameterIsNull();
            }
            else
            {
                result = Models.User.FindByRole(value.RoleId, status);

            }
            return result;
        }

        #endregion

        #region GetById

        /// <summary>
        /// Seach User By User Id (partial match).
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName(RouteConsts.User.GetById.Name)]
        public NDbResult<User> GetById([FromBody] Search.Users.ById value)
        {
            NDbResult<User> result;
            if (null == value)
            {
                result = new NDbResult<User>();
                result.ParameterIsNull();
            }
            else
            {
                result = Models.User.GetUser(value.UserId);

            }
            return result;
        }

        #endregion

        #region SearchByGroupId

        /// <summary>
        /// Search User By Role Group Id.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName(RouteConsts.User.SearchByGroupId.Name)]
        public NDbResult<List<User>> SearchByGroupId([FromBody] Search.Users.ByGroupId value)
        {
            int status = 1; // active only
            NDbResult<List<User>> result;

            if (null == value)
            {
                result = new NDbResult<List<User>>();
                result.ParameterIsNull();
            }
            else
            {
                result = Models.User.FindByGroupId(value.GroupId, status);
            }
            return result;
        }

        #endregion

        #region SearchById

        /// <summary>
        /// Search User By User Id (exact match).
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Returns List of User that match specificed User.</returns>
        [HttpPost]
        [ActionName(RouteConsts.User.SearchById.Name)]
        public NDbResult<List<User>> SearchById([FromBody] Search.Users.ById value)
        {
            NDbResult<List<User>> result;
            if (null == value)
            {
                result = new NDbResult<List<User>>();
                result.ParameterIsNull();
            }
            else
            {
                result = Models.User.SearchById(value.UserId, value.Roles);

            }
            return result;
        }

        #endregion

        #region GetByCardId

        /// <summary>
        /// Search User By Card Id.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Returns match User instance.</returns>
        [HttpPost]
        [ActionName(RouteConsts.User.GetByCardId.Name)]
        public NDbResult<User> GetByCardId([FromBody] Search.Users.ByCardId value)
        {
            NDbResult<User> result;
            if (null == value)
            {
                result = new NDbResult<User>();
                result.ParameterIsNull();
            }
            else
            {
                result = Models.User.GetByCardId(value.CardId);
            }
            return result;
        }

        #endregion

        #region GetByLogIn

        /// <summary>
        /// Gets User by User Name and Password.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Returns match User instance.</returns>
        [HttpPost]
        [ActionName(RouteConsts.User.GetByLogIn.Name)]
        public NDbResult<User> GetByLogIn([FromBody] Search.Users.ByLogIn value)
        {
            NDbResult<User> result;
            if (null == value)
            {
                result = new NDbResult<User>();
                result.ParameterIsNull();
            }
            else
            {
                result = Models.User.GetByUserId(value.UserId, value.Password);
            }
            return result;
        }

        #endregion

        #region SaveUser

        /// <summary>
        /// Save User.
        /// </summary>
        /// <param name="value">The User Instance.</param>
        /// <returns>Returns Save User instance.</returns>
        [HttpPost]
        [ActionName(RouteConsts.User.SaveUser.Name)]
        public NDbResult<User> SaveUser([FromBody] User value)
        {
            NDbResult<User> result;
            if (null == value)
            {
                result = new NDbResult<User>();
                result.ParameterIsNull();
            }
            else
            {
                result = Models.User.SaveUser(value);
            }
            return result;
        }

        #endregion

        #endregion
    }
}
