using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CommonObjectLibraryCore
{
    public class Entity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EntityId { get; set; }
        public string CompanyName { get; set; }
        public List<CaseEntity> CaseEntities { get; set; }


    }

    public class CaseEntityProperties
    {
        public int CaseEntityPropertiesId { get; set; }
        public string Reference { get; set; }

    }
    public class CaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CaseEntityId { get; set; }


        public int CaseId { get; set; }
        public Case Case { get; set; }

        public int EntityId { get; set; }
        public Entity Entity { get; set; }

        public int EntityRoleId { get; set; }
        public EntityRole EntityRole { get; set; }

        public int CaseEntityPropertiesId { get; set; }
        public CaseEntityProperties CaseEntityProperties { get; set; }
    }


    [Index(nameof(EntityRoleName), IsUnique = true)]
    public class EntityRole
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EntityRoleId { get; set; }
        [Required]
        public string EntityRoleName { get; set; }


    }
}