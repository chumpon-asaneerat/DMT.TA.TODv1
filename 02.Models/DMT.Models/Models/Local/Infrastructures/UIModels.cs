#region Using

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

// Required for custom command in UI
using System.Windows.Input;

using NLib;
using NLib.Design;
using NLib.Reflection;

using SQLite;
using SQLiteNetExtensions.Attributes;
using SQLiteNetExtensions.Extensions;
// required for JsonIgnore attribute.
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System.Reflection;

#endregion

namespace DMT.Models
{
    #region UI Models for Infrastructure Tree

    #region TSBItem

    /// <summary>
    /// The TSBItem model class.
    /// </summary>
    public class TSBItem : TSB
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        private TSBItem() : base()
        {
            Plazas = new ObservableCollection<PlazaItem>();
        }
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="value">The TSB instance.</param>
        public TSBItem(TSB value) : this() 
        {
            if (null != value) value.AssignTo(this);
        }

        /// <summary>Gets Is Active in string.</summary>
        [Browsable(false)]
        public string IsActive { get { return (Active) ? "[A]" : string.Empty; } set { } }
        /// <summary>Gets Plazas</summary>
        [Browsable(false)]
        public ObservableCollection<PlazaItem> Plazas { get; set; }

        /// <summary>
        /// Route Command for Change Active TSB.
        /// </summary>
        public static readonly RoutedUICommand ChangeActiveTSB = new RoutedUICommand(
            "ChangeActiveTSB",
            "ChangeActiveTSB",
            typeof(TSBItem),
            new InputGestureCollection() 
            { 
                //new KeyGesture(Key.F4, ModifierKeys.Alt) 
            });
    }

    #endregion

    #region PlazaItem

    /// <summary>
    /// The PlazaItem model class.
    /// </summary>
    public class PlazaItem : Plaza
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        private PlazaItem()
        {
            Lanes = new ObservableCollection<LaneItem>();
        }
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="value">The Plaza instance.</param>
        public PlazaItem(Plaza value) : this()
        {
            if (null != value) value.AssignTo(this);
        }
        /// <summary>Gets Lanes</summary>
        [Browsable(false)]
        public ObservableCollection<LaneItem> Lanes { get; set; }
    }

    #endregion

    #region LaneItem

    /// <summary>
    /// The LaneItem model class.
    /// </summary>
    //[Browsable(false)]
    public class LaneItem : Lane 
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        private LaneItem() : base() { }
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="value">The Lane instance.</param>
        public LaneItem(Lane value) : this()
        {
            if (null != value) value.AssignTo(this);
        }
    }

    #endregion

    #endregion
}
