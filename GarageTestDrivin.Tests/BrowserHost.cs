﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.Seleno.Configuration;

namespace GarageTestDrivin.Tests
{
    public static class BrowserHost
    {
        public static readonly SelenoHost Instance = new SelenoHost();
        public static readonly string RootUrl;

        static BrowserHost()
        {
            Instance.Run("GarageTestDrivin", 4223,
                            configure => configure
                            .WithRemoteWebDriver(BrowserFactory.Chrome)
                            .WithRouteConfig(RouteConfig.RegisterRoutes) // To allow us to navigate by selecting a controller and action rather than a url string
                        );

            RootUrl = Instance.Application.Browser.Url;
        }
    }
}
