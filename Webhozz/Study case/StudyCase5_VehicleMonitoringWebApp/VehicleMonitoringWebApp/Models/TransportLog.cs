using System.ComponentModel.DataAnnotations;
namespace VehicleMonitoringWebApp.Models;

public enum Efisiensi
{
    Good,
    Fair,
    Bad
}

public class TransportLog
{
    public int ID { get; set; }

    [Required]
    public DateTime Tanggal { get; set; } = DateTime.Today;

    [Range(0, float.MaxValue)]
    public float Qty_L { get; set; }

    [Range(0, int.MaxValue)]
    public int Harga_BBM_Rp { get; set; }

    [Range(0, int.MaxValue)]
    public int Adometer_Buka { get; set; }

    [Range(0, int.MaxValue)]
    public int Adometer_Tutup { get; set; }

    public int KM => Adometer_Tutup - Adometer_Buka;

    public int Total_BBM_Rp => (int)(Qty_L * Harga_BBM_Rp);

    [Range(0, int.MaxValue)]
    public int Biaya_Toll_Rp { get; set; }

    [Range(0, int.MaxValue)]
    public int Parkir_Rp { get; set; }

    public int Grand_Total => Total_BBM_Rp + Biaya_Toll_Rp + Parkir_Rp;

    public string Job_Number { get; set; } = string.Empty;

    public string Supir { get; set; } = string.Empty;

    [Required(ErrorMessage = "Efisiensi BBM harus dipilih.")]
    public Efisiensi Efisiensi_BBM { get; set; } = Efisiensi.Good;
}