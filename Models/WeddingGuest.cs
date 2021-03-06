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
        [ForeignKey("wedding_id")]
        public int WeddingId {get;set;}
        [Column("user_id")]
        [ForeignKey("user_id")]
        public int UserId {get;set;}
        public User Guest {get;set;}
        public Wedding Wedding {get;set;}
        [Column("pending")]
        public bool Pending {get;set;}

        public WeddingGuest(Wedding NewWedding, User NewUser)
        {
            WeddingId = NewWedding.WeddingId;
            UserId = NewUser.UserId;
            Guest = NewUser;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Pending = true;
        }
        public WeddingGuest()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Pending = true;
        }
    }
}