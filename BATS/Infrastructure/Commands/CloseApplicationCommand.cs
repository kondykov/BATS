using System.Windows;
using BATS.Infrastructure.Commands.Base;

namespace BATS.Infrastructure.Commands;

public class CloseApplicationCommand : Command
{
    public override bool CanExecute(object parameter) => true;

    public override void Execute(object parameter) => Application.Current.Shutdown();
}