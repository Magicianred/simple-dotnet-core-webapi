using FakerDotNet;
using FizzWare.NBuilder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using simple_dotnet_core_webapi.Utils;
using simple_dotnet_core_webapi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simple_dotnet_core_webapi.Controllers
{
    /// <summary>
    /// Handle Tags
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TagsController : ControllerBase
    {
        private readonly ILogger<TagsController> _logger;

        public TagsController(ILogger<TagsController> logger)
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
        public async Task<IEnumerable<Tag>> Get(int page = 0, int size = 100)
        {
            var posts = Builder<Tag>
                                .CreateListOfSize(size)
                                .All()
                                    .With(i => i.Id = Guid.NewGuid())
                                    .With(i => i.Name = Faker.Food.Ingredient())
                                    .With(i => i.Description = Faker.Food.Description())
                                    .With(i => i.PostsCount = (int)Faker.Number.Between(1,20))
                                .Build();

            // create some delay to simulate bad performance
            BadPerformance.MakeDelay(10, 100, size);

            return await Task.FromResult(posts.Skip(page * size));
        }

    }
}
