namespace PlexByte.MoCap.Logging
{
    public enum TraceObjectType : int
    {
        EnterScope = 1,
        ExitScope = 2,
        SysInfo = 0,
        Exception = 5,
        Error = 10,
        Info = 40,
        Warning = 20,
        Detail = 60,
        Verbose = 80,
        All = 100,
    }
}