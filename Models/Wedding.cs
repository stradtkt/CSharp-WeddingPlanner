using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WeddingPlanner.Models
{
    public class Wedding : BaseEntity
    {
        [Key, Column("wedding_id")]
        public int WeddingId {get;set;}

        [Column("wedder_one")]
        public string WedderOne {get;set;}

        [Column("wedder_two")]
        public string WedderTwo {get;set;}

        [Column("event_name")]
        public string EventName {get;set;}
        [Column("event_date")]
        public DateTime EventDate {get;set;}

        [Column("address")]
        public string Address {get;set;}

        public List<WeddingGuest> Guests {get;set;}

        public Wedding()
        {
            Guests = new List<WeddingGuest>();
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}