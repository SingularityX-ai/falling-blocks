
using game.logic.tile;
using UnityEngine;

namespace game.logic.tilespawner
{
    public class TPiece: ISpawnable
    {

        /// <summary>
        /// Creates and spawns a new tile with a specified color.
        /// </summary>
        /// <returns>A new instance of <see cref="ITileable"/> representing the spawned tile.</returns>
        /// <remarks>
        /// This method instantiates a new tile object with the color magenta.
        /// The spawned tile can be used in various game or application contexts where
        /// a tileable element is required. The method ensures that each call results
        /// in a fresh instance of a tile, allowing for dynamic creation and management
        /// of tileable elements in the environment.
        /// </remarks>
        public ITileable Spawn()
        {
            return new Tile(Color.magenta);
        }
    }
}