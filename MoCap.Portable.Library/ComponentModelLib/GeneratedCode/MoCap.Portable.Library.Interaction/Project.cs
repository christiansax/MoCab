﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace MoCap.Portable.Library.Interaction
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public class Project : IInteraction
	{
		public virtual IEnumerable<Poll> Poll
		{
			get;
			set;
		}

		public virtual IEnumerable<Task> Task
		{
			get;
			set;
		}

		public virtual Account Account
		{
			get;
			set;
		}

		public virtual Chat Chat
		{
			get;
			set;
		}

	}
}

