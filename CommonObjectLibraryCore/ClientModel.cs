using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CommonObjectLibraryCore
{
    [Table("Clients")]
    public class ClientEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ClientEntityId { get; set; }
        [DisplayName("Main Address")]
        public virtual PostalAddress PrincipalAddress { get; set; }
        [Required]
        [DisplayName("Client Name")]
        public string ClientName { get; set; }
        [DisplayName("Client Legal Name")]
        public string LegalClientName { get; set; }
        [DisplayName("Short Client Name")]
        public string ShortClientName { get; set; }
        [DisplayName("SOS Prefix Code")]
        public string SOSPrefixCode { get; set; }
        [DisplayName("Contact Information")]
        public virtual ContactDetail ContactInformation { get; set; }
    }
}