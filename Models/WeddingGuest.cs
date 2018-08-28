using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WeddingPlanner.Models
{
    public class WeddingGuest : BaseEntity
    {
        [Key, Column("wedding_guest_id")]
        public int WeddingGuestId {get;set;}
        [Column("wedding_id")]
        public int WeddingId {get;set;}
        [Column("user_id")]
        public int UserId {get;set;}
        public User Guest {get;set;}
        public Wedding Wedding {get;set;}
        [Column("pending")]
        public bool Pending {get;set;}

    }
}