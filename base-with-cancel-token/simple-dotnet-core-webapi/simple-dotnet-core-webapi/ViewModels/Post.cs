using System.Collections.Generic;

namespace simple_dotnet_core_webapi.ViewModels
{
    /// <summary>
    /// Post model with complete data
    /// </summary>
    public class Post : ShortPost
    {
        public string Text { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Category> Category { get; set; }
    }
}
