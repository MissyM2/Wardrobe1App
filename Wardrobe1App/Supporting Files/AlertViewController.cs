using UIKit;

namespace Wardrobe1App
{
    public partial class AlertViewController
    {
        UIAlertController AlertController;

        public AlertViewController()
        {
        }

        // FOR UIViewController (these two are exactly the same except for the UIKit controller type
        public void ShowAlertBox(string errorTitle, string errorMsg, bool isOtherButton, string otherButtonTitle, string cancelButtonTitle, bool isButtonHandle, string alertType, UIViewController controller)
        {
            AlertController = UIAlertController.Create(errorTitle, errorMsg, UIAlertControllerStyle.Alert);

            if (isOtherButton == true)
            {
                AlertController.AddAction(UIAlertAction.Create(otherButtonTitle, UIAlertActionStyle.Default, (action) => { }));
            }

            AlertController.AddAction(UIAlertAction.Create(cancelButtonTitle, UIAlertActionStyle.Cancel, (action) => { }));
            controller.PresentViewController(AlertController, true, null);
        }

        // FOR UITableViewController
        public void ShowAlertBox(string errorTitle, string errorMsg, bool isOtherButton, string otherButtonTitle, string cancelButtonTitle, bool isButtonHandle, string alertType, UITableViewController controller)
        {
            AlertController = UIAlertController.Create(errorTitle, errorMsg, UIAlertControllerStyle.Alert);

            if (isOtherButton == true)
            {
                AlertController.AddAction(UIAlertAction.Create(otherButtonTitle, UIAlertActionStyle.Default, (action) => { }));

            }
            //Let javascript handle the Cancel click by passing the completionHandler to the controller
            AlertController.AddAction(UIAlertAction.Create(cancelButtonTitle, UIAlertActionStyle.Cancel, (action) => { }));

            controller.PresentViewController(AlertController, true, null);

        }

    
    }
}

