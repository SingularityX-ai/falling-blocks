
using game.logic.tile;
using UnityEngine;

namespace game.logic.tilespawner
{
    public class SPiece: ISpawnable
    {

        /// <summary>
        /// Spawns a new tile and returns it.
        /// </summary>
        /// <returns>A new instance of <see cref="ITileable"/> representing a green tile.</returns>
        /// <remarks>
        /// This method creates a new tile with a green color and returns it as an object that implements the <see cref="ITileable"/> interface.
        /// The method also logs a message to the debug console indicating that the spawn operation has been initiated.
        /// This can be useful for tracking the spawning of tiles during gameplay or in a simulation.
        /// The returned tile can be used in various game mechanics or visual representations as needed.
        /// </remarks>
        public ITileable Spawn()
        {
            Debug.Log("S");
            return new Tile(Color.green);
        }
    }
}