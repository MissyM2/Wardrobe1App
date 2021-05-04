//******************* Wardrobe App ****************
// <APP VERSION>1.0</APP VERSION>
// <AUTHOR>Missy Maloney</AUTHOR>
// <DATE>04/30/2021 </DATE>
// <SUMMARY> </SUMMARY>
//*************************************************

using System;
using UIKit;


namespace Wardrobe1App
{
    public class CommonHelper
    {
        public string EnvironmentFolderPath { get; set; }
        public string DatabaseName { get; set; }

        public UIFont TextFont { get; set; }
        public UIFont TextFontAuth { get; set; }

        public UIFont BoldTextFont { get; set; }

        public CommonHelper()
        {
            EnvironmentFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            DatabaseName = "myWardrobeDb.db";

            TextFont = UIFont.PreferredHeadline;
            BoldTextFont = UIFont.BoldSystemFontOfSize(16);
            TextFontAuth = UIFont.SystemFontOfSize(25);
        }

        // ---------------- GET DEVICE NAME ---------------
        public string GetDeviceName()
        {
            string deviceName = UIDevice.CurrentDevice.Name;
            return deviceName;
        }
    }
}
