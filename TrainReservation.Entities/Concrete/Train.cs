using System.Text.Json.Serialization;

namespace TrainReservation.Models
{
    //Tren bilgilerini ve vagonların listesini tutar.
    public class Train
    {
        [JsonPropertyName("ad")]
        public string Name { get; set; }

        [JsonPropertyName("vagonlar")]
        public List<Wagon> Wagons { get; set; }
    }
}