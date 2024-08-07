using System.Collections.Generic;

namespace debugtools
{
    public class DebugReceiver
    {
        private List<string> supportedCommands = new List<string>() { "vardump" };

        /// <summary>
        /// Performs an action based on the provided command string.
        /// </summary>
        /// <param name="action">The command string representing the action to be performed.</param>
        /// <remarks>
        /// This method checks if the specified <paramref name="action"/> is supported by the system.
        /// If the action is not found in the list of supported commands, a <see cref="System.NotImplementedException"/> is thrown.
        /// This allows for validation of commands before attempting to execute any associated functionality,
        /// ensuring that only recognized actions are processed.
        /// It is important to handle this exception appropriately to maintain the stability of the application.
        /// </remarks>
        /// <exception cref="System.NotImplementedException">Thrown when the specified action is not supported.</exception>
        public void Action(string action)
        {
            if(!(supportedCommands.Contains(action))){
                throw new System.NotImplementedException();
            }
        }
    }
}