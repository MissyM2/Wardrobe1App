using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace Wardrobe1App
{
    public partial class AddLastWornViewController : UIViewController
    {
        int h = (int)UIScreen.MainScreen.Bounds.Size.Height;
        int w = (int)UIScreen.MainScreen.Bounds.Size.Width;


        // table
        public TBL_WARDROBE wardrobeObj { get; set; }

        // helper files
        CommonHelper commonHelper;

        // views
        UIView headerView;

        // date picker controls
        UIDatePicker picker;

        // other controls
        UILabel titleLbl, subtitleLbl, dateShowLbl;
        UIBarButtonItem nextButton, prevButton;
        public AddLastWornViewController() : base("AddLastWornViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            commonHelper = new CommonHelper();
            this.NavigationItem.Title = "Last Worn Date";

            // create next button
            nextButton = new UIBarButtonItem("Other Details", UIBarButtonItemStyle.Plain, NextButtonClickAction);
            NavigationItem.SetRightBarButtonItem(nextButton, true);

            // create previous button
            prevButton = new UIBarButtonItem("ItemType", UIBarButtonItemStyle.Plain, PrevButtonClickAction);
            NavigationItem.SetLeftBarButtonItem(prevButton, true);


            var calendar = new NSCalendar(NSCalendarType.Gregorian);
            var currentDate = NSDate.Now;
            var components = new NSDateComponents();

            components.Year = -60;

            NSDate minDate = calendar.DateByAddingComponents(components, NSDate.Now, NSCalendarOptions.None);
            Console.WriteLine("ViewDidLoad, before AddScreenLayout wardrobeObj" + wardrobeObj.ItemType);



            AddScreenLayout();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        //---------------------- Previous Button Click Action ----------------
        private void PrevButtonClickAction(object sender, EventArgs e)
        {
            var prevView = new AddItemViewController();
            NavigationController.PushViewController(prevView, true);
        }

        //----------------- Next Button Click Action ---------------
        void NextButtonClickAction(object sender, EventArgs args)
        {
            var nextView = new AddItemDetailsViewController();
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
            titleLbl.Text = "Add Date Last Worn";
            titleLbl.TextAlignment = UITextAlignment.Center;
            headerView.Add(titleLbl);

            subtitleLbl = new UILabel(new CGRect(25, 80, w - 50, 22));
            subtitleLbl.BackgroundColor = UIColor.Clear;
            subtitleLbl.Font = UIFont.BoldSystemFontOfSize(16);
            subtitleLbl.Text = "Select date that you last wore the item and click next.";
            subtitleLbl.TextAlignment = UITextAlignment.Center;
            headerView.Add(subtitleLbl);

            View.AddSubview(headerView);
        }

        // --------------------- What if Date or Time Changes ------------------
        void DateTimeChanged(UIDatePicker sender)
        {
            // Formatting for Date
            NSDateFormatter dateFormat = new NSDateFormatter();
            dateFormat.DateFormat = "yyyy-MM-dd";

            // Formatting for Time
            NSDateFormatter timeFormat = new NSDateFormatter();
            timeFormat.TimeStyle = NSDateFormatterStyle.Short;

            // Formatting for Date and Time
            NSDateFormatter dateTimeformat = new NSDateFormatter();
            dateTimeformat.DateStyle = NSDateFormatterStyle.Long;
            dateTimeformat.TimeStyle = NSDateFormatterStyle.Short;

        }


        void AddBodyView()
        {
            var bodyView = new UIView(new CGRect(0, 150, w, 500));
            bodyView.BackgroundColor = UIColor.Green;
            bodyView.Layer.BorderWidth = 0;
            var screenWidth = (int)UIScreen.MainScreen.Bounds.Size.Width;

            picker = new UIDatePicker(new CGRect(10, 150, 300, 250));
            picker.PreferredDatePickerStyle = UIDatePickerStyle.Wheels;
            picker.Mode = UIDatePickerMode.DateAndTime;
            picker.MinuteInterval = 15;

            picker.ValueChanged += delegate (object sender, EventArgs e)
            {
                DateTime selectedDate = (DateTime)(sender as UIDatePicker).Date;
                wardrobeObj.LastWorn = selectedDate;
                Console.WriteLine("wardrobeObj.LastWorn " + wardrobeObj.LastWorn);
                dateShowLbl.Text = wardrobeObj.LastWorn.Value.ToString("ddd, MM/dd/yyyy hh:mm tt");
            };

            bodyView.Add(picker);

            dateShowLbl = new UILabel();
            dateShowLbl.Frame = new CGRect(30, 50, w - 60, 30);
            dateShowLbl.BackgroundColor = UIColor.SystemPinkColor;
            dateShowLbl.Text = "";
            dateShowLbl.TextAlignment = UITextAlignment.Center;
            dateShowLbl.BackgroundColor = UIColor.LightGray;
            dateShowLbl.Layer.CornerRadius = 12;
            dateShowLbl.Font = commonHelper.TextFont;
            bodyView.Add(dateShowLbl);

            View.AddSubview(bodyView);



        }
    }
}

