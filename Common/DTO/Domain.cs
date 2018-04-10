namespace Common
{
    public class DomainDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PowerCenterDto[] PowerCenters { get; set; }
    }
}
