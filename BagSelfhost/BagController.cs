using System;
using System.Collections.Generic;
using System.Data;


namespace BagSelfhost
{
    public class BagController : System.Web.Http.ApiController
    {
        public List<clsBrand> GetBagBrands()
        {
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT * FROM Bag_brand", null);
            List<clsBrand> lcNames = new List<clsBrand>();
            foreach (DataRow dr in lcResult.Rows)
            {
                clsBrand b = new clsBrand();
                b.brand_name = (string)dr["bag_brand"];
                b.brand_description = (string)dr["bag_description"];
                lcNames.Add(b);
            }
            return lcNames;
        }

        public List<clsBag> GetBrandBags(string b)
        { 
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT * FROM Bag WHERE bag_brand_id = '" + b + "'", null); ;
            List<clsBag> lcNames = new List<clsBag>();
            foreach (DataRow dr in lcResult.Rows)
            {
                clsBag bb = new clsBag();
                bb.bag_name = (string)dr["bag_name"];
                bb.bag_price = Convert.ToDecimal(dr["bag_price"].ToString());
                bb.bag_colour = (string)dr["bag_colour"];
                bb.bag_size = (string)dr["bag_size"];
                bb.bag_brand_id = (string)dr["bag_brand_id"];
                bb.bag_catergory = Convert.ToChar(dr["bag_catergory"]);
                if (!string.IsNullOrEmpty((string)dr["bag_condition"]))
                    bb.bag_condition = (string)dr["bag_condition"];
                if (!string.IsNullOrEmpty((string)dr["bag_warranty"]))
                    bb.bag_warranty = (string)dr["bag_warranty"];
                lcNames.Add(bb);
            }
            return lcNames;
        }

        public List<clsOrder> GetAllOrders()
        {
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT * FROM Orders", null); ;
            List<clsOrder> lcNames = new List<clsOrder>();
            foreach (DataRow dr in lcResult.Rows)
            {
                clsOrder bb = new clsOrder();
                bb.order_id = (int)dr["order_id"];
                bb.order_bag_id = (string)dr["order_bag_id"];
                bb.order_total = Convert.ToDecimal(dr["order_total"].ToString());
                bb.order_name = (string)dr["order_name"];
                bb.order_address = (string)dr["order_address"];
                bb.order_phone = (string)dr["order_phone"];
                bb.order_date = Convert.ToDateTime(dr["order_date"]);
                lcNames.Add(bb);
            }
            return lcNames;
        }

        public string PutBrand(clsBrand prBrand)
        {   // update
            try
            {
                int lcRecCount = clsDbConnection.Execute(
        "UPDATE Bag_brand SET bag_description = @brand_description WHERE bag_brand = @brand_name",
        prepareBrandParameters(prBrand));
                if (lcRecCount == 1)
                    return "One Brand updated";
                else
                    return "Unexpected Brand update count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        public string DeleteBag(string Name)
        {   // delete
            try
            {
                int lcRecCount = clsDbConnection.Execute(
        "DELETE FROM Bag WHERE bag_name='" + Name + "'", null);
                if (lcRecCount == 1)
                    return "One Bag deleted";
                else
                    return "Unexpected Bag delete count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        public string DeleteOrder(int ID)
        {   // delete
            try
            {
                int lcRecCount = clsDbConnection.Execute(
        "DELETE FROM Orders WHERE order_id=" + ID.ToString(), null);
                if (lcRecCount == 1)
                    return "One Order deleted";
                else
                    return "Unexpected Order delete count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        public string DeleteBrand(string Name)
        {   // delete
            try
            {
                int lcRecCount = clsDbConnection.Execute(
        "DELETE FROM Bag_brand WHERE bag_brand='" + Name + "'", null);
                if (lcRecCount == 1)
                    return "One Brand deleted";
                else
                    return "Unexpected Brand delete count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        public string PostBrand(clsBrand prBrand)
        {   // insert
            try
            {
                int lcRecCount = clsDbConnection.Execute(
        "Insert Into Bag_brand Values(@brand_name, @brand_description)",
        prepareBrandParameters(prBrand));
                if (lcRecCount == 1)
                    return "One Brand inserted";
                else
                    return "Unexpected Brand insert count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        private Dictionary<string, object> prepareBrandParameters(clsBrand prBrand)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(3);
            par.Add("brand_name", prBrand.brand_name);
            par.Add("brand_description", prBrand.brand_description);
            return par;
        }

        public string PutBag(clsBag prBag)
        {   // update
            try
            {
                int lcRecCount = clsDbConnection.Execute("UPDATE Bag SET " +
                "bag_price = @bag_price, bag_condition = @bag_condition, bag_warranty = @bag_warranty " +
                "WHERE bag_name=@bag_name",
                prepareBagParameters(prBag));
                if (lcRecCount == 1)
                    return "One Bag updated";
                else
                    return "Unexpected Bag update count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        public string PostBag(clsBag prBag)
        {   // insert
            try
            {
                int lcRecCount = clsDbConnection.Execute("INSERT INTO Bag " +
                "VALUES (@bag_name, @bag_price, @bag_colour, @bag_size, @bag_brand_id, @bag_condition, @bag_warranty, @bag_catergory)",
                prepareBagParameters(prBag));
                if (lcRecCount == 1)
                    return "One Bag inserted";
                else
                    return "Unexpected Bag insert count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        private Dictionary<string, object> prepareBagParameters(clsBag prBag)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(10);
            par.Add("bag_name", prBag.bag_name);
            par.Add("bag_price", prBag.bag_price);
            par.Add("bag_colour", prBag.bag_colour);
            par.Add("bag_size", prBag.bag_size);
            par.Add("bag_brand_id", prBag.bag_brand_id);
            par.Add("bag_condition", prBag.bag_condition);
            par.Add("bag_warranty", prBag.bag_warranty);
            par.Add("bag_catergory", prBag.bag_catergory);
            return par;
        }
    }
}