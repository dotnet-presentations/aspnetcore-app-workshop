# Session 1

- Intro
	- Show the API startup, explain configuration is injected into the Startup class
	- Explain MVC CompatibilityVersion
	- Show the ValuesController
- EntityFramework basics
	- Explain that a DbContext maps to the database
	- Explain that a DbSet maps to a table
	- Explain how DataAnnotations are used to model the database
	- Explain how migrations work at a high level
		- There's an up migration and a down migration (but nobody ever uses down migrations in production)
		- EF stores the current model state in the database and compares it to the model in source
	- Explain how wiring up the DbContext makes it available anywhere.
- Scaffolding
	- Show scaffolding support in VS
	- Show the command line version
- APIs
    - Discuss the scaffolded code briefly
	- Explain why ActionResult<T> exists and what the old code used to look like
	- Explain the new API controller attribute
	- Mention the ControllerBase base class and how it has less methods than Controller
- Swagger
	- Explain what swagger is and how it's used
	- Talk about the Swashbuckle library and mention NSwag (an alternate model)
	- Talk about the new build time swagger generation support that's coming
	- Talk about middleware order and how the redirect works
	- Discuss and show the swagger UI
 
# Session 2

- Intro
	- Explain that we're creating a class library to share the model types and attribute definitions between
	the front end and back end applications.
	- Explain what parts of the framework consume data annotations
		- APIs use it for validation
		- It's used as part of the swagger definition
		- It's used to generate client side logic
		- It's used to handle server side logic
		- It's used to as part of the generated DDL

- EntityFramework
	- Modelling a relation database using EntityFramework
		- Show how many to many is expressed in an EF model classes (the middleware table must be explicitly modeled)
		- Explain how each of the classes reference other entities for foreign keys
			- This is one of the reasons why it's bad to directly return the EF models
		- Show how the EF Model can be modifed in the DbContext
			- Show how Session has a computed property and show how this is handled in the ModelBuilder
			- Show how to setup unique indexes
			- Show the intellisense for various model builder APIs
			- Explain that the ModelBuilder can be used to fully describe the entities instead of using attributes
	- Migrations
		- Show how the attributes affect the migration code (and show DDL)
		- Show creating a db script
	- Queries
	    - Explain AsNoTracking and why it's good for web scenarios
		- Explain that EF 2.1 supports lazy loading and that it's off by default (https://docs.microsoft.com/en-us/ef/ef6/querying/related-data#lazy-loading)
			- Point to best practices doc for lazy loading and serialization (https://docs.microsoft.com/en-us/ef/ef6/querying/related-data#turn-lazy-loading-off-for-serialization)
		- Modify the EF queries and show eager loading with Include (explain how it avoids the N+1 problems with lazy loading)
		- Show how to view the generated EF queries in logs
- APIs
	- Show how the new API controller removes boilerplate (show the old 2.1 workshop)
		- FromBody is inferred
		- FromRoute is inferred if the route parameter matches the route definition
		- ModelState.IsValue is removed
    - Show the entities in the swagger, show how it has the entire object graph because we're returning the EF model
	- Explain why ActionResult<T> exists and what the old code used to look like
	- Explain how ActionResult<T> helps generate better swagger
	- Show the swagger.json and syntax for declaring things like responses etc
	- Show how problem details works for 400 errors
	- Show the API convention analyzers
	- Discuss automatic model validation
- Misc
   - Discuss how file upload works
   - Explain the difference between the IFormFile (it's buffered) vs the streaming MultipartReader (https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads?view=aspnetcore-2.2)
 
