using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using game.logic;
using game.logic.EventQueue;
using game.logic.playfield;
using game.logic.tile;
using game.logic.tilespawner;
using game.service;
using gamerunner;
using network;
using UnityEngine;

public class GameInitialiser : MonoBehaviour
{
    public PlayFieldView PlayFieldPrefab;
    public TileView TilePrefab;
    
    [SerializeField]
    public LoginButton _loginButton;

    public Dispatcher Dispatcher;

    /// <summary>
    /// Initializes the game environment by setting up HTTP requests, the play field, and various services.
    /// </summary>
    /// <remarks>
    /// This method is responsible for the initial setup of the game. It creates HTTP GET and POST requests using the
    /// <see cref="HttpRequestFactory"/>. It then initializes the play field and its view model, linking them to the
    /// corresponding view. The method populates the play field with tiles based on its dimensions, instantiating
    /// tile views for each tile placed. Additionally, it sets up gravity strategies and registers various services
    /// such as gravity, tile spawner, and event queue with the service locator. Finally, it links the login button
    /// to the event queue and adds the game runner, gravity service, and play field view model to the dispatcher
    /// for updates. After completing these tasks, it destroys the current game object to clean up resources.
    /// </remarks>
    void Start()
    {
        var httpRequestFactory = new HttpRequestFactory();
        var getRequest = (HttpGetRequest)httpRequestFactory.CreateHttpRequest(HttpMethod.Get);
        var postRequest = httpRequestFactory.CreateHttpRequest(HttpMethod.Post);
        
        var serviceLocator = new ServiceLocator();
        
        var playField = new PlayField();
        var playFieldVM = new PlayFieldViewModel(playField, serviceLocator);
        
        var playFieldView = GameObject.Instantiate(PlayFieldPrefab);
        playFieldView.Link(playFieldVM);
        
        for (int x = 0; x < playFieldVM.Width; x++)
        {
            for (int y = 0; y < playFieldVM.Height; y++)
            {
                var tile = new Tile(Color.black);
                playFieldVM.PlaceTile(tile, x, y);
                
                var tileView = GameObject.Instantiate(TilePrefab, playFieldView.TileAnchor);
                tileView.Link(new TileViewModel(playFieldVM, x, y));
            }
        }

        var gravityStrategies = new List<IGravityStrategy>()
        {
            new LevelBasedGravityStrategy(),
            new TimeBasedGravityStrategy()
        };
        var gravityStrategy = gravityStrategies[Random.Range(0, gravityStrategies.Count-1)];
        var gravity = new GravityService(gravityStrategy);
        serviceLocator.RegisterService(gravity);

        var spawner = new TileSpawnerService();
        serviceLocator.RegisterService(spawner);
        
        var eventQueue = new EventQueue();
        serviceLocator.RegisterService(eventQueue);
        
        _loginButton.Link(eventQueue);
        
        var gameRunner = new GameRunner(serviceLocator);
        Dispatcher.addUpdatable(gameRunner);
        Dispatcher.addUpdatable(gravity);
        Dispatcher.addUpdatable(playFieldVM);
        
        Destroy(this.gameObject);
    }
}
