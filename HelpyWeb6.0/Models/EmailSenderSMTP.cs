using System.Runtime.Serialization;

namespace HelpyAdmin.Models
{
    [DataContract]
    [Serializable]
    public class EmailSenderSMTP
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string DisplayName { get; set; }
        [DataMember]
        public string Server { get; set; }
        [DataMember]
        public string FromEmail { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public int TLS_Port { get; set; }
        [DataMember]
        public int SSL_Port { get; set; }
        [DataMember]
        public bool VerifyEmailBeforeSending { get; set; }
    }
}
