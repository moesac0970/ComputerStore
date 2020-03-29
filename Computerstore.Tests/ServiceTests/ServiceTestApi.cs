using AutoMapper;
using Computerstore.Tests.Data;
using ComputerStore.Api.Repositories;
using ComputerStore.Api.Services;
using ComputerStore.Lib.Dto;
using ComputerStore.Lib.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Computerstore.Tests.ServiceTests
{
    public class ServiceTestApi
    {
        public ServiceTestApi()
        {
        }

        [Fact]
        public async Task TestGenerateBearer()
        {
            // arange 
            List<IdentityRole<string>> claims = new List<IdentityRole<string>>();
            claims.Add(MockData.StandardUserRoles);
                // request 
            var request = new Mock<HttpRequest> ();
            request.Setup(r => r.Headers["Authorization"])
                   .Returns("basic johndoe@email.com");
                // context 
            var context = new Mock<UsersRepository>();
            context.Setup(c => c.GetUserByNameAsync("johndoe@email.com"))
                   .Returns<User>(d => MockData.StandardUser);
            context.Setup(c => c.GetRolesById(MockData.StandardUser.Id))
                   .Returns<Task<List<IdentityRole<string>>>>( d=> Task.FromResult(claims));
                // bearerRepo 
            var repo = new Mock<BearerHistoryRepository>();
            repo.Setup(b => b.CreateBearerHistory(MockData.TokenStringStandardUser, MockData.StandardUser))
                .Returns(Task.FromResult(MockData.BearerHistoryEntryStandardUser));
                // service to assert
            var bearerService = new BearerTokenService(context.Object, repo.Object);

            // act
            var result = await bearerService.GenerateBearerToken(request.Object);

            // assert
            Assert.NotEqual("wrong request", result);
            Assert.NotEqual("not valid user", result);

        }

        [Fact] // isnt right when testingen but when debugging it is?
        public void TestNewOrNahServiceFalse()
        {
            // arrange 
            DateTime date = DateTime.Now.Subtract(new TimeSpan(6, 0, 0, 0));

            // act
            PcPartBasic partBasic = new PcPartBasic
            {
                Hot = DtoServices.NewOrNah(date)
            };

            // assert
            Assert.True(!partBasic.Hot);
        }

        [Fact]
        public void TestNewOrNahServiceTrue()
        {
            // arrange 
            DateTime date = DateTime.Now;

            // act
            PcPartBasic partBasic = new PcPartBasic
            {
                Hot = DtoServices.NewOrNah(date)
            };

            // assert
            Assert.True(partBasic.Hot);
        }

        [Fact]
        public void TestConverterBytesToMBytes()
        {
            // arrange 
            long bytes = 50000000;

            // act
            double mBytes = ValueConversionService.ConvertBytesToMegabytes(bytes);

            // assert
            Assert.Equal(47.6837158203125, mBytes);
        }

        [Fact]
        public void TestConverterKBtoMB()
        {
            // arrange 
            long kiloBytes = 5000000;

            // act
            double megaBytes = ValueConversionService.ConvertKilobytesToMegabytes(kiloBytes);

            // assert
            Assert.Equal(4882.8125, megaBytes);
        }
    }
}
