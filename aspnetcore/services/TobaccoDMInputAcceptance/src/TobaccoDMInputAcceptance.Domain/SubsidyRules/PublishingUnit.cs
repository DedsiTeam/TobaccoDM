using Volo.Abp.Domain.Entities;

namespace TobaccoDMInputAcceptance.SubsidyRules
{
    public class PublishingUnit:Entity<Guid>
    {
        

        protected PublishingUnit() { }

        public PublishingUnit(Guid id, string depName, Guid depCode) : base(id)
        {
            DepName = depName;
            DepCode = depCode;
        }


        public Guid PartId { get; private set; }

        public void ChangePartId(Guid partId)
        {
            PartId = partId;
        }


        /// <summary>
        /// 发布单位名称
        /// </summary>
        public string DepName { get; private set; }

        /// <summary>
        /// 发布单位编码
        /// </summary>
        public Guid DepCode { get; private set; }

    }
}
