## Backend
 - APIs talking to EF
 - Returning DTOs
 - Accepting DTOs to prevent over binding
 - CRUD
 - AsNoTracking
 - Include
 - EF with Many to Many
 - OnModelCreating and entity mapping
 - Migrations
 - async Action methods
 - Swashbuckle and Swagger
 - Configuring the URL
 - Seeding data
 - Search
 
 ## ConferenceDTO
 - .NET Standard 2.0 library
 - APIs are back in .NET Standard 2.0
 - Model Metadata
 
 ## FrontEnd
 - User Secrets
 - Razor Pages
 - Custom Tag Helpers
 - Custom Filter
 - Validation in forms
 - Logging
 - Outgoing HttpClient calls with JSON
 - Configuration in DI
 - Authentication (new system in 2.0)
   - Cookies
   - Adding Twitter and Google support
- Status Code pages
- Error page
 
 ## Cross cutting
 - Unit testing Controllers
 - Unit testing Pages
 
 
 ## Extra credit

- Add local user accounts using ASP.NET Core Identity
- Add 3rd party logger (serilog) and disable built in console logging
- Add image upload to Speaker entity
- Add caching to front end (memory cache and distributed cache)
- Make the site work for multiple conferences
  - Add conference date
  - Make the home page show upcoming conferences (instead of agenda) and move agenda to separate page
- Make the names slugs instead of using ids to navigate entities
- Add `ILogger` support to ApiClient implementation 
- Allow Markdown for the Abstract using a custom markdown tag helper
- Add date filtering to the backend (instead of doing it in the front end)
- Add paging to the back end
- Use postgres instead of SQL server or SQLite
- Add admin pages to manage:
  - Tracks
  - Attendees
  - Conferences
  - Sessions

