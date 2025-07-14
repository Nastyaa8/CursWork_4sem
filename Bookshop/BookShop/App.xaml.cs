using System.Globalization;
using System.Windows;
using System.Windows.Input;
using BookShop.Data;
using BookShop.Mvvm.Base;
using BookShop.Mvvm.Helpers;
using BookShop.Mvvm.Services;
using BookShop.ViewModels;
using BookShop.ViewModels.Base;
using BookShop.ViewModels.Books;
using BookShop.ViewModels.Events;
using BookShop.ViewModels.Orders;
using BookShop.ViewModels.UserEvents;
using BookShop.ViewModels.Users;
using BookShop.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BookShop;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly IHost _host;

    public App()
    {
        var builder = Host.CreateDefaultBuilder();

        builder.ConfigureServices((hostContext, services) =>
        {
            InitViews(services);
            InitViewModels(services);
            
            services.AddScoped<INavigationService, NavigationService>();
            services.AddScoped<Func<Type, ViewModelBase>>(provider =>
                viewModelType => (ViewModelBase)provider.GetRequiredService(viewModelType));

            const string sqlConnectionString = @"Server=.\SQLEXPRESS;Database=BookShop;Trusted_Connection=True;TrustServerCertificate=True";
            services.AddEFRepositories(sqlConnectionString);
        });
        
        _host = builder.Build();
        
        ApplicationSettings.Language = new CultureInfo("ru-RU");
        
        var cursor = new Cursor(GetResourceStream(new Uri("pack://application:,,,/BookShop.Resources;component/Resources/cursor.cur"))?.Stream!);
        Mouse.OverrideCursor = cursor;
    }





    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void App_OnStartup(object sender, StartupEventArgs e)
    {
        ApplicationSettings.Theme = EThemeType.Pink;
        var wnd = _host.Services.GetRequiredService<MainWindow>();
        wnd.Show();
    }

    private void InitViews(IServiceCollection services)
    {
        services.AddTransient<LoginWindow>(provider =>
        {
            var loginWindow = new LoginWindow();
            var loginViewModel = provider.GetRequiredService<LoginWindowViewModel>();
            loginWindow.DataContext = loginViewModel;
            return loginWindow;
        });

        services.AddTransient<RegisterWindow>(provider =>
        {
            var registerWindow = new RegisterWindow();
            var registerViewModel = provider.GetRequiredService<MainWindowViewModel>();
            registerWindow.DataContext = registerViewModel;
            return registerWindow;
        });

        services.AddTransient<MainWindow>(provider =>
        {
            var mainWindow = new MainWindow();
            var mainViewModel = provider.GetRequiredService<MainWindowViewModel>();
            mainWindow.DataContext = mainViewModel;
            return mainWindow;
        });
    }
    
    private void InitViewModels(IServiceCollection services)
    {
        services.AddSingleton<LoginWindowViewModel>();
        services.AddSingleton<RegisterWindowViewModel>();
        services.AddSingleton<MainWindowViewModel>();
        
        services.AddTransient<MainViewModel>();
        
        services.AddTransient<BookWrapViewModel>();
        services.AddTransient<AddBookViewModel>();
        services.AddTransient<BooksViewModel>();
        services.AddTransient<BookInfoViewModel>();
        
        services.AddTransient<UserWrapViewModel>();
        services.AddTransient<AddUserViewModel>();
        services.AddTransient<UsersViewModel>();
        
        services.AddTransient<EventWrapViewModel>();
        services.AddTransient<AddEventViewModel>();
        services.AddTransient<EventsViewModel>();
        
        services.AddTransient<UserEventWrapViewModel>();
        services.AddTransient<AddUserEventViewModel>();
        services.AddTransient<UserEventsViewModel>();

        services.AddTransient<OrderWrapViewModel>();
        services.AddTransient<EditOrderViewModel>();
        services.AddTransient<OrdersViewModel>();
        
        services.AddSingleton<CartViewModel>();
    }
}