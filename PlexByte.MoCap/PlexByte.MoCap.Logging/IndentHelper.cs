using System.Collections.Generic;

public class IndentHelper
{
	public virtual int CurrentIndent
	{
		get;
		set;
	}

	public virtual List<IndentLevel> IndentHistory
    {
		get;
	}

	public IndentHelper()
	{
        IndentHistory = new List<IndentLevel>();
	    CurrentIndent = 0;
	}

    public virtual void AddIndentLevel(string pTopic, string pScopedMethod, string pThreadId, int pLevel)
    {
        IndentHistory.Add(new IndentLevel(pScopedMethod, pTopic, pThreadId, ++CurrentIndent));
    }

	public virtual int GetIndentLevel(string pTopic, string pScopedMethod, string pThreadId)
	{
	    if (IndentHistory.FindIndex(x => x.Topic == pTopic
	                                     && x.ScopedMethod == pScopedMethod
	                                     && x.ThreadId == pThreadId) >= 0)
	    {
	        return IndentHistory.Find(x => x.Topic == pTopic
	                                       && x.ScopedMethod == pScopedMethod
	                                       && x.ThreadId == pThreadId).Level;
	    }
	    else
	    {
	        // We did not find the indet history and insert it at the last position
            IndentLevel tmp = new IndentLevel(pScopedMethod, pTopic,pThreadId,++CurrentIndent);
            IndentHistory.Add(tmp);
            return tmp.Level;
	    }
	}

    public virtual void DeleteIndent(string pTopic, string pThreadId, string pScopedMethod)
    {
        if (IndentHistory.FindIndex(x => x.Topic == pTopic
                                         && x.ScopedMethod == pScopedMethod
                                         && x.ThreadId == pThreadId) >= 0)
        {
            IndentHistory.RemoveAt(
                IndentHistory.FindIndex(x => x.Topic == pTopic
                                             && x.ScopedMethod == pScopedMethod
                                             && x.ThreadId == pThreadId));
            CurrentIndent--;
        }
    }

}

