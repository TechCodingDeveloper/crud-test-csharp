﻿using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.AcceptanceTests
{
    public abstract class TestBase
    {
        public Client ClientServices { get; set; }
        public string BaseUrl { get; set; } = "http://localhost:5000/";
        private static bool ServerRun { get; set; } = false;
        public TestBase()
        {
            if(!ServerRun)
            {
                var builder = Application.API.Program.CreateHostBuilder(Array.Empty<string>());
                var host = builder.Build();
                Task.Run(() => host.Run());

                ServerRun = true;
            }

            ClientServices = new Client(BaseUrl, new HttpClient());
        }
    }
}
