using TrainReservation.Models;
using TrainReservation.Services.Interfaces;

namespace TrainReservation.Services
{
    public class ReservationService : IReservationService
    {
        private readonly ITrainService _trainService;

        public ReservationService(ITrainService trainService)
        {
            _trainService = trainService;
        }
        //Bu metod, rezervasyon talebini işlemekle sorumludur.
        //TrainService'in PlacePeopleInSeats metodunu çağırarak rezervasyon işlemi yapılır.
        //Eğer yerleştirme başarılı olmazsa (boş koltuk yoksa),
        //ReservationOutput ile başarısız bir sonuç döner. Eğer yerleştirme yapılırsa,
        //başarı durumu ve yerleşim bilgileri geri döndürülür.
        public ReservationOutput Reserve(ReservationInput reservationInput)
        {
            Train train = reservationInput.Train;
            int numberOfPeople = reservationInput.NumberOfPeopleToReservation;
            bool canPeoplePlacedInDifferentWagons = reservationInput.CanPeoplePlacedInDifferentWagons;

            var reservationOutput = _trainService.PlacePeopleInSeats(train, numberOfPeople, canPeoplePlacedInDifferentWagons);

            if (reservationOutput == null || reservationOutput.Count == 0)
            {
                return new ReservationOutput { Reservationable = false, PlacementDetails = new List<Placement>() };
            }

            return new ReservationOutput
            {
                Reservationable = true,
                PlacementDetails = reservationOutput
            };
        }
    }
}