using GraphQL;
using GraphQL.Types;
using TodoListWebApp.GraphQl;
using TodoListWebApp.Repository;
using GraphQL.Server.Ui.Playground;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=List;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
builder.Services.AddTransient<IListRepository, ListRepository>(provider => new ListRepository(connectionString));
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddGraphQL(config => config
				.AddSystemTextJson()
				.AddErrorInfoProvider(options => options.ExposeExceptionStackTrace = true)
				.AddSchema<AppSchema>()
				.AddGraphTypes(typeof(AppSchema).Assembly)
				);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");


app.UseGraphQL("/graphql");


app.UseGraphQL<ISchema>();

app.UseGraphQLAltair();

app.Run();
