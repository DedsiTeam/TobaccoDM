namespace TobaccoDMInputAcceptance.SubsidyRules;

public record  CreateSubsidyRuleInputDto(string projectNameOfInvestment, string projectOfInvestmentNumber,
            InvestInSmallCategoriesInputDto inSmallCategories,
            TypeOfInvestmentInputDto typeInvestment, 
            bool isStatusConfig,bool allowSubordinateAdjustments, 
            StatusEnum publishingStatus, Guid createUserId, string createUserName,
            ProjectCalculationFormulaInputDto[] ProjectCalculationFormulas,
            PublishingUnitInputDto[] PublishingUnits);

//投入规则小类
public record InvestInSmallCategoriesInputDto(Guid PartId, string PartName, Guid Id, string Name);

//投入类型
public record TypeOfInvestmentInputDto(Guid Id, string Name);


/// <summary>
/// 投入项目计算公式
/// </summary>
public class ProjectCalculationFormulaInputDto
{
    public string NameOfInvestment { get; set; }

    public CategoryOfInvestmentInputDto CategoryInvestment { get; set; }

    public TobaccoFarmerChoiceInputDto TobaccoFarmerChoice { get; set; }

    public TypeOfRegisteredAccountInputDto TypeOfRegisteredAccount { get; set; }

    public TobaccoVarietiesInputDto TobaccoVarieties { get; set; }

    public decimal InputCriteria { get; set; }
}

public record CategoryOfInvestmentInputDto(Guid Id, string Name);

public record TobaccoFarmerChoiceInputDto(Guid Id, string Name);

public record TypeOfRegisteredAccountInputDto(Guid Id, string Name);

public record TobaccoVarietiesInputDto(Guid Id, string Name);

/// <summary>
/// 发布单位
/// </summary>
/// <param name="depName"></param>
/// <param name="depCode"></param>
public record PublishingUnitInputDto(string depName,Guid depCode);