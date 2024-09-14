using TrainReservation.Models;
using TrainReservation.Services.Interfaces;

namespace TrainReservation.Services
{
    public class TrainService : ITrainService
    {
        private readonly IPlacementService _placementService;

        public TrainService(IPlacementService placementService)
        {
            _placementService = placementService;
        }

        // Bu metod, insanları trenin vagonlarına yerleştirmek için kullanılır.
        // Eğer canPeoplePlacedInDifferentWagons true ise, kişileri farklı vagonlara yerleştirir
        // (PlaceInDifferentWagon metodunu çağırır).
        // Aksi halde, aynı vagona yerleştirir (PlaceInSameWagon metodunu çağırır).
        public List<Placement> PlacePeopleInSeats(Train train, int numberOfPeople, bool canPeoplePlacedInDifferentWagons)
        {
            if (canPeoplePlacedInDifferentWagons)
            {
                return _placementService.PlaceInDifferentWagon(train.Wagons, numberOfPeople);
            }
            else
            {
                return _placementService.PlaceInSameWagon(train.Wagons, numberOfPeople);
            }
        }
    }
}