using System.Windows;
using Autofac;
using Autofac.Core;
using Autofac.Features.ResolveAnything;
using Database.Context;
using Database.Entities;
using Database.Repository;
using WPFApp.DataManager;
using WPFApp.DataManager.Managers.DbManager;
using WPFApp.DataManager.Managers.TestManager;
using WPFApp.DataManager.Mapper;
using WPFApp.ViewModels;
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

            container.RegisterType<CasinoRepository>()
                .As<ICasinoRepository>();

#if TESTBUILD
            container.RegisterType<TestCasinoManager>()
                .As<ICasinoDataManager>();
#else
            container.RegisterType<UserContext>()
                .As<UserContext>();

            container.RegisterType<CasinoRepository>()
                .As<ICasinoRepository>();

            container.RegisterType<DbCasinoManager>()
                .As<ICasinoDataManager>()
                .WithParameters(new Parameter[]
                {
                    new TypedParameter(typeof(ICasinoRepository),
                        new CasinoRepository(new UserContext())),

                    new TypedParameter(typeof(AbstractMapper<User, UserViewModel>),
                        new UserMapper())
                });
#endif

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