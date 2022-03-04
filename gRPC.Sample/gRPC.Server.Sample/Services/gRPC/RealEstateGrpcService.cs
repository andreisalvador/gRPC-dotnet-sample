using Grpc.Core;

namespace gRPC.Server.Sample.Services.gRPC
{
    public class RealEstateGrpcService : RealEstate.RealEstateBase
    {
        private readonly ILogger<RealEstateGrpcService> _logger;

        public RealEstateGrpcService(ILogger<RealEstateGrpcService> logger)
        {
            _logger = logger;
        }

        public override Task<RealEstateDetailsResponse> GetDetails(GetDetailsRequest request, ServerCallContext context)
        {
            _logger.LogInformation("Request received");

            return Task.FromResult(new RealEstateDetailsResponse()
            {
                Id = Guid.NewGuid().ToString(),
                Streetname = "Any name st.",
                Number = 123
            });
        }
    }
}
