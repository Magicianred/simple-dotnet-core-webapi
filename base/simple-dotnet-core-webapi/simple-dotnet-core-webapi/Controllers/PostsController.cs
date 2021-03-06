using FakerDotNet;
using FizzWare.NBuilder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace simple_dotnet_core_webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly ILogger<PostsController> _logger;

        public PostsController(ILogger<PostsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Post>> Get()
        {
            var posts = Builder<Post>
                                .CreateListOfSize(10)
                                .All()
                                    .With(c => c.Title = Faker.Number.Number(2))
                                    .With(c => c.Title = Faker.Food.Dish())
                                    .With(c => c.Text = Faker.Food.Description())
                                    .With(c => c.CreateDate = Faker.Date.Backward())
                                .Build();

            Random r = new Random();
            var delay = r.Next(10, 50) * 100;
            Thread.Sleep(delay);

            return await Task.FromResult(posts);
        }
    }
}
