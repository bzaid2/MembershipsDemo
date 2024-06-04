using CommunityToolkit.Mvvm.Messaging;
using MaterialDesignThemes.Wpf;
using System.Windows.Controls;
using MembershipsDemo.Messenger;

namespace MembershipsDemo.Views.Shared
{
    /// <summary>
    /// Lógica de interacción para ChildSnackbarView.xaml
    /// </summary>
    public partial class ChildSnackbarView : UserControl
    {
        public static Snackbar Snackbar = new();

        public ChildSnackbarView()
        {
            InitializeComponent();
            WeakReferenceMessenger.Default.Register<ChildSnackBarChangedMessage>(
                this, (r, m) => MainSnackbar.MessageQueue?.Enqueue(m.Value));

            Snackbar = MainSnackbar;
        }
    }
}
