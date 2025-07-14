using System.Globalization;
using System.Windows;
using System.Windows.Input;
using BookShop.Data;
using BookShop.Mvvm.Base;
using BookShop.Mvvm.Helpers;
using BookShop.Mvvm.Services;
using BookShop.Personal.ViewModels;
using BookShop.Personal.Views;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BookShop.Personal;

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
        const string sqlConnectionstring = @"Server=.\SQLEXPRESS;Database=master;Trusted_Connection=True;TrustServerCertificate=True";

        var sqlConnection = new SqlConnection(sqlConnectionstring);
        sqlConnection.Open();


        const string sqlText = """
                               IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'BookShop')
                               BEGIN

                               CREATE DATABASE [BookShop]
                               END	
                               """;
        
        var sqlCommand = new SqlCommand(sqlText, sqlConnection);
        var result = sqlCommand.ExecuteNonQuery();
        
        
        const string dbConnectionString = @"Server=.\SQLEXPRESS;Database=BookShop;Trusted_Connection=True;TrustServerCertificate=True";
        var dbConnection = new SqlConnection(dbConnectionString);
        dbConnection.Open();

        const string dbText = """
                              /****** Object:  Table [dbo].[Books]    Script Date: 06.06.2025 14:26:43 ******/
                              SET ANSI_NULLS ON
                              SET QUOTED_IDENTIFIER ON

                              CREATE TABLE [dbo].[Books](
                              	[Id] [int] IDENTITY(1,1) NOT NULL,
                              	[Name] [nvarchar](255) NOT NULL,
                              	[Author] [nvarchar](255) NOT NULL,
                              	[Genre] [nvarchar](255) NOT NULL,
                              	[Price] [decimal](18, 2) NOT NULL,
                              	[Image] [nvarchar](255) NOT NULL,
                              	[Available] [bit] NOT NULL,
                              	[Description] [nvarchar](max) NULL,
                               CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
                              (
                              	[Id] ASC
                              )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
                              ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


                              CREATE TABLE [dbo].[Events](
                              	[Id] [int] IDENTITY(1,1) NOT NULL,
                              	[Name] [nvarchar](255) NOT NULL,
                              	[Description] [nvarchar](max) NULL,
                              	[Date] [datetime] NOT NULL,
                              	[Location] [nvarchar](50) NOT NULL,
                               CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
                              (
                              	[Id] ASC
                              )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
                              ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

                              CREATE TABLE [dbo].[OrderItems](
                              	[Id] [int] IDENTITY(1,1) NOT NULL,
                              	[OrderId] [int] NOT NULL,
                              	[BookId] [int] NOT NULL,
                              	[Quantity] [int] NOT NULL,
                               CONSTRAINT [PK_OrderItems] PRIMARY KEY CLUSTERED 
                              (
                              	[Id] ASC
                              )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
                              ) ON [PRIMARY]

                              CREATE TABLE [dbo].[Orders](
                              	[Id] [int] IDENTITY(1,1) NOT NULL,
                              	[UserId] [int] NOT NULL,
                              	[Date] [datetime] NOT NULL,
                              	[TotalPrice] [decimal](18, 2) NOT NULL,
                              	[Status] [varchar](255) NOT NULL,
                               CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
                              (
                              	[Id] ASC
                              )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
                              ) ON [PRIMARY]

                              CREATE TABLE [dbo].[UserEvents](
                              	[Id] [int] IDENTITY(1,1) NOT NULL,
                              	[UserId] [int] NOT NULL,
                              	[EventId] [int] NOT NULL,
                               CONSTRAINT [PK_UserEvents] PRIMARY KEY CLUSTERED 
                              (
                              	[Id] ASC
                              )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
                              ) ON [PRIMARY]

                              CREATE TABLE [dbo].[Users](
                              	[Id] [int] IDENTITY(1,1) NOT NULL,
                              	[FirstName] [nvarchar](255) NOT NULL,
                              	[LastName] [nvarchar](255) NOT NULL,
                              	[Email] [nvarchar](255) NOT NULL,
                              	[Phone] [nvarchar](20) NOT NULL,
                              	[Address] [nvarchar](255) NOT NULL,
                              	[Login] [nvarchar](255) NOT NULL,
                              	[PasswordHash] [nvarchar](255) NOT NULL,
                              	[IsAdmin] [bit] NOT NULL,
                              	[Image] [varbinary](max) NULL,
                               CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
                              (
                              	[Id] ASC
                              )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
                              ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

                              ALTER TABLE [dbo].[Events] ADD  CONSTRAINT [DF_Events_Date]  DEFAULT (getdate()) FOR [Date]

                              ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsAdmin]  DEFAULT ((0)) FOR [IsAdmin]

                              ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_Books] FOREIGN KEY([BookId])
                              REFERENCES [dbo].[Books] ([Id])

                              ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK_OrderItems_Books]

                              ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_Orders] FOREIGN KEY([OrderId])
                              REFERENCES [dbo].[Orders] ([Id])

                              ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK_OrderItems_Orders]

                              ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Users] FOREIGN KEY([UserId])
                              REFERENCES [dbo].[Users] ([Id])

                              ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Users]

                              ALTER TABLE [dbo].[UserEvents]  WITH CHECK ADD  CONSTRAINT [FK_UserEvents_Events] FOREIGN KEY([EventId])
                              REFERENCES [dbo].[Events] ([Id])

                              ALTER TABLE [dbo].[UserEvents] CHECK CONSTRAINT [FK_UserEvents_Events]

                              ALTER TABLE [dbo].[UserEvents]  WITH CHECK ADD  CONSTRAINT [FK_UserEvents_UserEvents] FOREIGN KEY([UserId])
                              REFERENCES [dbo].[Users] ([Id])

                              ALTER TABLE [dbo].[UserEvents] CHECK CONSTRAINT [FK_UserEvents_UserEvents]

                              USE [master]

                              ALTER DATABASE [BookShop] SET  READ_WRITE 
                              """;
        
        var dbCommand = new SqlCommand(dbText, dbConnection);
        var dbResult = dbCommand.ExecuteNonQuery();
        
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
        services.AddSingleton<MainWindowViewModel>();
        //
        services.AddTransient<MainViewModel>();
        //
        // services.AddTransient<BookWrapViewModel>();
        // services.AddTransient<AddBookViewModel>();
        // services.AddTransient<BooksViewModel>();
        // services.AddTransient<BookInfoViewModel>();
        //
        // services.AddTransient<UserWrapViewModel>();
        // services.AddTransient<AddUserViewModel>();
        // services.AddTransient<UsersViewModel>();
        //
        // services.AddTransient<EventWrapViewModel>();
        // services.AddTransient<AddEventViewModel>();
        // services.AddTransient<EventsViewModel>();
        //
        // services.AddTransient<UserEventWrapViewModel>();
        // services.AddTransient<AddUserEventViewModel>();
        // services.AddTransient<UserEventsViewModel>();
        //
        // services.AddTransient<OrderWrapViewModel>();
        // services.AddTransient<EditOrderViewModel>();
        // services.AddTransient<OrdersViewModel>();
        //
        // services.AddSingleton<CartViewModel>();
    }
}