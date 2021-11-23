using System;
using Xunit;
using FluentAssertions;
using WeeklyReport;
using WeeklyReport.Repositories;

namespace Weekly_Report_IntegrationTests
{
    public class CompanyTest
    {
        [Fact]
        public void ShouldBeAbleToCreateCompanyRepository()
        {
            var companyRepo = new CompanyRepository();
            companyRepo.Should().NotBeNull();
        }
        [Fact]
        public void ShouldBeAbleToCreateCompanyInDatabase()
        {
            var companyRepo = new CompanyRepository();

            var company = new Company();
            company.Name = "ANKOCorp";
            company.EstablishDate = "11.08.99";
            companyRepo.Create(company);
            company.Should().NotBeNull();
            company.Name.Should().Be("ANKOCorp");
            company.EstablishDate.Should().Be("11.08.99");
            //company.CompanyId.Should().BeGreaterThan(0);
            
        }
        [Fact]
        public void ShouldBeAbleToReadCompany()
        {
            var companyRepo = new CompanyRepository();
            var company = companyRepo.Read(18); ;
            company.Name.Should().Be("ANKOCorp");
            company.EstablishDate.Should().Be("11.08.99");
            company.CompanyId.Should().Be(18);
        }
        [Fact]
        public void ShouldBeAbleToUpdateCompany()
        {
            var companyRepo = new CompanyRepository();
            var company = companyRepo.Read(17);
            company.Name = "Google";
            company.EstablishDate = "Unknown";
            var companyUpdated = companyRepo.Update(company);
            companyUpdated.Name.Should().Be("Google");
            company.EstablishDate.Should().Be("Unknown");
        }
        [Fact]
        public void ShouldBeAbleToDeleteCompany()
        {
            var companyRepo = new CompanyRepository();
            var company = companyRepo.Delete(7);
            company.Should().BeNull();
            
        }
    }
}
