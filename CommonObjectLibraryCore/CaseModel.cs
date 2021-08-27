using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CommonObjectLibraryCore
{
    [Index(nameof(CaseReference), IsUnique = true)]
    public class Case
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CaseId { get; set; }
        [Required]
        public string CaseReference { get; set; }
        public List<CaseEntity> CaseEntities { get; set; }

    }
}
