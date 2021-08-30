using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CommonObjectLibraryCore
{
    [Table("CasesStatuses")]
    public class CaseStatus
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CaseStatusId { get; set; }
        public string CaseStatusName { get; set; }
    }
}