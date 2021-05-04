using System;
using UIKit;

namespace Wardrobe1App
{
   public class TabController : UITabBarController
   {
       //UITabBarController tabController;
       //UIViewController vcMyWardrobe, vcMyReports, vcOtherStuff;

        UITabBarController tabController;
        

       public TabController()
       {
            
            //UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.LightContent;

             
             // tab 2: My Reports
             // this is the simplest implementation:  add a view controller to tabbar
             //vcMyReports = new UIViewController();

             // the next level is to create a separate view controller, which is either
             // a view controller or a navigation view controller which manages a stack of views
             //var vcMyReports = new MyReportsViewController();
             //NavigationBarController nbcMyReports = new NavigationBarController();
             //UINavigationController ncMyReports = nbcMyReports.GetNavigationController(vcMyReports);

             //vcMyReports.Title = "My Reports";
             //vcMyReports.View.BackgroundColor = UIColor.Orange;

          //   var vcOtherStuff = new UIViewController();
          //   vcOtherStuff.Title = "Other Stuff";
       //      vcOtherStuff.View.BackgroundColor = UIColor.Red;

            //TabController tabController = new TabController();
            //tabController.AddChildViewController(vcMyReports);

            /*
            var tabs = new UIViewController[] {
                 //vcMyWardrobe,
                 vcMyReports,
                // vcOtherStuff
             };
             ViewControllers = tabs;
            */


        }

        public TabController getTabBar()
        {

            //tab 1: My Wardrobe
            // this is the simplest implementation:  add a view controller to tabbar
            //vcMyWardrobe = new UIViewController();

            // the next levelis to create a separate view controller, which is either
            // a view controller or a navigation view controller which manages a stack of views
            var vcMyWardrobe = new MyWardrobeViewController();
            NavigationBarController nbcMyWardrobe = new NavigationBarController();
            UINavigationController ncMyWardrobe = nbcMyWardrobe.GetNavigationController(vcMyWardrobe);

            vcMyWardrobe.Title = "My Wardrobe";
            vcMyWardrobe.View.BackgroundColor = UIColor.Green;

            var vcMyReports = new MyReportsViewController();
            NavigationBarController nbcMyReports = new NavigationBarController();
            UINavigationController ncMyReports = nbcMyReports.GetNavigationController(vcMyReports);

            vcMyReports.Title = "My Reports";
            vcMyReports.View.BackgroundColor = UIColor.Orange;

            TabController tabController = new TabController();
            tabController.AddChildViewController(vcMyWardrobe);
            tabController.AddChildViewController(vcMyReports);

            return tabController;
        }
   }
}
