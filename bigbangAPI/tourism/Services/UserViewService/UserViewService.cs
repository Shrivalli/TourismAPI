using Microsoft.AspNetCore.Mvc;
using tourismBigBang.Models.Dto;
using tourismBigBang.Models.View_Model;
using tourismBigBang.Repository.UserViewRepo;

namespace tourismBigBang.Services.UserViewService
{
    public class UserViewService : IUserViewService
    {
        private readonly IUserViewRepo _userViewRepo;
        public UserViewService(IUserViewRepo userViewRepo)
        {
            _userViewRepo = userViewRepo;
        }

        public async Task<List<PlanDTO>> GetPlans()
        {
            var places = await _userViewRepo.GetPlace();
            var packages = await _userViewRepo.GetPackage();

            var result = places
                .GroupJoin(packages,
                    place => place.Id,
                    package => package.PlaceId,
                    (place, placePackages) => new
                    {
                        Id = place.Id,
                        PlaceName = place.PlaceName,
                        MinimumPrice = placePackages.Min(pp => pp.PricePerPerson)
                    })
                .ToList();

            // Create a list of PlanDTO objects based on the 'result'
            var planDTOs = result.Select(r => new PlanDTO
            {
                Id = r.Id,
                PlaceName = r.PlaceName,
                MinimumPrice = r.MinimumPrice
            }).ToList();

            return planDTOs;
        }
       
    }
}
