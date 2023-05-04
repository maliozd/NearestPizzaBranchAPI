using Application.Dtos.Branch;
using Application.Dtos.Location;
using Application.Interfaces;
using Application.Interfaces.Repository;
using Domain;

namespace Application.Services
{
    public class BranchService : IBranchService
    {
        readonly IBranchRepository _branchRepository;
        readonly ILocationService _locationService;
        public BranchService(IBranchRepository branchRepository, ILocationService locationService)
        {
            _branchRepository = branchRepository;
            _locationService = locationService;
        }
        public ICollection<BranchDTO> GetAllBranches()
        {
            return _branchRepository.GetAll().Select(x => new BranchDTO()
            {
                Latitude = x.Latitude,
                Longitude = x.Longitude,
                Name = x.Name
            }).ToList();
        }

        /// <summary> 
        /// kullanıcının lokasyonu göre, belirtilen kilometre içerisinde , belirtilen sayı kadar şubeyi geri dönen method
        /// </summary>        
        /// <param name="userLocation">    
        /// kullanıcının lokasyonu      
        /// </param>        
        /// <param name="withinKilometer">
        /// şubenin kaç km içerisinde olacağını belirten parametre        /// 
        /// </param>       
        /// <param name="takeSize">
        /// alınacak şube sayısı
        /// </param>      
        /// <returns>
        /// kullanıcıya en yakın şubeler
        /// </returns>
        public async Task<ICollection<NearBranchDTO>> GetNearBranches(Location userLocation, double withinKilometer, int takeSize)
        {
            /* LINQ 
            IEnumerable<Branch> branches = _branchRepository.GetAll();
            List<NearBranchDTO> nearBranches = branches.Where(x => _locationService.GetKmDistanceBetweenLocations(new() { Latitude = x.Latitude, Longitude = x.Longitude }, userLocation) < withinKilometer)
                                       .Select(b => new NearBranchDTO()
                                       {
                                           KilometersAwayFromUser = Math.Round(_locationService.GetKmDistanceBetweenLocations(userLocation, new() { Latitude = b.Latitude, Longitude = b.Longitude }),2),
                                           Name = b.Name,
                                       })
                                       .OrderBy(x => x.KilometersAwayFromUser)
                                       .Take(takeSize)
                                       .ToList();
            */
            List<NearBranchDTO> nearBranches = new();
            foreach (Branch branch in _branchRepository.GetAll())
            {
                Location branchLocation = new() { Latitude = branch.Latitude, Longitude = branch.Longitude };
                double distanceBetweenUserAndBranch = _locationService.GetKmDistanceBetweenLocations(branchLocation, userLocation);

                if (distanceBetweenUserAndBranch < withinKilometer)
                    nearBranches.Add(new NearBranchDTO() { KilometersAwayFromUser = Math.Round(distanceBetweenUserAndBranch, 2), Name = branch.Name });
            }
            nearBranches = nearBranches.OrderBy(x => x.KilometersAwayFromUser).Take(takeSize).ToList();
            return nearBranches;
        }
    }
}

