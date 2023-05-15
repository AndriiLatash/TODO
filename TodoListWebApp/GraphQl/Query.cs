using GraphQL;
using GraphQL.Types;
using System.Threading.Tasks;
using TodoListWebApp.GraphQl.Types;
using TodoListWebApp.Models;
using TodoListWebApp.Repository;

namespace TodoListWebApp.GraphQl
{
    public class ToDoQuery : ObjectGraphType
	{
		public ToDoQuery(IListRepository repo)
		{
			Field<ListGraphType<ToDoTypes>>(
			"tasks",
			resolve: context =>
			{
				return repo.GetList();
			});

			Field<ToDoTypes>(
				"task",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "TaskId", Description = "The ID of the task" }
				),
				resolve: context =>
				{
					int Taskid = context.GetArgument<int>("TaskId");
					return repo.GetId(Taskid);
				});
		}
	}
	}

