using Data.Models;
using SendGrid.Helpers.Errors.Model;
using Shared.DTO;
using Shared.Exceptions;
using Shared.Repositories;
using Shared.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services
{
    public class CompanyService(CompanyRepository _companyRepository) : ICompanyService
    {

        public async Task AddCompany(AddCompanyDTO company)
        {
            if (await _companyRepository.CompanyExists(company.CompanyCode))
            {
                throw new DuplicateException($"The company code {company.CompanyCode} is already exist");
            }

            var newCompany = new Company()
            {
                CompanyCode = company.CompanyCode,
                CompanyName = company.CompanyName,
            };

            await _companyRepository.AddAsync(newCompany);
        }

        public async Task<CompanyDTO> GetCompanyByCode(int companyCode)
        {
            if (!await _companyRepository.CompanyExists(companyCode))
            {
                throw new Exceptions.MyNotFoundException($"The company code {companyCode} is not exist");
            }

            CompanyDTO company = await _companyRepository.CompanyByCode(companyCode);

            return company;
        }

        public async Task<List<CompanyDTO>> GetAllCompanies()
        {
            var companies = await _companyRepository.GetAllCompanies();
            return companies;

        }

    }
}
