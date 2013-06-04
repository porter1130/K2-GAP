using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SourceCode.SmartObjects.Services.ServiceSDK;
using SourceCode.SmartObjects.Services.ServiceSDK.Objects;
using SourceCode.SmartObjects.Services.ServiceSDK.Types;
using System.Data;

namespace McDonald.GAP.K2.Service
{
    public class MyCustomService : ServiceAssemblyBase
    {
        public MyCustomService() { }

        /// <summary>
        /// Used to define configuration values for the service instance
        /// after it has been deployed.
        /// </summary>
        /// <returns></returns>
        public override string GetConfigSection()
        {
            this.Service.ServiceConfiguration.Add("Server", true, "Default Value");
            return base.GetConfigSection();
        }

        /// <summary>
        /// Defines the public interface for the SmartObject service.
        /// </summary>
        /// <returns></returns>
        public override string DescribeSchema()
        {
            //set base info
            this.Service.Name = "GAPCustomService";
            this.Service.MetaData.DisplayName = "GAP Custom Service";
            this.Service.MetaData.Description = "Custom service for GAP";

            //create the service object
            ServiceObject so = new ServiceObject();
            so.Name = "GAPCustomServiceObject";
            so.MetaData.DisplayName = "GAP Stub Service";
            so.MetaData.Description = "Use for GAP Stub Service";
            so.Active = true;
            this.Service.ServiceObjects.Add(so);

            //create field definition
            Property property1 = new Property();
            property1.Name = "MyGAPField1";
            property1.MetaData.DisplayName = "My Field 1";
            property1.MetaData.Description = "My Field 1";
            property1.Type = "Integer";
            property1.SoType = SoType.Number;
            so.Properties.Add(property1);

            //create field definition
            Property property2 = new Property();
            property2.Name = "MyGAPField2";
            property2.MetaData.DisplayName = "My Field 2";
            property2.MetaData.Description = "My Field 2";
            property2.Type = "System.String";
            property2.SoType = SoType.Text;
            so.Properties.Add(property2);

            //create load method
            Method method1 = new Method();
            method1.Name = "Load";
            method1.MetaData.DisplayName = "Load";
            method1.MetaData.Description = "Load a single record of data.";
            method1.Type = MethodType.Read;
            method1.Validation.RequiredProperties.Add(property1);
            method1.InputProperties.Add(property1);
            method1.ReturnProperties.Add(property1);
            method1.ReturnProperties.Add(property2);
            so.Methods.Add(method1);

            //create list method
            Method method2 = new Method();
            method2.Name = "List";
            method2.MetaData.DisplayName = "List";
            method2.MetaData.Description = "Load collection of data";
            method2.Type = MethodType.List;
            method2.Validation.RequiredProperties.Add(property1);
            method2.InputProperties.Add(property1);
            method2.ReturnProperties.Add(property1);
            method2.ReturnProperties.Add(property2);
            so.Methods.Add(method2);

            return base.DescribeSchema();
        }

        public override void Execute()
        {
            try
            {
                //loop over called ServiceObject(s)
                foreach (ServiceObject so in Service.ServiceObjects)
                {
                    switch (so.Name)
                    {
                        case "GAPCustomServiceObject":
                            //loop over the method(s) that were called.
                            foreach (Method method in so.Methods)
                            {
                                switch (method.Name)
                                {
                                    case "Load":
                                        LoadMethod(so, method);
                                        break;
                                    case "List":
                                        ListMethod(so, method);
                                        break;
                                    default:
                                        throw new Exception("Service method undefined");
                                }
                            }
                            break;
                        default:
                            throw new Exception("Service Object Not Found");
                    }
                }
            }
            catch (Exception ex)
            {
                string errorMsg = Service.MetaData.DisplayName + " Error >> " + ex.Message;
                this.ServicePackage.ServiceMessages.Add(errorMsg, MessageSeverity.Error);
                this.ServicePackage.IsSuccessful = false;
            }
            base.Execute();
        }

        private void ListMethod(ServiceObject so, Method method)
        {
            so.Properties.InitResultTable();
            DataTable resultTable = this.ServicePackage.ResultTable;

            //Write code to fill the ResultTable with data.
        }

        private void LoadMethod(ServiceObject so, Method method)
        {
            //add in code here to retrieve data from any external data source and 
            //load it into the result set for the this method.
            so.Properties.InitResultTable();
            so.Properties["MyGAPField1"].Value = 1;
            so.Properties["MyGAPField2"].Value = "Comments";
            so.Properties.BindPropertiesToResultTable();
        }

        public override void Extend()
        {
            throw new NotImplementedException();
        }
    }
}
