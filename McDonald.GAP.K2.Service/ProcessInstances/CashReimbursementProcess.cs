using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SourceCode.Workflow.Client;

namespace McDonald.GAP.K2.Service.ProcessInstances
{
    public class CashReimbursementProcess : ProcessBase
    {
        #region DataFields

        public const string DestinationUser = "DestinationUser";

        public const string TaskFormUrl = "TaskFormUrl";

        #endregion

        public CashReimbursementProcess(Connection conn):base(conn)
        {
            base.ProcessName = @"McDonald.GAP.K2.Workflow\CashReimbursementProcess";
        }

        public CashReimbursementProcess(Connection conn, string sn) : base(conn, sn)
        {
            base.ProcessName = @"McDonald.GAP.K2.Workflow\CashReimbursementProcess";
        }
    }
}
