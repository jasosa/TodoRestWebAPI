using System;
namespace TodoAppRestAPI.Models
{
    public static class TodoItemBuilder
    {
        public static TodoItem BuildItemLearnAppDevelopment() => new TodoItem()
        {
            ID = Guid.NewGuid().ToString(),
            Name = "Learn app development",
            Notes = "Attend Xamarin university",
            IsDone = true
        };

        public static TodoItem BuildItemDevelopApps() => new TodoItem()
        {
            ID = Guid.NewGuid().ToString(),
            Name = "Develop Apps",
            Notes = "Use Xamarin/Visual Studio",
            IsDone = false
        };

        public static TodoItem BuildItemPublishApps() => new TodoItem()
        {
            ID = Guid.NewGuid().ToString(),
            Name = "Publish apps",
            Notes = "All app stores",
            IsDone = false
        };
    }
}
