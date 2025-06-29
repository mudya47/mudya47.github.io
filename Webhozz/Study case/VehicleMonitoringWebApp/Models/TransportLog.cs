﻿using System.ComponentModel.DataAnnotations;

namespace VehicleMonitoringWebApp.Models
{
    public enum Efisiensi
    {
        Fair,
        Unfair
    }

    public class TransportLog
    {
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

        public int Grand_Total => (Biaya_Toll_Rp ?? 0) + (Parkir_Rp ?? 0);

        [Required]
        public string Supir { get; set; } = string.Empty;

        [Required]
        public string Job_Number { get; set; } = string.Empty;

        public Efisiensi? Efisiensi_BBM { get; set; }

        [Required]
        public string? Nopol { get; set; }

    }
}