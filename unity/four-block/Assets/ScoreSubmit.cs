using System.Collections;
using System.Collections.Generic;
using game.logic.EventQueue;
using network.score;
using network.user;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScoreSubmit : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;

    /// <summary>
    /// Initializes the application or component.
    /// </summary>
    /// <remarks>
    /// This method is typically called when the application starts or when the component is instantiated.
    /// It is used to set up any necessary resources, initialize variables, or perform any startup tasks required
    /// for the application to function correctly. The method currently does not contain any implementation details,
    /// but it serves as a placeholder for future initialization logic.
    /// </remarks>
    void Start()
    {
        
    }

    /// <summary>
    /// Updates the state of the object.
    /// </summary>
    /// <remarks>
    /// This method is intended to be called regularly to refresh or update the internal state of the object.
    /// It may be used for tasks such as refreshing data, processing events, or performing periodic checks.
    /// The implementation of this method should define what specific updates are necessary for the object's functionality.
    /// As it currently stands, this method does not perform any operations, but it can be extended in the future.
    /// </remarks>
    void Update()
    {
        
    }

    /// <summary>
    /// Submits the player's score to the score service.
    /// </summary>
    /// <remarks>
    /// This method retrieves the score from the input field, parses it as an integer, and then submits it to the ScoreService.
    /// It assumes that the input field contains a valid integer representation of the score.
    /// The method does not return any value, as it is designed to perform an action (submitting the score) rather than compute a result.
    /// Ensure that the input field is properly populated before calling this method to avoid potential parsing errors.
    /// </remarks>
    public void Win()
    {
        var score = int.Parse(_inputField.text);
        ScoreService scoreService = new ScoreService();
        scoreService.SubmitScore(score);
    }
}
