using UnityEngine;

namespace game.logic.playfield
{
    public class PlayFieldView : MonoBehaviour
    {
        public Transform TileAnchor;
        
        private PlayFieldViewModel _playFieldVM;

        /// <summary>
        /// Initializes the component or system.
        /// </summary>
        /// <remarks>
        /// This method is typically called when the component is first created or activated.
        /// It is used to set up any necessary state, resources, or configurations required
        /// for the component to function correctly. This method does not return any value
        /// and does not take any parameters. It serves as a starting point for the execution
        /// of the component's functionality.
        /// </remarks>
        private void Start()
        {
        }

        /// <summary>
        /// Links the provided PlayFieldViewModel to the current instance.
        /// </summary>
        /// <param name="playFieldVM">The PlayFieldViewModel instance to be linked.</param>
        /// <remarks>
        /// This method assigns the given <paramref name="playFieldVM"/> to the private field <c>_playFieldVM</c>.
        /// It is typically used to establish a connection between the view model and the view, allowing for data binding and interaction.
        /// This method does not return a value and is primarily used for setting up the state of the object.
        /// </remarks>
        public void Link(PlayFieldViewModel playFieldVM)
        {
            _playFieldVM = playFieldVM;
        }

        /// <summary>
        /// Updates the state of the object.
        /// </summary>
        /// <remarks>
        /// This method is intended to be called regularly to refresh or update the internal state of the object.
        /// It may include operations such as refreshing data, recalculating values, or any other necessary updates
        /// that need to occur over time. The specific implementation details would depend on the context in which
        /// this method is used. As it currently stands, this method does not perform any operations, but it serves
        /// as a placeholder for future functionality.
        /// </remarks>
        void Update()
        {
        
        }
    }
}
