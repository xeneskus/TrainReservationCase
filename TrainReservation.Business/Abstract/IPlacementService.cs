using System.Collections.Generic;
using TrainReservation.Models;

namespace TrainReservation.Services.Interfaces
{
    public interface IPlacementService
    {
        List<Placement> PlaceInSameWagon(List<Wagon> wagons, int numberOfPeople);
        List<Placement> PlaceInDifferentWagon(List<Wagon> wagons, int numberOfPeople);
    }
}
