using FakerDotNet;
using FizzWare.NBuilder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using simple_dotnet_core_webapi.Utils;
using simple_dotnet_core_webapi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace simple_dotnet_core_webapi.Controllers
{
    /// <summary>
    /// Handle Categories
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(ILogger<CategoriesController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Retrieve some post for simulation
        /// </summary>
        /// <param name="page">Fake parameter with generated data</param>
        /// <param name="size">How for page</param>
        /// <returns>List of posts</returns>
        [HttpGet]
        public async Task<IEnumerable<Category>> Get(int page = 0, int size = 100, CancellationToken cancelToken = default(CancellationToken))
        {
            cancelToken.ThrowIfCancellationRequested();
            var items = Builder<Category>
                                .CreateListOfSize(size)
                                .All()
                                    .With(i => i.Id = Guid.NewGuid())
                                    .With(i => i.Name = Faker.Food.Ingredient())
                                    .With(i => i.Description = Faker.Lorem.Paragraph(2))
                                    .With(i => i.PostsCount = (int)Faker.Number.Between(1, 30))
                                .Build();

            cancelToken.ThrowIfCancellationRequested();
            // create some delay to simulate bad performance
            BadPerformance.MakeDelay(10, 20, size, cancelToken);

            return await Task.FromResult(items.Skip(page * size));
        }

    }
}
