using System;
using Prism.Mvvm;
using Prism.Regions;
using Super.User.Interfaces.ViewModels;

namespace Super.User.Infrastructure.ViewModels
{
    /// <summary>
    /// SuperUserViewModel  view model object derived from the <see cref="BindableBase"/> object.
    /// and the interfaces <seealso cref="ISuperUserViewModel"/>, <seealso cref="IConfirmNavigationRequest"/>
    /// ,<seealso cref="IConfirmNavigationRequest"/>, <seealso cref="IRegionMemberLifetime"/>, and 
    /// <seealso cref="IDisposable"/>
    /// The SuperUserViewModel serves as the base view model for all view models that participate in navgiation.
    /// It uses BindableBase object for INotifyPropertyChanged to simplify model, and the IConfirmNavigationRequest,
    /// IConfirmNavigationRequest, IRegionMemberLifetime in navigation. 
    /// </summary>
    public class SuperUserViewModel: BindableBase
        , ISuperUserViewModel
        , IConfirmNavigationRequest
        , IRegionMemberLifetime
        , IDisposable
    {

        #region Fields
        private string _title = string.Empty;

        #endregion
        /// <summary>
        /// Parameter constructor
        /// </summary>
        public SuperUserViewModel()
        {
            
        }
        #region Constructor

        #endregion

        #region Property Accessors


        #region ISuperUserViewModel implantation
        /// <summary>
        /// Title Property GetSet Accessor
        /// Provides the title for a view
        /// </summary>
        /// <value> string</value>


        public virtual string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        #endregion
        #endregion

        #region IConfirmNavigationRequest Implementation
        /// <summary>
        /// ConfirmNavigationRequest method
        /// Called in navigation to determine if navigation is allowed on the view or view model 
        /// </summary>
        /// <param name="navigationContext">Navigation information object</param>
        /// <param name="continuationCallback">Action method to used in specifying if navigation allowed</param>
        public virtual void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            continuationCallback(true);
        }
        #endregion

        #region INagivagateAware Implementation
        /// <summary>
        /// IsNavigationTarget virtual method
        /// Called during navigation to determine if a  preexisting view and or view model
        /// will  be used, or a new one created when navigating to 
        /// </summary>
        /// <param name="navigationContext">Navigation information object</param>
        /// <returns>true to indicated preexisting view shall be used</returns>
        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        /// <summary>
        /// OnNavigatedFrom virtual method
        /// Called during navigation on the view being navigate from
        /// </summary>
        /// <param name="navigationContext">Navigation information object</param>
        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        /// <summary>
        /// OnNavigatedTo virtual method
        /// Called during navigation on the view being navigate to
        /// </summary>
        /// <param name="navigationContext">>Navigation information object</param>
        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
        }
        #endregion

        #region IRegionMemberLifetime Implementation

        /// <summary>
        /// KeepAlive  virtual  property accessor
        ///  Used make deactivated views available for garbage collection when set false.
        /// If set true deactivated view remains in memory
        /// </summary>
        /// <returns>true indicating deactivated view remain in memory</returns>
        public virtual bool KeepAlive => true;

        #endregion



        #region IDispoable and Disposon methods
        public void Dispose() 
        {
            Dispose(true);
        // Prevent finalizer from running.
            GC.SuppressFinalize(this); 
        } 
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Call Dispose() on other objects owned by this instance.
                // You can reference other finalizable objects here.
                
            }
            // Release unmanaged resources owned by (just) this object.
            // ...
        }
        #endregion

        #region Finalizer
        ~SuperUserViewModel() => Dispose(false);
        #endregion
    }
}
