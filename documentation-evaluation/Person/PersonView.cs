using System;

namespace documentation_evaluation.person
{
    public class PersonView
    {
        private PersonViewModel _viewModel;

        public PersonView(PersonViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        /// <summary>
        /// Displays the name and age of the view model.
        /// </summary>
        /// <remarks>
        /// This method retrieves the name and age properties from the associated view model and prints them to the console.
        /// It formats the output as "Name: {Name}, Age: {Age}", providing a simple way to visualize the current state of the view model's data.
        /// This method does not return any value and is primarily used for debugging or informational purposes.
        /// </remarks>
        public void Display()
        {
            Console.WriteLine($"Name: {_viewModel.Name}, Age: {_viewModel.Age}");
        }

        /// <summary>
        /// Updates the name property of the view model based on user input.
        /// </summary>
        /// <remarks>
        /// This method prompts the user to enter a new name via the console.
        /// It reads the input from the console and assigns it to the Name property of the
        /// associated view model. This allows for dynamic updates to the name, reflecting
        /// any changes made by the user during runtime. The method does not return any value
        /// and directly modifies the state of the view model.
        /// </remarks>
        public void UpdateName()
        {
            Console.Write("Enter a new name: ");
            _viewModel.Name = Console.ReadLine();
        }


        public void UpdateName()
        {
            Console.Write("Enter a new name: ");
            _viewModel.Name = Console.ReadLine();
        }

        /// <summary>
        /// Updates the age of the view model based on user input.
        /// </summary>
        /// <remarks>
        /// This method prompts the user to enter a new age and updates the
        /// <see cref="_viewModel.Age"/> property with the provided value.
        /// It reads the input from the console, parses it as an integer,
        /// and assigns it to the Age property of the view model.
        /// It is important to ensure that the input is a valid integer,
        /// as invalid input will result in a runtime exception.
        /// </remarks>
        public void UpdateAge()
        {
            Console.Write("Enter a new age: ");
            _viewModel.Age = int.Parse(Console.ReadLine());
        }
    }
}
