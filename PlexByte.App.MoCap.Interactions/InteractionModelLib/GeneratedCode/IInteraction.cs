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

public interface IInteraction 
{
	string Id { get; }

	DateTime StartDateTime { get;set; }

	DateTime EndDateTime { get;set; }

	DateTime CreatedDateTime { get; }

	DateTime ModifiedDateTime { get; }

	bool IsActive { get;set; }

	string Text { get;set; }

	InteractionType Type { get;set; }

	void OnComplete(IInteraction pInteraction, InteractionEventArgs e);

	void ChangeOwner(IUser pUser);

	void ChangeIsActive(bool pActive);

}
