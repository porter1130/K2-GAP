using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SourceCode.SmartObjects.Client;
using SourceCode.Hosting.Client.BaseAPI;

namespace ConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {

            SmartObjectClientServer server = new SmartObjectClientServer();



            try
            {

                SCConnectionStringBuilder cb = new SCConnectionStringBuilder();

                cb.Host = "DLX";

                cb.Port = 5555;

                cb.Integrated = true;

                cb.IsPrimaryLogin = true;



                //Connect to server

                server.CreateConnection();

                server.Connection.Open(cb.ToString());







                //--------------------------

                //Get the Employee

                //Get SmartObject Definition

                SmartObject employee = server.GetSmartObject("Employee");



                //Set properties

                employee.Properties["ID"].Value = "2";



                //Get the record

                employee.MethodToExecute = "FindEmployee";

                server.ExecuteScalar(employee);



                System.Diagnostics.Trace.WriteLine(

                    employee.Properties["FirstName"].Value);



                System.Diagnostics.Trace.WriteLine(

                    employee.Properties["LastName"].Value);



                System.Diagnostics.Trace.WriteLine(

                    employee.Properties["Email"].Value);





            }

            catch (Exception ex)
            {

                throw new Exception("Error Creating Request >> " + ex.Message);

            }

        }
    }
}
