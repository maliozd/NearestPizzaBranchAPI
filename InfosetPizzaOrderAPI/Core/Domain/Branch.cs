using Domain.Base;

namespace Domain
{
    public class Branch : BaseEntity
    {
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
