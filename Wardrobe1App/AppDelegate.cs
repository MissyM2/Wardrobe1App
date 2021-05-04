using Foundation;
using UIKit;
using System;
using UserNotifications;
using System.Collections.Generic;
using System.Linq;

namespace Wardrobe1App
{
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        UIWindow window;

        TabController tabController;

        SqliteCipherHelper databaseHelper;


        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            window = new UIWindow(UIScreen.MainScreen.Bounds);
            tabController = new TabController();


            if (window.RootViewController == null)
            {
                window.RootViewController = tabController.getTabBar();
            };

            databaseHelper = new SqliteCipherHelper();

            window.MakeKeyAndVisible();

            return true;
        }
    }
}

