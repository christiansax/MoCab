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

public interface IAccount 
{
	IEnumerable<ITimeslice> TimesliceList { get;set; }

	IEnumerable<IExpense> ExpenseList { get;set; }

	void EditExpense(IExpense pExpense, IExpense pNewExpense);

	void DeleteExpense(IExpense pExpense);

	void EditTimeslice(ITimeslice pTimeslice, ITimeslice pNewTimeslice);

	void DeleteTimeslice(ITimeslice pTimeslice);

}

