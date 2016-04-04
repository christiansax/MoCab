//////////////////////////////////////////////////////////////
//                      Interface Task                              
//      Author: Christian B. Sax            Date:   2016/02/23
//      Implemented in class task

using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace PlexByte.MoCap.Interactions
{
    public interface ITask
    {
        string Id { get; }

        string InteractionId { get; set; }

        string ProjectId { get; set; }

        DateTime DueDateTime { get; }

        decimal Budget { get; }

        int Duration { get; }

        int Priority { get; }

        int Progress { get; }

        int DurationCurrent { get; }

        decimal BudgetUsed { get; }

        string Title { get; set; }

        List<ITask> SubTasks { get; }

        List<Expense> ExpenseItems { get; set; }

        List<Timeslice> TimesliceItems{ get; set; }

        void AddTimeslice(int pDuration);

        void AddExpense(decimal pExpenseValue);

        void UdateProgress(int pProgress);

        void AddSubTask(ITask pTask);
    }
}