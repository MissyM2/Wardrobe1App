//******************* Wardrobe App ****************
// <APP VERSION>1.0</APP VERSION>
// <AUTHOR>Missy Maloney</AUTHOR>
// <DATE>04/30/2021 </DATE>
// <SUMMARY> </SUMMARY>
//*************************************************

using System;
using Foundation;
using System.IO;
using SQLite;
using System.Collections.Generic;

namespace Wardrobe1App
{
    public class SettingsController
    {

        public SettingsController()
        {

        }

        //----------------- Get App Name from settings.plist --------------
        public string GetAppName()
        {
            string appName = NSBundle.MainBundle.InfoDictionary["CFBundleName"].ToString();
            return appName;
        }

        //----------------- Get Project ID from settings.plist -------------
        public string GetProjectID()
        {
            string projectID = "";

            string fileName = "Settings.plist";

            NSDictionary dictionary = NSDictionary.FromFile(fileName);
            NSObject keyObject = dictionary[NSObject.FromObject("Project ID")];
            projectID = Convert.ToString(keyObject);

            return projectID;
        }
    }
}
