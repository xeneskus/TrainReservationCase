using System.Text.Json.Serialization;

namespace TrainReservation.Models
{
    public class ReservationOutput
    {
        //Rezervasyon sonucunu ve yerleşim ayrıntılarını döner.
        [JsonPropertyName("rezervasyonYapilabilir")]
        public bool Reservationable { get; set; }

        [JsonPropertyName("yerlesimAyrinti")]
        public List<Placement> PlacementDetails { get; set; }
    }
}