using AutoMapper;
using Computerstore.Tests.Data;
using ComputerStore.Api.Repositories;
using ComputerStore.Api.Services;
using ComputerStore.Data;
using ComputerStore.Lib.Models;
using ComputerStore.Lib.Models.Parts;
using ComputerStore.Lib.Models.PartTypes.Enumerations;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Computerstore.Tests.RepositoryTests
{
    public class RepostitoryTests : RepositoryTestBase
    {
        #region - Private Properties -
        private IMapper _mapper;
        #endregion

        #region - Constructor -
        public RepostitoryTests()
        {
            // automapper configuration
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfileConfiguration());
            });
            _mapper = config.CreateMapper();
        }
        #endregion

        #region - Test -
        /// <summary>
        /// This is the class for testing the repositories
        /// 
        /// repo's to be tested:
        /// - pcparts
        /// - messages
        /// - maker
        /// - pcbuild
        /// - users
        /// - orders
        /// - parts (cpu's, gpu's, memories, motherboards, pccases)
        /// 
        /// - specific
        /// --> CRUD on all of the repositories
        /// --> GetById
        /// 
        /// --> pcparts
        ///     - GetImagePathByName
        ///     - CreateImage
        ///     - GetAllbyCategoryName
        ///     - GetByPartId
        ///     - getPartBasicById
        ///     - GetPartsBasic
        ///     - HandleNewPcpart
        /// 
        /// --> users
        ///     - gertrolesById
        ///     - getUserByBearer
        ///     
        /// --> messages
        ///     - getByUserId
        /// 
        /// --> bearerHistory
        ///     - getuserfromBearter
        ///     - bearerHistory
        /// </summary>



        [Fact]
        public void TestGetAllPcParts()
        {
            // Arrange
            var repo = new PcPartRepository(_context, _mapper);

            // act
            var result = repo.GetAll();

            // assert
            Assert.Equal(34, result.Count());
        }

        [Fact]
        public async Task TestPcPartsGetById()
        {
            // arrange
            var repo = new PcPartRepository(_context, _mapper);
       
            // act
            var result = await repo.GetById(1);

            // assert
            Assert.Equal(MockData.StandardPcPart.Name, result.Name);
        }

        [Fact]
        public async Task TestGetAllByCategoryNamePCpartsRepo()
        {
            // arrange
            var repo = new PcPartRepository(_context, _mapper);
                // expected
            var parts = repo.db.PcParts.Where(p => p.Type == PartType.Gpu).ToList();

            // act
            var result = await repo.GetAllByCategoryName("Gpu");

            // assert
            Assert.Equal(parts, result);
        }

        [Fact]
        public async Task TestPcPartRepoGetPartByPcPartId()
        {
            // arrange
            var repo = new PcPartRepository(_context, _mapper);
            int partIndex = 5;
            var expected = MockData.Cpus.Where(c => c.Id == 2).FirstOrDefault(); // 2 is the cpu with partId 5

            // act
            var result = await repo.GetPartById(partIndex);

            // assert
            Assert.Equal(expected.PcPartId, result.PcPartId);
        }

        [Fact]
        public async Task TestDeletePcPart()
        {
            // arrange
            var repo = new PcPartRepository(_context, _mapper);

            // act
            var result = await repo.Delete(1);

            // assert
            Assert.Equal(MockData.StandardPcPart.Name, result.Name);
        }

        [Fact]
        public void TestPcPartRepoForImageByName()
        {
            // arrange
            var repo = new PcPartRepository(_context, _mapper);
            // expected
            var image = MockData.ListOfImages.Where(i=> i.FileName == "amd_ryzen_5.jpg").FirstOrDefault();

            // act
            var result = repo.GetImagePathByName("amd_ryzen_5.jpg");

            // assert
            Assert.Equal(image.Id, result.Id);
        }

        [Fact]
        public async void TestPcPartForListBasic()
        {
            // arrange
            var repo = new PcPartRepository(_context, _mapper);
            // expected

            // act
            var result = await repo.GetPartsBasic();

            // assert
            Assert.Equal(MockData.ListOfPcParts.Count(), result.Count());
        }

        [Fact]
        public async void TestPcPartForBasicPart()
        {
            // arrange
            var repo = new PcPartRepository(_context, _mapper);
            // expected
            string expectedPartName = MockData.StandardPcPart.Name;

            // act
            var result = await repo.GetPartsBasicById(1); 

            // assert
            Assert.Equal(expectedPartName, result.Name);
        }

        [Fact]
        public async void TestPcPartUpdatePcPart()
        {
            // arrange
            var repo = new PcPartRepository(_context, _mapper);
            // expected
            var expectedPartName = MockData.StandardPcPart.Name;

            // act
            var result = await repo.Update(await repo.GetById(1));

            // assert
            Assert.Equal(expectedPartName, result.Name);
        }

        [Fact]
        public async void TestPcPartAddPcPart()
        {
            // arrange
            var repo = new PcPartRepository(_context, _mapper);
            // expected
            var PartToAdd = await repo.GetById(1);
            PartToAdd.Name = "GeForce GTX 2090 Ti";

            // act
            var result = await repo.Add(PartToAdd);

            // assert
            Assert.Equal(PartToAdd.Name, result.Name);
        }

        [Fact]
        public void TestGetAllMakers()
        {
            // arrange
            var repo = new MakerRepository(_context, _mapper);

            // act
            var result =  repo.GetAll();

            // assert
            Assert.Equal(MockData.ListOfMakers.Count(), result.Count()) ;
        }

        [Fact]
        public async void TestGetMakerById()
        {
            // arrange
            int indexMaker = 5;
            var repo = new MakerRepository(_context, _mapper);
            Maker Expected = MockData.ListOfMakers.Where(m => m.Id == indexMaker).FirstOrDefault();

            // act
            var result = await repo.GetById(indexMaker);

            // assert
            Assert.Equal(Expected.Id, result.Id);
        }

        [Fact]
        public async void TestDeleteMakerById()
        {
            // arrange
            int indexMaker = 5;
            var repo = new MakerRepository(_context, _mapper);
            Maker Expected = MockData.ListOfMakers.Where(m => m.Id == indexMaker).FirstOrDefault();

            // act
            var result = await repo.Delete(indexMaker);

            // assert
            Assert.Equal(Expected.Id, result.Id);
        }

        [Fact]
        public async void TestUpdateMaker()
        {
            // arrange
            int indexMaker = 5;
            var repo = new MakerRepository(_context, _mapper);
            Maker Expected = MockData.ListOfMakers.Where(m => m.Id == indexMaker).FirstOrDefault();

            // act
            var result = await repo.Update(Expected);

            // assert
            Assert.Equal(Expected, result);
        }

        [Fact]
        public void TestPartsGetAllCpu()
        {
            // arrange
            var repo = new PartRepository<Cpu>(_context, _mapper);

            // act
            var result = repo.GetAll();

            // assert
            Assert.Equal(MockData.Cpus.Count(), result.Count()) ;
        }

        [Fact]
        public  void TestPartsGetAllGpu()
        {
            // arrange
            var repo = new PartRepository<Gpu>(_context, _mapper);

            // act
            var result = repo.GetAll();

            // assert
            Assert.Equal(MockData.Gpus.Count(), result.Count());
        }

        [Fact]
        public void TestPartsGetAllMotherBoard()
        {
            // arrange
            var repo = new PartRepository<MotherBoard>(_context, _mapper);

            // act
            var result = repo.GetAll();

            // assert
            Assert.Equal(MockData.MotherBoards.Count(), result.Count());
        }


        [Fact]
        public void TestPartsGetAllPcCase()
        {
            // arrange
            var repo = new PartRepository<PcCase>(_context, _mapper);

            // act
            var result = repo.GetAll();

            // assert
            Assert.Equal(MockData.PcCases.Count(), result.Count());
        }

        [Fact]
        public void TestPartsGetAllMemory()
        {
            // arrange
            var repo = new PartRepository<Memory>(_context, _mapper);

            // act
            var result = repo.GetAll();

            // assert
            Assert.Equal(MockData.Memories.Count(), result.Count());
        }
        
        [Fact]
        public async void TestPartRepoForDelete()
        {
            // arrange
            int indexCpu = 5;
            var repo = new PartRepository<Cpu>(_context, _mapper);
            var expected = MockData.Cpus.Where(c => c.Id == indexCpu).FirstOrDefault();

            // act
            var result = await repo.Delete(indexCpu);

            // assert
            Assert.Equal(expected.Id, result.Id);
        }

        [Fact]
        public async void TestPartRepoForUpdate()
        {
            // arrange
            int indexCpu = 5;
            var repo = new PartRepository<Cpu>(_context, _mapper);
            var expected = MockData.Cpus.Where(c => c.Id == indexCpu).FirstOrDefault();

            // act
            var result = await repo.Update(expected);

            // assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public async void TestPartRepoForAdd()
        {
            // arrange
            int indexCpu = 5;
            var repo = new PartRepository<Cpu>(_context, _mapper);
            var expected = MockData.Cpus.Where(c => c.Id == indexCpu).FirstOrDefault();
            
            // act
            var result = await repo.Add(expected);

            // assert
            Assert.Equal(expected.Description, result.Description);
        }

        

        #endregion

    }
}
