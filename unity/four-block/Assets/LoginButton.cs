using System.Collections;
using System.Collections.Generic;
using game.logic.EventQueue;
using network.user;
using UnityEngine;
using UnityEngine.EventSystems;

public class LoginButton : MonoBehaviour
{
    private EventQueue _eventQueue;

    /// <summary>
    /// Initializes the application or component.
    /// </summary>
    /// <remarks>
    /// This method is typically called at the beginning of the application lifecycle.
    /// It is used to set up any necessary resources, configurations, or initial states required for the application to function correctly.
    /// This method may include tasks such as loading settings, initializing variables, or starting services.
    /// It is important to ensure that all required components are properly initialized before proceeding with the application's main logic.
    /// </remarks>
    void Start()
    {
        
    }

    /// <summary>
    /// Updates the state of the object.
    /// </summary>
    /// <remarks>
    /// This method is intended to be called regularly to refresh or update the internal state of the object.
    /// It may include operations such as processing input, updating properties, or performing calculations.
    /// The specific implementation details are dependent on the context in which this method is used.
    /// As it currently stands, this method does not perform any operations, but it can be extended to include the necessary logic.
    /// </remarks>
    void Update()
    {
        
    }

    /// <summary>
    /// Links the specified event queue to the current instance.
    /// </summary>
    /// <param name="eventQueue">The event queue to be linked.</param>
    /// <remarks>
    /// This method assigns the provided <paramref name="eventQueue"/> to the private field <c>_eventQueue</c> of the current instance.
    /// It allows the current object to interact with the specified event queue, enabling event handling and processing.
    /// This method does not return any value and is primarily used for establishing a connection between the current instance and the event queue.
    /// </remarks>
    public void Link(EventQueue eventQueue)
    {
        _eventQueue = eventQueue;
    }

    /// <summary>
    /// Handles the click event by retrieving the user's name and enqueuing a user login event.
    /// </summary>
    /// <remarks>
    /// This method is triggered when a click event occurs. It creates an instance of the <see cref="UserService"/> class to access user-related functionalities.
    /// The method retrieves the current user's name using the <see cref="GetUserName"/> method from the <see cref="UserService"/> instance.
    /// After obtaining the user's name, it enqueues a new <see cref="UserLoginEvent"/> into the event queue, which can be processed later.
    /// This allows for asynchronous handling of user login actions, ensuring that the application remains responsive.
    /// </remarks>
    public void OnClick()
    {
        UserService userService = new UserService();
        var userName = userService.GetUserName();
        _eventQueue.Enqueue(new UserLoginEvent(this, userName));
    }
}
