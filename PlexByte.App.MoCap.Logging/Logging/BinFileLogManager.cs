//////////////////////////////////////////////////////////////////////////////
//      <ClassTemplate>
//      Author:     <AuthorName>
//      Project:    <ProjectName>
//      Component:  <ComponentName>
#region usings
#region Includes (Microsoft based)
//////////////////////////////////////////////
//      using includes here (Microsoft)     //
//////////////////////////////////////////////
#endregion

#region Includes (3rd parties)
//////////////////////////////////////////////
//      using includes here (3rd parties)   //
//////////////////////////////////////////////
#endregion

#region Includes (MoCap based)
//////////////////////////////////////////////
//      using includes here (MoCap)         //
//////////////////////////////////////////////
#endregion
#endregion

using System;

namespace MoCap.Logging
{
    #region Delegates are declared here

    #endregion

    #region Global variables are declared here

    #endregion

    #region Enum(-s) or type(-s) declaration here

    #endregion

    /// <summary>
    /// This is the summary of the class
    /// </summary>
    public class BinFileLogManager : LogManager
    {
        #region Class members

        #region Events

        #endregion

        #region Properties

        #endregion

        #region Private variables

        #endregion

        #endregion

        #region Methods

        #region Constructor(-s) & Destructor

        public BinFileLogManager(string LogName, string LogPath):base(LogName, false)
        {
        }

        #endregion

        #region Private Methods

        #endregion

        #region Event handlers (methods)

        #endregion

        #region Public Methods

        public override void MessageAdded(EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void ReadStream()
        {
            throw new NotImplementedException();
        }

        public override void WriteStream(EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion

        #region Nested classes here (indentical structure here)

        #endregion
    }
}