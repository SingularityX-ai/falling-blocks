using System;
using System.Collections.Generic;
using UnityEngine;

namespace gamerunner
{
    public class Dispatcher : MonoBehaviour
    {
        private List<IUpdatable> _updatables;

        /// <summary>
        /// Initializes the component when it is first loaded.
        /// </summary>
        /// <remarks>
        /// This method is called when the script instance is being loaded.
        /// It initializes the private field <c>_updatables</c> to a new instance of a list that implements the <c>IUpdatable</c> interface.
        /// This setup is crucial for managing objects that require periodic updates during the game loop.
        /// The <c>Awake</c> method is typically used for initialization tasks that need to be completed before any other methods are called.
        /// </remarks>
        private void Awake()
        {
            _updatables = new List<IUpdatable>();
        }

        /// <summary>
        /// Updates all updatable entities in the collection.
        /// </summary>
        /// <remarks>
        /// This method iterates through a collection of updatable entities stored in the private field <paramref name="_updatables"/>.
        /// For each entity, it calls the <c>Update</c> method, allowing each entity to perform its own update logic.
        /// This is typically used in game loops or similar scenarios where multiple entities need to be updated on each frame or tick.
        /// The method does not return any value and does not throw exceptions.
        /// </remarks>
        private void Update()
        {
            foreach (var updatable in _updatables)
            {
                updatable.Update();
            }
        }

        /// <summary>
        /// Adds an updatable object to the collection of updatables.
        /// </summary>
        /// <param name="updatable">The updatable object to be added.</param>
        /// <remarks>
        /// This method allows for the registration of objects that implement the <see cref="IUpdatable"/> interface.
        /// The added updatable can then be updated in a batch process, typically during a game loop or a similar update cycle.
        /// This is useful for managing multiple objects that require periodic updates, such as animations, game entities, or other dynamic components.
        /// The method modifies the internal collection of updatables by adding the provided object to it.
        /// </remarks>
        public void addUpdatable(IUpdatable updatable)
        {
            _updatables.Add(updatable);
        }
    }
}