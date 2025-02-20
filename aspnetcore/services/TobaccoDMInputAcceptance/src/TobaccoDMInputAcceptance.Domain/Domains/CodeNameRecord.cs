namespace TobaccoDMInputAcceptance.Domains
{
    public interface ICodeNameRecord<T>
    {
        public T Id { get; }

        public string Name { get; }
    }

    public class CodeNameRecord<T>(T id, string name): ICodeNameRecord<T>
    {

        public T Id { get; set; } = id;

        public string Name { get; set; } = name;
    }
}
