using GraphQL.Types;
using TodoListWebApp.GraphQl.Mutations;
using TodoListWebApp.Repository;

namespace TodoListWebApp.GraphQl
{
	public class AppSchema : Schema
	{
		public AppSchema(IServiceProvider provider) : base(provider)
		{
			Query = provider.GetRequiredService<ToDoQuery>();
			Mutation = new ToDoMutation(provider.GetRequiredService<IListRepository>());
		}
	}
}