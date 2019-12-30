using System;
using System.Collections.Generic;

namespace WhoMeBroadcastReceiverViewer.Models
{
    public class EventHubModel
    {
        public EventHubModel(string personaGuid, Dictionary<string,string> infoDic)
        {
            Guid = personaGuid;
            InfoDic = infoDic;
        }
        public string Guid { get; set; }
        public Dictionary<string, string> InfoDic { get; set; }
    }
}
