using MembershipsDemo.Interfaces;
using Moq;

namespace MembershipsDemo.Tests
{
    [TestClass]
    public class PartnerTest
    {
        Mock<IPartner> mock;
        public PartnerTest()
        {
            var model = new Models.Partner
            {
                Id = 1,
                CreatedAt = DateTime.Now,
                CreatedBy = "admin",
                Email = "bzaid2@gmail.com",
                EmergencyPhone = "",
                Gender = Models.GenderType.Hombre,
                LastName = "López",
                Name = "Brandon",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "admin",
                Phone = string.Empty
            };
            mock = new Mock<IPartner>();
            mock.Setup(p => p.FindAllAsync()).ReturnsAsync(new List<Models.Partner>
            {
                model
            });
            mock.Setup(p => p.AddAsync(It.IsAny<Models.Partner>())).ReturnsAsync(true);
            mock.Setup(p => p.FindByIdAsync(1)).ReturnsAsync(model);
            mock.Setup(p => p.DeleteAsync(1)).ReturnsAsync(true);
            mock.Setup(p => p.UpdateAsync(It.IsAny<Models.Partner>())).ReturnsAsync(true);
        }

        [TestMethod]
        public async Task GetAllPartners()
        {
            // Arrange
            IPartner partnerService = mock.Object;

            // Act
            var result = await partnerService.FindAllAsync();

            // Assert
            Assert.IsTrue(result.Count() > 0);
        }

        [TestMethod]
        public async Task CreateNewPartner()
        {
            // Arrange
            IPartner partnerService = mock.Object;
            var model = new Models.Partner
            {
                CreatedAt = DateTime.Now,
                CreatedBy = "admin",
                Email = "bzaid2@gmail.com",
                EmergencyPhone = "",
                Gender = Models.GenderType.Hombre,
                LastName = "López",
                Name = "Brandon",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "admin",
                Phone = string.Empty
            };

            // Act
            var result = await partnerService.AddAsync(model);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task FindPartnerById()
        {
            // Arrange
            IPartner partnerService = mock.Object;
            var id = 1;

            // Act
            var result = await partnerService.FindByIdAsync(id);

            // Assert
            Assert.IsTrue(result.Id > 0);
        }

        [TestMethod]
        public async Task DeletePartnerById()
        {
            // Arrange
            IPartner partnerService = mock.Object;
            var id = 1;

            // Act
            var result = await partnerService.DeleteAsync(id);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task UpdatePartner()
        {
            // Arrange
            IPartner partnerService = mock.Object;
            var model = await partnerService.FindByIdAsync(1);
            model.UpdatedAt = DateTime.Now;
            model.UpdatedBy = "Admin2";
            model.Phone = "55 4421 1234";

            // Act
            var result = await partnerService.UpdateAsync(model);

            // Assert
            Assert.IsTrue(result);
        }
    }
}