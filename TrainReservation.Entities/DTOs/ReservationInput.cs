using System.Text.Json.Serialization;

namespace TrainReservation.Models
{
    public class ReservationInput
    {
        //Rezervasyon için gerekli olan verileri (tren, kişi sayısı, farklı vagonlara yerleştirilebilir mi) tutar.
        [JsonPropertyName("tren")]
        public Train Train { get; set; }

        [JsonPropertyName("rezervasyonYapilacakKisiSayisi")]
        public int NumberOfPeopleToReservation { get; set; }

        [JsonPropertyName("kisilerFarkliVagonlaraYerlestirilebilir")]
        public bool CanPeoplePlacedInDifferentWagons { get; set; }
    }
}
