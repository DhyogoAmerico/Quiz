namespace Quiz.Domain.ContractsCommand
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task<CommandResult> Handle(T command);
    }
}