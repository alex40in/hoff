namespace Hoff.Domain.Entity.CbRf
{
    public class ValuteEntity
    {
        public ValuteEntity(int id, string name, string code) =>
            (Id, Name, Code) = (id, name,code);

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Code { get; private set; }
    }
}
