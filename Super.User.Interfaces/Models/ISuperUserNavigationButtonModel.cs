namespace Super.User.Interfaces.Models
{
    /// <summary>
    /// ISuperUserNavigationButtonModel model interface dervived from the <see cref="ISuperUserModelBase"/> interface
    /// Serves as model interface for navigation buttons
    /// </summary>
    public interface ISuperUserNavigationButtonModel : ISuperUserModelBase
    {
        #region Accessors
        /// <summary>
        /// DisplayText Accessors Get Property
        /// A nullable string property used to display information
        /// </summary>
        /// <value>nullable string</value>
         string? DisplayText { get; }

        /// <summary>
        /// Name Accessors Get Property
        /// A nullable string property which provides the name of the object
        /// </summary>
        /// <value>nullable string</value>
         string? Name { get; }

        /// <summary>
        ///  NavigationUrl Get Property
        /// A nullable string property which provides the navigation path url to the object
        /// </summary>
        /// <value>nullable string</value>
         string? NavigationUrl { get; }

        /// <summary>
        /// IsEnabled Get Property
        /// A nullable boolean where which determines the enable state of the object
        /// If the value is true the the enable state is set.
        /// For all other values the state is reset.
        /// </summary>
        /// <value>nullable boolean</value>
         bool? IsEnabled { get; }


        /// <summary>
        /// IsVisible Get Property
        /// A nullable boolean where which determines the visibility state of the object
        /// If the value is true the the visibility state is set.
        /// For all other values the state is reset.
        /// </summary>
        /// <value>nullable boolean</value>
         bool? IsVisible { get; }


        /// <summary>
        ///  ToolTip Get Property
        /// A nullable string property which provides the tooltip for the object
        /// </summary>
        /// <value>nullable string</value>
         string? ToolTip { get; }

        #endregion
    }
}
