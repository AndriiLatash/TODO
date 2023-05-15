using GraphQL.Types;
using TodoListWebApp.Models;

namespace TodoListWebApp.GraphQl.Types
{
    public class ToDoTypes : ObjectGraphType<TODOlist>
    {
        public ToDoTypes()
        {
            Field(x => x.TaskId, type: typeof(IdGraphType));
            Field(x => x.TaskName);
			Field(x => x.Deadline, nullable: true, type: typeof(DateTimeGraphType));    
			Field(x => x.Status, nullable: true);
            Field(x => x.CategoryId, nullable: true);
            //Field(x => x.Category, type: typeof(CategoryType), nullable: true);
        }
    }
}
