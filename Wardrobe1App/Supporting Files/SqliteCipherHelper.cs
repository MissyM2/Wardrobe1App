//******************* Wardrobe App ****************
// <APP VERSION>1.0</APP VERSION>
// <AUTHOR>Missy Maloney</AUTHOR>
// <DATE>04/30/2021 </DATE>
// <SUMMARY> </SUMMARY>
//*************************************************

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using SQLite;

namespace Wardrobe1App
{
    public class SqliteCipherHelper
    {
        private string _pathToDatabase;

        public SqliteCipherHelper()
        {
            string databaseName = "myWardrobeDb.db";

            // Create database
            CommonHelper commonHelper = new CommonHelper();
            var documents = commonHelper.EnvironmentFolderPath;
            _pathToDatabase = Path.Combine(documents, databaseName);
            Console.WriteLine("_path", _pathToDatabase);
            CheckDatabase();
        }

        public void CheckDatabase()
        {
            if (File.Exists(_pathToDatabase))
            {
                Debug.WriteLine("CheckDatabase (MyWardrobeDB.db) YES");
                CreateDatabase();
                PopulateWardrobe();
                PopulateReports();
            }
            else
            {
                Console.WriteLine("Database does not exist.  Now creating and populatig");
                //CreateDatabase();
                //PopulateWardrobe();
                //PopulateReports();
            }
        }

        //------------------- GET SQLITE CONNECTION STRING ------------------
        public SQLiteConnection GetConnectionString()
        {
            SQLiteConnection conn = new SQLite.SQLiteConnection(_pathToDatabase);
            return conn;
        }

        public void CreateDatabase()
        {
            Console.WriteLine("inside Create database");
            var conn = GetConnectionString();
            using (conn)
            {
                conn.CreateTable<TBL_WARDROBE>();
                Console.WriteLine("TBL_WARDROBE should be created",conn.Table<TBL_WARDROBE>().ToString());
                conn.CreateTable<TBL_REPORTS>();
                Console.WriteLine("TBL_REPORTS should be created");
            }
        }

        public void PopulateWardrobe()
        {

            DeleteAllFromTblWardrobe();
            var row1 = new TBL_WARDROBE { ItemType = "shirt", ItemDesc = "white short-sleeved", Size = "8", LastWorn = Convert.ToDateTime("03/14/2021") };
            var row2 = new TBL_WARDROBE { ItemType = "pants", ItemDesc = "navy long dress", Size = "6", LastWorn = Convert.ToDateTime("10/20/2020") };
            var row3 = new TBL_WARDROBE { ItemType = "dress", ItemDesc = "green mini-dress", Size = "8", LastWorn = Convert.ToDateTime("01/15/2016") };
            var row4 = new TBL_WARDROBE { ItemType = "shirt", ItemDesc = "silk blouse peach", Size = "10", LastWorn = Convert.ToDateTime("03/14/2021") };
            var row5 = new TBL_WARDROBE { ItemType = "dress", ItemDesc = "floral tea length", Size = "8", LastWorn = Convert.ToDateTime("06/25/2019") };
            var row6 = new TBL_WARDROBE { ItemType = "pants", ItemDesc = "twill shorts", Size = "6", LastWorn = Convert.ToDateTime("04/20/2021") };

            using (var db = GetConnectionString())
            {
                db.Insert(row1);
                db.Insert(row2);
                db.Insert(row3);
                db.Insert(row4);
                db.Insert(row5);
                db.Insert(row6);
            }

        }

        public void PopulateReports()
        {
            DeleteAllFromTblReports();
            var row1 = new TBL_REPORTS { ReportName = "DelWar", ReportDesc = "Delete all items in your wardrobe." };
            var row2 = new TBL_REPORTS { ReportName = "Show All", ReportDesc = "Show entire wardrobe." };
            var row3 = new TBL_REPORTS { ReportName = "query3", ReportDesc = "This is desc for q3" };
            var row4 = new TBL_REPORTS { ReportName = "query4", ReportDesc = "This is desc for q4" };
            
            using (var db = GetConnectionString())
            {
                db.Insert(row1);
                db.Insert(row2);
                db.Insert(row3);
                db.Insert(row4);
            }

        }

        public List<TBL_WARDROBE> GetAllFromTblWardrobe()
        {
            var conn = GetConnectionString();
            List<TBL_WARDROBE> wardrobeList = new List<TBL_WARDROBE>();

            wardrobeList = conn.Table<TBL_WARDROBE>().ToList();

            foreach (var item in wardrobeList)
            {
                Console.WriteLine(item.ItemType + ", " + item.ItemDesc + ", " + item.Size + ", " + item.LastWorn);
            }

            return wardrobeList;

        }

        public List<TBL_REPORTS> GetAllFromTblReports()
        {
            var conn = GetConnectionString();
            List<TBL_REPORTS> reportsList = new List<TBL_REPORTS>();

            reportsList = conn.Table<TBL_REPORTS>().ToList();

            foreach (var item in reportsList)
            {
                Console.WriteLine(item.ReportName + ", " + item.ReportDesc);
            }

            return reportsList;

        }

        public List<TBL_REPORTS> DeleteAllFromTblReports()
        {
            var conn = GetConnectionString();
            List<TBL_REPORTS> reportsList = new List<TBL_REPORTS>();

            reportsList = conn.Table<TBL_REPORTS>().ToList();

            foreach (var item in reportsList)
            {
                Console.WriteLine(item.ReportName + ", " + item.ReportDesc + " has been deleted.");
                conn.Delete(item);
            }

            return reportsList;

        }

        public List<TBL_WARDROBE> DeleteAllFromTblWardrobe()
        {
            var conn = GetConnectionString();
            List<TBL_WARDROBE> reportsList = new List<TBL_WARDROBE>();

            reportsList = conn.Table<TBL_WARDROBE>().ToList();

            foreach (var item in reportsList)
            {
                Console.WriteLine(item.ItemType + ", " + item.ItemDesc + " has been deleted.");
                conn.Delete(item);
            }

            return reportsList;

        }
    }
}
