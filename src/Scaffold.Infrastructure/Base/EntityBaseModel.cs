
namespace Scaffold.Infrastructure.Base
{
    public class EntityBaseModel
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
    }
}
