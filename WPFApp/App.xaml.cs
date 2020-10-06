using System.Windows;
using Autofac;
using Autofac.Features.ResolveAnything;
using AutoMapper;
using Database.Context;
using DataManager.Storages;
using DataManager.Storages.StubStorage;
using WPFApp.DataManager;
using WPFApp.MapperProfiles;
using WPFApp.Views;

namespace WPFApp
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private IContainer _container;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            try
            {
                ConfigureContainer();
                ComposeGraph();
            }
            finally
            {
                Shutdown();
            }
        }

        private void ConfigureContainer()
        {
            var container = new ContainerBuilder();


            container.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());

            container.RegisterType<UserContext>()
                .As<UserContext>();

            container.Register<IConfigurationProvider>(_ =>
                new MapperConfiguration(cfg => cfg.AddProfile(new UserProfile())));
            container.RegisterType<Mapper>()
                .As<Mapper>();

#if TESTBUILD
            container.RegisterType<StubUserStorage>()
                .As<IUserStorage>();
#else
            container.RegisterType<DbUserStorage>()
                .As<IUserStorage>();
#endif

            container.RegisterType<CasinoDataManager>()
                .As<CasinoDataManager>();

            _container = container.Build();
        }

        private void ComposeGraph()
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                var loginView = scope.Resolve<LoginView>();
                var mainView = scope.Resolve<MainView>();

                if (loginView.ShowDialog() == true)
                {
                    loginView.Close();
                    mainView.ShowDialog();
                }
            }
        }
    }
}