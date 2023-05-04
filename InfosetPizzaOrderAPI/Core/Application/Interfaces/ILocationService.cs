using Application.Dtos.Location;

namespace Application.Interfaces
{
    public interface ILocationService
    {
        Task<Location> GetLocationByIPAsync(string ip);
        double GetKmDistanceBetweenLocations(Location location1, Location location2);
    }
}
