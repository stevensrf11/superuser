using Prism.Mvvm;
using Super.User.Module.Interfaces.Models;


namespace Super.User.Module.Models
{
    /// <summary>
    /// NavigationButtonModel model dervied from the <see cref="BindableBase"/> object,
    /// and the <seealso cref="INavigationButtonModel"/>
    /// Contains the navigation bar button information which is used for binding ot the navigation bar
    /// </summary>
    public class NavigationButtonModel : BindableBase
        , INavigationButtonModel
    {
        #region Fields
        /// <summary>
        /// _displayText Field
        /// String variable used to display information
        /// Default value set to string.Empty
        /// </summary>
        /// <value>string</value>
        private string _displayText = string.Empty;

        /// <summary>
        /// _name Field
        /// String variable used to set the name 
        /// Default value set to string.Empty
        /// </summary>
        /// <value>string</value>
        private string _name = string.Empty;

        /// <summary>
        /// _navigationUrl Field
        /// String variable which contains the navigation url
        /// Default value set to string.Empty
        /// </summary>
        /// <value>string</value>
        private string _navigationUrl = string.Empty;



        /// <summary>
        /// _isEnabled Field
        /// Boolean variable used to indicate the enabled state
        /// A true value indicates the state is set
        /// A false value indicates the state is reset
        /// </summary>
        /// <value>string</value>
        private bool _isEnabled;

        /// <summary>
        /// _isVisible Field
        /// Boolean variable used to indicate the visibility state
        /// A true value indicates the state is set
        /// A false value indicates the state is reset
        /// </summary>
        /// <value>string</value>
        private bool _isVisible;

        /// <summary>
        /// _toolTip Field
        /// String variable used to set the tooltip 
        /// Default value set to string.Empty
        /// </summary>
        /// <value>string</value>
        private string _toolTip = string.Empty;


        #endregion

        #region Accessors
        /// <summary>
        /// DisplayText Accessor Get / Set Property
        /// A  string property used to display information
        /// </summary>
        /// <value> string</value>
        public virtual string DisplayText
        {
            get { return _displayText; }
            set { SetProperty(ref _displayText, value); }
        }
        /// <summary>
        /// Name Accessor Get / Set Property
        /// A  string property which provides the name of the object
        /// </summary>
        /// <value> string</value>
        public virtual string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        /// <summary>
        ///  NavigationUrl Accessor Get / Set
        /// A  string property which provides the navigation path url to the object
        /// </summary>
        /// <value> string</value>
        public virtual string NavigationUrl
        {
            get { return _navigationUrl; }
            set { SetProperty(ref _navigationUrl, value); }
        }

        /// <summary>
        /// IsEnabled Accessor Get / Set
        /// A  boolean where which determines the enable state of the object
        /// If the value is true the the enable state is set.
        /// For all other values the state is reset.
        /// </summary>
        /// <value> boolean</value>
        public virtual bool IsEnabled
        {
            get { return _isEnabled; }
            set { SetProperty(ref _isEnabled, value); }
        }

        /// <summary>
        /// IsVisible Accessor Get / Set
        /// A  boolean where which determines the visibility state of the object
        /// If the value is true the the visibility state is set.
        /// For all other values the state is reset.
        /// </summary>
        /// <value> boolean</value>
        public virtual bool IsVisible
        {
            get { return _isVisible; }
            set { SetProperty(ref _isVisible, value); }
        }

        /// <summary>
        ///  ToolTip Get Set Property
        /// A  string property which provides the tooltip for the object
        /// </summary>
        /// <value> string</value>
        public virtual string ToolTip
        {
            get { return _toolTip; }
            set { SetProperty(ref _toolTip, value); }
        }
        #endregion

    }
}
