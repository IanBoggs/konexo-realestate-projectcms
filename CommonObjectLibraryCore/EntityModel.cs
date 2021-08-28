using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CommonObjectLibraryCore
{
    /// <summary>
    /// A entity in the system, and its constant properties
    /// </summary>
    public class Entity : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid EntityId { get; set; }
        public PostalAddress PrincipalAddress { get; set; }



    }

    public class CompanyEntity : Entity
    {
        public string CompanyName { get; set; }
        public List<CaseEntity> CaseEntities { get; set; }
    }

    public class IndividualEntity : Entity
    {
        public string FirstNames { get; set; }
        public string Surname { get; set; }
        public List<CaseEntity> CaseEntities { get; set; }

    }


    /// <summary>
    /// Mapping between cases and their entities
    /// </summary>
    public class CaseEntity
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CaseEntityId { get; set; }


        public int CaseId { get; set; }
        public Case Case { get; set; }

        public Guid EntityId { get; set; }
        public Entity Entity { get; set; }

        public int EntityRoleId { get; set; }
        public EntityRole EntityRole { get; set; }

        public List<CaseEntityDataPoint> CaseEntityDataPointList { get; set; }

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