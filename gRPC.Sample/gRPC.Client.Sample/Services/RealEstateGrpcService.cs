using gRPC.Client.Sample.Services.Dtos;
using gRPC.Server.Sample.Services.gRPC;

namespace gRPC.Client.Sample.Services
{
    public interface IRealEstateGrpcService
    {
        Task<RealEstateDetailsDto> GetRealEstateDetails();
    }
    public class RealEstateGrpcService : IRealEstateGrpcService
    {
        private readonly RealEstate.RealEstateClient _realEstateClient;

        public RealEstateGrpcService(RealEstate.RealEstateClient realEstateClient)
        {
            _realEstateClient = realEstateClient;
        }

        public async Task<RealEstateDetailsDto> GetRealEstateDetails()
        {            
            var x = await _realEstateClient.GetDetailsAsync(new GetDetailsRequest());

            return new RealEstateDetailsDto()
            {
                Id = Guid.Parse(x.Id),
                StreetName = x.Streetname,
                Number = x.Number
            };
        }
    }
}
