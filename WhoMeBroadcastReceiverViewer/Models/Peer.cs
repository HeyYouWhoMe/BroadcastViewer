using System;
using System.Collections.Generic;

namespace WhoMeBroadcastReceiverViewer.Models
{
    public class Peer
    {
        public Peer() { }

        public Peer(
            bool isWellKnown,
            string guid,
            string name,
            string description,
            string infoLabel,
            string fullDomainMame,
            Dictionary<string, string> serviceInfoDictionary,
            Dictionary<string, string> keyNameMap,
            Dictionary<string, string> keyTypeMap,
            List<string> editableKeys)
        {
            IsWellKnown = isWellKnown;
            Guid = guid;
            Name = name;
            Description = description;
            InfoLabel = infoLabel;
            FullDomainName = fullDomainMame;
            ServiceInfoDictionary = serviceInfoDictionary;
            KeyNameMap = keyNameMap;
            KeyTypeMap = keyTypeMap;
            EditableKeys = editableKeys;
        }

        public Peer(
            bool isWellKnown,
            string guid,
            string name,
            string description,
            string infoLabel,
            string fullDomainMame,
            Dictionary<string, string> serviceInfoDictionary,
            Dictionary<string, string> keyNameMap,
            Dictionary<string, string> keyTypeMap,
            List<string> editableKeys,
            DateTime profileCreationDate,
            DateTime profileExpiryDate,
            string profileDocumentationWebAddress,
            string authorGuid,
            string authorName,
            string authorEmail,
            string organisationName,
            string webAddress
            )
        {
            IsWellKnown = isWellKnown;
            Guid = guid;
            Name = name;
            Description = description;
            InfoLabel = infoLabel;
            FullDomainName = fullDomainMame;
            ServiceInfoDictionary = serviceInfoDictionary;
            KeyNameMap = keyNameMap;
            KeyTypeMap = keyTypeMap;
            EditableKeys = editableKeys;

            ProfileCreatedDate = profileCreationDate;
            ProfileExpiryDate = profileExpiryDate;
            ProfileDocumentationWebAddress = profileDocumentationWebAddress;
            AuthorGuid = authorGuid;
            AuthorName = authorName;
            AuthorEmail = authorEmail;
            OrganisationName = organisationName;
            WebAddress = webAddress;
        }

        public int ID { get; set; }
        public bool IsWellKnown { get; set; }
        public string Guid { get; set; }
        public DateTime ProfileCreatedDate { get; set; }
        public DateTime ProfileExpiryDate { get; set; }
        public string ProfileDocumentationWebAddress { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string InfoLabel { get; set; }
        public string FullDomainName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public IDictionary<string, string> ServiceInfoDictionary { get; set; }
        public Dictionary<string, string> KeyNameMap { get; set; }
        public Dictionary<string, string> KeyTypeMap { get; set; }
        public Dictionary<string, string> KeyToMacroIdMap { get; set; }
        public Dictionary<string, string> MacroIdToKeyMap { get; set; }
        public List<String> EditableKeys { get; set; }
        public string MacAddress { get; set; }
        public DateTime TimeLocationUpdated { get; set; }
        public DateTime TimeKeepAliveUpdated { get; set; }

        public string AuthorGuid { get; set; }
        public string AuthorName { get; set; }
        public string AuthorEmail { get; set; }
        public string OrganisationName { get; set; }
        public string WebAddress { get; set; }
    }
}
