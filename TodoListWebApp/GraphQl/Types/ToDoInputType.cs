using GraphQL.Types;
using TodoListWebApp.Models;

namespace TodoListWebApp.GraphQl.Types
{
	public class ToDoInputType : InputObjectGraphType<TODOlist>
	{
		public ToDoInputType()
		{
			Name = "ToDoInput";
			Field<IdGraphType>("TaskId");
			Field<NonNullGraphType<StringGraphType>>("TaskName");
			Field<DateTimeGraphType>("Deadline");
			Field<BooleanGraphType>("Status");
			Field<IntGraphType>("CategoryId");
			//Field<CategoryInputType>("category");
		}
	}
}
