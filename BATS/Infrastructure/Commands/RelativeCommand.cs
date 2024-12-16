using BATS.Infrastructure.Commands.Base;

namespace BATS.Infrastructure.Commands;

internal class RelativeCommand(Action<object> execute, Func<object, bool>? canExecute = null)
    : Command
{
    private readonly Func<object, bool>? _canExecute = canExecute;
    private readonly Action<object> _execute = execute ?? throw new ArgumentNullException(nameof(execute));

    public override bool CanExecute(object parameter) => _canExecute?.Invoke(parameter) ?? true;

    public override void Execute(object parameter) => _execute(parameter);
}