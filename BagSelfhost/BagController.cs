using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace ConsoleApplication1
{
    public class BagController : System.Web.Http.ApiController
    {
        public List<string> GetBagBrands()
        {
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT bag_brand FROM Bag_brand", null);
            List<string> lcNames = new List<string>();
            foreach (DataRow dr in lcResult.Rows) lcNames.Add((string)dr[0]);
            return lcNames;
        }


    }
}