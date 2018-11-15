using Jim.Utils.Filter.Operators;

namespace Jim.Utils
{
    public interface IFilter
    {
        
        string OperatorConvert(Logical op);
        string Sql();
        string Execute();
    }
}