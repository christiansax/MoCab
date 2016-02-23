﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface ITask 
{
	decimal Budget { get; }

	int Duration { get; }

	int Priority { get; }

	int DurationCurrent { get;set; }

	decimal BudgetUsed { get;set; }

	int Progress { get; }

	List<ITask> SubTasks { get; }

    List<ITimeslice> TimesliceList { get; }

    List<IExpense> ExpenseList { get; }

	void AddTimeslice(ITimeslice pTimeslice);

	void AddExpense(IExpense pExpense);

	void UdateProgress(int pProgress);

}

