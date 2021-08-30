using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CommonObjectLibraryCore
{

    /// <summary>
    /// Case class for an entity on a case
    /// </summary>
    public class Entity : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid EntityId { get; set; }
        public virtual PostalAddress PrincipalAddress { get; set; }
        public virtual ContactDetail ContactInformation { get; set; }
        public virtual List<BankDetail> AlternativeBankDetails { get; set; }
        public virtual BankDetail DefaultBankDetails { get; set; }
    }

    /// <summary>
    /// A Company Entity with an interest on a case
    /// </summary>
    public class CompanyEntity : Entity
    {
        [Required]
        public string CompanyName { get; set; }
        public string CompanyNumber { get; set; }
        public virtual List<CaseEntity> CaseEntities { get; set; }
    }

    /// <summary>
    /// An Individual Entity with an interest on a case
    /// </summary>
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
        public DateTime DateOfBirth { get; set; }
        public virtual List<CaseEntity> CaseEntities { get; set; }

    }

}