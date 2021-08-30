using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CommonObjectLibraryCore
{
    /// <summary>
    /// Class represetning a postal address
    /// </summary>
    [Table("PostalAddresses")]
    public class PostalAddress
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostalAddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string AddressLine4 { get; set; }
        [Required]
        public string PostCode { get; set; }

    }
}