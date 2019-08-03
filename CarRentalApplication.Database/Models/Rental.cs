using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalApplication.Database.Models
{
    [Table("Rentals")]
    public class Rental
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        public string OwnerName { get; set; }
        public string OwnerPhone { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
