using System.Collections.Generic;
using SourceCode.Workflow.Client;

namespace McDonald.GAP.K2.Service.ProcessInstances
{
    public abstract class ProcessBase
    {

        public Dictionary<string, object> DataFields;

        private Connection _conn;

        private string _sn;

        public string ProcessName { get; set; }

        public string Folio { get; set; }

        public Actions Actions { get; set; }

        public ProcessBase(Connection conn)
        {
            DataFields = new Dictionary<string, object>();
            this._conn = conn;
        }

        public ProcessBase(Connection conn, string sn)
        {

            //Get the WorklistItem object
            WorklistItem wi = conn.OpenWorklistItem(sn);

            //get the processing instance object
            ProcessInstance pi = wi.ProcessInstance;

            InitializeDataFields(pi.DataFields);

            this._conn = conn;
            this._sn = sn;
            this.Actions = wi.Actions;
            this.Folio = pi.Folio;
        }

        private void InitializeDataFields(SourceCode.Workflow.Client.DataFields dataFields)
        {
            DataFields = new Dictionary<string, object>();
            foreach (DataField dataField in dataFields)
            {
                this.DataFields.Add(dataField.Name, dataField.Value);
            }
        }

        public virtual int StartProcessInstance(string folio)
        {
            ProcessInstance pi = _conn.CreateProcessInstance(ProcessName);

            pi.Folio = folio;

            foreach (KeyValuePair<string, object> pair in DataFields)
            {
                pi.DataFields[pair.Key].Value = pair.Value;
            }

            _conn.StartProcessInstance(pi);

            return pi.ID;
        }

        public virtual void Excute(string actionName)
        {
            //Get the WorklistItem object
            WorklistItem wi = _conn.OpenWorklistItem(this._sn);

            //get the processing instance object
            ProcessInstance pi = wi.ProcessInstance;

            foreach (KeyValuePair<string, object> pair in DataFields)
            {
                pi.DataFields[pair.Key].Value = pair.Value;
            }

            //determine the action object for the chosen item
            SourceCode.Workflow.Client.Action action = wi.Actions[actionName];

            //execute the action
            action.Execute();
        }
    }
}
