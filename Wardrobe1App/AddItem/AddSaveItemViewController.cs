using System;
using CoreGraphics;
using UIKit;

namespace Wardrobe1App
{
    public partial class AddSaveItemViewController : UIViewController
    {
        int h = (int)UIScreen.MainScreen.Bounds.Size.Height;
        int w = (int)UIScreen.MainScreen.Bounds.Size.Width;

        // table object for wardrobe items
        public TBL_WARDROBE wardrobeObj { get; set; }

        // views used in this class
        UIView headerView, bodyView;

        // other controls
        UIBarButtonItem prevButton;
        UIButton addItemBtn;

        UILabel titleLbl, subtitleLbl, wardrobeReviewLbl;

        public AddSaveItemViewController() : base("AddSaveItemViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.NavigationItem.Title = "Save Item";

            // create previous button
            prevButton = new UIBarButtonItem("Other Details", UIBarButtonItemStyle.Plain, PrevButtonClickAction);
            NavigationItem.SetLeftBarButtonItem(prevButton, true);

            // layout the screen
            AddScreenLayout();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        private void PrevButtonClickAction(object sender, EventArgs e)
        {
            var prevView = new AddItemDetailsViewController();
            NavigationController.PushViewController(prevView, true);
        }

        void AddScreenLayout()
        {
            AddHeaderView();
            AddBodyView();
        }

        void AddHeaderView()
        {
            headerView = new UIView(new CGRect(0, 20, w, 100));
            headerView.Layer.BorderWidth = 0;

            // create title and subtitle
            titleLbl = new UILabel(new CGRect(40, 60, w - 80, 22));
            titleLbl.BackgroundColor = UIColor.Clear;
            titleLbl.Font = UIFont.BoldSystemFontOfSize(18);
            titleLbl.Text = "Save Item Details";
            titleLbl.TextAlignment = UITextAlignment.Center;
            headerView.Add(titleLbl);

            subtitleLbl = new UILabel(new CGRect(25, 80, w - 50, 22));
            subtitleLbl.BackgroundColor = UIColor.Clear;
            subtitleLbl.Font = UIFont.BoldSystemFontOfSize(14);
            subtitleLbl.Text = "Review your wardrobe item and click add.";
            subtitleLbl.TextAlignment = UITextAlignment.Center;
            headerView.Add(subtitleLbl);

            View.AddSubview(headerView);

        }

        void AddBodyView()
        {
            bodyView = new UIView(new CGRect(0, 120, w, 500));
            bodyView.Layer.BorderWidth = 5;
            bodyView.BackgroundColor = UIColor.SystemGreenColor;

            wardrobeReviewLbl = new UILabel(new CGRect(50, 200, w - 100, 30));
            wardrobeReviewLbl.BackgroundColor = UIColor.SystemOrangeColor;
            bodyView.Add(wardrobeReviewLbl);

            addItemBtn = new UIButton(new CGRect(70, 250, w - 150, 50));
            addItemBtn.SetTitle("Save Item", UIControlState.Normal);
            bodyView.Add(addItemBtn);

            addItemBtn.TouchUpInside += AddItemClickAction;

            View.AddSubview(bodyView);

        }

        public void AddItemClickAction(object sender, EventArgs e)
        {
            Console.WriteLine("made it to Click Action");
        }
    }
}