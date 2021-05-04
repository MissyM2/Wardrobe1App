using System;

using UIKit;

namespace Wardrobe1App
{
    public class TabPlusController
    {

        public TabPlusController()
        {
        }
        public UITabBarController GetTabBarController()
        {

            UITabBarController tabBarController = new UITabBarController();

            tabBarController.TabBar.BarTintColor = UIColor.Black;

            return tabBarController;
        }
    }
}

