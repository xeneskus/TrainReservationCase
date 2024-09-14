using TrainReservation.Models;

namespace TrainReservation.Services.Interfaces
{
    public interface IReservationService
    {
        ReservationOutput Reserve(ReservationInput reservationInput);
    }
}