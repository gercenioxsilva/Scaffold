using Scaffold.Infrastructure.Base;

namespace Scaffold.Infrastructure.Models
{
    public class CustomerModelDto : EntityBaseModel
    {
        public string Name { get; set; }
        public string Document { get; set; }

        public int Type { get; set; }

        
    }
}
