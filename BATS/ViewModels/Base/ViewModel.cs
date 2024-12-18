﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BATS.ViewModels.Base;

internal abstract class ViewModel : INotifyPropertyChanged, IDisposable
{
    private bool _disposed;

    public void Dispose()
    {
        Dispose(true);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected virtual bool SetProperty<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposing || _disposed) return;
        _disposed = true;
        // Освобождение управляемых ресурсов
    }

    // ~ViewModel()
    // {
    //     Dispose(disposing: false);
    // }
}