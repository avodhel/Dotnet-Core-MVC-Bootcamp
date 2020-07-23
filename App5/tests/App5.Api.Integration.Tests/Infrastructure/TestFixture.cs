using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace App5.Api.Integration.Tests.Infrastructure
{
    public class TestFixture : IClassFixture<TestWebApplicationFactory<Startup>>
    {
        public readonly TestWebApplicationFactory<Startup> _factory;

        public TestFixture(TestWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
    }
}
