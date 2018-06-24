using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;
using static System.Net.WebRequestMethods;

namespace BagSelfhost
{
    class Program
    {
        public static object Route { get; private set; }

        static void Main(string[] args)
        {// Set up server configuration

            Uri _baseAddress = new Uri("http://localhost:60064/");

            HttpSelfHostConfiguration config = new HttpSelfHostConfiguration(_baseAddress);

            config.Routes.MapHttpRoute(

            name: "DefaultApi",

            routeTemplate: "api/{controller}/{action}/{id}",

            defaults: new { id = RouteParameter.Optional }

            );

            // Create server

            HttpSelfHostServer server = new HttpSelfHostServer(config);

            // Start listening

            server.OpenAsync().Wait();

            Console.WriteLine("eBag Web-API Self hosted on " + _baseAddress);

            Console.WriteLine("Hit ENTER to exit...");

            Console.ReadLine();

            server.CloseAsync().Wait();
        }
    }
}
