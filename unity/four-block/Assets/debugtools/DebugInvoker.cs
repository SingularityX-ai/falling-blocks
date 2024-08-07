namespace debugtools
{
    public class DebugInvoker
    {
        private ICommand _command;

        /// <summary>
        /// Sets the command to be executed.
        /// </summary>
        /// <param name="command">The command to be set.</param>
        /// <remarks>
        /// This method assigns the provided <paramref name="command"/> to the private field <c>_command</c>.
        /// It allows for the dynamic configuration of commands that can be executed later.
        /// This is particularly useful in scenarios where the command to be executed may change at runtime,
        /// enabling flexibility in command execution without needing to modify the underlying logic.
        /// </remarks>
        public void SetCommand(ICommand command)
        {
            _command = command;
        }

        /// <summary>
        /// Executes the command associated with this instance.
        /// </summary>
        /// <remarks>
        /// This method calls the <see cref="_command.Execute"/> method to perform the action defined by the command.
        /// It is typically used in scenarios where a command pattern is implemented, allowing for the encapsulation of actions as objects.
        /// The execution of the command may involve various operations depending on the specific implementation of the command.
        /// This method does not return any value and is intended to trigger side effects or changes in state as defined by the command's logic.
        /// </remarks>
        public void ExecuteCommand()
        {
            _command.Execute();
        }
    }
}