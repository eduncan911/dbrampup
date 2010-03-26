using System;
using System.Collections.Generic;
using System.Text;
using CmdParser;
namespace DBRampUp
{
    public class SetupArgs
    {
         
        [Switch]
        [Parameter()]
		[Help("Allow For Debug", "Should DBRampUp pause to allow debugger attachment.")]
        public bool Debug;
        [Switch]
        [Parameter()]
		[Help("Preserve Content", "Should DBRampUp give a chance to save and preserve db.  Implementer is responsible for preserving.")]
        public bool PreserveContent;
        [Switch]
        [Parameter()]
		[Help("Tear Down Existing Database", "Should DBRampUp tear down the existing database.  Overridable script string is dropAllObjectsScript.")]
        public bool TearDownDB;
        [Switch]
        [Parameter()]
		[Help("Run DB scripts ", "Should DBRampUp run your database Install scripts.  Default SQL folder is ..\\data, but can be overriden.")]
        public bool BuildDB;
        
        [Switch]
        [Parameter()]
		[Help("Add Custom Site Settings", "Should DBRampUp add your custom site settings.  Overridable provider method is AddCustomSiteSettings.")]
        public bool CustomSettings;
        [Switch]
        [Parameter()]
		[Help("Build Test Data", "Should DBRampUp build test data. Overridable provider method is BuildTestData.")]
        public bool Test;
        [Switch]
        [Parameter()]
		[Help("Write To Log", "Should DBRampUp write to log file.  Default log path is setup\\logs.  Log Path and filename format are overridable.")]
        public bool Log;

        [Parameter()]
		[Help("Environment", "Used to pass an environment name (Dev, Staging, etc) to DBRampUp.  No default functionality is based on this.")]
        public string Environment;
        
        [Parameter()]
		[Help("Custom Parameters", "Used to pass an custom parameters to DBRampUp.  Implementer is responsible for formatting.  No default functionality is based on these.")]
        public string CustomParms;
    
    }
}
