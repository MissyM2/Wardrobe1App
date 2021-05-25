using System;
using CoreGraphics;
using UIKit;

namespace Wardrobe1App
{
    public partial class AddItemDetailsViewController : UIViewController
    {

        int h = (int)UIScreen.MainScreen.Bounds.Size.Height;
        int w = (int)UIScreen.MainScreen.Bounds.Size.Width;

        // table
        public TBL_WARDROBE wardrobeObj { get; set; }

        // views used in this class
        UIView headerView, bodyView;

        // other controls
        UIBarButtonItem nextButton, prevButton;

        UILabel titleLbl, subtitleLbl;
        UITextField itemDescField, itemSizeField, itemColorField;

        public AddItemDetailsViewController() : base("AddItemDetailsViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.NavigationItem.Title = "Other Details";

            // create next button
            nextButton = new UIBarButtonItem("Save Item", UIBarButtonItemStyle.Plain, NextButtonClickAction);
            NavigationItem.SetRightBarButtonItem(nextButton, true);

            // create previous button
            prevButton = new UIBarButtonItem("Last Worn", UIBarButtonItemStyle.Plain, PrevButtonClickAction);
            NavigationItem.SetLeftBarButtonItem(prevButton, true);

            // layout the screen
            AddScreenLayout();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        //---------------------- Previous Button Click Action ----------------
        private void PrevButtonClickAction(object sender, EventArgs e)
        {
            var prevView = new AddLastWornViewController();
            NavigationController.PushViewController(prevView, true);
        }

        //---------------------- Next Button Click Action ----------------

        private void NextButtonClickAction(object sender, EventArgs e)
        {
            var nextView = new AddSaveItemViewController();
            nextView.wardrobeObj = wardrobeObj;
            NavigationController.PushViewController(nextView, true);
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
            titleLbl.Text = "Add Item Details";
            titleLbl.TextAlignment = UITextAlignment.Center;
            headerView.Add(titleLbl);

            subtitleLbl = new UILabel(new CGRect(25, 80, w - 50, 22));
            subtitleLbl.BackgroundColor = UIColor.Clear;
            subtitleLbl.Font = UIFont.BoldSystemFontOfSize(14);
            subtitleLbl.Text = "Enter all item details.";
            subtitleLbl.TextAlignment = UITextAlignment.Center;
            headerView.Add(subtitleLbl);

            View.AddSubview(headerView);

        }

        void AddBodyView()
        {
            itemDescField = new UITextField(new CGRect(50, 200, w - 100, 30));
            itemDescField.Placeholder = "Item description";
            itemDescField.Text = "";
            itemDescField.BorderStyle = UITextBorderStyle.RoundedRect;
            subtitleLbl.Font = UIFont.BoldSystemFontOfSize(16);
            itemDescField.BackgroundColor = UIColor.White;
            itemDescField.EditingDidBegin += (object sender, EventArgs e) =>
            {
                wardrobeObj.ItemDesc = itemDescField.Text;
                Console.WriteLine("Editing did beginwardrobeObj.ItemDesc " + wardrobeObj.ItemDesc);
                Console.WriteLine("Editing did beginitemDescField.Text " + itemDescField.Text);
            };

            itemDescField.EditingDidEnd += (object sender, EventArgs e) =>
            {
                wardrobeObj.ItemDesc = itemDescField.Text;
                Console.WriteLine("Editing didend wardrobeObj.ItemDesc " + wardrobeObj.ItemDesc);
                Console.WriteLine("Editing didend itemDescField.Text " + itemDescField.Text);

            };

            View.AddSubview(itemDescField);

            itemSizeField = new UITextField(new CGRect(50, 250, w - 100, 30));
            itemSizeField.Placeholder = "Size";
            itemSizeField.BorderStyle = UITextBorderStyle.RoundedRect;
            subtitleLbl.Font = UIFont.BoldSystemFontOfSize(16);
            itemSizeField.BackgroundColor = UIColor.White;
            itemSizeField.EditingDidBegin += (object sender, EventArgs e) =>
            {
                wardrobeObj.Size = itemSizeField.Text;
                Console.WriteLine("wardrobeObj.Size " + wardrobeObj.Size);
            };
            itemSizeField.EditingDidEnd += (object sender, EventArgs e) =>
            {
                wardrobeObj.Size = itemSizeField.Text;
                Console.WriteLine("wardrobeObj.Size " + wardrobeObj.Size);
            };
            View.AddSubview(itemSizeField);

            itemColorField = new UITextField(new CGRect(50, 300, w - 100, 30));
            itemColorField.Placeholder = "Color";
            itemColorField.BorderStyle = UITextBorderStyle.RoundedRect;
            itemColorField.Font = UIFont.BoldSystemFontOfSize(16);
            itemColorField.BackgroundColor = UIColor.White;
            itemColorField.EditingDidBegin += (object sender, EventArgs e) =>
            {
                wardrobeObj.Color = itemColorField.Text;
                Console.WriteLine("wardrobeObj.Color " + wardrobeObj.Color);
                Console.WriteLine("itemColorField.Text " + itemColorField.Text);
            };
            itemColorField.EditingDidEnd += (object sender, EventArgs e) =>
            {
                wardrobeObj.Color = itemColorField.Text;
                Console.WriteLine("wardrobeObj.Color " + wardrobeObj.Color);
                Console.WriteLine("wardrobeObj whole objecct" + wardrobeObj);
            };
            View.AddSubview(itemColorField);
        }

    }
}

