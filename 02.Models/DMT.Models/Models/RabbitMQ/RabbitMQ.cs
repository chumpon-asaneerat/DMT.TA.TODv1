﻿#region Using

using System;
using System.Collections.Generic;

#endregion

namespace DMT.Models
{
    #region RabbitMQMessage

    /// <summary>
    /// The Common Rabbit MQ Message
    /// </summary>
    public class RabbitMQMessage
    {
        /// <summary>
        /// Gets or sets Parameter Name.
        /// </summary>
        public string parameterName { get; set; }
        /// <summary>
        /// Gets or sets TimeStamp.
        /// </summary>
        public DateTime? timestamp { get; set; }
        /// <summary>
        /// Gets or sets version.
        /// </summary>
        public int? version { get; set; }
    }

    #endregion

    #region RabbitMQMessage with Staff

    /// <summary>
    /// The RabbitMQStaff class.
    /// </summary>
    public class RabbitMQStaff
    {
        /// <summary>
        /// Gets or sets Staff Id.
        /// </summary>
        public string staffId { get; set; }
        /// <summary>
        /// Gets or sets Staff Family Name.
        /// </summary>
        public string staffFamilyName { get; set; }
        /// <summary>
        /// Gets or sets Staff First Name.
        /// </summary>
        public string staffFirstName { get; set; }
        /// <summary>
        /// Gets or sets Staff Middle Name.
        /// </summary>
        public string staffMiddleName { get; set; }
        /// <summary>
        /// Gets or sets Staff Title.
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// Gets or sets Password.
        /// </summary>
        public string password { get; set; }
        /// <summary>
        /// Gets or sets Group.
        /// </summary>
        public int group { get; set; }
        /// <summary>
        /// Gets or sets Card S/N.
        /// </summary>
        public string cardSerialNo { get; set; }
        /// <summary>
        /// Gets or sets password update datetime.
        /// </summary>
        public DateTime passwordUpdateDatetime { get; set; }
        /// <summary>
        /// Gets or sets status.
        /// </summary>
        public string status { get; set; }

        // TODO: Requird User Model class.
        /*
        public static User ToLocal(RabbitMQStaff value)
        {
            if (null == value) return null;
            User ret = new User();

            ret.UserId = value.staffId;
            ret.PrefixEN = value.title;
            ret.FirstNameEN = value.staffFirstName;
            ret.MiddleNameEN = value.staffMiddleName;
            ret.LastNameEN = value.staffFamilyName;
            ret.PrefixTH = value.title;
            ret.FirstNameTH = value.staffFirstName;
            ret.MiddleNameEN = value.staffMiddleName;
            ret.LastNameTH = value.staffFamilyName;
            ret.Password = value.password;
            ret.CardId = value.cardSerialNo;
            ret.GroupId = value.group;

            return ret;
        }

        public static List<User> ToLocals(List<RabbitMQStaff> values)
        {
            List<User> rets = new List<User>();
            var roles = Role.GetRoles().Value();
            if (null != values && values.Count > 0)
            {
                values.ForEach(c =>
                {
                    User inst = ToLocal(c);

                    if (null != roles)
                    {
                        var role = roles.Find(x => x.GroupId == inst.GroupId);
                        if (null != role)
                        {
                            inst.RoleId = role.RoleId;
                        }
                        else
                        {
                            Console.WriteLine("Not Found Group: " + inst.GroupId);
                        }
                    }

                    if (null != inst) rets.Add(inst);
                });
            }
            return rets;
        }
        */
    }

    /// <summary>
    /// The RabbitMQStaffMessage class.
    /// </summary>
    public class RabbitMQStaffMessage : RabbitMQMessage
    {
        /// <summary>
        /// Gets or sets staff list.
        /// </summary>
        public List<RabbitMQStaff> staff { get; set; }
    }


    #endregion
}
