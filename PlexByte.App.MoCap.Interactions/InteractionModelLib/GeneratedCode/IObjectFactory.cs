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

public interface IObjectFactory 
{
	IVote CreateVote(string pId, IUser pUser, ISurveyOption pOption);

	ITimeslice CreateTimeslice(string pId, IUser pUser, DateTime pStartDT, DateTime pEndDT);

	ITimeslice CreateTimeslice(string pId, IUser pUser, int pDuration);

	SurveyOption CreateSurveyOption(string pId, string pText);

	ISurveyOption CreateSurveyOption(string pId, string pText);

	IExpense CreateExpense(string pId, string pText, System.Drawing.Image pReceipt, decimal pValue, IUser pUser);

	IExpense CreateExpense(string pId, string pText, IUser pUser);

}

