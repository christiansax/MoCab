//////////////////////////////////////////////////////////////
//                      Interface Task                              
//      Author: Christian B. Sax            Date:   2016/02/23
//      Implemented in class task

using System;
using System.Collections.Generic;

public interface ITask 
{
    DateTime DueDateTime { get; }

    decimal Budget { get; }

	int Duration { get; }

	int Priority { get; }

    int Progress { get; }

    int DurationCurrent { get; }

	decimal BudgetUsed { get; }

    List<ITask> SubTasks { get; }

    void AddTimeslice(ITimeslice pTimeslice);

	void AddExpense(IExpense pExpense);

    void UdateProgress(int pProgress);

}

