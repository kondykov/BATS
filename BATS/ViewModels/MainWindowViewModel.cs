using System.Windows;
using System.Windows.Input;
using BATS.Infrastructure.Commands;
using BATS.Models;
using BATS.ViewModels.Base;

namespace BATS.ViewModels;

internal class MainWindowViewModel : ViewModel
{
    private IEnumerable<DataPoint> _testDataPoints;

    public MainWindowViewModel()
    {
        #region Commands

        CloseAppCommand = new RelativeCommand(OnCloseAppCommandExecuted, CanCloseAppCommandCanExecute);

        #endregion

        var dataPoints = new List<DataPoint>();
        for (var x = 0d; x < 360; x += .1)
        {
            const double rad = Math.PI / 180;
            var y = Math.Sin(x * rad);

            dataPoints.Add(new DataPoint { Longitude = x, Latitude = y });
        }
        
        TestDataPoints = dataPoints;
    }

    public IEnumerable<DataPoint> TestDataPoints
    {
        get => _testDataPoints;
        set => SetProperty(ref _testDataPoints, value);
    }

    #region Title

    private string? _title = "Анализ статистики";

    /// <summary>
    ///     Заголовок окна
    /// </summary>
    public string? Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }

    #endregion

    #region Status : string - Статус программы

    private string? _status = "Готов!";

    /// <summary>
    ///     Статус программы
    /// </summary>
    public string? Status
    {
        get => _status;
        set => SetProperty(ref _status, value);
    }

    #endregion

    #region Commands

    public ICommand CloseAppCommand { get; }

    private static void OnCloseAppCommandExecuted(object? obj)
    {
        Application.Current.Shutdown();
    }

    private static bool CanCloseAppCommandCanExecute(object obj)
    {
        return true;
    }

    #endregion
}