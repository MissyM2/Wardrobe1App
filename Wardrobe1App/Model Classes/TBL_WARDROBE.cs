using System;
using SQLite;

namespace Wardrobe1App
{
    public class TBL_WARDROBE
    {

        [PrimaryKey, AutoIncrement]
        public int ItemID { get; set; }

        public string ItemType { get; set; }

        public string ItemDesc { get; set; }

        public string Size { get; set; }

        public DateTime? LastWorn { get; set; }
    }
}
