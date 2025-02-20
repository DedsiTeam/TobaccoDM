using Dedsi.Ddd.CQRS.CommandHandlers;
using TobaccoDMInputAcceptance.Repositories.SubsidyRules;
using TobaccoDMInputAcceptance.SubsidyRules.Commands;

namespace TobaccoDMInputAcceptance.SubsidyRules.CommandHandlers;

public class CreateInvestmentRulesCommandHandler(ISubsidyRulesRepository subsidyRulesRepository) : DedsiCommandHandler<CreateInvestmentRulesCommand, bool>
{
    public override async Task<bool> Handle(CreateInvestmentRulesCommand command, CancellationToken cancellationToken)
    {

        var investmentRules = new InvestmentRules(GuidGenerator.Create(), 
             command.projectNameOfInvestment, 
             command.projectOfInvestmentNumber,
             command.inSmallCategories, 
             command.typeInvestment, 
             command.isStatusConfig,
             command.allowSubordinateAdjustments, 
             command.publishingStatus, 
             command.createUserId, 
             command.createUserName);
        
        investmentRules.AddProjectCalculationFormulaParId(command.ProjectCalculationFormulas);

        investmentRules.AddPublishingUnitParId(command.PublishingUnits);

        await subsidyRulesRepository.InsertAsync(investmentRules, false, cancellationToken);

        return true;
    }
}
