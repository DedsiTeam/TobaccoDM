using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TobaccoDMInputAcceptance.Domains;
using Volo.Abp.Domain.Entities;

namespace TobaccoDMInputAcceptance.SubsidyRules
{
    /// <summary>
    /// 投入项目计算公式
    /// </summary>
    public class ProjectCalculationFormula:Entity<Guid>
    {
        protected ProjectCalculationFormula() { }

        public ProjectCalculationFormula(Guid id,string nameOfInvestment, CategoryOfInvestment categoryInvestment, TobaccoFarmerChoice tobaccoFarmerChoice, TypeOfRegisteredAccount typeOfRegisteredAccount,
            TobaccoVarieties tobaccoVarieties,decimal inputCriteria) :base(id)
        {
            NameOfInvestment = nameOfInvestment;
            CategoryInvestment = categoryInvestment;
            TobaccoFarmerChoice = tobaccoFarmerChoice;
            TypeOfRegisteredAccount = typeOfRegisteredAccount;
            TobaccoVarieties = tobaccoVarieties;
            InputCriteria = inputCriteria;
            CalculationFormulaForInvestmentAmount = $"【{CategoryInvestment.Name}】X 【{InputCriteria}】";
        }
       

        /// <summary>
        /// 名称
        /// </summary>
        public string NameOfInvestment { get; private set; }


        /// <summary>
        /// 投入品类
        /// </summary>
        public CategoryOfInvestment CategoryInvestment { get; private set; }


        /// <summary>
        /// 职业烟农选择
        /// </summary>
        public TobaccoFarmerChoice TobaccoFarmerChoice { get; private set; }


        /// <summary>
        /// 建档立卡户类型
        /// </summary>
        public TypeOfRegisteredAccount TypeOfRegisteredAccount { get; private set; }


        /// <summary>
        /// 烟叶品种
        /// </summary>
        public TobaccoVarieties TobaccoVarieties { get; private set; }

        /// <summary>
        /// 投入标准 
        /// </summary>
        public decimal InputCriteria { get; private set; }


        /// <summary>
        /// 投入金额计算公式
        /// </summary>
        public string CalculationFormulaForInvestmentAmount { get; private set; }

       


        /// <summary>
        ///  投入规则Id
        /// </summary>
        public Guid PartId { get; private set; }

        public void ChangePartId(Guid newPartId)
        {
            PartId = newPartId;
        }


        /// <summary>
        /// 投入对象
        /// </summary>
        public string InvestmentTarget => "种植者";

        /// <summary>
        /// 制定日期
        /// </summary>
        public DateTime EnactmentTime { get; private set; }

        /// <summary>
        /// 年度
        /// </summary>
        public int Year { get; private set; }


        /// <summary>
        /// 编辑日期
        /// </summary>
        public DateTime? EditTime { get; private set; }

        /// <summary>
        /// 保存日期
        /// </summary>
        public void ChangeDateTime()
        {
            EnactmentTime = DateTime.Now;
            Year = EnactmentTime.Year;
        }

        /// <summary>
        /// 修改编辑日期
        /// </summary>
        public void ChagneEditTime()
        {
            EditTime = DateTime.Now;
        }


        

    }

    public class CategoryOfInvestment(Guid id, string name) : CodeNameRecord<Guid>(id, name);

    public class TobaccoFarmerChoice(Guid id, string name) : CodeNameRecord<Guid>(id,name);

    public class TypeOfRegisteredAccount(Guid id, string name) : CodeNameRecord<Guid>(id, name);

    public class TobaccoVarieties(Guid id, string name) : CodeNameRecord<Guid>(id, name);
}
