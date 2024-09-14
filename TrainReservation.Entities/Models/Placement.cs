using System.Text.Json.Serialization;

namespace TrainReservation.Models
{
    //Bir vagon içine kaç kişinin yerleştirildiğini temsil eder.
    public class Placement
    {
        [JsonPropertyName("vagonAdi")]
        public string WagonName { get; set; }

        [JsonPropertyName("kisiSayisi")]
        public int NumberOfPeople { get; set; }
    }
}