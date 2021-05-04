//******************* Wardrobe App ****************
// <APP VERSION>1.0</APP VERSION>
// <AUTHOR>Missy Maloney</AUTHOR>
// <DATE>04/30/2021 </DATE>
// <SUMMARY> </SUMMARY>
//*************************************************
using System;
using Foundation;
using UIKit;

namespace Wardrobe1App
{
    public partial class NavigationBarController
    {
        public NavigationBarController()
        {
        }

        public UINavigationController GetNavigationController (UIViewController viewController)
        {
            UINavigationController navController = new UINavigationController(viewController);
            navController.NavigationBar.BarStyle = UIBarStyle.Black;
            navController.NavigationBar.Translucent = true;  // Show status bar
            navController.NavigationBar.BarTintColor = UIColor.Black;
            navController.NavigationBar.TintColor = UIColor.FromRGB(51, 153, 255);  // Color for navigation bar buttons

            return navController;
        }
    }
}

