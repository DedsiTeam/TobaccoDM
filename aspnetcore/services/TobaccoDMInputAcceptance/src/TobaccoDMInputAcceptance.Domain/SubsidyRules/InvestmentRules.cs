using TobaccoDMInputAcceptance.Domains;
using Volo.Abp.Domain.Entities;

namespace TobaccoDMInputAcceptance.SubsidyRules
{
    public class InvestmentRules : Entity<Guid>
    {


        protected InvestmentRules() { }

        public InvestmentRules(Guid id, string projectNameOfInvestment,string projectOfInvestmentNumber,
            InvestInSmallCategories inSmallCategories, TypeOfInvestment typeInvestment, bool isStatusConfig, bool allowSubordinateAdjustments, StatusEnum publishingStatus,Guid createUserId,string createUserName) 
            : base(id)
        {
            ProjectNameOfInvestment = projectNameOfInvestment;
            ProjectOfInvestmentNumber = projectOfInvestmentNumber;
            InSmallCategories = inSmallCategories;
            TypeInvestment = typeInvestment;
            IsStatusConfig = IsStatusConfig;
            AllowSubordinateAdjustments = AllowSubordinateAdjustments;
            PublishingStatus = PublishingStatus;
            CreateTime = DateTime.Now;
            CreateUserId = createUserId;
            CreateUserName = createUserName;
        }

        public DateTime CreateTime { get; private set; }

        public Guid CreateUserId { get; private set; }

        public string CreateUserName { get; private set; }

        /// <summary>
        /// 投入项目名称
        /// </summary>
        public string ProjectNameOfInvestment { get; private set; }

        /// <summary>
        /// 投入项目编号
        /// </summary>
        public string ProjectOfInvestmentNumber { get; private set; }

        /// <summary>
        /// 投入规则小类
        /// </summary>
        public InvestInSmallCategories InSmallCategories { get; private set; }

        /// <summary>
        /// 投入类型
        /// </summary>
        public TypeOfInvestment TypeInvestment { get; private set; }

        /// <summary>
        /// 是否配置投入标准
        /// </summary>
        public bool IsStatusConfig { get; private set; }

        /// <summary>
        /// 投入标准是否允许下级调整
        /// </summary>
        public bool AllowSubordinateAdjustments { get; private set; }

        /// <summary>
        /// 发布状态
        /// </summary>
        public StatusEnum PublishingStatus { get; private set; }


        /// <summary>
        /// 投入标准
        /// </summary>
        public ICollection<ProjectCalculationFormula> ProjectCalculationFormula { get; private set; } = new List<ProjectCalculationFormula>();

        /// <summary>
        /// 添加项目计算公式Id
        /// </summary>
        /// <param name="tobaccoGrowers"></param>
        public void AddProjectCalculationFormulaParId(IEnumerable<ProjectCalculationFormula> projectCalculationFormulas)
        {
            foreach (var projectCalculation in projectCalculationFormulas)
            {
                projectCalculation.ChangePartId(Id);

                AddProjectCalculationFormulaRules(projectCalculation);
            }
        }

        public void AddProjectCalculationFormulaRules(ProjectCalculationFormula projectCalculation)
        {
            ProjectCalculationFormula.Add(projectCalculation);
        }

        public void ClearProjectCalculationFormulaRules()
        {
            ProjectCalculationFormula.Clear();
        }

        /// <summary>
        /// 发布单位
        /// </summary>
        public ICollection<PublishingUnit> PublishingUnits { get; private set; } = new List<PublishingUnit>();

        public void AddPublishingUnitParId(IEnumerable<PublishingUnit> publishingUnits)
        {
            foreach (var publishingUnit in publishingUnits)
            {
                publishingUnit.ChangePartId(Id);
                AddPublishingUnitRules(publishingUnit);
            }
        }

        public void AddPublishingUnitRules(PublishingUnit publishingUnit)
        {
            PublishingUnits.Add(publishingUnit);
        }

        public void ClearPublishingUnitRules()
        {
            PublishingUnits.Clear();
        }


        /// <summary>
        /// 获得发布单位名称
        /// </summary>
        /// <returns></returns>
        public string GetPublishingUnitName()
        {
            return string.Join(",", PublishingUnits.Select(p => p.DepName));
        }


    }

    public enum StatusEnum
    {
        /// <summary>
        /// 未发布
        /// </summary>
        Enable = 1,

        /// <summary>
        /// 已发布
        /// </summary>
        Disable = 2,
    }
    

    public class InvestInSmallCategories(Guid PartId,string PartName,Guid Id,string Name) : CodeNameRecord<Guid>(Id, Name)
    {
        public Guid PartId { get; private set; } = PartId;

        public string PartName { get; private set; } = PartName;
    }

    public class TypeOfInvestment(Guid Id,string Name):CodeNameRecord<Guid>(Id, Name);

    

}
