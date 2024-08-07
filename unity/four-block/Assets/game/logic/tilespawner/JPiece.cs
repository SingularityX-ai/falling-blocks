using System;
using game.logic.tile;
using UnityEngine;

namespace game.logic.tilespawner
{
    public class JPiece: ISpawnable
    {

        /// <summary>
        /// Spawns a new tile and returns it.
        /// </summary>
        /// <returns>A new instance of <see cref="ITileable"/> representing a blue tile.</returns>
        /// <remarks>
        /// This method creates a new tile object of type <see cref="Tile"/> with a blue color.
        /// It also logs a debug message to indicate that the spawn process has been initiated.
        /// The returned tile can be used in various game mechanics or visual representations within the application.
        /// Ensure that the appropriate context is set up for the tile to function correctly in the game environment.
        /// </remarks>
        public ITileable Spawn()
        {
            Debug.Log("J");
            return new Tile(Color.blue);
        }
    }
}