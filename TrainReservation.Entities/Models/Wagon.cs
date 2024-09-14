using System.Text.Json.Serialization;

namespace TrainReservation.Models
{
    public class Wagon
    {
        //Bir vagonun bilgilerini (ad, kapasite, dolu koltuk sayısı) tutar.
        [JsonPropertyName("ad")]
        public string Name { get; set; }

        [JsonPropertyName("kapasite")]
        public int Capacity { get; set; }

        [JsonPropertyName("doluKoltukAdet")]
        public int NumberOfFullSeats { get; set; }
    }
}