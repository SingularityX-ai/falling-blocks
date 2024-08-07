using UnityEngine;

namespace game.logic.tile
{
    public class TileView : MonoBehaviour
    {
        public SpriteRenderer TileSprite;
        
        private TileViewModel _tileVM;

        /// <summary>
        /// Initializes the component or system.
        /// </summary>
        /// <remarks>
        /// This method is typically called when the component is started or activated.
        /// It may contain logic to set up necessary resources, initialize variables,
        /// or perform any required setup actions before the component begins its main operations.
        /// This method does not return any value and does not take any parameters.
        /// </remarks>
        private void Start()
        {
        }

        /// <summary>
        /// Links the specified TileViewModel to the current object and updates its position.
        /// </summary>
        /// <param name="tileVM">The TileViewModel instance containing the position data.</param>
        /// <remarks>
        /// This method assigns the provided <paramref name="tileVM"/> to a private field and updates the position of the current object
        /// based on the X and Y coordinates from the <paramref name="tileVM"/>. The Z coordinate is set to 0.
        /// This is typically used in a graphical context where the position of a tile needs to be updated in a 2D space.
        /// </remarks>
        public void Link(TileViewModel tileVM)
        {
            _tileVM = tileVM;
            this.transform.position = new Vector3(tileVM.X, tileVM.Y, 0);
        }

        /// <summary>
        /// Updates the view based on the current state of the tile view model.
        /// </summary>
        /// <remarks>
        /// This method is responsible for refreshing or updating the user interface to reflect any changes
        /// made to the underlying tile view model (_tileVM). It is typically called whenever there is a need
        /// to synchronize the view with the model, ensuring that the displayed information is accurate and
        /// up-to-date. The implementation details of how the view is updated will depend on the specific
        /// requirements of the application and the structure of the view model.
        /// </remarks>
        void Update()
        {
            // Update the view based on the _tileVM here
        }
    }
}
