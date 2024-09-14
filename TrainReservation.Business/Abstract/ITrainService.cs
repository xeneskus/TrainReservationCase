using TrainReservation.Models;

namespace TrainReservation.Services.Interfaces
{
    public interface ITrainService
    {
        List<Placement> PlacePeopleInSeats(Train train, int numberOfPeople, bool canPeoplePlacedInDifferentWagons);
    }
}