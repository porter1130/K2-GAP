using SourceCode.Workflow.Client;

namespace McDonald.GAP.K2.Service
{
    public class K2Connection : Connection
    {       

        public K2Connection(string userId)
        {

            K2ConnectionStringBuilder connectionStringBuilder = new K2ConnectionStringBuilder(userId);

            base.Open(connectionStringBuilder.ConnSetup);
        }

    }
}
