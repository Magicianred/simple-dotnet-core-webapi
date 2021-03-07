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
    /// Handle Posts
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly ILogger<PostsController> _logger;

        public PostsController(ILogger<PostsController> logger)
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
        public async Task<IEnumerable<ShortPost>> Get(int page = 0, int size = 100, CancellationToken cancelToken = default(CancellationToken))
        {

            cancelToken.ThrowIfCancellationRequested();
            var items = Builder<ShortPost>
                                .CreateListOfSize(size)
                                .All()
                                    .With(i => i.Id = Guid.NewGuid())
                                    .With(i => i.Title = Faker.Food.Dish())
                                    .With(i => i.Abstract = Faker.Food.Description())
                                    .With(i => i.CreateDate = Faker.Date.Backward())
                                    .With(i => i.TagsCount = (int)Faker.Number.Between(1, 30))
                                    .With(i => i.CategoriesCount = (int)Faker.Number.Between(1, 30))
                                .Build();


            cancelToken.ThrowIfCancellationRequested();
            // create some delay to simulate bad performance
            BadPerformance.MakeDelay(10, 20, size, cancelToken);

            return await Task.FromResult(items.Skip(page * size));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Post> Get(Guid id, CancellationToken cancelToken = default(CancellationToken))
        {
            // Id is fake, create a new Post
            

            cancelToken.ThrowIfCancellationRequested();

            var post = Builder<Post>
                                .CreateNew()
                                    .With(i => i.Title = Faker.Number.Number(2))
                                    .With(i => i.Title = Faker.Food.Dish())
                                    .With(i => i.Abstract = Faker.Food.Description())
                                    .With(i => i.Text = String.Join(".\n\r", Faker.Lorem.Paragraphs(10)))
                                    .With(i => i.CreateDate = Faker.Date.Backward())
                                .Build();


            cancelToken.ThrowIfCancellationRequested();
            // create some delay to simulate bad performance
            BadPerformance.MakeDelay(10, 100, (int)Faker.Number.Between(20,40), cancelToken);

            return await Task.FromResult(post);
        }
    }
}
