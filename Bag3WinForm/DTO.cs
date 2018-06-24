using System;

namespace Bag3WinForm
{

    public class clsBrand

    {

        public string brand_name { get; set; }

        public string brand_description { get; set; }
        public override string ToString()
        {
            return brand_name;
        }
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

        public static readonly string FACTORY_PROMPT = "Enter U for Used old bag, N for New bag!?";

        public override string ToString()
        {
            return bag_catergory.ToString() + " \t " + bag_name + " \t " + bag_size + " \t $" + bag_price.ToString();
        }

        public static clsBag NewWork(char prChoice)
        {
            return new clsBag() { bag_catergory = Char.ToUpper(prChoice) };
        }
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

        public override string ToString()
        {
            return order_id.ToString() + " \t " + order_name + " \t " + order_date.ToShortDateString() + " \t $" + order_total.ToString();
        }

        public string AllInfo()
        {
            return " Order ID: " + order_id.ToString() + " \n g: " + order_bag_id + " \n g: " + order_name + " \n g: " + order_address + " \n g: " + order_phone + " \n g: " + order_date.ToShortDateString() + " \n g: $" + order_total.ToString();
        }
    }
}