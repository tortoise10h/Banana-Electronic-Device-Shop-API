using System;

namespace api.Entities
{
    public class BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public String LastModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}