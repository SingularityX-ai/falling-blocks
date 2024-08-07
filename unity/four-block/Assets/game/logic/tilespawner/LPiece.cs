using game.logic.tile;
using UnityEngine;

namespace game.logic.tilespawner
{
    public class LPiece: ISpawnable
    {

        /// <summary>
        /// Spawns a new tile and returns it.
        /// </summary>
        /// <returns>An instance of <see cref="ITileable"/> representing the newly spawned tile.</returns>
        /// <remarks>
        /// This method creates a new tile with a specific color defined by the RGB values (1f, 0.5f, 0f), which corresponds to an orange color.
        /// It also logs a message to the debug console indicating that the spawn process has been initiated.
        /// The returned tile can be used in the game environment as an interactive or visual element.
        /// </remarks>
        public ITileable Spawn()
        {
            Debug.Log("L");
            return new Tile(new Color(1f, 0.5f, 0f));
        }
    }
}