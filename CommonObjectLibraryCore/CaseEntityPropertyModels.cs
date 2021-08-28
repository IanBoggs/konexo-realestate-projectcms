using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CommonObjectLibraryCore
{

    [Table("CaseEntityDataPoints")]
    public class CaseEntityDataPoint
    {
        public int CaseEntityDataPointId { get; set; }
        public int DataPointTypeId { get; set; }
        public DataPointType DataPointType { get; set; }
        public string DataPointValue { get; set; }
    }

    [Table("DataPointTypes")]
    public class DataPointType
    {
        public int DataPointTypeId { get; set; }
        public string DataPointName { get; set; }
    }
}
