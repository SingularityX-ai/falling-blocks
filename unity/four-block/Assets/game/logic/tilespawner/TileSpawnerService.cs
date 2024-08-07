using System;
using System.Collections.Generic;
using System.Linq;
using game.service;
using Unity.VisualScripting;
using Random = System.Random;

namespace game.logic.tilespawner
{
    public class TileSpawnerService: IService
    {
        public delegate ISpawnable CreateTileShapeDelegate();
        
        List<CreateTileShapeDelegate> _pieces = new List<CreateTileShapeDelegate>{
            SpawnIPiece, SpawnJPiece, SpawnLPiece, SpawnOPiece, SpawnSPiece, SpawnTPiece, SpawnZPiece
        };

        public TileSpawnerService()
        {
            Shuffle();
        }

        /// <summary>
        /// Creates and returns a new instance of the IPiece class.
        /// </summary>
        /// <returns>A new instance of <see cref="IPiece"/>.</returns>
        /// <remarks>
        /// This method is responsible for instantiating an object of the <see cref="IPiece"/> type.
        /// The <see cref="IPiece"/> class represents a specific type of spawnable object in the application.
        /// By calling this method, users can obtain a fresh instance of <see cref="IPiece"/> which can then be used in the game or application logic.
        /// This method does not take any parameters and is designed to be a simple factory method for creating IPiece objects.
        /// </remarks>
        private static ISpawnable SpawnIPiece() => new IPiece();

        /// <summary>
        /// Creates and returns a new instance of the JPiece object.
        /// </summary>
        /// <returns>A new instance of <see cref="JPiece"/> that implements the <see cref="ISpawnable"/> interface.</returns>
        /// <remarks>
        /// This method is responsible for instantiating the JPiece, which is a specific type of object that can be spawned in the game or application.
        /// The returned object can be used to represent a J-shaped piece in a game like Tetris or similar.
        /// This method does not take any parameters and provides a straightforward way to obtain a new JPiece instance whenever needed.
        /// </remarks>
        private static ISpawnable SpawnJPiece() => new JPiece();

        /// <summary>
        /// Creates and returns a new instance of the LPiece class.
        /// </summary>
        /// <returns>An instance of <see cref="LPiece"/> that implements the <see cref="ISpawnable"/> interface.</returns>
        /// <remarks>
        /// This method is responsible for instantiating a new LPiece object, which is typically used in games or applications
        /// that require the representation of a specific game piece or object. The LPiece class is expected to implement
        /// the ISpawnable interface, ensuring that it adheres to the required contract for spawnable objects.
        /// This method does not take any parameters and directly returns the newly created LPiece instance.
        /// </remarks>
        private static ISpawnable SpawnLPiece() => new LPiece();

        /// <summary>
        /// Creates and returns a new instance of the OPiece class.
        /// </summary>
        /// <returns>A new instance of <see cref="OPiece"/> that implements the <see cref="ISpawnable"/> interface.</returns>
        /// <remarks>
        /// This method is responsible for instantiating an object of type OPiece, which is expected to implement the ISpawnable interface.
        /// The OPiece class represents a specific type of spawnable object within the application, and this method encapsulates the creation logic.
        /// By using this method, you ensure that you are always working with a fresh instance of OPiece, which can be useful for managing state and behavior in your application.
        /// </remarks>
        private static ISpawnable SpawnOPiece() => new OPiece();

        /// <summary>
        /// Creates and returns a new instance of the SPiece class.
        /// </summary>
        /// <returns>A new instance of <see cref="SPiece"/> that implements the <see cref="ISpawnable"/> interface.</returns>
        /// <remarks>
        /// This method is responsible for instantiating the SPiece object, which is expected to implement the ISpawnable interface.
        /// The SPiece class may contain specific properties and methods that define its behavior in the context of the application.
        /// This factory method simplifies the creation of SPiece instances, ensuring that the caller receives a properly initialized object.
        /// </remarks>
        private static ISpawnable SpawnSPiece() => new SPiece();

        /// <summary>
        /// Creates and returns a new instance of the TPiece class.
        /// </summary>
        /// <returns>A new instance of <see cref="TPiece"/> that implements the <see cref="ISpawnable"/> interface.</returns>
        /// <remarks>
        /// This method is responsible for instantiating a TPiece object, which is typically used in games or applications
        /// that require a specific type of spawnable entity. The TPiece class is expected to implement the ISpawnable
        /// interface, ensuring that it adheres to the necessary contract for spawnable objects.
        /// This method does not take any parameters and provides a straightforward way to obtain a new TPiece instance.
        /// </remarks>
        private static ISpawnable SpawnTPiece() => new TPiece();

        /// <summary>
        /// Creates and returns a new instance of the ZPiece.
        /// </summary>
        /// <returns>A new instance of <see cref="ZPiece"/> that implements the <see cref="ISpawnable"/> interface.</returns>
        /// <remarks>
        /// This method is responsible for instantiating a ZPiece object, which is a specific type of spawnable entity in the application.
        /// The ZPiece is typically used in contexts where a specific shape or functionality is required, such as in games or simulations.
        /// By encapsulating the creation logic in this method, it allows for easier modifications in the future, such as changing the way ZPiece instances are created or initialized.
        /// </remarks>
        private static ISpawnable SpawnZPiece() => new ZPiece();

        /// <summary>
        /// Spawns a new tile shape by shuffling the available pieces and returning the first piece.
        /// </summary>
        /// <returns>A delegate representing the first tile shape after shuffling the pieces.</returns>
        /// <remarks>
        /// This method first invokes the <see cref="Shuffle"/> method to randomize the order of the available tile shapes.
        /// After shuffling, it retrieves and returns the first tile shape from the collection of pieces.
        /// This is useful in scenarios where a random selection of tile shapes is required, such as in game mechanics or puzzle generation.
        /// The returned delegate can then be used to create or manipulate the spawned tile shape.
        /// </remarks>
        public CreateTileShapeDelegate Spawn()
        {
            Shuffle();
            return _pieces.First();
        }

        private Random rng = new Random();

        /// <summary>
        /// Shuffles the elements of the collection randomly.
        /// </summary>
        /// <remarks>
        /// This method implements the Fisher-Yates shuffle algorithm to randomly reorder the elements in the
        /// private collection of pieces. It iterates through the collection, selecting a random index for each
        /// element and swapping it with the current element. This ensures that each possible permutation of the
        /// collection is equally likely, resulting in a fair shuffle. The method modifies the original collection
        /// in place, meaning that the order of elements in _pieces will be changed after this method is called.
        /// </remarks>
        private void Shuffle()  
        {  
            var n = _pieces.Count;  
            while (n > 1) {  
                n--;  
                var k = rng.Next(n + 1);  
                (_pieces[k], _pieces[n]) = (_pieces[n], _pieces[k]);
            }  
        }
    }
}