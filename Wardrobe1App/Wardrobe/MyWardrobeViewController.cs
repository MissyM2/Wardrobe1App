//******************* Wardrobe App ****************
// <APP VERSION>1.0</APP VERSION>
// <AUTHOR>Missy Maloney</AUTHOR>
// <DATE>04/30/2021 </DATE>
// <SUMMARY> </SUMMARY>
//*************************************************

using System;
using System.Drawing;

using Foundation;
using UIKit;
using System.Collections.Generic;
using System.Linq;
using CoreGraphics;

namespace Wardrobe1App
{
    public partial class MyWardrobeViewController : UIViewController
    {

        UIView headerView;
        UITableView table;

        // passing a variable
        // declare a public variable: TestVar
        // get/set
        // where I call the view (My
        public string rptName { get; set; }
        public string rptDesc { get; set; }

        SqliteCipherHelper databaseHelper;

        UILabel titleLbl, subtitleLbl;

        int h = (int)UIScreen.MainScreen.Bounds.Size.Height;
        int w = (int)UIScreen.MainScreen.Bounds.Size.Width;

        private List<TBL_WARDROBE> wardrobeList = new List<TBL_WARDROBE>();

        public MyWardrobeViewController() : base("MyWardrobeViewController", null)
        {
            databaseHelper = new SqliteCipherHelper();
            string titleName = "View Wardrobe";
            Title = NSBundle.MainBundle.GetLocalizedString(titleName, titleName);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
           
            AddScreenLayout();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        
        public void AddScreenLayout()
        {
            Console.WriteLine("rptName/Desc:" + rptName + rptDesc);

            headerView = new UIView(new CGRect(0, 20, w, 100));
            headerView.Layer.BorderWidth = 0;

            // create title and subtitle
            titleLbl = new UILabel(new CGRect(40, 60, w - 80, 22));
            titleLbl.BackgroundColor = UIColor.Clear;
            titleLbl.Font = UIFont.BoldSystemFontOfSize(18);
            titleLbl.Text = rptName;
            titleLbl.TextAlignment = UITextAlignment.Center;
            headerView.Add(titleLbl);

            subtitleLbl = new UILabel(new CGRect(25, 80, w - 50, 22));
            subtitleLbl.BackgroundColor = UIColor.Clear;
            subtitleLbl.Font = UIFont.BoldSystemFontOfSize(14);
            subtitleLbl.Text = rptDesc;
            subtitleLbl.TextAlignment = UITextAlignment.Center;
            headerView.Add(subtitleLbl);

            View.Add(headerView);
            List<TBL_WARDROBE> wardrobeList = new List<TBL_WARDROBE>();
            wardrobeList = databaseHelper.GetAllFromTblWardrobe();
            this.View.BackgroundColor = UIColor.SystemIndigoColor;

            //table = new UITableView(View.Bounds);
            table = new UITableView(new CGRect(0, 150, w, 450));
            table.Source = new WardrobeSource(this, wardrobeList);
            Add(table);
        }
    }
        

    public class WardrobeSource : UITableViewSource
        {
            static readonly NSString CellIdentifier = new NSString("DataSourceCell");

            MyWardrobeViewController controller;
            //CommonHelper commonHelper;
            SqliteCipherHelper databaseHelper;
            MessageManager messageManager;

            int h = (int)UIScreen.MainScreen.Bounds.Size.Height;
            int w = (int)UIScreen.MainScreen.Bounds.Size.Width;

            private List<TBL_WARDROBE> _wardrobeList = new List<TBL_WARDROBE>();

            public WardrobeSource(MyWardrobeViewController wardcontroller, List<TBL_WARDROBE> wardrobeList)
            {
                controller = wardcontroller;
                //commonHelper = new CommonHelper();
                //messageManager = new MessageManager();

                _wardrobeList = wardrobeList;

                //this.controller.TableView.ReloadData();
            }

            // Customize the table
            public override nint NumberOfSections(UITableView tableView)
            {
                return 1;
            }

            public override nint RowsInSection(UITableView tableview, nint section)
            {
                int rows = 0;
                if (_wardrobeList.Count == 0)
                {
                    rows = 1;
                }
                else
                {
                    rows = _wardrobeList.Count;
                }
                return rows;
            }

            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                var cell = tableView.DequeueReusableCell(CellIdentifier);

                cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier);
                cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;

                if (_wardrobeList.Count > 0)
                {
                    TBL_WARDROBE values = _wardrobeList[indexPath.Row];

                    UILabel typeLbl = new UILabel();
                    typeLbl.Frame = new RectangleF(20, 5, 95, 30);
                    typeLbl.BackgroundColor = UIColor.Clear;
                    typeLbl.Text = values.ItemType;
                    //typeLbl.Font = commonHelper.BoldTextFont;
                    cell.ContentView.AddSubview(typeLbl);


                    UILabel descLbl = new UILabel();
                    descLbl.Frame = new RectangleF(115, 5, w - 155, 30);
                    descLbl.BackgroundColor = UIColor.Clear;
                    descLbl.Text = values.ItemDesc;
                    //descLbl.Font = commonHelper.TextFont;
                    cell.ContentView.AddSubview(descLbl);

                    UILabel lastWornLbl = new UILabel();
                    lastWornLbl.Frame = new RectangleF(20f, 35f, 314, 25f);
                    lastWornLbl.BackgroundColor = UIColor.Clear;
                    lastWornLbl.Text = (values.LastWorn).ToString();
                    //lastWornLbl.Font = commonHelper.TextFont;
                    cell.ContentView.AddSubview(lastWornLbl);

                }
                else
                {
                    cell.TextLabel.Text = messageManager.NoResultMessage;
                    //cell.TextLabel.Font = commonHelper.TextFont;
                    cell.TextLabel.TextAlignment = UITextAlignment.Center;
                    cell.Accessory = UITableViewCellAccessory.None;
                }

                return cell;
            }

            public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
            {
                if (_wardrobeList.Count > 0)
                {
                    TBL_WARDROBE wardrobeItem = _wardrobeList[indexPath.Row];
                }
            }

            public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
            {
                return 90f;
            }
        }
}