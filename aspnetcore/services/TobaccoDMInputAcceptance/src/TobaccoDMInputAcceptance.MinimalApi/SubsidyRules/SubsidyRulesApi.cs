using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dedsi.Ddd.CQRS.Mediators;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using TobaccoDMInputAcceptance.InitialInspections.Commands;
using TobaccoDMInputAcceptance.InitialInspections;
using Volo.Abp.Guids;
using TobaccoDMInputAcceptance.SubsidyRules.Commands;

namespace TobaccoDMInputAcceptance.SubsidyRules;
public static class SubsidyRulesApi
{
    /// <summary>
    /// Map SubsidyRules Api
    /// </summary>
    /// <param name="builder"></param>
    public static void MapSubsidyRulesApi(this IEndpointRouteBuilder builder)
    {
        var api = builder
            .MapGroup(TobaccoDMInputAcceptanceMinimalApi.ApiPrefix + "/SubsidyRules")
            .WithTags("SubsidyRules");

        api.MapPost("/CreateSubsidyRule", CreateSubsidyRuleAsync);
    }

    private static Task<bool> CreateSubsidyRuleAsync([FromBody] CreateSubsidyRuleInputDto request,
        IDedsiMediator dedsiMediator,
        IGuidGenerator guidGenerator,
            HttpContext httpContext)
    {

        var projectCalculationFormulas = request.ProjectCalculationFormulas
                               .Select(a => new ProjectCalculationFormula(guidGenerator.Create(),a.NameOfInvestment,
                                     new CategoryOfInvestment(a.CategoryInvestment.Id,a.CategoryInvestment.Name),
                                     new TobaccoFarmerChoice(a.TobaccoFarmerChoice.Id,a.TobaccoFarmerChoice.Name),
                                     new TypeOfRegisteredAccount(a.TypeOfRegisteredAccount.Id,a.TypeOfRegisteredAccount.Name),
                                     new TobaccoVarieties(a.TobaccoVarieties.Id,a.TobaccoVarieties.Name),
                                     a.InputCriteria))
                                .ToArray();

        var publishingUnits = request.PublishingUnits
            .Select(a => new PublishingUnit(guidGenerator.Create(), a.depName, a.depCode))
            .ToArray();


        return dedsiMediator.SendAsync(new CreateInvestmentRulesCommand(
            request.projectNameOfInvestment,
            request.projectOfInvestmentNumber,
            new InvestInSmallCategories(request.inSmallCategories.PartId,request.inSmallCategories.PartName ,request.inSmallCategories.Id,request.inSmallCategories.Name),
            new TypeOfInvestment(request.typeInvestment.Id, request.typeInvestment.Name),
            request.isStatusConfig,
            request.allowSubordinateAdjustments,
            request.publishingStatus,
            request.createUserId,
            request.createUserName,
            projectCalculationFormulas,
            publishingUnits
            ), httpContext.RequestAborted);
    }
}
