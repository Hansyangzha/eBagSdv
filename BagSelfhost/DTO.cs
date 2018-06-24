using System;

namespace BagSelfhost
{
    public class clsBrand

    {

        public string brand_name { get; set; }

        public string brand_description { get; set; }

    }

    public class clsBag
    {

        public string bag_size { get; set; }

        public string bag_colour { get; set; }

        public string bag_name { get; set; }

        public string bag_brand_id { get; set; }

        public decimal bag_price { get; set; }

        public string bag_condition { get; set; }

        public string bag_warranty { get; set; }

        public char bag_catergory { get; set; }

    }

    public class clsOrder

    {
        public int order_id { get; set; }

        public string order_bag_id { get; set; }

        public decimal order_total { get; set; }

        public string order_name { get; set; }

        public string order_address { get; set; }

        public string order_phone { get; set; }

        public DateTime order_date { get; set; }
    }
}