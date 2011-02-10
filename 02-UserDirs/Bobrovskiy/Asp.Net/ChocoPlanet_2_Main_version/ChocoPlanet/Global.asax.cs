using System;
using ChocoPlanet.Business;
using ChocoPlanet.DataAccess;
using ChocoPlanet.DataAccess.Abstraction;
using ChocoPlanet.DataAccess.Fakes;
using ChocoPlanet.DataAccess.Fakes.Order;
using ChocoPlanet.Model;
using ChocoPlanet.Model.Order;

namespace ChocoPlanet
{
    public class Global : System.Web.HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            ServiceLocator.RegisterInstance<IDataProvider<Category>>(new CategoryDataProviderFake());
            ServiceLocator.RegisterInstance<IDataProvider<Product>>(new ProductDataProviderFakes());

            ServiceLocator.RegisterInstance<IDataProvider<OrderState>>(new OrderStateDataProviderFake());
            ServiceLocator.RegisterInstance<IDataProvider<OrderStatus>>(new OrderStatusDataProviderFake());
            ServiceLocator.RegisterInstance<IDataProvider<UserOrder>>(new UserOrderDataProviderFake());

            ServiceLocator.RegisterInstance<IDataProvider<Basket>>(new BasketDataProviderFake());

            ServiceLocator.RegisterInstance<UserOrderManager>(new UserOrderManager());
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

    }
}
