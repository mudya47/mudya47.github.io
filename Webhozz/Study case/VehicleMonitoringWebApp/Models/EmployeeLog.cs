using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleMonitoringWebApp.Models
{
    [Table("EmployeeLog")]
    public class EmployeeLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public DateTime Tanggal { get; set; } = DateTime.Today;
        [Required]
        [Range(0, float.MaxValue)]
        public double Qty_L { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int Harga_BBM_Rp { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int Adometer_Buka { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int Adometer_Tutup { get; set; }

        public int KM => Adometer_Tutup - Adometer_Buka;

        public int Total_BBM_Rp => (int)(Qty_L * Harga_BBM_Rp);
        [Required]
        [Range(0, int.MaxValue)]
        public int? Biaya_Toll_Rp { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int? Parkir_Rp { get; set; }

        public decimal Grand_Total => (Biaya_Toll_Rp ?? 0) + (Parkir_Rp ?? 0) + ActualFuelConsumption;

        [Required]
        public string Supir { get; set; } = string.Empty;

        [Required]
        public string Job_Number { get; set; } = string.Empty;

        public Efisiensi? Efisiensi_BBM { get; set; }

        [Required]
        public string? Nopol { get; set; }
        [Required]
        public string Dari { get; set; } = string.Empty;
        [Required]
        public string Tujuan { get; set; } = string.Empty;

        [NotMapped]
        public decimal ActualFuelConsumption => (KM / 8m) * Harga_BBM_Rp;
        //Fair Amount = Total Fuel - Actual Fuel Consumption
        [NotMapped]
        public decimal FairAmountRp => Total_BBM_Rp - ActualFuelConsumption;

    }
}