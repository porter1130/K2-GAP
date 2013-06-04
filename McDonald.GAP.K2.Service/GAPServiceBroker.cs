using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SourceCode.SmartObjects.Services.ServiceSDK;
using SourceCode.SmartObjects.Services.ServiceSDK.Objects;
using SourceCode.SmartObjects.Services.ServiceSDK.Types;

namespace McDonald.GAP.K2.Service
{
    public class GAPServiceBroker : ServiceAssemblyBase
    {
        public GAPServiceBroker() { }
        public override string GetConfigSection()
        {

            this.Service.ServiceConfiguration.Add("DatabaseConnection", true, "Default Value");



            return base.GetConfigSection();

        }



        public override string DescribeSchema()
        {

            //Custom service object

            Type employeeType = typeof(Employee);

            base.Service.ServiceObjects.Add(new ServiceObject(employeeType));



            return base.DescribeSchema();

        }



        /// <summary>

        /// This method does not have to be implemented. However it is used to set

        /// configuration values that are set in the K2 Workspace.  As well, exceptions

        /// from the Employee object are handled here.

        /// </summary>

        public override void Execute()
        {

            try
            {

                foreach (ServiceObject so in base.Service.ServiceObjects)
                {

                    if (so.Name == "EmployeeServiceObject")
                    {

                        string server = base.Service.ServiceConfiguration["DatabaseConnection"].ToString();

                        so.Properties["DatabaseConnection"].Value = server;

                    }

                }



                base.Execute();

            }

            catch (Exception ex)
            {

                string errorMsg = Service.MetaData.DisplayName + " Error >> " + ex.Message;

                this.ServicePackage.ServiceMessages.Add(errorMsg, MessageSeverity.Error);

                this.ServicePackage.IsSuccessful = false;

            }

        }



        public override void Extend()
        {

            //throw new Exception("The method or operation is not implemented.");

        }


    }
}
