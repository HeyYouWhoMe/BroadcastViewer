using System;
using System.Collections.Generic;

namespace WhoMeBroadcastReceiverViewer.Models
{
    public class SharedWhoMeProfile
    {
        public string ProfileAPIVersion { get; set; }
        public string Guid { get; set; }
        public DateTime ProfileCreatedDate { get; set; }
        public DateTime ProfileExpiryDate { get; set; }
        public string ProfileDocumentationWebAddress { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string InfoLabel { get; set; }
        public string FullDomainName { get; set; }
        public IDictionary<string, string> ServiceInfoDictionary { get; set; }
        public Dictionary<string, string> KeyNameMap { get; set; }
        public Dictionary<string, string> KeyTypeMap { get; set; }
        public Dictionary<string, string> KeyToMacroIdMap { get; set; }
        public Dictionary<string, string> MacroIdToKeyMap { get; set; }
        public List<String> EditableKeys { get; set; }
        public string AuthorGuid { get; set; }
        public string AuthorName { get; set; }
        public string AuthorEmail { get; set; }
        public string OrganisationName { get; set; }
        public string WebAddress { get; set; }
    }
}
