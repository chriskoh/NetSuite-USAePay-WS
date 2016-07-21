using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Protocols;
using NetSuiteTest.com.netsuite.webservices;

namespace NetSuiteTest
{
    class Program
    {
        static void Main(string[] args)
        {
            NetSuiteService service = new NetSuiteService();
            service.CookieContainer = new System.Net.CookieContainer();

            //invoke the login operation
            Passport passport = new Passport();
            passport.account = "TSTDRV96"; // replace with NS account number
            passport.email = "username@netsuite.com"; // replace with login
            RecordRef role = new RecordRef();
            role.internalId = "3"; // roles: 3 == admin
            passport.role = role;
            passport.password = "mypassword"; // replace with account password
            Status status = service.login(passport).status;
            Console.Write("Logging In");

            // create a customer
            Customer cust = new Customer();
            cust.entityID( “XYZ Inc” );
            WriteResponse response = service.add(cust);
            Console.Write("Creating Customer");

            // logout
            service.logout();
            Console.Write("Logout");

            // leave console open debugging
            Console.Read();
        }
    }
}
