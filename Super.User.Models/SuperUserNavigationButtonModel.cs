using Super.User.Interfaces.Models;


namespace Super.User.Models
{
    /// <summary>
    /// SuperUserNavigationButtonModel navigation buttom model object derived from the <see cref="SuperUserModelBase"/>  object
    /// , and the ISuperUserNavigationButtonModel interface
    /// Serves as the model for a navigation button
    /// </summary>
    public class SuperUserNavigationButtonModel : SuperUserModelBase
        , ISuperUserNavigationButtonModel
    {
        #region Constructor
        /// <summary>
        /// SuperUserNavigationButtonModel parametized constuctor used to intialise properties
        /// </summary>
        /// <param name="displayText">
        /// Display information. 
        /// A string variable used for displaying information to the user
        /// </param>
        /// <param name="name">
        /// Name of the object
        /// A string variable used for naming the object
        /// </param>
        /// <param name="navigationUrl">
        /// Navigation path url of the object
        /// A string variable used for navigating to the object
        /// </param>
        /// <param name="isEnabled">
        /// The enable state of the object
        /// A  boolean  which determines the enable state of the object
        /// If the value is true the the enable state is set.
        /// For all other values the state is reset.
        /// </param>
        /// <param name="isVisible">
        /// Visibility state of the object
        /// A  boolean  which determines the visibility state of the object
        /// If the value is true the the visibility state is set.
        /// For all other values the state is reset.
        /// </param>
        /// <param name="toolTip">
        /// Tooltip for the object
        /// A  string property which provides the tooltip for the object
        /// </param>
        public SuperUserNavigationButtonModel(string displayText
            ,string name
            , string navigationUrl
            ,bool isEnabled
            ,bool isVisible
            ,string toolTip)
        {
            DisplayText = displayText;
            Name = name;
            NavigationUrl = navigationUrl;
            IsEnabled = isEnabled;
            IsVisible = isVisible;
            ToolTip = toolTip;
        }

        /// <summary>
        /// SuperUserNavigationButtonModel default constructor
        /// Made private
        /// </summary>
        private SuperUserNavigationButtonModel() { }

        #endregion

        #region Accessors
        /// <summary>
        /// DisplayText Accessors Get Property 
        /// A nullable string property used to display information
        /// </summary>
        /// <value>nullable string</value>
        public virtual string? DisplayText { get; protected set; }

        /// <summary>
        /// Name Accessors Get Property
        /// A nullable string property which provides the name of the object
        /// </summary>
        /// <value>nullable string</value>
        public virtual string? Name { get; protected set; }

        /// <summary>
        ///  NavigationUrl Get Property
        /// A nullable string property which provides the navigation path url to the object
        /// </summary>
        /// <value>nullable string</value>
        public virtual string? NavigationUrl { get; protected set; }

        /// <summary>
        /// IsEnabled Get Property
        /// A nullable boolean  which determines the enable state of the object
        /// If the value is true the the enable state is set.
        /// For all other values the state is reset.
        /// </summary>
        /// <value>nullable boolean</value>
        public virtual bool? IsEnabled { get; protected set; }


        /// <summary>
        /// IsVisible Get Property
        /// A nullable boolean  which determines the visibility state of the object
        /// If the value is true the the visibility state is set.
        /// For all other values the state is reset.
        /// </summary>
        /// <value>nullable boolean</value>
        public virtual bool? IsVisible { get; protected set; }


        /// <summary>
        ///  ToolTip Get Property
        /// A nullable string property which provides the tooltip for the object
        /// </summary>
        /// <value>nullable string</value>
        public virtual string? ToolTip { get; protected set; }

        #endregion

    }
}
