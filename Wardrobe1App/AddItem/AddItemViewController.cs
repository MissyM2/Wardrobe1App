using System;
using System.Drawing;
using CoreGraphics;
using UIKit;

namespace Wardrobe1App
{
    public partial class AddItemViewController : UIViewController
    {

        int h = (int)UIScreen.MainScreen.Bounds.Size.Height;
        int w = (int)UIScreen.MainScreen.Bounds.Size.Width;

        public TBL_WARDROBE wardrobeObj { get; set; }

        PickerModel itemTypePickerModel;
        UIPickerView itemTypePicker;
        int pickerSelection = 0;

        UIBarButtonItem nextButton;

        UIView headerView, bodyView;
        UILabel titleLbl, subtitleLbl, itemTypeLbl;

        public AddItemViewController() : base("AddItemViewController", null)
        {

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.NavigationItem.Title = "Item Type";
            nextButton = new UIBarButtonItem("Last Worn", UIBarButtonItemStyle.Plain, NextButtonClickAction);

            NavigationItem.SetRightBarButtonItem(nextButton, true);
            AddScreenLayout();
        }


        void AddScreenLayout()
        {
            // HEADER VIEW
            AddHeaderView();
            AddBodyView();
        }

        void AddHeaderView()
        {
            var screenWidth = (int)UIScreen.MainScreen.Bounds.Size.Width;

            headerView = new UIView(new CGRect(0, 20, w, 100));
            headerView.Layer.BorderWidth = 0;

            // create title and subtitle
            titleLbl = new UILabel(new CGRect(40, 60, w - 80, 22));
            titleLbl.BackgroundColor = UIColor.Clear;
            titleLbl.Font = UIFont.BoldSystemFontOfSize(18);
            titleLbl.Text = "Add Item";
            titleLbl.TextAlignment = UITextAlignment.Center;
            headerView.Add(titleLbl);

            subtitleLbl = new UILabel(new CGRect(25, 80, w - 50, 22));
            subtitleLbl.BackgroundColor = UIColor.Clear;
            subtitleLbl.Font = UIFont.BoldSystemFontOfSize(14);
            subtitleLbl.Text = "Select an item type and click next.";
            subtitleLbl.TextAlignment = UITextAlignment.Center;
            headerView.Add(subtitleLbl);

            View.AddSubview(headerView);
        }


        void AddBodyView()
        {
            bodyView = new UIView(new CGRect(0, 150, w, 500));
            bodyView.Layer.BorderWidth = 0;
            bodyView.BackgroundColor = UIColor.White;

            // initializing/instantiating label
            itemTypeLbl = new UILabel();

            // describe the control
            itemTypeLbl.Frame = new CGRect(50, 50, w - 100, 50);
            itemTypeLbl.TextAlignment = UITextAlignment.Center;
            itemTypeLbl.BackgroundColor = UIColor.SystemTealColor;
            itemTypeLbl.Layer.CornerRadius = 12;

            // add the control to the screen
            bodyView.Add(itemTypeLbl);

            // initializing/instantiating class (must be before control is added
            itemTypePickerModel = new PickerModel(itemTypeLbl);

            // instantiating the picker view control
            itemTypePicker = new UIPickerView();

            // set the frame as any other controller
            itemTypePicker.Frame = new RectangleF(50, 100, w - 100, 200);
            itemTypePicker.BackgroundColor = UIColor.SystemTealColor;

            // assign control to the model
            itemTypePicker.Model = itemTypePickerModel;

            // select initial item selected
            itemTypePicker.Select(pickerSelection, 0, true);

            // add control to the view
            bodyView.Add(itemTypePicker);

            View.AddSubview(bodyView);

        }

        //------------ Next Button Click Action ------------
        void NextButtonClickAction(object sender, EventArgs args)
        {
            var nextView = new AddLastWornViewController();
            nextView.wardrobeObj = itemTypePickerModel.wardrobeObj;
            //var nextView = new AddItemDetailsViewController();
            NavigationController.PushViewController(nextView, true);
        }

    }

    //-------------- PICKER CLASS ----------
    public class PickerModel: UIPickerViewModel
    {

        public TBL_WARDROBE wardrobeObj { get; set; }

        public string[] itemTypeAry = new string[]
        {
            "top",
            "bottom",
            "shoes",
            "outerwear"
        };

        private UILabel itemTypeLbl;

        public PickerModel(UILabel itemTypeLbl)
        {
            // variable from AddItemViewController is passed into PickerModel
            // this.itemTypeLbl says that it is available locally.
            this.itemTypeLbl = itemTypeLbl;
        }

        public override nint GetComponentCount(UIPickerView pickerView)
        {
            return 1;
        }

        public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
        {
            return itemTypeAry.Length;
        }

        public override string GetTitle(UIPickerView pickerView, nint row, nint component)
        {
            if (component == 0)
                return itemTypeAry[row];
            else
                return row.ToString();
        }

        public override void Selected(UIPickerView pickerView, nint row, nint component)
        {
            wardrobeObj = new TBL_WARDROBE();
               
                
            int rowNo = (int)pickerView.SelectedRowInComponent(0);
            string itemTypeStr = itemTypeAry[rowNo];
            itemTypeLbl.Text = itemTypeStr;
            wardrobeObj.ItemType = itemTypeStr;
            AddLastWornViewController addLastWornViewController = new AddLastWornViewController();
            addLastWornViewController.wardrobeObj = wardrobeObj;

            Console.WriteLine("itemTypeStr is " + itemTypeStr);
            Console.WriteLine("wardrobeObj.itemType is " + wardrobeObj.ItemType);
        }

        public override nfloat GetComponentWidth(UIPickerView pickerView, nint component)
        {
            return 240f;
        }

        public override nfloat GetRowHeight(UIPickerView pickerView, nint component)
        {
            return 40f;
        }

    }

}


