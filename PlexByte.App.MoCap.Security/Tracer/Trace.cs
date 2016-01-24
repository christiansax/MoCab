using System;
using System.Configuration;
using MoCap.Logging;
using System.Collections.Specialized;

namespace MoCap.Security
{
    /// <summary>
    /// Init once globally
    /// </summary>
    public sealed class Trace
    {
        public TraceManager Log { get; } = null;

        public Trace(string pTopic)
        {
            if (Log == null)
            {
                try
                {

                    Config config = new Config();
                    Log = new TraceManager(config.FileName, config.FilePath,
                        System.Reflection.Assembly.GetExecutingAssembly().GetName().Name,
                        config.LogLevel,
                        config.Cache,
                        false,
                        config.MaxFileSize);
                    Log.RegisterTopic(pTopic);
                    if (Log == null)
                        throw new ArgumentException("The settings specified in app.config are not valid");
                }
                catch (Exception exp) { throw new TypeInitializationException("MoCap.Security.Tracer", exp); }
            }
        }
    }

    class Config
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public int LogLevel { get; set; }
        public int Cache { get; set; }
        public long MaxFileSize { get; set; }

        public Config()
        {
            string[] configContent;
            string configFileFullPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\trace.cfg";
            if (System.IO.File.Exists(configFileFullPath))
            {
                configContent = new string[System.IO.File.ReadAllLines(configFileFullPath).Length];
                configContent = System.IO.File.ReadAllLines(configFileFullPath);
            }
            else
            {
                throw new Exception(String.Format(@"Trace config was not found in folder [FileName={0}]",
                    configFileFullPath));
            }

            if (configContent != null)
            {
                foreach (string s in configContent)
                {
                    switch (s.Substring(0, s.IndexOf('=')))
                    {
                        case "fileName":
                            FileName = s.Substring(s.IndexOf('=') + 1);
                            break;
                        case "level":
                            LogLevel = Convert.ToInt32(s.Substring(s.IndexOf('=') + 1));
                            break;
                        case "logPath":
                            FilePath = s.Substring(s.IndexOf('=') + 1);
                            break;
                        case "cache":
                            Cache = Convert.ToInt32(s.Substring(s.IndexOf('=') + 1));
                            break;
                        case "maxFileSize":
                            MaxFileSize = Convert.ToInt64(s.Substring(s.IndexOf('=') + 1));
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}