namespace MVC.Routing {
	public class Class {
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "ASP0014:Suggest using top level route registrations", Justification = "<Pending>")]
		public static void Main(string[] args) {
			var builder = WebApplication.CreateBuilder(args);
			var app = builder.Build();

			//? Enables Routing 
			//? Select Appropriate Endpoint based on URL path and HTTP Method
			app.UseRouting();

			//? Execute Endpoints
			//? Selected By UseRouting() 
			//? Whenever A MIDDLEWARE is executed based on ROUTING it's called ----> ENDPOINT

			//app.Run(async context => {
			//	await context.Response.WriteAsync("Page doesn't exists!!");
			//});

			app.UseEndpoints(endpoints => {

				//? Works only when GET method is called on this URL
				//endpoints.MapGet("file/{filename}.{extension}", async context => {
				//	string? fileName = Convert.ToString(context.Request.RouteValues["filename"]);
				//	await context.Response.WriteAsync(fileName + ": Get Method");
				//});

				//? Works only when POST method is called on this URL
				//endpoints.MapPost("files/{filename}.{extension}", async context => {
				//	string? fileName = Convert.ToString(context.Request.RouteValues["filename"]);
				//	await context.Response.WriteAsync(fileName + ": Post Method");
				//});

				//? Default Values will be assign
				//? If values not supply in QUERY STRING
				//endpoints.MapGet("files/{filename=anything}", async context => {
				//	string? fileName = Convert.ToString(context.Request.RouteValues["filename"]);
				//	await context.Response.WriteAsync(fileName + ": Get Method");   //! Anything : Get Method
				//});

				//? If value is NULL or Not Supplies
				//endpoints.MapGet("files/{filename=null}", async context => {
				//	string? fileName = Convert.ToString(context.Request.RouteValues["filename"]);
				//	await context.Response.WriteAsync("Filename is Not Supplied");   //! Anything : Get Method
				//});

				//? ******************** Route Constraints ****************************** 

				//! Date Time
				//! Allowed Format: yyyy-mm-dd || mm-dd-yyyy
				//endpoints.MapGet("reports/datetime/{datetime_value:datetime}", async context => {
				//	var date_time = Convert.ToDateTime(context.Request.RouteValues["datetime_value"]);
				//	await context.Response.WriteAsync("Reporting Time is : " + date_time.ToString());
				//});

				//! Integer
				//endpoints.MapGet("reports/id/{id:int}", async context => {
				//	var Id = Convert.ToString(context.Request.RouteValues["Id"]);
				//	await context.Response.WriteAsync("Reporting Id is : " + Id);
				//});

				//! Limits
				//! For NUMBERS ----------> range (Min, Max) 
				//! For STRING ---------->  length (Min, Max) 
				//! Here DEFAULT VALUE SHOULD BE IN RANGE 
				//endpoints.Map("reports/{id:int:range(1, 1000)=203}", async context => {
				//	var Id = Convert.ToString(context.Request.RouteValues["id"]);
				//	await context.Response.WriteAsync("Reporting Id is : " + Id);
				//});

				//! Alphabetical

				endpoints.Map("reports/{name:length(4, 20):alpha=yash}", async context => {
					var name = Convert.ToString(context.Request.RouteValues["name"]);
					await context.Response.WriteAsync("Reporting name is : " + name);
				});


			});

			//? Works When one of above endpoints doesn't executed
			app.Run(async context => {
				await context.Response.WriteAsync("Page doesn't found !");
			});

			app.Run();
		}
	}
}
