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

	public class Chat : IInteraction
	{
		public virtual IEnumerable<Message> Message
		{
			get;
			set;
		}

		public virtual Project Project
		{
			get;
			set;
		}

	}
}

