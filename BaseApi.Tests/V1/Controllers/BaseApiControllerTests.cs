using AutoFixture;
using BaseApi.V1.Controllers;
using BaseApi.V1.UseCase;
using BaseApi.V1.UseCase.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.Tests.V1.Controllers
{
    [TestFixture]
    public class BaseApiControllerTests : LogCallAspectFixture
    {
        private BaseApiController _classUnderTest;
        private Mock<IGetByIdUseCase> _mockGetByIdUseCase;
        private Mock<IGetAllUseCase> _mockGetByAllUseCase;

        [SetUp]
        public void SetUp()
        {
            _mockGetByIdUseCase = new Mock<IGetByIdUseCase>();
            _mockGetByAllUseCase = new Mock<IGetAllUseCase>();
            _classUnderTest = new BaseApiController(_mockGetByAllUseCase.Object, _mockGetByIdUseCase.Object);
        }


        //Add Tests Here
    }
}
