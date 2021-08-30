using System;
using System.Collections.Generic;
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
        public virtual PostalAddress PrincipalAddress { get; set; }
        [Required]
        public string ClientName { get; set; }
        public string LegalClientName { get; set; }
        public string ShortClientName { get; set; }
        public string SOSPrefixCode { get; set; }
    }
}