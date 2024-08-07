using System.Collections.Generic;
using game.service;

namespace game.logic.EventQueue
{
    public class EventQueue: IService
    {
        private Dictionary<EventId, Queue<IEvent>> _queues;
        
        public EventQueue()
        {
            _queues = new Dictionary<EventId, Queue<IEvent>>();
        }

        /// <summary>
        /// Adds an event to the appropriate queue based on its identifier.
        /// </summary>
        /// <param name="e">The event to be enqueued.</param>
        /// <remarks>
        /// This method checks if a queue for the given event's identifier already exists in the internal dictionary.
        /// If it does not exist, a new queue is created for that identifier. The event is then added to the corresponding queue.
        /// This allows for organizing events by their identifiers, enabling efficient processing of events in a structured manner.
        /// </remarks>
        public void Enqueue(IEvent e)
        {
            if(!_queues.ContainsKey(e.Id))
            {
                _queues[e.Id] = new Queue<IEvent>();
            }
            _queues[e.Id].Enqueue(e);
        }

        /// <summary>
        /// Checks if there is at least one event associated with the specified EventId.
        /// </summary>
        /// <param name="id">The EventId to check for associated events.</param>
        /// <returns>True if there is at least one event associated with the specified <paramref name="id"/>; otherwise, false.</returns>
        /// <remarks>
        /// This method verifies the presence of an event in the internal data structure, represented by the dictionary <paramref name="_queues"/>.
        /// It first checks if the dictionary contains the specified <paramref name="id"/> as a key.
        /// If the key exists, it then checks if the corresponding value (a collection of events) has a count greater than zero.
        /// This is useful for determining whether any events are queued for processing or handling for a specific identifier.
        /// </remarks>
        public bool HasEvent(EventId id) => _queues.ContainsKey(id) && _queues[id].Count > 0;

        /// <summary>
        /// Dequeues an event from the specified event queue identified by the given EventId.
        /// </summary>
        /// <param name="id">The identifier of the event queue from which to dequeue the event.</param>
        /// <returns>An instance of <see cref="IEvent"/> representing the dequeued event, or null if no event is available for the specified id.</returns>
        /// <remarks>
        /// This method checks if there is an event available in the queue associated with the provided <paramref name="id"/>.
        /// If an event exists, it is removed from the queue and returned. If no event is present for the specified id,
        /// the method returns null, indicating that there are no events to dequeue.
        /// This is useful for managing event-driven architectures where events are processed in a first-in-first-out (FIFO) manner.
        /// </remarks>
        public IEvent Dequeue(EventId id)
        {
            if (HasEvent(id))
            {
                return _queues[id].Dequeue();
            }
            return null;
        }
    }
}