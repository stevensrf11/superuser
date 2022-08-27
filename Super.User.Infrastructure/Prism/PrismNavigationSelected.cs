using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Super.User.Infrastructure.Prism
{
    ///  <summary>
    /// ListBox object
    /// Represent the ListBox Command object used fore executing a command
    /// against the ListBox Select event
    /// </summary>
    public class PrismNavigationSelected
    {
        #region Dependency Properties 
        /// <summary>
        /// CommandProperty Attached Dependency Property
        /// Represents the command parameter to be sent for a command to b
        /// </summary>
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.RegisterAttached("CommandParameter",
                typeof(object), typeof(PrismNavigationSelected),
                new PropertyMetadata(OnSetCommandParameterCallback));      
        
        /// <summary>
        /// SelectedCommandBehaviorProperty Attached Dependency Property
        /// Represents object the command is for
        /// </summary>
        private static readonly DependencyProperty SelectedCommandBehaviorProperty =      
            DependencyProperty.RegisterAttached("SelectedCommandBehavior",
          typeof(PrismNavigationCommandBehavior),
          typeof(PrismNavigationSelected), null);

        /// <summary>
        /// CommandProperty Attached Dependency Property
        /// Represents the command  to be executed
        /// </summary>
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.RegisterAttached("Command",
                typeof(ICommand),
                typeof(PrismNavigationSelected),
                new PropertyMetadata(OnSetCommandCallback));

        #endregion

        #region Property Accessors
        /// <summary>
        /// GetCommand Get Property Accessor
        ///  CommandProperty DP Get Accessor
        /// </summary>
        /// <param name="listBox">ListBox object</param>
        /// <returns>ICommand</returns>
        public static ICommand? GetCommand(ListBox listBox)
        {
            return listBox.GetValue(CommandProperty) as ICommand;
        }

        /// <summary>
        /// SetCommand Set Property Accessor
        ///  CommandProperty DP Set Accessor
        /// </summary>
        /// <param name="listBox">ListBox to set the command parameter on</param>
        /// <param name="command">Command</param>
        public static void SetCommand(ListBox listBox, ICommand command)
        {
            listBox.SetValue(CommandProperty, command);
        }

        /// <summary>
        /// GetCommandParameter Get Property Accessor
        ///  CommandParameterProperty DP Get Accessor
        /// </summary>
        /// <param name="menuItem">ListBox object</param>
        /// <returns>object</returns>
        public static object GetCommandParameter(ListBox listBox)
        {
            return listBox.GetValue(CommandParameterProperty);
        }
        /// <summary>
        /// SetCommandParameter Set Property Accessor
        ///  CommandProperty DP Set Accessor
        /// </summary>
        /// <param name="menuItem">ListBox to set the parameter on</param>
        /// <param name="command">Command parameter</param>
        public static void SetCommandParameter(ListBox listBox, object parameter)
        {
            listBox.SetValue(CommandParameterProperty, parameter);
        }
        #endregion


        #region Event Handlers

        /// <summary>
        /// OnSetCommandCallback event handler 
        /// CommandProperty's DP PropertyChanged event handler
        /// Called when the property is changed
        /// Used to wire up the Command to the ListBox
        /// </summary>
        /// <param name="dependencyObject">Object property is called on</param>
        /// <param name="e">Event argument information</param>
        private static void OnSetCommandCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            if (dependencyObject is ListBox listBox)
            {
                PrismNavigationCommandBehavior behavior = GetOrCreateBehavior(listBox);
                behavior.Command = e.NewValue as ICommand;
            }
        }



        /// <summary>
        /// OnSetCommandParameterCallback event handler 
        /// CommandProperty's DP PropertyChanged event handler
        /// Called when the property is changed
        /// Used to wire up the Command Parameter to the ListBox
        /// </summary>
        /// <param name="dependencyObject"></param>
        /// <param name="e"></param>
        private static void OnSetCommandParameterCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            if (dependencyObject is ListBox listBox)
            {
                PrismNavigationCommandBehavior behavior = GetOrCreateBehavior(listBox);
                behavior.CommandParameter = e.NewValue;
            }
        }
        #endregion

        #region Utility Method
        /// <summary>
        /// GetOrCreateBehavior method
        /// Used to create or use existing ListBox
        /// </summary>
        /// <param name="listBox">ListBox reference</param>
        /// <returns></returns>
        private static PrismNavigationCommandBehavior GetOrCreateBehavior(ListBox listBox)
        {
            if (listBox.GetValue(SelectedCommandBehaviorProperty) is not PrismNavigationCommandBehavior behavior)
            {
                behavior = new PrismNavigationCommandBehavior(listBox);
                listBox.SetValue(SelectedCommandBehaviorProperty, behavior);
            }

            return behavior;
        }
            #endregion
    }
}
