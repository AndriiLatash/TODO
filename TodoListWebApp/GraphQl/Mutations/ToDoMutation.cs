using GraphQL;
using GraphQL.Types;
using Microsoft.Data.SqlClient;
using System.Data;
using TodoListWebApp.GraphQl.Types;
using TodoListWebApp.Models;
using TodoListWebApp.Repository;

namespace TodoListWebApp.GraphQl.Mutations
{
	public class ToDoMutation : ObjectGraphType
	{
		public ToDoMutation(IListRepository repo)
		{
			Field<ToDoTypes>("toDoCreate")
				.Argument<ToDoInputType>("toDo")
				.Resolve(context =>
				{
					var todo = context.GetArgument<TODOlist>("toDo");
					repo.Create(todo);
					return null;
				});

			Field<BooleanGraphType>("toDoDelete")
			   .Argument<IdGraphType>("id")
			   .Resolve(context =>
			   {
				   int id = context.GetArgument<int>("id");
				   
			
					repo.Delete(id);
				    return null;
				   
				  
			   });

			Field<BooleanGraphType>("toDoUpdate")
			   .Argument<IdGraphType>("id")
			   .Argument<ToDoInputType>("toDo")
			   .Resolve(context =>
			   {
				   int id = context.GetArgument<int>("id");
				   var todo = context.GetArgument<TODOlist>("toDo");
				   repo.Update(id, todo);
				   return null;


			   });
		}
	}
}
