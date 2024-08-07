
using game.logic.tile;
using UnityEngine;

namespace game.logic.tilespawner
{
    public class ZPiece: ISpawnable
    {

        /// <summary>
        /// Spawns a new tile and returns it.
        /// </summary>
        /// <returns>A new instance of <see cref="ITileable"/> representing a red tile.</returns>
        /// <remarks>
        /// This method creates a new tile object of type <see cref="Tile"/> with a red color.
        /// It also logs a message to the debug console for tracking purposes.
        /// The returned tile can be used in various contexts where an ITileable object is required.
        /// Ensure that the necessary components are in place to utilize the spawned tile effectively.
        /// </remarks>
        public ITileable Spawn()
        {
            Debug.Log("Z");
            return new Tile(Color.red);
        }
    }
}