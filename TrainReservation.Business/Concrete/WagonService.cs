using Microsoft.Extensions.Logging;
using TrainReservation.Models;
using TrainReservation.Services.Interfaces;

namespace TrainReservation.Services
{
    public class WagonService : IWagonService
    {
        private readonly ILogger<WagonService> _logger;

        public WagonService(ILogger<WagonService> logger)
        {
            _logger = logger;
        }

        //Bu metod, verilen vagonların her birindeki mevcut boş koltuk sayısını hesaplar ve bir Dictionary<string, int> ile geri döner. Vagonun adı string anahtar olarak kullanılır, boş koltuk sayısı ise int değerinde tutulur. Hesaplama için HowManySeatsAreAvailable metodunu kullanır.
        public Dictionary<string, int> GetAvailableSeatsInAllWagons(List<Wagon> wagons)
        {
            var availableSeats = new Dictionary<string, int>();
            foreach (var wagon in wagons)
            {
                var result = HowManySeatsAreAvailable(wagon);
                availableSeats.Add(wagon.Name, result);
            }
            return availableSeats;
        }
        //Bu metod trenin toplam boş koltuk sayısını hesaplar. Her vagon için HowManySeatsAreAvailable metodunu kullanarak boş koltuk sayısını toplar. Eğer hiç boş koltuk yoksa bir hata mesajı loglar.
        public int TotalAvailableSeatsOnTrain(List<Wagon> wagons)
        {
            int totalAvailableSeats = 0;
            foreach (var wagon in wagons)
            {
                totalAvailableSeats += HowManySeatsAreAvailable(wagon);
            }
            if (totalAvailableSeats == 0)
            {
                _logger.LogError("No available seats on the train.");
                return 0;
            }
            return totalAvailableSeats;
        }

        //Bu metod, bir vagondaki boş koltuk sayısını hesaplar. Vagonun kapasitesinin %70'i dolmuşsa koltuk ayırtılamayacağını loglar ve 0 döner. Aksi halde, kapasitenin %70'inden dolu koltuk sayısını çıkarır.
        private int HowManySeatsAreAvailable(Wagon wagon)
        {
            if (wagon.Capacity * 7 / 10 < wagon.NumberOfFullSeats)
            {
                _logger.LogError("Cannot reserve seats in this wagon.");
                return 0;
            }
            return wagon.Capacity * 7 / 10 - wagon.NumberOfFullSeats;
        }
    
    }
}
