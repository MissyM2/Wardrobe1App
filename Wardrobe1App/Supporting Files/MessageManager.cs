//******************* Wardrobe App ****************
// <APP VERSION>1.0</APP VERSION>
// <AUTHOR>Missy Maloney</AUTHOR>
// <DATE>04/30/2021 </DATE>
// <SUMMARY> </SUMMARY>
//*************************************************

using System;
namespace Wardrobe1App
{
    public class MessageManager
    {
        //SettingsController settings;
        public string NoResultMessage { get; set; }
        public string TestMessage { get; set; }

        public MessageManager()
        {
            //settings = new SettingsController();

            NoResultMessage = "No results found.";
            TestMessage = "Test Message";
        }
    }
}
