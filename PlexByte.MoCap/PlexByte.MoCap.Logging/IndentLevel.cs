public class IndentLevel
{
	public virtual string ScopedMethod
	{
		get;
		set;
	}

	public virtual int Level
	{
		get;
		set;
	}

	public virtual string ThreadId
	{
		get;
		set;
	}

	public virtual string Topic
	{
		get;
		set;
	}

    public IndentLevel(string pScopedMethod, string pTopic, string pThreadId, int pIndentLevel)
    {
        ScopedMethod = pScopedMethod;
        Topic = pTopic;
        ThreadId = pThreadId;
        Level = pIndentLevel;
    }

}

