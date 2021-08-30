using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CommonObjectLibraryCore
{
    [Table("ContactDetails")]
    public class ContactDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactDetailId { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string PrimaryEmail { get; set; }
        public string SecondaryEmail { get; set; }
        public string WorkFax { get; set; }
        public string DXAddress { get; set; }
    }
}