using System;
namespace Interactions
{
    public interface IComponent
    {
        /// <summary>
        /// The dateTime this item was created
        /// </summary>
        DateTime CreatedDateTime { get; }
        /// <summary>
        /// The dateTime this item was modified
        /// </summary>
        DateTime ModifiedDateTime { get; }
        /// <summary>
        /// The dateTime this item was sent
        /// </summary>
        DateTime SentDateTime { get; }
        /// <summary>
        /// The dateTime this item was read
        /// </summary>
        DateTime ReadDateTime { get; }
        DateTime DueDateTime { get; }
        string Id{ get; }
        string Title { get; }
        string Description { get; }
        int Priority { get; }
        int TimeToLive{ get; }
    }
}
