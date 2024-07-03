using AutoMapper;
using AutoMapper.QueryableExtensions;
using CongestionTaxService.Application.Common.Interfaces;
using CongestionTaxService.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxService.Application.TaxRules.Queries.GetTaxRules
{
    public record GetTaxRulesQuery : IRequest<List<TaxRuleDto>>
    {
        public string City { get; set; }
    }

    public class GetTaxRulesQueryValidator : AbstractValidator<GetTaxRulesQuery>
    {
        public GetTaxRulesQueryValidator()
        {
            RuleFor(v => v.City)
                .NotEmpty()
                .WithErrorCode("City is empty.");
        }
    }

    public class GetTaxRulesQueryHandler : IRequestHandler<GetTaxRulesQuery, List<TaxRuleDto>>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetTaxRulesQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<List<TaxRuleDto>> Handle(GetTaxRulesQuery request, CancellationToken cancellationToken)
        {
            return await dbContext
                .TaxRules.AsNoTracking()
                .Where(x => x.City == request.City)
                .ProjectTo<TaxRuleDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }

    public class TaxRuleDto
    {        
        public string City { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int Amount { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<TaxRule, TaxRuleDto>();
            }
        }
    }
}
