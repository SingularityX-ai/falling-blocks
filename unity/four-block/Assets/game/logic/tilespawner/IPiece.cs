
using game.logic.tile;
using UnityEngine;

namespace game.logic.tilespawner
{
    public class IPiece: ISpawnable
    {

        /// <summary>
        /// Spawns a new tile and returns it.
        /// </summary>
        /// <returns>A new instance of <see cref="ITileable"/> representing a tile with a cyan color.</returns>
        /// <remarks>
        /// This method creates a new tile object of type <see cref="Tile"/> with the color set to cyan.
        /// It logs a message to the debug console indicating that the spawn operation has occurred.
        /// The returned tile can be used in the game environment where tiles are required,
        /// and it implements the <see cref="ITileable"/> interface, ensuring it adheres to the expected behavior for tile objects.
        /// </remarks>
        public ITileable Spawn()
        {
            Debug.Log("I");
            return new Tile(Color.cyan);
        }
    }
}