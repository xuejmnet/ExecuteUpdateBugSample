namespace ExcuteUpdateBugSample;

public interface ILogicDelete
{
    bool IsDelete { get; set; }
}

public class LogicDatabaseEntity:ILogicDelete
{
    public string Id { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public bool IsDelete { get; set; }

}