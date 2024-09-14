using TrainReservation.Models;

namespace TrainReservation.Services.Interfaces
{
    public interface IWagonService
    {
        // Dictionary anahtar-değer (key-value) çiftleri şeklinde veri tutan bir veri yapısıdır.

        //string: Sözlüğün anahtarının(key) türü string, yani bir metin olacak. Bu metinler genellikle vagon isimlerini temsil edebilir.
        //int: Sözlüğün değeri (value) ise int, yani bir tam sayı olacak.Bu değer de her vagonun boş koltuk sayısını temsil edebilir.

        Dictionary<string, int> GetAvailableSeatsInAllWagons(List<Wagon> wagons);
        int TotalAvailableSeatsOnTrain(List<Wagon> wagons);
    }
}