using AutoMapper;
using Computerstore.Tests.RepositoryTests;
using ComputerStore.Api.Controllers;
using ComputerStore.Api.Repositories;
using ComputerStore.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Computerstore.Tests.ControllerTests
{
    public class ControllerTest : RepositoryTestBase
    {
        #region - Private Properties -
        private IMapper _mapper;
        #endregion

        #region - Constructor -
        public ControllerTest()
        {
            // automapper configuration
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfileConfiguration());
            });
            _mapper = config.CreateMapper();
        }
        #endregion

        [Fact]
        public async void TestPcPartControllerGetALl()
        {
            // arrange
            var repo = new PcPartRepository(_context, _mapper);
            var controller = new PcPartsController(repo);

            // act
            var result = await controller.Get();

            // assert
            var objectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(StatusCodes.Status200OK, objectResult.StatusCode);

        }

        [Fact]
        public async void TestPcPartControllerGetById()
        {
            // arrange
            var repo = new PcPartRepository(_context, _mapper);
            var controller = new PcPartsController(repo);

            // act
            var result = await controller.Get(1);

            // assert
            var objectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(StatusCodes.Status200OK, objectResult.StatusCode);

        }

        [Fact]
        public async void TestPcPartControllerParts()
        {
            // arrange
            var repo = new PcPartRepository(_context, _mapper);
            var controller = new PcPartsController(repo);

            // act
            var result = await controller.PartById();

            // assert
            var objectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(StatusCodes.Status200OK, objectResult.StatusCode);

        }

        [Fact]
        public async void TestPcPartControllerGetPartByPcPartId()
        {
            // arrange
            var repo = new PcPartRepository(_context, _mapper);
            var controller = new PcPartsController(repo);

            // act
            var result = await controller.PartByPartId(4);

            // assert
            var objectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(StatusCodes.Status200OK, objectResult.StatusCode);

        }

        [Fact]
        public void TestPcPartControllerGetCategories()
        {
            // arrange
            var repo = new PcPartRepository(_context, _mapper);
            var controller = new PcPartsController(repo);

            // act
            var result = controller.Categories();

            // assert
            var objectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(StatusCodes.Status200OK, objectResult.StatusCode);

        }

        [Fact]
        public async void TestPcPartControllerCategoryByName()
        {
            // arrange
            var repo = new PcPartRepository(_context, _mapper);
            var controller = new PcPartsController(repo);

            // act
            var result = await controller.CategoryByName("Gpu");

            // assert
            var objectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(StatusCodes.Status200OK, objectResult.StatusCode);

        }

        [Fact]
        public async void TestPcPartControllerBasicById()
        {
            // arrange
            var repo = new PcPartRepository(_context, _mapper);
            var controller = new PcPartsController(repo);

            // act
            var result = await controller.BasicById(4);

            // assert
            var objectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(StatusCodes.Status200OK, objectResult.StatusCode);

        }

        [Fact]
        public async void TestPcPartControllerImageByFileName()
        {
            // arrange
            var repo = new PcPartRepository(_context, _mapper);
            var controller = new PcPartsController(repo);
            var contentType = "image/jpeg" ;


            // act
            var result = controller.ImageByFileName("amd_ryzen_5.jpg");

            // assert
            var objectResult = Assert.IsType<PhysicalFileResult>(result);
            Assert.Equal(contentType, objectResult.ContentType);
        }



    }
}
