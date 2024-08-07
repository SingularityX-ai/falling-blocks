
using game.logic.tile;
using UnityEngine;

namespace game.logic.tilespawner
{
    public class OPiece: ISpawnable
    {

        /// <summary>
        /// Spawns a new tile and returns it.
        /// </summary>
        /// <returns>A new instance of <see cref="ITileable"/> representing a yellow tile.</returns>
        /// <remarks>
        /// This method creates a new tile object with a yellow color and returns it.
        /// It also logs a message to the debug console indicating that the spawn process has started.
        /// The returned tile implements the <see cref="ITileable"/> interface, allowing it to be used in various tile-related operations.
        /// This method does not take any parameters and is designed to be called when a new tile needs to be created in the game environment.
        /// </remarks>
        public ITileable Spawn()
        {
            Debug.Log("O");
            return new Tile(Color.yellow);
        }
    }
}