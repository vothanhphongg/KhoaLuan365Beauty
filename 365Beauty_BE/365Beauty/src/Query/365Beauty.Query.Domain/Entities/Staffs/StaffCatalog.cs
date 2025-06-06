﻿using _365Beauty.Query.Domain.Abstractions.Aggregates;
using _365Beauty.Query.Domain.Entities.Services;

namespace _365Beauty.Query.Domain.Entities.Staffs
{
    public class StaffCatalog : AggregateRoot<int>
    {
        public string? Code { get; set; }
        public string? IdCard { get; set; }
        public string FullName { get; set; }
        public int Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? Tel { get; set; }
        public string? Introduction { get; set; }
        public string? Img { get; set; }
        public int SalonId { get; set; }
        public int? DegreeId { get; set; }
        public int? TitleId { get; set; }
        public int? OccupationId { get; set; }
        public string? Address { get; set; }
        public string? WardId { get; set; }
        public int IsActived { get; set; }

        #region Navigation properties

        public ICollection<ServiceCatalog>? ServiceCatalogs { get; set; }
        public OccupationCatalog? OccupationCatalog { get; set; }
        public DegreeCatalog? DegreeCatalog { get; set; }
        public TitleCatalog? TitleCatalog { get; set; }
        #endregion
    }
}