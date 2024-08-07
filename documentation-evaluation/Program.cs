using System;
using documentation_evaluation.person;

namespace documentation_evaluation
{
    internal class Program
    {

        /// <summary>
        /// The entry point of the application that demonstrates the usage of the Person, PersonViewModel, and PersonView classes.
        /// </summary>
        /// <param name="args">An array of command-line arguments passed to the application. This parameter is not used in this implementation.</param>
        /// <remarks>
        /// This method serves as the main execution point for the program. It begins by printing "Hello World" to the console.
        /// Then, it creates an instance of the <see cref="Person"/> class with a name and age.
        /// A <see cref="PersonViewModel"/> is instantiated using the created person, which acts as a model for the view.
        /// Subsequently, a <see cref="PersonView"/> is created with the view model, allowing for interaction with the user.
        /// The view displays the person's information, allows for updates to the name and age, and displays the updated information again.
        /// Finally, it waits for a key press before terminating the application.
        /// </remarks>
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            
            Person person = new Person { Name = "John Doe", Age = 30 };
            PersonViewModel viewModel = new PersonViewModel(person);
            PersonView view = new PersonView(viewModel);

            view.Display();
            view.UpdateName();
            view.UpdateAge();
            view.Display();

            Console.ReadKey();
        }
    }
}