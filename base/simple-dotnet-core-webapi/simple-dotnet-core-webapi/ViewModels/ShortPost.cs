using System;

namespace simple_dotnet_core_webapi.ViewModels
{
    /// <summary>
    /// Post model with short info, for list page
    /// </summary>
    public class ShortPost
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public DateTime CreateDate { get; set; }
        public int TagsCount { get; set; }
        public int CategoriesCount { get; set; }
    }
}
