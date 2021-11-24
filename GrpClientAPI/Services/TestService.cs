using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnitOfWork.Interfaces;

namespace GrpClientAPI.Services
{
    public class TestService: Test.TestBase
    {
        private readonly ILogger<TestService> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TestService(ILogger<TestService> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        /// <summary>
        /// Getting all Test from DB Test
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task<TestModels> GetAllTests(Empty request, ServerCallContext context)
        {
            _logger.Log(LogLevel.Information, $"Starting into Method: {nameof(GetAllTests)}");
            using (var uwork = _unitOfWork.CreateRepositoryGRPC_Test())
            {
                var result = await uwork.Repositories.TestRepository.GetAll();
                IEnumerable<TestModel> models = _mapper.Map<IEnumerable<Models.FromProto.TestModel>, 
                    IEnumerable<TestModel>>(result);

                return new TestModels
                {
                    TestModelList = { models }
                };
            }
        }
        /// <summary>
        /// Inserting test
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task<Empty> InsertTest(TestModel request, ServerCallContext context)
        {
            _logger.Log(LogLevel.Information, $"Starting into Method: {nameof(InsertTest)}");
            using (var uwork = _unitOfWork.CreateRepositoryGRPC_Test())
            {
                var model = _mapper.Map<TestModel, Models.FromProto.TestModel >(request);
                await uwork.Repositories.TestRepository.Create(model);
                return new Empty();
            }
        }
    }
}
