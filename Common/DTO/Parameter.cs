namespace Common
{
    public class ParameterDto
    {
        public int Id { get; set; }
        public OikCategory OikCategory { get; set; }
        public int OikId { get; set; }
        public MztoType MztoType { get; set; }
        public string Description { get; set; }
    }
}
