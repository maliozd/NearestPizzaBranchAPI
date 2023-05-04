using Application.Dtos.Location;
using Application.Interfaces;
using Infrastructure.Interfaces;
using System.Device.Location;

namespace Infrastructure.Services
{
    // ? LocationHttpClientService, LocationService içerisine taşınabilir ?
    public class LocationService : ILocationService
    {
        readonly ILocationHttpClientService _locationHttpClient;
        public LocationService(ILocationHttpClientService locationHttpClient)
        {
            _locationHttpClient = locationHttpClient;
        }
        private double ConvertMeterToKm(double meter) => meter / 1000;

        //GeoCoordinate.GetDistanceTo() --> returns meter
        public double GetKmDistanceBetweenLocations(Location location1, Location location2)
        {
            GeoCoordinate coordinate1 = new GeoCoordinate(location1.Latitude, location1.Longitude);
            GeoCoordinate coordinate2 = new GeoCoordinate(location2.Latitude, location2.Longitude);
            return ConvertMeterToKm(coordinate1.GetDistanceTo(coordinate2));
        }
        public async Task<Location> GetLocationByIPAsync(string ip)
        {
            return await _locationHttpClient.GetLocationFromIPStackAsync(ip);
        }
    }
}
