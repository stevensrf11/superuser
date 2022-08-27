using Prism.Interactivity;
using Super.User.Interfaces.Models;
using System.Windows;

using System.Windows.Controls;

namespace Super.User.Infrastructure.Prism
{

    ///  <summary>
    /// PrismNavigationCommandBehavior object derived from the <see cref="CommandBehaviorBase"/> object type AccordionItem
    /// A PRISM custom command behavior for the ListBox's SelectionChanged event to execute a command
    /// </summary>
    public class PrismNavigationCommandBehavior : CommandBehaviorBase<ListBox>
    {
        #region Constructor
        /// <summary>
        /// PrismNavigationCommandBehavior parameterized constructor
        /// Registers for the ListBox's SelectionChanged event
        /// </summary>
        /// <param name="listBox">ListBox control</param>        
        public PrismNavigationCommandBehavior(ListBox listBox)
            : base(listBox)
        {

            listBox.SelectionChanged += Item_Selected;
        }
        #endregion

        #region Event Handler
        /// <summary>
        /// Item_Selected event handler
        /// Event handler for the ListBox's SelectionChanged event
        /// Executes a command for the SelectionChanged event
        /// </summary>
        /// <param name="sender">ListBox</param>
        /// <param name="e">Selected event arguments</param>
        void Item_Selected(object sender, RoutedEventArgs e)
        {
            if (e.Source is ListBox newSelectedItem)
            {
                var item = newSelectedItem.SelectedItem;
                var navigationModel = item as ISuperUserNavigationButtonModel;
                CommandParameter = navigationModel;
                ExecuteCommand(CommandParameter);
            }

        }
        #endregion

    }
}

