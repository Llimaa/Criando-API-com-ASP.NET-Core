namespace DevStore.Shared.Commands
{
    public interface ICommandResult
    {
        bool Sucess { get; set; }
        string Mensagem { get; set; }
        object Data { get; set; }

    }
}
