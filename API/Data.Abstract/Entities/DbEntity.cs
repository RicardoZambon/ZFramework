using ZFramework.Data.Abstract.Interfaces;

namespace ZFramework.Data.Abstract.Entities
{
    public abstract class DbEntity : BaseEntity, ISoftDelete
    {
        public bool IsDeleted { get; set; }
    }
}