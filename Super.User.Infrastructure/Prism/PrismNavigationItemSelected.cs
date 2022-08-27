using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Super.User.Infrastructure.Prism
{
    ///  <summary>
    /// PrismNavigationItemSelected object
    /// Represent the AccordionItemSelected Command object used fore executing a command
    /// against the AccordionItem Select event
    /// </summary>
    public class PrismNavigationItemSelected
    {
        #region Dependency Properties 
        /// <summary>
        /// CommandProperty Attached Dependency Property
        /// Represents the command parameter to be sent for a command to b
        /// </summary>
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.RegisterAttached("CommandParameter",
                typeof(object), typeof(PrismNavigationItemSelected),
                new PropertyMetadata(OnSetCommandParameterCallback));      
        
        /// <summary>
        /// SelectedCommandBehaviorProperty Attached Dependency Property
        /// Represents object the command is for
        /// </summary>
        private static readonly DependencyProperty SelectedCommandBehaviorProperty =      
            DependencyProperty.RegisterAttached("SelectedCommandBehavior",
          typeof(PrismNavigationCommandBehavior),
          typeof(PrismNavigationItemSelected), null);

        /// <summary>
        /// CommandProperty Attached Dependency Property
        /// Represents the command  to be executed
        /// </summary>
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.RegisterAttached("Command",
                typeof(ICommand),
                typeof(PrismNavigationItemSelected),
                new PropertyMetadata(OnSetCommandCallback));

        #endregion

        #region Property Accessors
        /// <summary>
        /// GetCommand Get Property Accessor
        ///  CommandProperty DP Get Accessor
        /// </summary>
        /// <param name="listBoxItem">ListBoxItem object</param>
        /// <returns>ICommand</returns>
        public static ICommand? GetCommand(ListBoxItem listBoxItem)
        {
            return listBoxItem.GetValue(CommandProperty) as ICommand;
        }

        /// <summary>
        /// SetCommand Set Property Accessor
        ///  CommandProperty DP Set Accessor
        /// </summary>
        /// <param name="menuItem">ListBoxItem to set the command parameter on</param>
        /// <param name="command">Command</param>
        public static void SetCommand(ListBoxItem listBoxItem, ICommand command)
        {
            listBoxItem.SetValue(CommandProperty, command);
        }

        /// <summary>
        /// GetCommandParameter Get Property Accessor
        ///  CommandParameterProperty DP Get Accessor
        /// </summary>
        /// <param name="listBoxItem">ListBoxItem object</param>
        /// <returns>object</returns>
        public static object GetCommandParameter(ListBoxItem listBoxItem)
        {
            return listBoxItem.GetValue(CommandParameterProperty);
        }
        /// <summary>
        /// SetCommandParameter Set Property Accessor
        ///  CommandProperty DP Set Accessor
        /// </summary>
        /// <param name="menuItem">ListBoxItem to set the parameter on</param>
        /// <param name="command">Command parameter</param>
        public static void SetCommandParameter(ListBoxItem listBoxItem, object parameter)
        {
            listBoxItem.SetValue(CommandParameterProperty, parameter);
        }
        #endregion


        #region Event Handlers

        /// <summary>
        /// OnSetCommandCallback event handler 
        /// CommandProperty's DP PropertyChanged event handler
        /// Called when the property is changed
        /// Used to wire up the Command to the ListBoxItem
        /// </summary>
        /// <param name="dependencyObject">Object property is called on</param>
        /// <param name="e">Event argument information</param>
        private static void OnSetCommandCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            if (dependencyObject is ListBoxItem listBoxItem)
            {
                PrismNavigationItemCommandBehavior behavior = GetOrCreateBehavior(listBoxItem);
                behavior.Command = e.NewValue as ICommand;
            }
        }



        /// <summary>
        /// OnSetCommandParameterCallback event handler 
        /// CommandProperty's DP PropertyChanged event handler
        /// Called when the property is changed
        /// Used to wire up the Command Parameter to the ListBoxItem
        /// </summary>
        /// <param name="dependencyObject">Object property is called on</param>
        /// <param name="e">Event argument information</param>
        private static void OnSetCommandParameterCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            if (dependencyObject is ListBoxItem listBoxItem)
            {
                PrismNavigationItemCommandBehavior behavior = GetOrCreateBehavior(listBoxItem);
                behavior.CommandParameter = e.NewValue;
            }
        }
        #endregion

        #region Utility Method
        /// <summary>
        /// GetOrCreateBehavior method
        /// Used to create or use existing ListBoxItem
        /// </summary>
        /// <param name="listBoxItem">ListBoxItem reference</param>
        /// <returns></returns>
        private static PrismNavigationItemCommandBehavior GetOrCreateBehavior(ListBoxItem listBoxItem)
        {
            if (listBoxItem.GetValue(SelectedCommandBehaviorProperty) is not PrismNavigationItemCommandBehavior behavior)
            {
                behavior = new PrismNavigationItemCommandBehavior(listBoxItem);
                listBoxItem.SetValue(SelectedCommandBehaviorProperty, behavior);
            }

            return behavior;
        }
            #endregion
    }
}
