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
        public virtual PostalAddress PrincipalAddress { get; set; }



    }


    public class CompanyEntity : Entity
    {

        public string CompanyName { get; set; }
        public virtual List<CaseEntity> CaseEntities { get; set; }
    }

    public class IndividualEntity : Entity
    {
        [NotMapped]
        public string FullName
        {
            get
            {
                var output = string.Empty;
                if (!string.IsNullOrEmpty(FirstNames))
                    output += FirstNames;
                if (!string.IsNullOrEmpty(Surname))
                    output += $" {Surname}";
                return output.Trim();
            }
        }

        public string FirstNames { get; set; }
        public string Surname { get; set; }
        public virtual List<CaseEntity> CaseEntities { get; set; }

    }


    /// <summary>
    /// Mapping between cases and their entities
    /// </summary>
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

        public virtual List<CaseEntityDataPoint> CaseEntityDataPointList { get; set; }

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