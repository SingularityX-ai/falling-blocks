using System.Collections;
using System.Collections.Generic;
using game.logic;
using game.logic.EventQueue;
using game.logic.tile;
using game.logic.tilespawner;
using game.service;
using gamerunner;
using UnityEngine;

public class GameRunner : IUpdatable
{
    private ServiceLocator _serviceLocator;
    private float _gravitySum = 0.0f;
    private int frames = 0;
    
    public TileSpawnerService.CreateTileShapeDelegate CreateTileShape;

    public GameRunner(ServiceLocator serviceLocator)
    {
        _serviceLocator = serviceLocator;
    }

    /// <summary>
    /// Updates the state of the object by processing gravity and spawning tiles when a threshold is reached.
    /// </summary>
    /// <remarks>
    /// This method retrieves the current gravity from the <see cref="GravityService"/> and accumulates it in the <c>_gravitySum</c> field.
    /// It increments the frame count and checks if the accumulated gravity exceeds 100.0f. If it does, it resets the frame count and gravity sum,
    /// and spawns a new tile shape using the <see cref="TileSpawnerService"/>. It also enqueues a <see cref="SpawnTileEvent"/> to notify other parts of the system
    /// about the new tile creation. The method ensures that a new tile shape is created each time the threshold is crossed.
    /// </remarks>
    public void Update()
    {
        var gravity = _serviceLocator.GetService<GravityService>();
        _gravitySum += gravity.CurrentGravity;
        frames++;
        if(_gravitySum > 100.0f)
        {
            var spawner = _serviceLocator.GetService<TileSpawnerService>();
            frames = 0;
            _gravitySum = 0.0f;
            if (CreateTileShape == null)
            {
                CreateTileShape = spawner.Spawn();    
            }
            
            var eventQueue = _serviceLocator.GetService<EventQueue>();
            eventQueue.Enqueue(new SpawnTileEvent(this, CreateTileShape));
            
            CreateTileShape = spawner.Spawn();
        }
    }
}
