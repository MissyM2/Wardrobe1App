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

            // tab 1: Add Item to Wardrobe
            var vcAddItem = new AddItemViewController();
            NavigationBarController nbcAddItem = new NavigationBarController();
            UINavigationController ncAddItem = nbcAddItem.GetNavigationController(vcAddItem);

            vcAddItem.Title = "Add Wardrobe Item";
            vcAddItem.View.BackgroundColor = UIColor.Green;

            // tab 2: View Reports
            var vcMyReports = new MyReportsViewController();
            NavigationBarController nbcMyReports = new NavigationBarController();
            UINavigationController ncMyReports = nbcMyReports.GetNavigationController(vcMyReports);

            vcMyReports.Title = "My Reports";
            vcMyReports.View.BackgroundColor = UIColor.Orange;

            TabController tabController = new TabController();
            tabController.AddChildViewController(ncAddItem);
            tabController.AddChildViewController(ncMyReports);

            return tabController;
        }
   }
}
