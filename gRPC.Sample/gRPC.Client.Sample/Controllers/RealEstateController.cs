using gRPC.Client.Sample.Services;
using gRPC.Client.Sample.Services.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace gRPC.Client.Sample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RealEstateController : ControllerBase
    {
        private readonly ILogger<RealEstateController> _logger;
        private readonly IRealEstateGrpcService _service;

        public RealEstateController(ILogger<RealEstateController> logger, IRealEstateGrpcService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet(Name = "gRPC")]
        public async Task<RealEstateDetailsDto> Get()
        {
            return await _service.GetRealEstateDetails();
        }
    }
}