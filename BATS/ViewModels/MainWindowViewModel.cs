using BATS.ViewModels.Base;

namespace BATS.ViewModels;

internal class MainWindowViewModel : ViewModel
{
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
}