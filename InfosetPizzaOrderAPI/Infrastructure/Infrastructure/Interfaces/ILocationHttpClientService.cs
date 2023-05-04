using Application.Dtos.Location;

namespace Infrastructure.Interfaces
{
    public interface ILocationHttpClientService
    {
        Task<Location> GetLocationFromIPStackAsync(string ip);

    }
}
