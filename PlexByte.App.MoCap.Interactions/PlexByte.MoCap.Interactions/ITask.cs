//////////////////////////////////////////////////////////////
//                      Interface Task                              
//      Author: Christian B. Sax            Date:   2016/02/23
//      Implemented in class task
using System.Collections.Generic;

public interface ITask 
{
	decimal Budget { get; }

	int Duration { get; }

	int Priority { get; }

    int Progress { get; }

    int DurationCurrent { get;set; }

	decimal BudgetUsed { get;set; }

    List<ITask> SubTasks { get; }

    List<ITimeslice> TimesliceList { get; }

    List<IExpense> ExpenseList { get; }

    void AddTimeslice(ITimeslice pTimeslice);

	void AddExpense(IExpense pExpense);

    void UdateProgress(int pProgress);

}

