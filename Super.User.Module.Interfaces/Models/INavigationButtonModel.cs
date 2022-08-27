namespace Super.User.Module.Interfaces.Models
{
    /// <summary>
    /// INavigationButtonModel interface
    /// Serves as the interface navigation buttonton model
    /// </summary>
    public interface INavigationButtonModel
    {
        #region Accessors
        /// <summary>
        /// DisplayText Accessor Get / Set Property
        /// A  string property used to display information
        /// </summary>
        /// <value> string</value>
        string DisplayText { get; set; }

        /// <summary>
        /// Name Accessor Get / Set Property
        /// A  string property which provides the name of the object
        /// </summary>
        /// <value> string</value>
        string Name { get; set; }

        /// <summary>
        ///  NavigationUrl Accessor Get / Set
        /// A  string property which provides the navigation path url to the object
        /// </summary>
        /// <value> string</value>
        string NavigationUrl { get; set; }

        /// <summary>
        /// IsEnabled Accessor Get / Set
        /// A  boolean where which determines the enable state of the object
        /// If the value is true the the enable state is set.
        /// For all other values the state is reset.
        /// </summary>
        /// <value> boolean</value>
        bool IsEnabled { get; set; }


        /// <summary>
        /// IsVisible Accessor Get / Set
        /// A  boolean where which determines the visibility state of the object
        /// If the value is true the the visibility state is set.
        /// For all other values the state is reset.
        /// </summary>
        /// <value> boolean</value>
        bool IsVisible { get; set; }


        /// <summary>
        ///  ToolTip Get Set Property
        /// A  string property which provides the tooltip for the object
        /// </summary>
        /// <value>nullable string</value>
        string ToolTip { get; set; }

        #endregion

    }
}
