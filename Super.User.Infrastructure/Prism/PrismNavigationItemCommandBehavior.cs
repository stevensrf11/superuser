using Prism.Interactivity;
using System.Windows;
using System.Windows.Controls;

namespace Super.User.Infrastructure.Prism
{

    ///  <summary>
    /// PrismNavigationItemCommandBehavior object derived from the <see cref="CommandBehaviorBase"/> object type ListBoxItem
    /// A PRISM custom command behavior for the ListBoxItem  Selected event to execute a command
    /// </summary>
    public class PrismNavigationItemCommandBehavior : CommandBehaviorBase<ListBoxItem>
    {
        #region Constructor
        /// <summary>
        /// PrismNavigationItemCommandBehavior parameterized constructor
        /// Registers for the listBoxItem's Selected event
        /// </summary>
        /// <param name="ListBoxItem">listBoxItem control</param>        
        public PrismNavigationItemCommandBehavior(ListBoxItem listBoxItem)
            : base(listBoxItem)
        {

           
        }
        #endregion

        #region Event Handler
        /// <summary>
        /// Item_Selected event handler
        /// Event handler for the ListBoxItem's Selected event
        /// Executes a command for the Selected event
        /// </summary>
        /// <param name="sender">ListBoxItem</param>
        /// <param name="e">Selected event arguments</param>
        void Item_Selected(object sender, RoutedEventArgs e)
        {
           
        }    
        #endregion

    }
}

