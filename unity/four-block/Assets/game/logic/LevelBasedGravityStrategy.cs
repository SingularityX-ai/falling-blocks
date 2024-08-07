using System;
using gamerunner;
using UnityEngine;

namespace game.logic
{
    [Serializable]
    public class LevelBasedGravityStrategy : IGravityStrategy
    {
        private readonly float _gravityBase = 9.8f;
        private int _level = 1;
        private const float GravityIncreasePerLevel = 0.75f;
    
        public float CurrentGravity => _gravityBase * _level;
        public float Gravity => _gravityBase * _level;

        /// <summary>
        /// Sets the level to the specified value.
        /// </summary>
        /// <param name="level">The level to be set.</param>
        /// <remarks>
        /// This method updates the private field <c>_level</c> with the value provided as the parameter <paramref name="level"/>.
        /// It allows for changing the state of the object by modifying its level attribute.
        /// This method does not perform any validation on the input value, so it is assumed that the caller will provide a valid level.
        /// </remarks>
        public void SetLevel(int level)
        {
            _level = level;
        }

        /// <summary>
        /// Increases the level of the character or entity by one.
        /// </summary>
        /// <remarks>
        /// This method is responsible for leveling up the character or entity within the game or application.
        /// When called, it increments the internal level counter (_level) by one, allowing the character or entity to progress to the next level.
        /// This is typically used in role-playing games (RPGs) or similar applications where characters gain experience and level up over time.
        /// Note that this method does not perform any checks on the maximum level or any other conditions that might be required for leveling up.
        /// </remarks>
        public void LevelUp()
        {
            _level++;
        }

        /// <summary>
        /// Resets the game level to the initial state.
        /// </summary>
        /// <remarks>
        /// This method sets the private field <c>_level</c> to 1, effectively restarting the game level.
        /// It is typically called when a player chooses to restart the game or after completing a level.
        /// This operation does not return any value and modifies the internal state of the game.
        /// </remarks>
        public void ResetLevel()
        {
            _level = 1;
        } 
    }
}
