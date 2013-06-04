using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SourceCode.SmartObjects.Services.ServiceSDK.Attributes;
using SourceCode.SmartObjects.Services.ServiceSDK.Types;

namespace McDonald.GAP.K2.Service
{
    [ServiceObject("EmployeeServiceObject",
         "Employee Service Object",
         "This is a test Employee Service Object.")]
    public class Employee
    {
        #region attributes

        private string _databaseConnection = "";

        private int _employeeNumber;
        private string _department = "";
        private string _firstName = "";
        private string _lastName = "";
        private string _email = "";
        private string _manager = "";
        #endregion


        #region properties

        [Property("EmployeeNumber", SoType.Number,

            "Employee Number", "Employee Number of employee")]

        public int EmployeeNumber
        {

            get
            {

                return _employeeNumber;

            }

            set
            {

                _employeeNumber = value;

            }

        }



        [Property("Department", SoType.Text,

          "Department", "Department of employee")]

        public string Department
        {

            get
            {

                return _department;

            }

            set
            {

                _department = value;

            }

        }



        [Property("FirstName", SoType.Text,

            "First Name", "First Name of employee")]

        public string FirstName
        {

            get
            {

                return _firstName;

            }

            set
            {

                _firstName = value;

            }

        }



        [Property("LastName", SoType.Text,

            "Last Name", "Last Name of employee")]

        public string LastName
        {

            get
            {

                return _lastName;

            }

            set
            {

                _lastName = value;

            }

        }



        [Property("Email", SoType.Text,

           "Email", "Email of employee")]

        public string Email
        {

            get
            {

                return _email;

            }

            set
            {

                _email = value;

            }

        }

        [Property("Manager", SoType.Text,

           "Manager", "Manager of employee")]

        public string Manager
        {

            get
            {

                return _manager;

            }

            set
            {

                _manager = value;

            }

        }



        /// <summary>

        /// Note this property was created to pass a value from the 

        /// EmployeeServiceBroker to the Employee object.  This property

        /// is not exposed through any of the methods.

        /// </summary>

        [Property("DatabaseConnection", SoType.Text,

            "Database Connection", "Connection string to the database.")]

        public string DatabaseConnection
        {

            get
            {

                return _databaseConnection;

            }

            set
            {

                _databaseConnection = value;

            }

        }

        #endregion

        #region Methods



        /// <summary>

        /// This method will get an Employee based on the Employee Number.

        /// The Employee number is required.

        /// </summary>

        /// <returns></returns>

        [Method("GetEmployee", MethodType.Read, "Get Employee",

            "Method will get Employee based on Employee ID.",

            new string[] { "EmployeeNumber" },

            new string[] { "EmployeeNumber" },

            new string[] { "FirstName", "LastName", "Email", "Department", "Manager" })]

        public Employee GetEmployee()
        {

            try
            {

                ///Write code here to fill in the object from where ever.

                ///this.EmployeeNumber; will contain the employee number

                ///value that was sent by the caller.



                ///Filling in some test data.

                FirstName = "Jason";

                LastName = "Apergis";

                Department = "Professional Services";

                Email = "jason@foobar.com";
                Manager = "K2:denallix\\mark";

            }

            catch (Exception ex)
            {

                throw new Exception("Error Getting an Employee >> " + ex.Message);

            }



            return this;    //return the Employee object to the Execute() call

        }



        /// <summary>

        /// This method will create an Employee.  First name, last name

        /// and department are required.  An employee number and email 

        /// address will be generated as a result of the creation of the employee.

        /// These two values will be returned.

        /// </summary>

        /// <returns></returns>

        [Method("HireEmployee", MethodType.Execute, "Hire Employee",

            "Method will complete the hire of an email creating a Employee Number and Email Address.",

            new string[] { "FirstName", "LastName", "Department" },

            new string[] { "FirstName", "LastName", "Department" },

            new string[] { "EmployeeNumber", "Email" })]

        public Employee HireEmployee()
        {

            Employee employee = new Employee();



            try
            {

                ///Write code here to save the object to where ever.

                ///this.FirstName, etc. to get values provided by the caller.



                ///returning some test values

                EmployeeNumber = 1;

                Email = "jason@foobar.com";

            }

            catch (Exception ex)
            {

                throw new Exception("Error Hiring an Employee >> " + ex.Message);

            }



            return this;    //return the Employee object to the Execute() call

        }



        /// <summary>

        /// This method will get a list of employees.  Providing no value

        /// will get all employees.  Providing a Department name will get

        /// all employees for the department.  This is because the Department

        /// field is not required.

        /// </summary>

        /// <returns></returns>

        [Method("GetEmployees", MethodType.List, "Get Employees",

            "Method will get Employees.",

            new string[] { },

            new string[] { "Department" },

            new string[] { "EmployeeNumber", "FirstName", "LastName", "Email" })]

        public List<Employee> GetEmployees()
        {

            List<Employee> employees = new List<Employee>();



            try
            {

                ///Check of there is a Department value

                if (String.IsNullOrEmpty(Department))
                {

                    ///Get all Employees

                }

                else
                {

                    ///Get Employees based on department id

                }



                ///Filling in some test data.

                Employee emp1 = new Employee();

                emp1.EmployeeNumber = 0;

                emp1.FirstName = "Jason";

                emp1.LastName = "Apergis";

                emp1.Department = "Professional Services";

                emp1.Email = "jason@foobar.com";



                employees.Add(emp1);



                Employee emp2 = new Employee();

                emp2.EmployeeNumber = 1;

                emp2.FirstName = "Ethan";

                emp2.LastName = "Apergis";

                emp2.Department = "Professional Services";

                emp2.Email = "ethan@foobar.com";



                employees.Add(emp2);

            }

            catch (Exception ex)
            {

                throw new Exception("Error Getting Employees >> " + ex.Message);

            }



            return employees;    //return the Employee objects to the Execute() call

        }



        #endregion
    }
}
