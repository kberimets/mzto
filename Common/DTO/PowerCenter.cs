namespace Common
{
    public class PowerCenterDto
    {
        public int Id { get; set; }
        public ParameterDto[] Parameters { get; set; }
        public string Name { get; set; }
        public bool IsObservable { get; set; }
    }
}
