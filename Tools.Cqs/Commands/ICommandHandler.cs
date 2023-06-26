namespace Tools.Cqs.Commands
{
    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        Result Execute(TCommand command);
    }
}
