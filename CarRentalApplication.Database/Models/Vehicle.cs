using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalApplication.Database.Models
{
    [Table("vehicles")]
    public class Vehicle
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [ForeignKey("VehicleType")]
        public int VehicleTypeId { get; set; }
        public string VehicleTypeName { get; set; }

        [Column("type")]
        public VehicleType Type { get; set; }

        [Column("fuel_percentage")]
        public short FuelPercentage { get; set; }

        [Column("damage_percentage")]
        public short DamagePercentage { get; set; }
    }
}
