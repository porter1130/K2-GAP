using System;
using SourceCode.Security.UserRoleManager.Management;

namespace McDonald.GAP.K2.Service
{
    public class K2UserRoleManager : UserRoleManager, IDisposable
    {

        public K2UserRoleManager()
        {
            base.CreateConnection();

            K2ConnectionStringBuilder builder = new K2ConnectionStringBuilder(ServerType.UserRoleManager);
            //open connection

            base.Connection.Open(builder.ConnectionString);
        }


        public void Dispose()
        {
            base.DeleteConnection();
            base.Connection = null;
        }
    }
}
