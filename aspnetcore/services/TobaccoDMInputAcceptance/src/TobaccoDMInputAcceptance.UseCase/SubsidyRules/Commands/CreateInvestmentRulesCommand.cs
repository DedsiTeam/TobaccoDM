using Dedsi.Ddd.CQRS.Commands;

namespace TobaccoDMInputAcceptance.SubsidyRules.Commands;

public record CreateInvestmentRulesCommand(string projectNameOfInvestment, string projectOfInvestmentNumber,
            InvestInSmallCategories inSmallCategories, 
            TypeOfInvestment typeInvestment, bool isStatusConfig,bool allowSubordinateAdjustments, 
            StatusEnum publishingStatus, Guid createUserId, string createUserName,
            ProjectCalculationFormula[] ProjectCalculationFormulas,
            PublishingUnit[] PublishingUnits
            ) : DedsiCommand<bool>;

