using System;
namespace MoCap.Interactions
{
    public class TaskEventArgs : EventArgs
    {
        public Task TaskObject { get; }
        public string Message { get; }

        public TaskEventArgs(Task pTask, string pMessage)
        {
            TaskObject = pTask;
            Message = pMessage;
        }
    }
}
