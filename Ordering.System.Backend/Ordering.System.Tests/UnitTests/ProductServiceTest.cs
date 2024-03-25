using AutoMapper;
using FluentAssertions;
using Moq;
using Ordering.System.Api.Entities;
using Ordering.System.Api.Models;
using Ordering.System.Api.Repositories.Interfaces;
using Ordering.System.Api.Services;
using Ordering.System.Tests.Mocks;

namespace Ordering.System.Tests.UnitTests
{
    public class ProductServiceTest
    {
        [Fact]
        public async void Should_Create_Product_And_Should_Be_Returned_By_Repository()
        {
            // Arrange
            var product = ProductMock.GetValidProduct();
            var inputProduct = ProductMock.GetValidInputProduct();
            var repository = new Mock<IProductRepository>();
            var mapper = new Mock<IMapper>();

            repository.Setup(repo =>
                repo.CreateProductAsync(It.IsAny<Product>()))
                .ReturnsAsync(product);

            repository.Setup(repo =>
               repo.ExistProductByIdAsync(It.IsAny<Guid>()))
               .ReturnsAsync(false);

            mapper.Setup(mapper => mapper.Map<Product>(inputProduct)).Returns(product);

            var service = new ProductService(repository.Object, mapper.Object);

            // Act
            var productData = await service.CreateProductAsync(inputProduct);

            // Assert
            productData.Should().Be(product);
            repository.Verify(repo => repo.CreateProductAsync(product), Times.Once);
        }

        [Fact]
        public async void Should_Update_Product_And_Should_Be_Returned_By_Repository()
        {
            // Arrange
            var product = ProductMock.GetValidProduct();
            var inputProduct = ProductMock.GetValidInputProduct();
            var updatedProduct = ProductMock.GetUpdatedProduct(product);
            var repository = new Mock<IProductRepository>();
            var mapper = new Mock<IMapper>();

            repository.Setup(repo =>
               repo.ExistProductByIdAsync(It.IsAny<Guid>()))
               .ReturnsAsync(true);

            repository.Setup(repo =>
                repo.UpdateProductAsync(It.IsAny<Product>()))
                .ReturnsAsync(updatedProduct);

            mapper.Setup(mapper => mapper.Map<Product>(inputProduct)).Returns(product);

            var service = new ProductService(repository.Object, mapper.Object);

            // Act
            var productData = await service.UpdateProductAsync(inputProduct);

            // Assert
            productData.Should().Be(updatedProduct);
            repository.Verify(repo => repo.UpdateProductAsync(product), Times.Once);
        }

        [Fact]
        public async void Should_GetProductById_And_Returned_By_Repository()
        {
            // Arrange
            var product = ProductMock.GetValidProduct();
            var productDto = ProductMock.GetValidProductsDto();
            var repository = new Mock<IProductRepository>();
            var mapper = new Mock<IMapper>();

            repository.Setup(repo =>
                repo.GetProductByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(product);

            mapper.Setup(mapper => mapper.Map<ProductViewModel>(product)).Returns(productDto);

            var service = new ProductService(repository.Object, mapper.Object);

            // Act
            var productData = await service.GetProductByIdAsync(product.Id);

            // Assert
            productData.Should().BeOfType<ProductViewModel>();
            productData.Should().BeEquivalentTo(productDto);
        }


        [Fact]
        public async void Should_Ge_All_tProducts_And_Returned_By_Repository()
        {
            // Arrange
            var products = new List<Product> { ProductMock.GetValidProduct() };
            var productsDto = new List<ProductViewModel> { ProductMock.GetValidProductsDto() };
            var pagination = new Pagination() { PageNumber = 1, PageSize = 1 };

            var repository = new Mock<IProductRepository>();
            var mapper = new Mock<IMapper>();

            repository.Setup(repo =>
                repo.GetProductsAsync(pagination))
                .ReturnsAsync(products);

            mapper.Setup(mapper => mapper.Map<IEnumerable<ProductViewModel>>(products)).Returns(productsDto);

            var service = new ProductService(repository.Object, mapper.Object);

            // Act
            var productsData = await service.GetProductsAsync(pagination);

            // Assert
            productsData.Should().BeOfType<List<ProductViewModel>>();
            productsData.Should().BeEquivalentTo(productsDto);
        }

        [Fact]
        public async void Should_Delete_Product_With_Success()
        {
            // Arrange
            var product = ProductMock.GetValidProduct();
            var repository = new Mock<IProductRepository>();
            var mapper = new Mock<IMapper>();

            repository.Setup(repo =>
                repo.DeleteProductAsync(It.IsAny<Product>()))
                .ReturnsAsync(product);

            var service = new ProductService(repository.Object, mapper.Object);

            // Act
            var productData = await service.DeleteProductByIdAsync(product.Id);

            // Assert
            productData.Should().BeNull();
        }

        [Fact]
        public async void Should_Verify_If_Products_Exists_And_Return_True()
        {
            // Arrange
            var repository = new Mock<IProductRepository>();
            var mapper = new Mock<IMapper>();

            repository.Setup(repo =>
                repo.ExistProductByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(true);

            var service = new ProductService(repository.Object, mapper.Object);

            // Act
            var result = await service.ExistProductAsync(Guid.NewGuid());

            // Assert
            result.Should().BeTrue();
        }
    }
}
