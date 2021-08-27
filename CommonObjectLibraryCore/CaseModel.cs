using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonObjectLibraryCore
{
    public class Case
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CaseId {get; set;}
        public string CaseReference {get; set;}
        public List<CaseEntity> CaseEntities {get; set;}
    }
}
