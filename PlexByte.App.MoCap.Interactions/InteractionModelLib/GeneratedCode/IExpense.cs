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

public interface IExpense 
{
	decimal Value { get;set; }

	System.Drawing.Image Receipt { get;set; }

	IInteraction Target { get;set; }

	string TaskId { get;set; }

	void AddReceipt(System.Drawing.Image pImage, decimal pValue);

	void DeleteReceipt(System.Drawing.Image pImage, decimal pValue);

	void EditReceipt(System.Drawing.Image pImage, System.Drawing.Image pNewImage, decimal pValue, decimal pNewValue);

}

