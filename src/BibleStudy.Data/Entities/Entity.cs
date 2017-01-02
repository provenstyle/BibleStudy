namespace BibleStudy.Data.Entities
{
    using System;

    public class Entity
    {
        public int      Id         { get; set; }
        public byte[]   RowVersion { get; set; }
        public string   CreatedBy  { get; set; }
        public DateTime Modified   { get; set; }
        public string   ModifiedBy { get; set; }
    }
}