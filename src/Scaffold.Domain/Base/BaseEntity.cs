

namespace Scaffold.Domain.Base
{
    public class BaseEntity
    {

        public long Id { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        public void AddUpdatedAt(DateTime dt) 
        {
            UpdatedAt = dt;
        }
    }
}
