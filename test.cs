using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Protocols;
using test3.com.netsuite.webservices;

namespace test3
{
    class Program
    {
        static void Main(string[] args)
        {
            // create objects for netsuite login
            NetSuiteService netsuite = new NetSuiteService();
            netsuite.CookieContainer = new System.Net.CookieContainer();
            Passport passport = new Passport();
            RecordRef role = new RecordRef();

            // hard code for administrator role 3
            role.externalId = "3";

            // latest NetSuite web services url
            netsuite.Url = "https://webservices.NETSUITE.com/services/NetSuitePort_2015_1";
            passport.account = "-";
            passport.email = "-";
            passport.password = "-";
            passport.role = role;

            Console.WriteLine("\nLogging into NetSuite ... ");
            Console.WriteLine("\nUsername: " + passport.email);
            Console.WriteLine("\nAccount: " + passport.account);

            // try loggin into web services
            Status status = netsuite.login(passport).status;

            Console.WriteLine("\nLogged in.");

            netsuite.logout();
            Console.WriteLine("\nLogged out.");

            Console.Read();
        }
    }
}
