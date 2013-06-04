using SourceCode.Hosting.Client.BaseAPI;
using SourceCode.Workflow.Client;

namespace McDonald.GAP.K2.Service
{
    public class K2ConnectionStringBuilder
    {
        public ConnectionSetup ConnSetup;
        public string ConnectionString { get; set; }

        public K2ConnectionStringBuilder(string userID)
        {
            ConnSetup = new ConnectionSetup();
            SCConnectionStringBuilder connectionString = new SCConnectionStringBuilder();
            connectionString.Authenticate = true;
            connectionString.Integrated = false;
            connectionString.IsPrimaryLogin = true;
            connectionString.EncryptedPassword = false;
            connectionString.Host = K2Environments.Host;
            connectionString.Port = K2Environments.Port;
            connectionString.SecurityLabelName = K2Environments.SecurityLabelName;
            connectionString.UserID = userID;
            connectionString.Password = "Pass!";

            ConnSetup.ConnectionString = connectionString.ToString();
        }

        public K2ConnectionStringBuilder(ServerType type)
        {
            switch (type)
            {
                case ServerType.UserRoleManager:
                    SCConnectionStringBuilder builder = new SCConnectionStringBuilder()

                    {

                        Host = K2Environments.Host,

                        Port = 5555,

                        Integrated = true,

                        IsPrimaryLogin = true,

                    };
                    this.ConnectionString = builder.ToString();
                    break;
            }

        }
    }

    public enum ServerType
    {
        UserRoleManager
    }
}
