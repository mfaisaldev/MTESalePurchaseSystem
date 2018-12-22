using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Admin.Models
{
    public class Status
    {
        public Guid StatusId { get; set; }
        public string Name { get; set; }
        public Guid StatusTypeId { get; set;}

        public List<StatusType> StatusType { get; set;}
}
    public class StatusType
    {
        public Guid StatusTypeId { get; set; }
        public string Name { get; set; }
    }

}