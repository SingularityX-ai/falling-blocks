using game.logic.EventQueue;
using game.logic.tile;
using game.service;
using gamerunner;
using UnityEngine;

namespace game.logic.playfield
{
    public class PlayFieldViewModel: IUpdatable
    {
        private PlayField _playField;
        private ServiceLocator _serviceLocator;

        public PlayFieldViewModel(PlayField playField, ServiceLocator serviceLocator)
        {
            _playField = playField;
            _serviceLocator = serviceLocator;
            
            for (int x = 0; x < _playField.Width; x++)
            {
                for (int y = 0; y < _playField.Height; y++)
                {
                    _playField.Field[x, y] = new Tile(Color.black);
                }
            }
        }

        public int Width => _playField.Width;

        public int Height => _playField.Height;

        public ITileable[,] Tiles
        {
            get => _playField.Field;
            set => _playField.Field = value;
        }

        /// <summary>
        /// Retrieves the tile located at the specified coordinates in the play field.
        /// </summary>
        /// <param name="x">The x-coordinate of the tile to retrieve.</param>
        /// <param name="y">The y-coordinate of the tile to retrieve.</param>
        /// <returns>An object implementing the <see cref="ITileable"/> interface representing the tile at the specified coordinates.</returns>
        /// <remarks>
        /// This method accesses the internal representation of the play field, which is organized as a two-dimensional array.
        /// It returns the tile located at the given (x, y) coordinates. The coordinates must be within the bounds of the play field.
        /// If the coordinates are out of bounds, this method may throw an exception, depending on the implementation of the underlying data structure.
        /// Ensure that the provided coordinates are valid before calling this method to avoid runtime errors.
        /// </remarks>
        public ITileable GetTile(int x, int y)
        {
            return _playField.Field[x, y];
        }

        /// <summary>
        /// Places a tile at the specified coordinates in the play field.
        /// </summary>
        /// <param name="tile">The tile to be placed in the play field.</param>
        /// <param name="x">The x-coordinate where the tile will be placed.</param>
        /// <param name="y">The y-coordinate where the tile will be placed.</param>
        /// <remarks>
        /// This method assigns the provided <paramref name="tile"/> to the specified position in the play field,
        /// which is represented as a two-dimensional array. The coordinates <paramref name="x"/> and <paramref name="y"/>
        /// must be within the bounds of the play field. If the coordinates are out of bounds, this may lead to an
        /// index out of range exception. This method does not return a value as it modifies the state of the play field directly.
        /// </remarks>
        public void PlaceTile(ITileable tile, int x, int y)
        {
            _playField.Field[x, y] = tile;
        }

        /// <summary>
        /// Updates the game state by processing events from the event queue.
        /// </summary>
        /// <remarks>
        /// This method retrieves the event queue from the service locator and checks for a specific event identified by <c>EventId.SpawnTile</c>.
        /// If a <c>SpawnTileEvent</c> is found in the queue, it invokes the delegate associated with the event to create a tile shape.
        /// The created tile shape is then placed at the specified coordinates (0, 0) in the game world.
        /// This method is typically called during the game loop to ensure that events are processed in a timely manner.
        /// </remarks>
        public void Update()
        {
            var eventQueue = _serviceLocator.GetService<EventQueue.EventQueue>();
            var e = (SpawnTileEvent)eventQueue.Dequeue(EventId.SpawnTile);
            if (e != null)
            {
                var createTileShape = e.CreateTileShapeDelegate;
                var shape = createTileShape();
                PlaceTile(shape.Spawn(), 0, 0);
            }
        }
    }
}