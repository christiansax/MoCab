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

	public class Poll : IInteraction
	{
		public virtual IEnumerable<Vote> Vote
		{
			get;
			set;
		}

		public virtual IEnumerable<PollOption> PollOption
		{
			get;
			set;
		}

		/// <summary>
		/// Poll distribute a task
		/// </summary>
		public virtual Task Task
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

