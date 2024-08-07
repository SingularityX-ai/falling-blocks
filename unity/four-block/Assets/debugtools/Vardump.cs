namespace debugtools
{
    public class VardumpCommand
    {
        private DebugReceiver _receiver;

        public VardumpCommand(DebugReceiver receiver)
        {
            _receiver = receiver;
        }

        /// <summary>
        /// Executes an action by invoking the receiver's method with a specific command.
        /// </summary>
        /// <remarks>
        /// This method calls the <paramref name="_receiver"/> to perform an action with the command "vardump".
        /// The purpose of this action is to trigger a specific behavior defined in the receiver's implementation.
        /// It does not return any value and is intended to be used when the action needs to be executed without any parameters.
        /// </remarks>
        public void Execute()
        {
            _receiver.Action("vardump");
        }
    }
}