using System;
using SQLite;

namespace Wardrobe1App
{
    public class TBL_REPORTS
    {
        [PrimaryKey, AutoIncrement]
        public int ReportID { get; set; }

        public string ReportName { get; set; }

        public string ReportDesc { get; set; }
    }
}
