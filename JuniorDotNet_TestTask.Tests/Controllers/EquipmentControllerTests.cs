using FakeItEasy;
using FluentAssertions;
using FluentAssertions.Equivalency;
using JuniorDotNet_TestTask.Controllers;
using JuniorDotNet_TestTask.DTOs;
using JuniorDotNet_TestTask.Interfaces;
using JuniorDotNet_TestTask.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuniorDotNet_TestTask.Tests.Controllers
{
    public class EquipmentControllerTests
    {
        private readonly IEquipmentContractRepository _contractRepository;
        private readonly EquipmentContractController _controller;

        public EquipmentControllerTests()
        {
            _contractRepository = A.Fake<IEquipmentContractRepository>();
            _controller = new EquipmentContractController(_contractRepository);
        }

        [Fact]
        public async void CreateContract_ShouldReturnBadRequest_WhenAreaIsFull()
        {
            // Arrange
            var contract = new CreateContractDto()
            {
                ProductionFacilityCode = "FAC5",
                EquipmentTypeCode = "EQ10",
                EquipmentQuantity = 10,
            };

            // Mock repository to return a facility with limited area
            A.CallTo(() => _contractRepository.GetProductionFacilityByCodeAsync(contract.ProductionFacilityCode))
                .Returns(new ProductionFacility { Id = 5, Code = "FAC5", Name = "Factory 5", StandardArea = 2500});

            // Mock repository to return equipment type with a large area requirement
            A.CallTo(() => _contractRepository.GetProcessEquipmentTypeByCodeAsync(contract.EquipmentTypeCode))
                .Returns(new ProcessEquipmentType { Id =  10, Code = "EQ10", Name = "Type 10 Extreme", Area = 200});

            // Mock repository to indicate most of the area is already used
            A.CallTo(() => _contractRepository.GetUsedAreaForFacilityAsync(5)).Returns(2000);

            // Act
            var result = await _controller.CreateContract(contract);

            // Assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public async Task CreateContract_ShouldReturnOk_WhenContractIsValid()
        {
            //Arrange
            var dto = new CreateContractDto
            {
                ProductionFacilityCode = "FAC1",
                EquipmentTypeCode = "EQ1",
                EquipmentQuantity = 5
            };

            var facility = new ProductionFacility { Id = 1, Code = "FAC1", Name = "Factory 1", StandardArea = 500 };
            var equipmentType = new ProcessEquipmentType { Id = 1, Code = "EQ1", Name = "Type 1 Equipment", Area = 50 };
            var contract = new EquipmentPlacementContract()
            {
                ProcessEquipmentTypeId = equipmentType.Id,
                ProductionFacilityId = facility.Id,
                EquipmentQuantity = dto.EquipmentQuantity
            };


            // Mock repository to return valid facility and equipment type
            A.CallTo(() => _contractRepository.GetProductionFacilityByCodeAsync(dto.ProductionFacilityCode))
                .Returns(facility);
            A.CallTo(() => _contractRepository.GetProcessEquipmentTypeByCodeAsync(dto.EquipmentTypeCode))
                .Returns(equipmentType);

            // Mock repository to indicate no area is used
            A.CallTo(() => _contractRepository.GetUsedAreaForFacilityAsync(1))
                .Returns(0);
            A.CallTo(() => _contractRepository.CreateAsync(A<EquipmentPlacementContract>.Ignored))
                .Returns(contract);


            //Act
            var result = await _controller.CreateContract(dto);

            //Assert
            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async void CreateContract_ShouldReturnNotFound_WhenFacilityDoesNotExist()
        {
            //Arrange
            var dto = new CreateContractDto
            {
                ProductionFacilityCode = "NON_EXISTENT",
                EquipmentTypeCode = "EQ1",
                EquipmentQuantity = 5
            };


            A.CallTo(() => _contractRepository.GetProductionFacilityByCodeAsync(dto.ProductionFacilityCode))
                .Returns(Task.FromResult<ProductionFacility?>(null));


            //Act
            var result = await _controller.CreateContract(dto);

            //Assert
            result.Should().BeOfType<NotFoundObjectResult>();
        }

        [Fact]
        public async void GetContract_ShouldReturnOk_WhenContractsExist()
        {
            //Arrange
            var contracts = new List<EquipmentPlacementContract>
            {
                new EquipmentPlacementContract
                {
                    Id = 1,
                    ProductionFacility = new ProductionFacility { Name = "Factory 1" },
                    ProcessEquipmentType = new ProcessEquipmentType { Name = "Type 1 Equipment" },
                    EquipmentQuantity = 5
                },
                new EquipmentPlacementContract
                {
                    Id = 2,
                    ProductionFacility = new ProductionFacility { Name = "Factory 2" },
                    ProcessEquipmentType = new ProcessEquipmentType { Name = "Type 2 Equipment" },
                    EquipmentQuantity = 10
                }
            };


            A.CallTo(() => _contractRepository.GetAllContractsAsync())
                .Returns(contracts);


            //Act
            var result = await _controller.GetContracts();


            //Assert
            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task GetContracts_ShouldReturnOkWithEmptyList_WhenNoContractsExist()
        {
            //Arrange
            A.CallTo(() => _contractRepository.GetAllContractsAsync())
                .Returns(new List<EquipmentPlacementContract>());

            //Act
            var result = await _controller.GetContracts();

            //Assert
            result.Should().BeOfType<OkObjectResult>();
        }
    }
}
