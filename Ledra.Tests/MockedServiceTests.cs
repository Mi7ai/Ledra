using AutoMapper;
using FluentAssertions;
using Ledra.Application.Dtos;
using Ledra.Domain.Abstractions.Repositories;
using Ledra.Domain.Abstractions.Services;
using Ledra.Domain.Models;
using Ledra.Services;
using Moq;

namespace Ledra.Tests
{
    public class MockedServiceTests
    {
        [Fact]
        public async Task GetExpenseById_ShouldReturnCorrectExpense()
        {
            // Arrange
            var mockRepo = new Mock<IExpenseRepository>();
            var mockMapper = new Mock<IMapper>();

            // Example data
            var expenseId = 1;
            var expenseEntity = new Expense { ExpenseId = expenseId, Amount = 100, Description = "Test Expense" };
            var expenseDto = new ExpenseGetDto { ExpenseId = expenseId, Amount = 100, Description = "Test Expense DTO" };

            // Mock the repository to return an Expense
            mockRepo
                .Setup(repo => repo.GetExpenseByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(expenseEntity);

            // Mock the IMapper to map the Expense to ExpenseDto
            mockMapper
                .Setup(mapper => mapper.Map<ExpenseGetDto>(It.IsAny<Expense>()))
                .Returns(expenseDto);

            // Service under test
            var service = new ExpenseService(mockRepo.Object, mockMapper.Object);

            // Act
            var result = await service.GetExpenseByIdAsync(expenseId);

            // Assert
            result.Should().NotBeNull();
            result.ExpenseId.Should().Be(expenseDto.ExpenseId);
            result.Amount.Should().Be(expenseDto.Amount);
            result.Description.Should().Be(expenseDto.Description);

            // Verify that repository and mapper were called
            mockRepo.Verify(repo => repo.GetExpenseByIdAsync(expenseId), Times.Once);
            mockMapper.Verify(mapper => mapper.Map<ExpenseGetDto>(expenseEntity), Times.Once);
        }

        [Fact]
        public async Task GetExpenseById_ShouldReturnNull()
        {
            // Arrange
            var mockRepo = new Mock<IExpenseRepository>();
            var mockMapper = new Mock<IMapper>();
            var expenseId = 123;

            // Act
            mockRepo
                .Setup(repo => repo.GetExpenseByIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult<Expense?>(null));

            // Assert
            // Call the method being tested
            var result = await mockRepo.Object.GetExpenseByIdAsync(expenseId);

            // Verify that result is null
            Assert.Null(result);
        }
    }
}
