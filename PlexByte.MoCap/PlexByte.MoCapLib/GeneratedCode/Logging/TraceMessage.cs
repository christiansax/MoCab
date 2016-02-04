﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Logging
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public class TraceMessage
	{
		public virtual string ComponentName
		{
			get;
			set;
		}

		public virtual string Context
		{
			get;
			set;
		}

		public virtual int IndentLevel
		{
			get;
			set;
		}

		public virtual int Level
		{
			get;
			set;
		}

		public virtual int LineNumber
		{
			get;
			set;
		}

		public virtual string Message
		{
			get;
			set;
		}

		public virtual string ObjectId
		{
			get;
			set;
		}

		public virtual string Operation
		{
			get;
			set;
		}

		public virtual string ScopedOperation
		{
			get;
			set;
		}

		public virtual string Source
		{
			get;
			set;
		}

		public virtual string ThreadId
		{
			get;
			set;
		}

		public virtual DateTime TimeStamp
		{
			get;
			set;
		}

		public virtual TraceType Type
		{
			get;
			set;
		}

		public virtual string threadId
		{
			get;
			set;
		}

		public TraceMessage(string pMessage, [System.Runtime.CompilerServices.CallerMemberName] string pMemberName = "", [System.Runtime.CompilerServices.CallerFilePath] string pSourceFilePath = "", [System.Runtime.CompilerServices.CallerLineNumber] int pSourceLineNumber = 0)
		{
		}

		public TraceMessage(string pMessage, int pLevel, TraceType pType, string pComponent, string pContext, string pThreadId, DateTime pTimeStamp, int pIndentLevel, string pObjectId, [System.Runtime.CompilerServices.CallerMemberName] string pMemberName = "", [System.Runtime.CompilerServices.CallerFilePath] string pSourceFilePath = "", [System.Runtime.CompilerServices.CallerLineNumber] int pSourceLineNumber = 0)
		{
            System.Reflection.ParameterInfo[] parameters = new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().GetParameters();
            Message = pMessage;
            Type = pType;
            Level = pLevel;
            if (pThreadId != System.Threading.Thread.CurrentThread.ManagedThreadId.ToString())
                ThreadId = pThreadId;
            else
                ThreadId = System.Threading.Thread.CurrentThread.ManagedThreadId.ToString();
            Context = pContext;
            ComponentName = pComponent;
            ObjectId = pObjectId;
            LineNumber = pSourceLineNumber;
            Operation = pMemberName;
            ScopedOperation = pMemberName + "(";

            Source = pSourceFilePath;

            for (int i = 0; i < parameters.Length; i++)
            {
                if (i == 0)
                    ScopedOperation += "[" + parameters[i].ParameterType + " | " + parameters[i].Name + "]";
                else
                    ScopedOperation += ", [" + parameters[i].ParameterType + " | " + parameters[i].Name + "]";
            }
            ScopedOperation += ")";
        }

	}
}

