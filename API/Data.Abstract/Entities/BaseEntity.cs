using System.ComponentModel.DataAnnotations;
using ZFramework.Data.Abstract.Interfaces;

namespace ZFramework.Data.Abstract.Entities
{
    public abstract class BaseEntity : IEntity, IKeyed<int>
    {
        [Key]
        public int ID { get; set; }
    }
}