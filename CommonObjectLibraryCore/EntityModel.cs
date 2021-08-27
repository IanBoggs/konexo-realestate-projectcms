using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonObjectLibraryCore
{
    public class Entity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EntityId {get; set;}
        public EntityType EntityType {get; set;}
        public string CompanyName {get; set;}

        public List<CaseEntity> CaseEntities {get; set;}

    
    }

    public class CaseEntity
    {

        public int CaseId {get; set;}
        public Case Case {get; set;}

        public int EntityId {get; set;}
        public Entity Entity {get; set;}
    }

    public class EntityType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EntityTypeId {get; set;}
        public string EntityTypeName {get; set;}

        
    }
}