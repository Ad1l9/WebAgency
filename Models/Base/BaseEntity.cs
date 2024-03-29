﻿namespace AgencyWebSite.Models.Base
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool IgnoreQuery { get; set; }
        public BaseEntity()
        {
            this.CreatedAt = DateTime.Now;
        }
    }
}
