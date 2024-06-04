using CommunityToolkit.Mvvm.Messaging;
using MaterialDesignThemes.Wpf;
using MembershipsDemo.Messenger;
using System.Windows;

namespace MembershipsDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Snackbar Snackbar = new();
        public MainWindow()
        {
            InitializeComponent();
            
            WeakReferenceMessenger.Default.Register<CloseRootDialogChangedMessage>(
                this, (r, m) =>
                {
                    try
                    {
                        DialogHost.Close("RootDialog");
                    }
                    catch { }
                });
            WeakReferenceMessenger.Default.Register<RootSnackBarChangedMessage>(
                this, (r, m) => MainSnackbar.MessageQueue?.Enqueue(m.Value));

            Snackbar = MainSnackbar;
        }
    }
}