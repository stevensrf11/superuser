using Prism.Commands;

namespace Super.User.Infrastructure.Prism.Commands
{
    /// <summary>
    /// CompositeCommands static commands 
    /// Contains static  composite command which represents a command that is composed from multiple child commands.
    /// When the composite command is invoked, each of its child commands is invoked in turn.
    /// </summary>
    public static class CompositeCommands
    {
        
        /// <summary>
        /// NavigateCommand Static Property Get Accessor
        /// Used for navigation to a view
        /// </summary>
        public static CompositeCommand NavigateCommand { get; } = new CompositeCommand();
      

    }
}
