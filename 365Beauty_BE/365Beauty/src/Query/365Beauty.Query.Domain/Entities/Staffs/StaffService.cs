using _365Beauty.Query.Domain.Entities.Services;
using Newtonsoft.Json;

namespace _365Beauty.Query.Domain.Entities.Staffs
{
    public class StaffService
    {
        public int StaffId { get; set; }
        public int ServiceId { get; set; }

        [JsonIgnore]
        public StaffCatalog? StaffCatalog { get; set; }
        [JsonIgnore]
        public ServiceCatalog? ServiceCatalog { get; set; }

    }
}