using System.Collections.Generic;

namespace WhoMeBroadcastReceiverViewer.Models
{
    public class BroadcastInfoDic
    {
        public string PersonaGuid { get; set; }
        public Dictionary<string, string> InfoDic { get; set; }
        public SharedWhoMeProfile Persona { get; set; }
        public BroadcastInfoDic(string guid, SharedWhoMeProfile persona, Dictionary<string, string> infoDic)
        {
            PersonaGuid = guid;
            InfoDic = infoDic;
            Persona = persona;
        }
    }
}
