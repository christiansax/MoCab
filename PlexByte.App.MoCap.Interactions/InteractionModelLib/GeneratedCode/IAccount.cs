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

public interface IAccount  : ITask
{
	IEnumerable<IExpense> ExpenseList { get;set; }

	IEnumerable<ITimeslice> TimesliceList { get;set; }

	void ProjectView(IProject pProject);

	void UserView(IProject pProject, IUser pUser);

}

