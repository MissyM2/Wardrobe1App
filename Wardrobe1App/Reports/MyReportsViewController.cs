//******************* Wardrobe App ****************
// <APP VERSION>1.0</APP VERSION>
// <AUTHOR>Missy Maloney</AUTHOR>
// <DATE>04/30/2021 </DATE>
// <SUMMARY> </SUMMARY>
//*************************************************
using System;
using System.Collections.Generic;
using System.Drawing;
using CoreGraphics;
using Foundation;
using UIKit;

namespace Wardrobe1App
{
    public partial class MyReportsViewController : UIViewController
    {
        UIView headerView;
        UITableView tableView;

        SqliteCipherHelper databaseHelper;

        UILabel titleLbl, subtitleLbl;

        int h = (int)UIScreen.MainScreen.Bounds.Size.Height;
        int w = (int)UIScreen.MainScreen.Bounds.Size.Width;

        private List<TBL_REPORTS> reportsList = new List<TBL_REPORTS>();


        public MyReportsViewController() : base("MyReportsViewController", null)
        {
            databaseHelper = new SqliteCipherHelper();
            string titleName = "View Wardrobe Reports";
            Title = NSBundle.MainBundle.GetLocalizedString(titleName, titleName);

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            databaseHelper.CheckDatabase();

            CreateScreenLayout();
        }

        public void CreateScreenLayout()
        {
            headerView = new UIView(new CGRect(0, 20, w, 100));
            headerView.Layer.BorderWidth = 0;

            // create title and subtitle
            titleLbl = new UILabel(new CGRect(40, 40, w - 80, 22));
            titleLbl.BackgroundColor = UIColor.Clear;
            titleLbl.Font = UIFont.BoldSystemFontOfSize(18);
            titleLbl.Text = "My Reports";
            titleLbl.TextAlignment = UITextAlignment.Center;
            headerView.Add(titleLbl);

            subtitleLbl = new UILabel(new CGRect(40, 60, w - 80, 22));
            subtitleLbl.BackgroundColor = UIColor.Clear;
            subtitleLbl.Font = UIFont.BoldSystemFontOfSize(14);
            subtitleLbl.Text = "select a report";
            subtitleLbl.TextAlignment = UITextAlignment.Center;
            headerView.Add(subtitleLbl);

            View.Add(headerView);

            List<TBL_REPORTS> reportsList = new List<TBL_REPORTS>();
            reportsList = databaseHelper.GetAllFromTblReports();

            tableView = new UITableView(View.Bounds);
            tableView.Source = new ReportSource(this, reportsList);

            View.Add(tableView);

        }

    }


    public class ReportSource : UITableViewSource
    {
        static readonly NSString CellIdentifier = new NSString("DataSourceCell");

        MyReportsViewController controller;
        SqliteCipherHelper databaseHelper;
        MessageManager messageManager;
        SettingsController settingsController;

        private List<TBL_REPORTS> _reportsList = new List<TBL_REPORTS>();

        public ReportSource(MyReportsViewController rptcontroller, List<TBL_REPORTS> reportsList)
        {
            controller = rptcontroller;
            //databaseHelper = new SqliteCipherHelper();
            settingsController = new SettingsController();
            messageManager = new MessageManager();
            _reportsList = reportsList;
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            return 1;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            int rows = 0;
            rows = _reportsList.Count;

            return rows;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(CellIdentifier);
            cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier);
            cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;

            if (_reportsList.Count > 0)
            {
                TBL_REPORTS values = _reportsList[indexPath.Row];

                UILabel typeLbl = new UILabel();
                typeLbl.Text = values.ReportName;
                typeLbl.Frame = new RectangleF(10, 5, 100, 30);
                typeLbl.BackgroundColor = UIColor.SystemGray2Color;
                typeLbl.TextColor = UIColor.Black;
                cell.ContentView.AddSubview(typeLbl);

                UILabel descLbl = new UILabel();
                descLbl.Text = values.ReportDesc;
                descLbl.Frame = new RectangleF(115, 5, 175, 30);
                descLbl.BackgroundColor = UIColor.SystemBlueColor;
                descLbl.TextColor = UIColor.Black;
                cell.ContentView.AddSubview(descLbl);
            }
            else
            {
                Console.WriteLine("there were no rows to show");

            }

            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            if (indexPath.Row == 1 && indexPath.Section == 0)
            {
                MessageManager messageManager = new MessageManager();
                AlertViewController alertView = new AlertViewController();
                alertView.ShowAlertBox(settingsController.GetAppName(), messageManager.TestMessage, false, "", "OK", false, "", controller);
            }
        }

        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return 90f;
        }

    }
}



