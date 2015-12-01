using System;
namespace Interactions
{
    public interface IComponent
    {
        DateTime CreatedDateTime { get; }
        DateTime ModifiedDateTime { get; }
        DateTime SentDateTime { get; }
        DateTime ReadDateTime { get; }
        DateTime DueDateTime { get; }
    }
}
