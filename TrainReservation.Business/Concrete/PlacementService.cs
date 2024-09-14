using TrainReservation.Models;
using TrainReservation.Services.Interfaces;

public class PlacementService : IPlacementService
{
    private readonly IWagonService _wagonService;

    public PlacementService(IWagonService wagonService)
    {
        _wagonService = wagonService;
    }
    //Kişileri aynı vagona yerleştirmeye çalışır.
    //Vagonlardaki boş koltukları kontrol eder ve yeterli boş koltuğa sahip bir vagon bulursa kişileri oraya yerleştirir.
    //Yerleştirme işlemi başarıyla yapılırsa Placement nesnesini geri döner.
    public List<Placement> PlaceInSameWagon(List<Wagon> wagons, int numberOfPeople)
    {
        List<Placement> placements = new List<Placement>();
        var availableSeats = _wagonService.GetAvailableSeatsInAllWagons(wagons);

        foreach (var wagon in availableSeats)
        {
            if (numberOfPeople <= wagon.Value)
            {
                placements.Add(new Placement { WagonName = wagon.Key, NumberOfPeople = numberOfPeople });
                return placements;
            }
        }
        return placements;
    }

    //Kişileri farklı vagonlara dağıtarak yerleştirir.
    //Bu metod, her vagondaki boş koltukları kontrol eder ve kişileri uygun vagonlara dağıtır.
    //Vagonlar doldukça kişileri yerleştirir ve son olarak yerleşim bilgilerini içeren bir liste döner.
    public List<Placement> PlaceInDifferentWagon(List<Wagon> wagons, int numberOfPeople)
    {
        List<Placement> placements = new List<Placement>();
        var availableSeats = _wagonService.GetAvailableSeatsInAllWagons(wagons);
        var placedWagons = new Dictionary<string, int>();
        var totalAvailableSeats = availableSeats.Sum(a => a.Value);

        if (totalAvailableSeats <= 0)
        {
            return placements;
        }
        while (numberOfPeople > 0)
        {
            foreach (var wagon in availableSeats)
            {
                if (wagon.Value > 0)
                {
                    if (numberOfPeople <= 0) break;
                    if (!placedWagons.ContainsKey(wagon.Key))
                    {
                        placedWagons[wagon.Key] = 0;
                    }
                    placedWagons[wagon.Key]++;
                    numberOfPeople--;
                    availableSeats[wagon.Key]--;
                }
            }
        }
        placements = GetFilledWagons(placedWagons);
        return placements;
    }
    //Bu yardımcı metod, kişilerin yerleştirildiği vagonların listesini döner.
    //Her vagon için, kaç kişi yerleştirildiğini bir Placement nesnesi olarak toplar ve geri döner.
    private List<Placement> GetFilledWagons(Dictionary<string, int> placedWagons)
    {
        return placedWagons
            .Where(wagon => wagon.Value > 0)
            .Select(wagon => new Placement { WagonName = wagon.Key, NumberOfPeople = wagon.Value })
            .ToList();
    }
}