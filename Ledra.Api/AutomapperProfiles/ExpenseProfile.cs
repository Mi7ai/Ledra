using AutoMapper;
using Ledra.Application.Dtos;
using Ledra.Domain.Models;

namespace Ledra.Api.AutomapperProfiles
{
    public class ExpenseProfile : Profile
    {
        public ExpenseProfile()
        {
            CreateMap<ExpensePostPutDto, Expense>()
            .ForMember(dest => dest.ExpenseId, opt => opt.Ignore()) // Ignore ID during mapping
            .ForMember(dest => dest.CreatedDate, opt => opt.Ignore()) // Ignore CreatedDate
            .ForMember(dest => dest.UpdatedDate, opt => opt.Ignore()); // Set UpdatedDate manually

            CreateMap<Expense, ExpenseGetDto>();

        }
    }
}
