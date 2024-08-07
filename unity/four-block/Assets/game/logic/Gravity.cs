using gamerunner;
using UnityEngine;

namespace game.logic
{
    public class GravityService : IUpdatable, IGravityService
    {
        private IGravityStrategy _gravityStrategy;

        public float CurrentGravity => _gravityStrategy.CurrentGravity;

        public GravityService(IGravityStrategy gravityStrategy)
        {
            _gravityStrategy = gravityStrategy;
        }

        /// <summary>
        /// Updates the current gravity strategy if it implements the IUpdatable interface.
        /// </summary>
        /// <remarks>
        /// This method checks if the current gravity strategy (_gravityStrategy) can be cast to the IUpdatable interface.
        /// If it can, the Update method of the updatable strategy is called. This allows for dynamic updates to the gravity strategy's state or behavior.
        /// This is particularly useful in scenarios where the gravity strategy may change over time and needs to be updated accordingly.
        /// </remarks>
        public void Update()
        {
            if (_gravityStrategy is IUpdatable updatable)
            {
                updatable.Update();
            }
        }
    }
}
