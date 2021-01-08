#region Using

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

#endregion

namespace DMT.Controls
{
    #region FocusOptions

    /// <summary>
    /// The Focus Options class.
    /// </summary>
    public class FocusOptions
    {
        #region SelectAll

        /// <summary>The SelectAllProperty variable</summary>
        public static readonly DependencyProperty SelectAllProperty = DependencyProperty.RegisterAttached(
            "SelectAll",
            typeof(bool),
            typeof(FocusOptions),
            new PropertyMetadata(false, SelectAllPropertyChanged));

        /// <summary>
        /// Gets SelectAll Value.
        /// </summary>
        /// <param name="obj">The target object.</param>
        /// <returns>Returns current proeprty value.</returns>
        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(TextBox))]
        [AttachedPropertyBrowsableForType(typeof(PasswordBox))]
        public static bool GetSelectAll(DependencyObject obj)
        {
            return (bool)obj.GetValue(SelectAllProperty);
        }
        /// <summary>
        /// Sets SelectAll Value.
        /// </summary>
        /// <param name="obj">The target object.</param>
        /// <param name="value">The new value.</param>
        public static void SetSelectAll(DependencyObject obj, bool value)
        {
            obj.SetValue(SelectAllProperty, value);
        }

        #endregion

        #region SelectAll Changed Handler

        private static void SelectAllPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (obj is TextBox || obj is PasswordBox)
            {
                if ((e.NewValue as bool?).GetValueOrDefault(false))
                {
                    HookEvents(obj as TextBox);
                    HookEvents(obj as PasswordBox);
                }
                else
                {
                    UnhookEvents(obj as TextBox);
                    UnhookEvents(obj as PasswordBox);
                }
            }
        }

        #region TextBox

        private static void HookEvents(TextBox ctrl) 
        {
            if (null == ctrl) return;
            ctrl.GotKeyboardFocus += OnGotKeyboardFocus;
            ctrl.PreviewMouseLeftButtonDown += OnPreviewMouseLeftButtonDown;
        }
        private static void UnhookEvents(TextBox ctrl) 
        {
            if (null == ctrl) return;
            ctrl.GotKeyboardFocus -= OnGotKeyboardFocus;
            ctrl.PreviewMouseLeftButtonDown -= OnPreviewMouseLeftButtonDown;
        }

        #endregion

        #region PasswordBox

        private static void HookEvents(PasswordBox ctrl) 
        {
            if (null == ctrl) return;
            ctrl.GotKeyboardFocus += OnGotKeyboardFocus;
            ctrl.PreviewMouseLeftButtonDown += OnPreviewMouseLeftButtonDown;
        }
        private static void UnhookEvents(PasswordBox ctrl) 
        {
            if (null == ctrl) return;
            ctrl.GotKeyboardFocus -= OnGotKeyboardFocus;
            ctrl.PreviewMouseLeftButtonDown -= OnPreviewMouseLeftButtonDown;
        }

        #endregion

        #endregion

        #region Control Event Handlers

        private static void OnGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (e.OriginalSource is TextBox || e.OriginalSource is PasswordBox)
            {
                KeyboardFocusSelectText(e.OriginalSource as TextBox, e);
                KeyboardFocusSelectText(e.OriginalSource as PasswordBox, e);
            }
        }

        private static void OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is TextBox || e.OriginalSource is PasswordBox)
            {
                MouseLeftButtonDownFocus(e.OriginalSource as TextBox, e);
                MouseLeftButtonDownFocus(e.OriginalSource as PasswordBox, e);
            }
        }

        #region TextBox

        private static void KeyboardFocusSelectText(TextBox ctrl, KeyboardFocusChangedEventArgs e)
        {
            if (null != ctrl && ctrl.IsKeyboardFocusWithin)
            {
                ctrl.Dispatcher.BeginInvoke(new Action(() =>
                {
                    ctrl.SelectAll();
                }));
            }
        }

        private static void MouseLeftButtonDownFocus(TextBox ctrl, MouseButtonEventArgs e)
        {
            if (ctrl == null) return;
            if (!ctrl.IsFocused)
            {
                ctrl.Dispatcher.BeginInvoke(new Action(() =>
                {
                    ctrl.Focus();
                    ctrl.ReleaseMouseCapture();
                }));
                e.Handled = true;
            }
        }

        #endregion

        #region PasswordBox

        private static void KeyboardFocusSelectText(PasswordBox ctrl, KeyboardFocusChangedEventArgs e)
        {
            if (null != ctrl && ctrl.IsKeyboardFocusWithin)
            {
                ctrl.Dispatcher.BeginInvoke(new Action(() =>
                {
                    ctrl.SelectAll();
                }));
            }
        }

        private static void MouseLeftButtonDownFocus(PasswordBox ctrl, MouseButtonEventArgs e)
        {
            if (null == ctrl) return;
            if (!ctrl.IsFocused)
            {
                ctrl.Dispatcher.BeginInvoke(new Action(() =>
                {
                    ctrl.Focus();
                    ctrl.ReleaseMouseCapture();
                }));
                e.Handled = true;
            }
        }

        #endregion

        #endregion
    }

    #endregion

    #region KeyboardOptions

    /// <summary>
    /// The Keyboard Options class.
    /// </summary>
    public class KeyboardOptions
    {
        #region Enter As Tab

        #region Public Dependency Properties and methods

        /// <summary>The EnterAsTabProperty variable</summary>
        public static readonly DependencyProperty EnterAsTabProperty = DependencyProperty.RegisterAttached(
            "EnterAsTab",
            typeof(bool),
            typeof(KeyboardOptions),
            new UIPropertyMetadata(false, EnterAsTabChanged));
        /// <summary>
        /// Gets EnterAsTab Value.
        /// </summary>
        /// <param name="obj">The target object.</param>
        /// <returns>Returns current proeprty value.</returns>
        [AttachedPropertyBrowsableForType(typeof(TextBox))]
        [AttachedPropertyBrowsableForType(typeof(PasswordBox))]
        public static bool GetEnterAsTab(DependencyObject obj)
        {
            return (bool)obj.GetValue(EnterAsTabProperty);
        }
        /// <summary>
        /// Sets EnterAsTab Value.
        /// </summary>
        /// <param name="obj">The target object.</param>
        /// <param name="value">The new value.</param>
        public static void SetEnterAsTab(DependencyObject obj, bool value)
        {
            obj.SetValue(EnterAsTabProperty, value);
        }

        #endregion

        #region EnterAsTab Changed Handler

        private static void EnterAsTabChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var ue = obj as FrameworkElement;

            if (!(ue is TextBox || ue is PasswordBox)) return; // only TextBox, PasswordBox
            if ((ue as TextBox).AcceptsReturn) return; // TextBox has AcceptsReturn property = true so ignore it. 

            if (ue == null) return;

            if ((bool)e.NewValue)
            {
                ue.Unloaded += ue_Unloaded;
                ue.PreviewKeyDown += ue_PreviewKeyDown;
            }
            else
            {
                ue.PreviewKeyDown -= ue_PreviewKeyDown;
            }
        }

        #endregion

        #region Control Event Handlers

        private static void ue_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var ue = e.OriginalSource as FrameworkElement;

            if (e.Key == Key.Enter)
            {
                if (ue is TextBox || ue is PasswordBox)
                {
                    e.Handled = true;
                    if (!ue.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next)))
                    {
                        //ue.MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
                    }
                }
            }
        }

        private static void ue_Unloaded(object sender, RoutedEventArgs e)
        {
            var ue = sender as FrameworkElement;
            if (ue == null) return;

            ue.Unloaded -= ue_Unloaded;
            ue.PreviewKeyDown -= ue_PreviewKeyDown;
        }

        #endregion

        #endregion
    }

    #endregion
}
