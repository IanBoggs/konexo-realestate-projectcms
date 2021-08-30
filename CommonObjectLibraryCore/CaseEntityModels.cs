using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CommonObjectLibraryCore
{
    /// <summary>
    /// Mapping between cases, the entities on the case and the entites settings
    /// </summary>
    [Table("CaseEntity_Rel")]
    public class CaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CaseEntityId { get; set; }
        public int CaseId { get; set; }
        public virtual Case Case { get; set; }
        public Guid EntityId { get; set; }
        public virtual Entity Entity { get; set; }
        public int EntityRoleId { get; set; }
        public virtual EntityRole EntityRole { get; set; }
        public int BankDetailId { get; set; }
        public virtual BankDetail BankDetail { get; set; }
        public virtual List<EntityDataPoint> CaseEntityDataPointList { get; set; }
    }

    [Table("EntityRoles")]
    [Index(nameof(EntityRoleName), IsUnique = true)]
    public class EntityRole
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EntityRoleId { get; set; }
        [Required]
        public string EntityRoleName { get; set; }

    }
}