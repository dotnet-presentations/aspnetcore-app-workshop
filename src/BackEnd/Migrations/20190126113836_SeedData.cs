using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Attendees_AttendeeID",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_AttendeeID",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "AttendeeID",
                table: "Sessions");

            migrationBuilder.CreateTable(
                name: "SessionAttendee",
                columns: table => new
                {
                    SessionID = table.Column<int>(nullable: false),
                    AttendeeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionAttendee", x => new { x.SessionID, x.AttendeeID });
                    table.ForeignKey(
                        name: "FK_SessionAttendee_Attendees_AttendeeID",
                        column: x => x.AttendeeID,
                        principalTable: "Attendees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SessionAttendee_Sessions_SessionID",
                        column: x => x.SessionID,
                        principalTable: "Sessions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Conferences",
                columns: new[] { "ID", "Name" },
                values: new object[] { 1, "NDC London 2019" });

            migrationBuilder.InsertData(
                table: "Speakers",
                columns: new[] { "ID", "Bio", "ConferenceID", "Name", "WebSite" },
                values: new object[,]
                {
                    { 66, null, null, "Seth Juarez", null },
                    { 65, null, null, "luis vieira", null },
                    { 64, null, null, "Guy Royse", null },
                    { 63, null, null, "Olivia Liddell", null },
                    { 62, null, null, "Layla Porter", null },
                    { 61, null, null, "Glenn F. Henriksen", null },
                    { 60, null, null, "Chris Klug", null },
                    { 59, null, null, "Ian Cooper", null },
                    { 58, null, null, "Jesse Phelps", null },
                    { 57, null, null, "Lee Mallon", null },
                    { 56, null, null, "Simona Cotin", null },
                    { 55, null, null, "Rafał Legiędź", null },
                    { 54, null, null, "Viktorija Almazova", null },
                    { 53, null, null, "Jessica White", null },
                    { 52, null, null, "Mathias  Brandewinder", null },
                    { 51, null, null, "Jim Bennett", null },
                    { 50, null, null, "Luce Carter", null },
                    { 49, null, null, "Arthur Doler", null },
                    { 48, null, null, "Anthony Brown", null },
                    { 67, null, null, "Gojko Adzic", null },
                    { 68, null, null, "Dennie Declercq", null },
                    { 69, null, null, "Jason Taylor", null },
                    { 70, null, null, "Scott Hanselman", null },
                    { 90, null, null, "Ryan Nowak", null },
                    { 89, null, null, "Alex Dunn", null },
                    { 88, null, null, "Clifford Agius", null },
                    { 87, null, null, "Shahid Iqbal", null },
                    { 86, null, null, "Elton Stoneman", null },
                    { 85, null, null, "Mahmoud Abdelghany", null },
                    { 84, null, null, "Simon Zeltser", null },
                    { 83, null, null, "Kendall Miller", null },
                    { 82, null, null, "Sarah Withee", null },
                    { 47, null, null, "Mete Atamel", null },
                    { 81, null, null, "Krista LaFentres", null },
                    { 79, null, null, "Andy Clarke", null },
                    { 78, null, null, "Mahesh Krishnan", null },
                    { 77, null, null, "Evelina Gabasova", null },
                    { 76, null, null, "Jennifer Wadella", null },
                    { 75, null, null, "Jon Skeet", null },
                    { 74, null, null, "Scott Wlaschin", null },
                    { 73, null, null, "Scott Helme", null },
                    { 72, null, null, "Matt Warren", null },
                    { 71, null, null, "Mark Seemann", null },
                    { 80, null, null, "Galiya Warrier", null },
                    { 91, null, null, "Edward Thomson", null },
                    { 46, null, null, "Jon Galloway", null },
                    { 44, null, null, "Lewis Denham-Parry", null },
                    { 19, null, null, "James Nugent", null },
                    { 18, null, null, "Tim G. Thomas", null },
                    { 17, null, null, "Aaron Stannard", null },
                    { 16, null, null, "Christine Yen", null },
                    { 15, null, null, "Oren Novotny", null },
                    { 14, null, null, "Tess Ferrandez-Norlander", null },
                    { 13, null, null, "Mark Rendle", null },
                    { 12, null, null, "Bryan Hogan", null },
                    { 11, null, null, "Nick Tune", null },
                    { 10, null, null, "Phillip Carter", null },
                    { 9, null, null, "Dominick Baier", null },
                    { 8, null, null, "David Fowler", null },
                    { 7, null, null, "Damian Edwards", null },
                    { 6, null, null, "Troy Hunt", null },
                    { 5, null, null, "Jimmy Bogard", null },
                    { 4, null, null, "Sam  Newman", null },
                    { 3, null, null, "Bill Wagner", null },
                    { 2, null, null, "Mads Torgersen", null },
                    { 1, null, null, "Hadi Hariri", null },
                    { 20, null, null, "Tannaz N. Roshandel", null },
                    { 21, null, null, "Line Moseng", null },
                    { 22, null, null, "Adrian Hornsby", null },
                    { 23, null, null, "Roy Derks", null },
                    { 43, null, null, "Dylan Beattie", null },
                    { 42, null, null, "Filip Ekberg", null },
                    { 41, null, null, "David Neal", null },
                    { 40, null, null, "Rob Conery", null },
                    { 39, null, null, "Steve Gordon", null },
                    { 38, null, null, "Steve Sanderson", null },
                    { 37, null, null, "Dan North", null },
                    { 36, null, null, "Kevlin Henney", null },
                    { 35, null, null, "Richard Campbell", null },
                    { 45, null, null, "Carl Franklin", null },
                    { 34, null, null, "Thiago Passos", null },
                    { 32, null, null, "Todd Gardner", null },
                    { 31, null, null, "Peter Myers", null },
                    { 30, null, null, "Patricia Aas", null },
                    { 29, null, null, "Clare Sudbery", null },
                    { 28, null, null, "Jeff Strauss", null },
                    { 27, null, null, "Jakob Ehn", null },
                    { 26, null, null, "Amy Kapernick", null },
                    { 25, null, null, "David Wengier", null },
                    { 24, null, null, "Jeremy Miller", null },
                    { 33, null, null, "Ingrid Guren", null }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "ID", "Name" },
                values: new object[] { 2223, "Tags" });

            migrationBuilder.InsertData(
                table: "Tracks",
                columns: new[] { "TrackID", "ConferenceID", "Name" },
                values: new object[,]
                {
                    { 2775, 1, "Room 1" },
                    { 2776, 1, "Room 2" },
                    { 2777, 1, "Room 3" },
                    { 2778, 1, "Room 4" },
                    { 2779, 1, "Room 5" },
                    { 2780, 1, "Room 6" }
                });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "ID", "Abstract", "ConferenceID", "EndTime", "StartTime", "Title", "TrackId" },
                values: new object[,]
                {
                    { 69229, @"Information is everywhere and for many people, especially in the connected world, it is accessible freely or at a minimal cost. News outlets rely on social media to broadcast breaking news. Social media in turn relies on us to feed it with information, be it of our surroundings or our personal information. It’s become somewhat of a self-sustaining self-serving machine in which we’re all part of. It’s big data and we’re a cog in the wheel. For now of course, because with big data and cheap yet powerful hardware, AI also wants to play the game.

                And if information and knowledge is the key to success, surely this means we’re on the right path. The question is, will we notice some of the warning signs before it’s too late…", 1, new DateTimeOffset(new DateTime(2019, 1, 30, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 30, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Keynote: Welcome to the Machine", 2775 },
                    { 67422, @"Open source tools. We all use them. Whether an entire framework, a focused toolkit, or a simple custom component from GitHub, npm, or NuGet, the opportunity to improve our development speed while learning new things from open source projects is enticing.

                But what does “open source” truly mean? What are our rights and limitations as open source consumers to use, modify, and redistribute these tools in a professional environment? The answer depends upon the OSS author's own decisions regarding project licensing. Come investigate the core principles of open source development and consumption while comparing and contrasting some of the more popular licenses in use today. Learn to make better decisions for your organization by becoming informed of how best to leverage the open source works of others and also how to properly license your own.", 1, new DateTimeOffset(new DateTime(2019, 1, 30, 11, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 30, 10, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "What You Need to Know About Open Source—Trust Me, I'm a Lawyer", 2779 },
                    { 67872, @"OpenCensus is an emerging standard for tracing and metrics of cloud services. You can use it to gain observability into applications that span multiple clouds and technological stacks.
                In this talk, we will use open source and vendor agnostic client libraries for OpenCensus and export telemetry to common distributed tracing systems such as Zipkin and others.
                Along the way. we will discuss core concepts such as tags, metrics, exporters, zPages and trace context propagation. ", 1, new DateTimeOffset(new DateTime(2019, 2, 1, 17, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 1, 16, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Distributed Tracing and Monitoring with OpenCensus", 2778 },
                    { 68882, @"For decades, we’ve been creating ever higher abstractions between ourselves and the computing hardware we’re programming, but in the end whether you’re writing JavaScript, Haskell, or Python it all comes down to 1’s and 0’s running through hardware patterns that were well understood twenty years ago.

                We’ll walk through the fundamentals of how CPU’s “think” in an accessible way (no engineering degree required!) so you can appreciate the marvel that is the modern CPU be it in a server data center or your fridge at home.  You’ll learn how a CPU turns the code we feed it into actions, what’s the big difference between an ARM and an Intel processor, how CPU’s constantly optimize work for us, and where is it all going for the next few years.

                Finally, we'll show how Meltdown and Spectre take advantage of CPU internals to expose data and why this class of security problems are going to be a challenge to the next generation of CPU's.
                ", 1, new DateTimeOffset(new DateTime(2019, 2, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Megahertz, Gigahertz, Registers and Instructions: How does a CPU actually work?", 2778 },
                    { 68894, @"Home virtual assistants, like Alexa, Google Now, Siri, and Cortana, are gaining a lot of popularity. They’re now incorporated into our phones, our laptops, and even available as separate devices in our homes. Some people haven’t adopted them out of privacy concerns. A new system called Mycroft has come onto the scene, and it’s built on open source hardware and software. You can install it on a Raspberry Pi, an old Linux box, or buy their own Mycroft device.

                In this session, we’ll go over the basics of what Mycroft is, and how you can quickly install it yourself. From there, we’ll talk about some of the underlying software and see a short demo. Finally, we’ll see how to build a new skill into it and contribute it back to the community. You’ll leave with your own virtual assistant and the knowledge on how make it do what you want but keep your privacy in check.", 1, new DateTimeOffset(new DateTime(2019, 2, 1, 14, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 1, 13, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "\"Hey Mycroft\": Getting Started with the OSS Home Assistant", 2778 },
                    { 62532, "Love it or hate it, advertising is currently a main source of revenue for many websites. But digital advertising is a complicated space that not many developers understand. If you'd like to understand the ad code on your site better, if your ad ops team has been talking about header bidding, or if you're just curious about how ads work, this is the talk for you. I'll give an overview of how programmatic advertising works, what header bidding is, explain some common tools and libraries, and address some common misconceptions and complaints about ads.", 1, new DateTimeOffset(new DateTime(2019, 2, 1, 12, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 1, 11, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "A Developer's Guide to Advertising", 2778 },
                    { 58161, "Often the hardest part of any problem is simply how to get started. On the ever-evolving web accessibility is a matter of ongoing importance: the brilliance of your code or sleekness of your UI is inconsequential if your app or website is unusable to some of your users. With a million other issues already on your plate how do you find a way to get started on accessibility testing? Pa11y to the rescue! Pa11y is a lightweight command-line accessibility testing tool with enough flexibility to integrate results into your current testing process. This talk will explain what pa11y does and does not cover, review examples of both command line and scripted usage, dive into the pa11y web service and show how to modify output to work in your current testing setup. Bonus content: how to convince the rest of your team and business why accessibility is worth prioritizing and how getting started with low-hanging fruit can vastly improve your product.", 1, new DateTimeOffset(new DateTime(2019, 2, 1, 11, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 1, 10, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Making Accessibility Testing Suck Less: An Intro to Pa11y.", 2778 },
                    { 64248, @"When we move from a monolith to microservices we abandon integrating via a shared database, as each service must own its own data to allow them it to be autonomous. But now we have a new problem, our data is distributed. What happens if I need one service needs to talk to another about a shared concept such as a product, a hotel room, or an order? Does every service need to have a list of all our users? Who knows what users have permissions to the entities within the micro service? What happens if my REST endpoint needs to include data from a graph that includes other services to make it responsive? And I am not breaking the boundary of my service when all of this data leaves my service boundary in response to a request?

                Naive solutions result in chatty calls as each service engages with multiple other services to fulfil a request, or in large message payloads as services add all the data required to process a message to each message. Neither scale well.

                In 2005, Pat Helland wrote a paper ‘Data on the Inside vs. Data on the Outside’ which answers the question by distinguishing between data a service owns and reference data that it can use. In this presentation we will explain reference data, how it is classified, and how it should be implemented. We will include a discussion of using reference data from ATOM feeds, discrete messaging and event streams. We’ll provide examples in C#, Python and Go as well as using RMQ and Kafka.", 1, new DateTimeOffset(new DateTime(2019, 1, 31, 18, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 31, 17, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Data on the Inside, Data on the Outside", 2778 },
                    { 68212, "I recently made build lights for the company I work for and my home office. They integrate with TeamCity and indicate when a build is running and success/failure of all the tests. In this session, we will reverse engineer a bluetooth light bulb’s protocol, learn how to have an Raspberry Pi communicate with the bulb, and by the end you too will know how to make your own build lights! Please note that this talk will be highly technical. We will be discussing low level details of bluetooth communication, protocol analysis with Wireshark, sniffing bluetooth packets, etc.", 1, new DateTimeOffset(new DateTime(2019, 1, 31, 17, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 31, 16, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Reverse Engineering a Bluetooth Lightbulb", 2778 },
                    { 68161, @"AI talk is everywhere but where do you start as a .NET developer?  During this session, we will explore how you can use AI in the applications your creating today. How to start building & training your ML models with your .NET skills through ML.NET. 

                Want to detect laughter in a phone conversation?  Detect the mood of Jira tickets or predict if/where your code has bugs. This session will get you started with AI and ML.NET.", 1, new DateTimeOffset(new DateTime(2019, 1, 31, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 31, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "ML.NET for developers without any AI experience", 2778 },
                    { 68736, "Serverless lets you focus on coding and testing instead of provisioning infrastructure, configuring web servers, debugging your configuration, managing security settings, and all the drudgery normally associated with getting an app up and running. In this session with, you’ll discover how to migrate an API of an existing app to Azure Functions. You’ll learn how to use Visual Studio Code and the Azure Functions extension to speed up your work. After this session, you’ll join the ranks of serverless developers.", 1, new DateTimeOffset(new DateTime(2019, 1, 31, 14, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 31, 13, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Build Nodejs APIs using Serverless on Azure", 2778 },
                    { 57079, @"Augmented Reality is far more than a Pokémon Go thing now. The hype is real, and many big players (Google, Microsoft, Apple, Facebook, you name it) are pushing AR to become ubiquitous. Hence the abundance of different approaches to AR, a significant need for content creators and creative ways of tackling problems using new techniques.

                Is mobile AR superior to HMDs? What's AR Cloud and why it's important?  What are real-world cases solved with AR? Is this all still sci-fi or should you start caring? This session presents the current state of AR, showcases its real capabilities, and demonstrates that we are on the verge of a revolution in how humans interact with digital content.", 1, new DateTimeOffset(new DateTime(2019, 1, 31, 12, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 31, 11, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Augmented Reality - The State of Play", 2778 },
                    { 67271, @"Learning Go programming is easy. Go is popular and becomes even more also in security experts world. Wanted to feel a bit as a hacker? Learn a new language? Or do both at the same time? This session is about it. 
                So let's jump into hands-on session and explore how security tools can be written in Go. How to enumerate network resources, extract an information, sniff packets and do port scanning, brute force and more all with Go. 
                By the end, you will have more ideas what else can be written or re-written in Go. ", 1, new DateTimeOffset(new DateTime(2019, 1, 31, 11, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 31, 10, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Hacking with Go", 2778 },
                    { 66632, @"Monitoring is difficult. First, there is a vast choice of tooling and setup. Then, figuring out what information should be displayed, where and why can be confusing. Finally what should be alerted upon and how to avoid fatigue.

                Together we will journey through a practical tour of dashboarding. Focusing on metrics, we will cover how to get information out of your applications using telemetry. I will show you how you might set up your monitoring infrastructure with a demo and talk through some hardened baselines. Finally, I’ll talk through a productionised setup including some gotchas to look out for.

                This will be a whirlwind tour from start to finish of a practical guide to development dashboarding. ", 1, new DateTimeOffset(new DateTime(2019, 1, 31, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 31, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "A Practical Guide to Dashboarding.", 2778 },
                    { 68826, @"Azure DevOps (previously known as Visual Studio Team Services) is a broad product suite with tools that assists small and large software development teams that want to deliver high quality software at a rapid speed. 

                In session we will walk through all major features in Azure DevOps, such as Azure Boards, Azure Pipelines and Azure Repos, and look at how we can continuously deliver value to or end users and implement DevOps practices such as Infrastructure as Code and testing in production using Azure.", 1, new DateTimeOffset(new DateTime(2019, 1, 30, 18, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 30, 17, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "A lap around Azure Devops", 2778 },
                    { 59857, @"We’ve all heard a lot in the last year about a new advancement in the world of CSS, called CSS Grid. Starting off at whispers, we’re now starting to hear it as a deafening roar as more and more developers write about it, talk about it, share it and start using it. In the world of front end, I see it everywhere I turn and am excited as I start to use it in my own projects.

                But what does this new CSS specification mean for software developers, and why should you care about it? In the world of tech today, we can do so many amazing things and use whatever language we choose across a wide range of devices and platforms. Whether it’s the advent of React and React Native, or frameworks like Electron, it’s easier than ever to build one app that works on multiple platforms with the language we know and work with best. The ability to do this also expands to styling apps on any platform using CSS, and therefore being able to utilise the magical thing that is
                CSS Grid.

                The reason CSS Grid is gaining so much attention, is because it’s a game changer for front end and layouts. With a few simple lines of code, we can now create imaginative, dynamic, responsive layouts (yep, I know that’s a lot of buzz words). While a lot of people are calling this the new ‘table layout’, grid gives us so much more, with the ability to spread cells across columns and rows to whatever size you choose, dictate which direction new items flow, allow cells to move around to fit in place and even tell certain cells exactly where they need to sit.

                While there is so much to worry about when developing an app, CSS Grid means that you can worry less about building the layout on the front end, and more about making sure the back end works well. Let me show you how the magic works.", 1, new DateTimeOffset(new DateTime(2019, 1, 30, 17, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 30, 16, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "CSS Grid - What is this Magic?!", 2778 },
                    { 66433, @"As a developer you often here both that performance is important, but also that you shouldn't worry about performance up front, so when is the right time to think about it? And if the time is right, what are you actually supposed to do?

                If you're interested to hear about a pragmatic approach to performance, this talk will explain when is the right time to think about benchmarking, but more importantly will run through how to correctly benchmark .NET code so any decisions made will be based on information about your code that is trustworthy.

                Additionally you'll also find out about some of the common, and some of the unknown, performance pitfalls of the .NET Framework and we'll discuss the true meaning behind the phrase ""premature optimization is the root of all evil"".", 1, new DateTimeOffset(new DateTime(2019, 1, 30, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 30, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Pragmatic Performance: When to care about perf, and what to do about it.", 2778 },
                    { 63252, "A possibly overlooked feature of the Roslyn compiler is the ability to generate, compile, and load new types at runtime. Sure, we've always had *some* ability to use dynamic code in .Net, but the existing techniques were either slow (Reflection) or daunting to use (IL generation or Expressions). Now though, we can just use C# in a way that's both more approachable for more developers and lends itself to more ambitious levels of dynamic behavior. In this talk I'll show some of the ways I've been using this technique to create more efficient, low allocation application frameworks. We'll also dive into the Utf8Json library already uses this approach today in its support for very highly efficient Json parsing.", 1, new DateTimeOffset(new DateTime(2019, 1, 30, 14, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 30, 13, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Dynamic Runtime Code with Roslyn", 2778 },
                    { 66715, @"Why GraphQL will become the new standard for accessing external data in your application. I will show how using GraphQL instead of REST services the development process becomes even more declarative as GraphQL will take away the (imperative) hassle of tying data from multiple endpoints together. This will increase the level of complexity in frontend development, while also increasing the performance of the application.
                ", 1, new DateTimeOffset(new DateTime(2019, 1, 30, 12, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 30, 11, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "GraphQL Will Do To REST What JSON Did To XML", 2778 },
                    { 67138, "In this talk, we will discuss computer vision, one of the most common real-world applications of machine learning. We will deep dive into various state-of-the-art concepts around building custom image classifiers - application of deep neural networks, specifically convolutional neural networks and transfer learning. We will demonstrate how those approaches could be used to create your own image classifier to recognise the characters of \"My Little Pony\" TV Series [or Pokemon, or Superheroes, or your custom images].", 1, new DateTimeOffset(new DateTime(2019, 2, 1, 17, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 1, 16, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Deep Learning in the world of little ponies", 2777 },
                    { 66814, @"If you are interested in mixed or virtual reality development then Unity is a tool you’ll want to learn. Go to Microsoft’s [Hololens development page](https://developer.microsoft.com/en-us/windows/mixed-reality/install_the_tools) and you’ll find the installation of Unity recommended in the first paragraph.

                One surprise to developers getting started with Unity is the level of integration with Visual Studio and how easy it is to add C# to manipulate your 3D world.

                In this demo led session we’ll go back to basics with Unity, easily creating a simple 3D experience with realistic physics. We’ll look at the fantastic Visual Studio integration and how easily the two editors work together.

                Finally we’ll look at the ways in which we can give our 3D experience some polish by adding textures, animations and some explosions!

                Keeping the best news for last: Unity is royalty free until you’re earning $100,000 – so if you like the idea of becoming wildly rich from making immersive 3D experiences this is the talk for you.", 1, new DateTimeOffset(new DateTime(2019, 2, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Unity 101 for C# Developers", 2777 },
                    { 69366, @"As more and more people are starting to deploy their application to the cloud, new architectural patterns have emerged, and some old ones have resurfaced or become more prominent.

                In this session, Mahesh Krishnan, will run through a large catalogue of cloud patterns that will cover categories such as availability, resiliency, data management, performance, scalability, design and implementation. You will learn about what problem each and every pattern addresses, how to implement them and what considerations you need to take into account while implementing them.", 1, new DateTimeOffset(new DateTime(2019, 2, 1, 14, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 1, 13, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Architectural patterns for the cloud", 2777 },
                    { 66768, @"It’s easy to forget what it felt like when you were a beginner. This lively dog-based* talk is about the rewards and pitfalls involved in introducing pair programming, TDD and an agile development approach to experienced developers who are used to working in a different way. It includes several practical suggestions of how to help and convince less agile-experienced colleagues.
                Based on my experience as a consultant technical lead, the aim is to help you to move your team members to a state of childlike fearlessness where learning is fun; is embedded in everything you do; and applies to all team members regardless of experience. 
                *It turns out that images of dogs can be used to illustrate an astonishing variety of concepts!", 1, new DateTimeOffset(new DateTime(2019, 1, 30, 12, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 30, 11, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Teaching New Tricks – How to enhance the skills of experienced developers", 2779 },
                    { 67078, @"More and more developers are building APIs, whether that be for consumption by client-side applications, exposing endpoints directly to customers so they can use an alternative front-end or wrapping up services in containers.

                Now that we have all these exposed endpoints, what are we doing to secure them?  Previously, our monolith was self-contained with limited points of access making authentication and authorisation more straightforward - that’s no longer the case.

                We’ll cover the potential risks we may face such as cross-site scripting and BruteForce attacks as well as a look at the possible options for securing API endpoints including OAuth, Access Tokens, JSON web tokens, IP whitelisting, rate limiting to name but a few.

                ", 1, new DateTimeOffset(new DateTime(2019, 2, 1, 12, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 1, 11, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "APIs Exposed!", 2777 },
                    { 58982, "Someone else's code. Even worse, thousands of lines, maybe hundreds of files of other peoples code. Is there a way to methodically read and understand other peoples work, build their mental models? In this talk I will go through techniques I have developed throughout 18 years of programming. Hopefully you will walk away with a plan on how to approach a new code base. But even more I hope you walk away with a feeling of curiosity, wanting to get to know your fellow programmers through their code.", 1, new DateTimeOffset(new DateTime(2019, 1, 30, 14, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 30, 13, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Reading other peoples code", 2779 },
                    { 67909, @"We were so preoccupied with whether we could, we didn’t stop to think if we should. Nowhere at Jurassic Park was this more true than how we developed software. Having the wrong software and support structures was a key factor in the failures of our first park. We were entrepreneurs launching something new and architects integrating an enterprise. And our decisions had lasting consequences. Deciding which problems were worth our time was foundational to our failure.

                Join us for a retrospective of software systems at Jurassic Park. We’ll dig into case studies and explore our successes and failures. We’ll uncover the options, costs, and risks inherent in deciding what software to build, what to buy, and alternatives in between. We’ll explore the opportunity cost of building systems, the sustainability of open-source, and the risks of vendor lock-in. You’ll leave equipped to make better decisions and avoid the pitfalls we made at Jurassic Park.", 1, new DateTimeOffset(new DateTime(2019, 1, 30, 18, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 30, 17, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Build vs Buy: Software Systems at Jurassic Park", 2779 },
                    { 76427, "Join Ryan Nowak from the ASP.NET Core team as he shares learnings from building the framework, improving performance, and helping customers. We’ll talk about design details of Razor Pages and Controllers for Web and APIs, as well as hidden gems and power user features. Come learn how MVC works and get some useful tips from one of the core developers.", 1, new DateTimeOffset(new DateTime(2019, 2, 1, 11, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 1, 10, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Lessons learned building ASP.NET Core MVC", 2780 },
                    { 68611, @"The explosive growth of web frameworks and the demands of users have changed the approach to building web applications. Many challenges exist, and getting started can be a daunting prospect. Let's change that now.

                This talk provides practical guidance and recommendations. We will cover architecture, technologies, tools, and frameworks. We will examine strategies for organizing your projects, folders and files. We will design a system that is simple to build and maintain - all the way from development to production. You leave this talk inspired and prepared to take your enterprise application development to the next level.", 1, new DateTimeOffset(new DateTime(2019, 1, 31, 18, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 31, 17, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Clean Architecture with ASP.NET Core 2.2", 2780 },
                    { 58551, @"Short Description

                Join me for this session and I will show you how with just a few lines of code, you can make your applications much more resilient and reliable. With Polly, the .NET resilience framework, your application can easily tolerate transient faults and longer outages in remote systems or infrastructure. 

                At the end of this hour you will know how to use all the features of Polly to make your application a rock solid piece of work. We’ll cover the reactive and proactive resilience strategies, starting with simple but very powerful retries and finishing with bulkhead isolation.
                Oh, and did I mention Polly is a .NET Standard library so it will work on any application you can think of! Join me for an hour, and your applications will never be the same.

                ----------------------------------------------------------------------------------------------------------------------------------

                Full Description

                Join me for this session and I will show you how with just a few lines of code, you can make your applications much more resilient and reliable. Let me tell you more… 

                Almost all applications now depend on connectivity, but what do you do when the infrastructure is unreliable or the remote system is down or returns an error? Does your application grind to a halt or just drop that single request? What if you could recover from these kinds of error, maybe even so quickly it won’t be noticed? 
                 
                With Polly your application can easily tolerate transient faults and longer outages in remote systems or infrastructure.  

                At the end of this hour you will know how to use all the features of Polly to make your application a rock solid piece of work. 

                We’ll start with the simple but very powerful Retry Policy which lets you retry a failed request. If simple retries are not good enough for you, there is a Wait and Retry policy which introduces a delay between retries, giving the remote service time to recover before being hit again. Then I show you how to use the circuit breaker for when things have really gone wrong and a remote system is struggling under too much load or has failed. If all these attempts are unsuccessful and you are still not getting through to the remote system, you can return a default response or execute arbitrary code to call for human help (or restart the cloud) with the fallback policy. 

                That takes care of what you can do when things go wrong, but Polly also lets you take proactive steps to keep your application and the services it depends on healthy.  

                To get you started with proactive strategies, you will learn how caching can be used to store and return responses from an in-memory or distributed cache without having to hit the remote server every time. Or you can use bulkhead isolation to marshal resources within your application so that no one struggling part can take down the whole. Finally, I’ll show you how to fail quickly when your application is in danger of being overloaded or the remote systems is not responding in a timely fashion, this is done with the bulkhead isolation and the timeout polices.   

                Oh, and did I mention Polly is a .NET Standard library so it will work on any application you can think of! Join me for an hour, and your applications will never be the same. ", 1, new DateTimeOffset(new DateTime(2019, 1, 31, 17, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 31, 16, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "System Stable : Robust connected applications with Polly, the .NET Resilience Framework", 2780 },
                    { 66322, @"Want to start building apps for people with disabilities but doesn’t no where to start? In this session we cover everything to start right now! There are many people with learning disabilities around the world. There are also people with autism, psychological disabilities… Many of them are also entering the era of mobile and internet. We talk about design guidelines that can reach them. 

                We talk about apps, but do not focus on a specific technology in this talk. Which apps are needed? Which steps of design helps them to catch the frontiers of mobile and internet right now? Microsoft and other big tech companies are working more and more about inclusive design and digital inclusion for people with disabilities. ", 1, new DateTimeOffset(new DateTime(2019, 1, 31, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 31, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Accessible App Design", 2780 },
                    { 59563, "Five amazing ways using the emerging cloud ecosystem can save you time. The true power of serverless comes from using not just the execution service, but the whole platform around it. This talk/demo shows how teams can use AWS Lambda with Cognito, IOT, Kinesis and S3 to achieve in a few hours what usually takes the the first three months of application development.", 1, new DateTimeOffset(new DateTime(2019, 1, 31, 12, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 31, 11, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Skip the first three months of development for your next app", 2780 },
                    { 69354, @"Deep Learning is fast becoming an indispensable approach to getting the most from your data. In this session attendees will learn both how Deep Learning fits into the Artificial Intelligence landscape as well as how to get started using PyTorch. The session will start with the basic intuitions behind the problem setup, models, and optimization methods used to solve computer vision problems.

                Attendees should come away with a strong foundation of how to both create deep learning models as well as how to consume them in their applications. Prior exposure to PyTorch is definitely not expected.", 1, new DateTimeOffset(new DateTime(2019, 1, 31, 11, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 31, 10, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Deep Learning with PyTorch", 2780 },
                    { 69255, @"This instructor-led workshop focuses on development practices for embedding Power BI reports, dashboards and the Q&A experience, and working with the Power BI JavaScript API.

                This workshop is designed for web developers experienced with ASP.NET, Visual C#, HTML and JavaScript. You are required to bring your own PC, with Visual Studio 2015 (or later) with web tools installed.", 1, new DateTimeOffset(new DateTime(2019, 1, 30, 17, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 30, 16, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Workshop: Embedding Power BI Analytics - Part 1/2", 2780 },
                    { 66459, "Cosmos DB is great and awesomely fast. Wouldn't be even more amazing if we could use our beloved entity framework to manage it? Let see how we can wire it up and get started", 1, new DateTimeOffset(new DateTime(2019, 1, 30, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 30, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Getting Started with Cosmos DB + EF Core", 2780 },
                    { 67163, @"Do you want to deploy your own application in the cloud, but don't know where you should start? This workshop is for you!

                In this workshop you will create your first Kubernetes cluster with Docker images in Google Cloud. By using Docker images, you can build and deploy your application without worrying about the environment on the server. We will create a cluster containing a frontend web application and a backend.

                 This workshop does not require knowledge about Docker, Kubernetes or Google Cloud.

                You will need to bring your own computer to attend the workshop.", 1, new DateTimeOffset(new DateTime(2019, 1, 30, 11, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 30, 10, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Workshop: An introduction to Kubernetes on Google Cloud with Docker - Part 1/2", 2780 },
                    { 66791, @"Dive into the latest craze in languages and platforms - Kotlin. This time we will be looking at it from the perspective of a .NET C# developer, draw comparisons between the languages, and bridge the gap between these 2 amazing languages.

                We'll look at:
                - Kotlin as a language
                - Platforms Kotlin is great for
                - Object Oriented Implementations in Kotlin
                - Extended Features
                - Features Kotlin has that C# doesn't
                - A demo Android application in Kotlin vs a Xamarin.Android app in C#

                In the end you will leave with a foundational knowledge of Kotlin and its capabilities to build awesome apps with less code. You should feel comfortable comparing C# applications to Kotlin applications and know where to find resources to learn even more!", 1, new DateTimeOffset(new DateTime(2019, 2, 1, 17, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 1, 16, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Kotlin for C# Developers", 2779 },
                    { 67372, @"Kayden a local 13yr Old was born with no left forearm and hand, being continually let down by very poor and expensive NHS prosthetics.  Being a close friend of the family, I started looking around the web after seeing news reports of home-made devices.  I stumbled across the OpenBionics team and the great work they do and set to building a version for Kayden.  
                After 3D printing the parts I moved onto the electronics but this requires building a bespoke board that often needs software changes to set-up and configure.  So my version uses off the shelf IOT parts and connects via Bluetooth to a Xamarin .Net application for changing the settings and configuring on Kayden’s phone. Still a work in progress but I will talk about the process used to get this far and how I have hopefully reduced the costs even more from a few hundred to around £80 for future hands and plan to give back to the opensource project.", 1, new DateTimeOffset(new DateTime(2019, 2, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "3D printed Bionic Hand a little IOT and a Xamarin Mobile App", 2779 },
                    { 58138, @"In this talk and with demos we'll cover some more advanced topics within Kubernetes such as:-
                Influencing the scheduling of pods
                Controlling applications being scheduled using admission controllers
                Auto-scaling of applications and clusters
                Options for extending/customising Kubernetes using Custom Resources
                Adding a service mesh to improve traffic shaping
                 
                After this talk attendees should have a much clearer understanding of the additional capability in Kubernetes and associated platforms that they can to use to improve their application platform.
                 
                Attendees should have a good understanding of the basic Kubernetes concepts and constructs.", 1, new DateTimeOffset(new DateTime(2019, 2, 1, 14, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 1, 13, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Kubernetes - going beyond the basics", 2779 },
                    { 68282, @"Communication is the backbone of distributed applications. Imagine you could control that backbone independently of all the components, so your application code just makes simple calls to other services, and your communication backbone does all the complex non-functional work. Load balancing, traffic management, fault tolerance, end-to-end monitoring, dynamic routing and secure communication could all be applied and controlled centrally. That's a service mesh.

                In this session I'll cover the major features of a service mesh using Istio - which is the most popular technology in this space. I'll show you what you can do with a service mesh, how it simplifies application design and also where it adds complexity. My examples will range from new microservices designs to legacy monoliths, and you'll see what a service mesh can bring to different types of application.", 1, new DateTimeOffset(new DateTime(2019, 2, 1, 12, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 1, 11, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Just what is a \"service mesh\", and if I get one will it make everything OK?", 2779 },
                    { 67087, @"
                While Java has grown enormously over the years, the fundamentals have stagnated.

                The motivation for this talk and underlying project, was the following question: why is Java, with it’s 20 years of age, and (at least)6 billion running JVM’s not a major player in the video-game development universe?

                #####TL;DR;
                So everybody knows the Doom games, right? Every new installment brought brand new ideas, and groundbreaking graphics. But more importantly, they brought the source code of the prior installment to the public eye.

                Naturally people have played and hacked the code to oblivion, as much as they played the games themselves. And I have the honor to be one of those people.

                I (naively) endeavored to port the Doom 3 C++ code to the fantabulous Java. In doing so, I hoped to learn, among other things, more about 3D graphics.
                ...what I didn't expect though, was for djoom3(cool name huh!) to teach me more about Java!?

                Aside from the basic game development intro, this talk focuses on the following:
                - Some areas where Java should learn from it's nemesis, C++
                - Other areas where the student(Java) becomes the master(C++)
                - And some promises that were made, but never keptWhile Ja", 1, new DateTimeOffset(new DateTime(2019, 2, 1, 11, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 1, 10, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Fallacies of Doom - Lessons learned from porting Doom 3 to Java", 2779 },
                    { 68009, @"Abstract
                Large frontend projects suffer from all of the same problems of other software projects with the same characteristics:
                Communication and coordination overhead
                Speed of delivery
                Large quantum size
                Low productivity 

                These factors are growing concerns for companies as productivity and speed of delivery is nowadays crucial for success in this competitive landscape

                A common way of solving many of these issues in software projects is the microservices approach.

                Today a similar approach of applying this same pattern to the frontend is being popularized and is commonly nominated as micro-frontends.

                However this approach has many fallacies because of frontend specific characteristics:
                - The performance cost of loading many independent applications
                - The need for a common visual language and experience
                - The browser is a monolithic runtime 

                Description
                This talk will be about the problems of large frontend projects and how to scale them in a way that balances team autonomy with performance and productivity

                I’ll talk about how at farfetch we’re progressively refactoring our frontend to multiple independent applications, and the strategies we’re using to make sure that despite having many applications made by different independent and geographically distributed teams we still can deliver a performant and consistent product to the end user.
                ", 1, new DateTimeOffset(new DateTime(2019, 1, 31, 18, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 31, 17, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Scaling Frontend Development", 2779 },
                    { 66866, @"Want to write a web application? Better get familiar with JavaScript JavaScript has long been the king of front-end. While there have been various attempts to dethrone it, they have typically involved treating JavaScript as an assembly-language analog that you transpile your code to. This has lead to complex build pipelines that result in JavaScript which the browser has to parse and *you* still have to debug. But what if there were an actual byte-code language you could compile your non-JavaScript code to instead? That is what WebAssembly is.

                I'm going to explain how WebAssembly works and how to use it in this talk. I'll cover what it is, how it fits into your application, and how to build and use your own WebAssembly modules. And, I'll demo how to build and use those modules with both Rust and the WebAssembly Text Format. That's right, I'll be live coding in an assembly language. I'll also go over some online resources for other languages and tools that make use of WebAssembly.

                When we're done, you'll have the footing you need to start building applications featuring WebAssembly. So grab a non-JavaScript language, a modern browser, and let's and get started!", 1, new DateTimeOffset(new DateTime(2019, 1, 31, 17, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 31, 16, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "An Introduction to WebAssembly", 2779 },
                    { 66437, @"Learn how .NET Core 3 brings WPF and Windows Forms into the future with a modern runtime. See what’s new for WPF and Windows Forms, learn how to easily retarget your .NET Framework application over to .NET Core, and how to get these modern desktop apps to your users.
                ", 1, new DateTimeOffset(new DateTime(2019, 1, 31, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 31, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "(WPF + WinForms) * .NET Core = Modern Desktop", 2779 },
                    { 65854, @"Think back to a time when you were in a conversation that could have gone better. Perhaps you said something the wrong way, or you walked away from the conversation not fully knowing if the other person even understood what you were trying to convey.

                Technical trainers rely on effective communication as the foundation of everything that we do. We help end users to learn how to use software and adjust to new workflows, through the process of constantly adapting to different backgrounds, skill levels, and learning styles.

                In this session, you’ll learn actionable strategies to begin thinking like a trainer, including:

                - Using active listening techniques to communicate with empathy.

                - Best practices for explaining technical concepts in non-technical terms.

                - Adjusting your communication approach for different communication styles.

                - Using problem solving skills to help you get unstuck during difficult conversations.", 1, new DateTimeOffset(new DateTime(2019, 1, 31, 14, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 31, 13, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Think Like a Trainer: Improving Your Communication Skills", 2779 },
                    { 67079, @"One common practice to write maintainable code is to minimise repetition, often referred to as DRY or Don't Repeat Yourself.

                However, have you ever considered how much you repeat yourself when you create a new .NET application? 

                You've found your ideal architecture and folder structure and now every time you create a new project you have to create the file structure then add all the different project types you need.

                Don't forget all those NuGet dependencies too and the boilerplate code from other projects you
                continually copy in. 

                In this talk you'll learn the different ways you can create custom templates for .NET projects using the dotnet CLI, Visual Studio templates and Yeoman, helping to reduce repetition, write better applications, apply incremental improvements, all whilst saving you time and effort. ", 1, new DateTimeOffset(new DateTime(2019, 1, 31, 12, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 31, 11, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Keeping it DRYer with Templates", 2779 },
                    { 68678, @"Recent technologies are enabling a host of new scenarios for doing data collection and analytics much closer to the source, at the ""edge"" so to speak. 

                How can using Artificial Intelligence in a cheap device the size of a matchbox change the way you do things? What kind of scenarios does this open up for business owners, enabling new opportunities for you and your company? What are the actual benefits for connecting the cloud and the edge in this way? 

                I'll give you some examples and demonstrate how Edge Computing can enable new scenarios and new business.
                ", 1, new DateTimeOffset(new DateTime(2019, 1, 31, 11, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 31, 10, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Why should you care about edge computing?", 2779 },
                    { 68607, @"At some point in your life, you start realizing that re-inventing the wheel isn't the best way to spend your time. Especially since Bob Wheel Sr. perfected that invention many, many years ago. And it's the same with software. Smart people have already encountered a lot of the problems that we face every day while building software. Some of them have even been nice enough to write down their solutions in so called ""patterns"". So why not stand on the shoulders of...well...maybe not giants...but at least very smart people who were born before you, and build on top of their hard-earned wisdom?
                This session, will walk you through a bunch of really useful patterns, and you'll not only learn their names, but also why they are useful and how to implement them in .NET. And maybe, just maybe, you'll even see that one pattern that solves that problem you are working on at the moment. But even if you don't see that one pattern that you need, you will at least get a few that you can store in your toolbelt for future problems.
                ", 1, new DateTimeOffset(new DateTime(2019, 1, 31, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 31, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Let’s talk patterns", 2779 },
                    { 69253, @"Integrate, Extend, Embed!

                In this session, you will learn how developers can deliver real-time dashboards, create custom visuals and embed rich interactive analytics in their apps with Power BI. This presentation specifically targets experienced app developers, and also those curious to understand what developers can achieve with Power BI. Numerous demonstrations will put the theory into action.", 1, new DateTimeOffset(new DateTime(2019, 1, 30, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 30, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Power BI for Developers", 2779 },
                    { 69231, @"It's nearly here! The Visual Studio 2019 Preview is already available, so if you haven't looked into what's coming in C# 8, now is the perfect time to do so.
                The most important feature of C# 8 is undoubtedly nullable reference types, but there's plenty more to look forward to as well.

                While I'll make this talk as easy to understand as I can, there's a huge amount to cover. Expect a fast pace, with lots of code.", 1, new DateTimeOffset(new DateTime(2019, 2, 1, 11, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 1, 10, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "C# 8", 2777 },
                    { 69228, @"Dungeons & Dragons, or D&D, is the grand-daddy of all role playing games. While playing D&D is great fun, the rules are a bit daunting for the beginner. The basic rulebook, the PHB, clocks in at a solid 300 pages, and can be extended with multiple additional rule sets. This should come as no surprise to software engineers: this is, after all, documentation for a system that models a complex domain, and has been in use for over 40 years now, going through numerous redesigns over time.

                As such, D&D rules make for a great exercise in domain modelling. In this talk, I will take you along my journey attempting to tame that monster. We will use no magic, but a weapon imbued with great power, F#; practical tips and tricks for the Adventurer on the functional road will be shared. So... roll 20 for initiative, and join us for an epic adventure in domain modeling with F#!", 1, new DateTimeOffset(new DateTime(2019, 1, 31, 18, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 31, 17, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Dungeons, Dragons and Functions", 2777 },
                    { 57812, @"In recent years there has been a shift in the way websites and mobile apps are being built - moving to architectures with immutable models and virtual UIs - based on the MVU (model-view-update) pattern. This has lead to great new frameworks like ELM and React for web, and ReactNative for mobile.

                Now there is a new MVU framework for building mobile apps - Fabulous. It's a community-driven open source framework, combining the simplicity of an MVU framework, with 100% native API access for both iOS and Android, all built with using an established, world class, battle-hardened functional programming language.

                This session will start with an overview of MVU, discussing how it works and why it is such a great architecture. It will then move on to building your first Fabulous app that runs on iOS and Android. Next up more features will be added to the app whilst the app is running on a device, showing the hot reload capabilities of Fabulous for both UI and app logic. Finally it will look at the underlying architecture, see how to use all of the iOS and Android APIs, see how to easily use native components such as cocoa pods or jars, and look at the massive range of libraries that this framework as available to it to do all manner of UI and application logic things. We'll even see how to use it on macOS and Windows, including being able to build iOS apps on Windows (with the help of a networked Mac, Apple licensing rules and whatnot).

                When looking at naming for this framework, someone suggested Fabulous. By the end of this session you will see why that name stuck.", 1, new DateTimeOffset(new DateTime(2019, 1, 31, 17, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 31, 16, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Build cross-platform mobile apps using Fabulous", 2777 },
                    { 68939, "Using protocols like OpenID Connect and OAuth 2 for authentication and API access can on one hand simply your front-ends dramatically since they don’t have to deal with credentials anymore – but on the other hand introduces new challenges like choosing the right protocol flow for the given client, secure token storage as well as token lifetime management. This talk gives an overview over the best practices how to solve the above problems for both native server and client-side applications as well as browser-based applications and SPAs.", 1, new DateTimeOffset(new DateTime(2019, 1, 30, 14, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 30, 13, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Building Clients for OpenID Connect/OAuth 2-based Systems", 2776 },
                    { 68938, "ASP.NET Core and MVC is a mature and modern platform to build secure web applications and APIs for a while now. Starting with version 2.2, Microsoft makes big investments in the areas of standards-based authentication, single sign-on and API security by including the popular open source project IdentityServer4 in the project templates. This talk gives an overview over the various security features in ASP.NET Core but focuses in particular on the API security scenarios enabled by IdentityServer.", 1, new DateTimeOffset(new DateTime(2019, 1, 30, 12, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 30, 11, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Securing Web Applications and APIs with ASP.NET Core 2.2 and 3.0", 2776 },
                    { 69170, @"Another new version of ASP.NET Core is here and it brings new capabilities, making it easier than ever to build and consume APIs. But there's also some hidden gems in the framework that aren't well known that you should definitely know about! 

                Damian and David from the ASP.NET Core team are back to show you the new features plus their favourite, little-known features that don't get enough attention but will make your lives easier.", 1, new DateTimeOffset(new DateTime(2019, 1, 30, 11, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 30, 10, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "What you need to know about ASP.NET Core 2.2", 2776 },
                    { 66952, @"2019 is the 30th anniversary of my first job in tech. On my first day I was given a Wyse 60 terminal attached via RS232 cables to a Tandon 286, and told to learn C from a dead tree so I could write text applications for an 80x24 character screen. Fast-forward to now: my phone is about a million times more powerful than that Tandon; screens are 3840x2160 pixels; every computer in the world is attached to every other thing with no cables; and we code using, well, still basically C.

                Having lived through all those changes in realtime, and as an incurable neophile, I think I can make an educated guess as to what the next 30 years are going to be like, and what we're all going to be doing by 2049. If anything, I'm going to underestimate it, but hopefully you'll be inspired, invigorated and maybe even informed about the future of your career in tech.", 1, new DateTimeOffset(new DateTime(2019, 2, 1, 17, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 1, 16, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Futurology for Dummies - the Next 30 Years in Tech", 2775 },
                    { 69010, @"With the launch of the Reporting API any browser that visits your site can automatically detect and alert you to a whole heap of problems with your application. DNS not resolving? Serving an invalid certificate? Got a redirect loop, using a soon to be deprecated API or any one of countless other problems, they can all be detected and reported with no user action, no agents, no code to deploy. You have one of the most extensive and powerful monitoring platforms in existence at your disposal, millions of browsers. Let's look at how to use them.

                In this talk we'll look at how to configure the browser to send you reports when things go wrong. These are brand new capabilities the likes of which we've haven't seen before and they're already supported in the world's most popular browser, Google Chrome. We'll look at how to receive reports and how to make use of them after having the browser do the hard work.", 1, new DateTimeOffset(new DateTime(2019, 2, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Crash, Burn, Report", 2775 },
                    { 69233, @"Scott has been a Type 1 diabetic for over 20 years. When he first became diabetic he did what every engineer would do...he wrote an app to solve his problem. Fast forward to 2018 and Scott lives 24 hours a day connected to an open source artificial pancreas. After years of waiting, the diabetes community online creating solutions.

                Scott will go through the history of diabetes online, the components (both hardware and software) needed for an artificial pancreas, and discuss the architectural design of two popular systems (LoopKit and OpenAPS). Plus, you'll see Scott *not die* live on stage as he's been ""looping"" for over a year!", 1, new DateTimeOffset(new DateTime(2019, 2, 1, 14, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 1, 13, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Solving Diabetes with an Open Source Artificial Pancreas", 2775 },
                    { 68521, @"Have you ever stopped to think about all the things that happen when you execute a simple .NET program?

                This talk will delve into the internals of the recently open-sourced .NET Core runtime, looking at what happens, when it happens and why. 

                Making use of freely available tools such as 'PerfView', we'll examine the Execution Engine, Type Loader, Just-in-Time (JIT) Compiler and the CLR Hosting API to see how all these components play a part in making 'Hello World' possible.", 1, new DateTimeOffset(new DateTime(2019, 2, 1, 12, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 1, 11, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "From 'dotnet run' to 'Hello World!'", 2775 },
                    { 69004, @"This talk attempts to answer a pair of frequently asked questions, the first one of which is: how do I combine dependency injection with async and await in C# without leaky abstractions?

                It turns out that the answer to that question can be found by answering another frequently asked question:  how do I get the value out of my monad?

                During the talk, you’ll get a quick and easy-to-understand explanation of monads.

                All code examples will be in C#.", 1, new DateTimeOffset(new DateTime(2019, 2, 1, 11, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 1, 10, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Async injection", 2775 },
                    { 69232, @"Phase 1 is nearly complete with open source .NET Core. What does Microsoft's Open Source plan look like for the next 10 years?

                Join Scott Hanselman as he compares the MCU (Marvel Cinematic Universe) to the MSFTOSSCU and talks about what a next phase MIGHT look like.", 1, new DateTimeOffset(new DateTime(2019, 2, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Keynote: The Microsoft Open Source Cinematic Universe - Phase 2", 2775 },
                    { 63671, @"In the world of microservices (yes, there's that buzzword again!) and distributed systems, we often find ourselves communicating over HTTP. What seems like a simple requirement can quickly become complicated! Networks aren't reliable and services fail. Dealing with those inevitable facts and avoiding a cascading failure can be quite a challenge. In this talk, Steve will explore how we can build .NET Core applications that make HTTP requests and rely on downstream services, whilst remaining resilient and fault tolerant.

                This session will focus on some of the improvements which have been released in .NET Core and ASP.NET Core 2.1, such as IHttpClientFactory and the new, more performant SocketHttpHandler. Steve will identify some HTTP anti-patterns and common mistakes and demonstrate how we can refactor existing code to use the new HttpClientFactory features.

                Next, Steve will demonstrate other HTTP tips and tricking, including Polly; a fantastic resilience and transient fault handling library which can be used to make your applications less prone to failure. When integrated with the Microsoft IHttpClientFactory; wrapping your HTTP calls in retries, timeouts and circuit-breakers has never been easier!

                If you're building services which make HTTP calls, then this talk is for you!", 1, new DateTimeOffset(new DateTime(2019, 1, 31, 18, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 31, 17, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Let's Talk HTTP in .NET Core", 2775 },
                    { 66795, @".NET has a new mechanism for generating and storing diagnostic data: DiagnosticSource. This is the cross-platform alternative to ETW. Much of ASP.NET Core and EF Core produce useful metric data using DiagnosticSource, and you can produce your own and stream some or all of the data to the metrics storage of your choice.

                In this talk I'll run through how DiagnosticSource works, show you how to use it to output your own metrics in any .NET application, and how to pipe those metrics to a Time-Series database and turn them into a lovely Grafana dashboard.

                You can use DiagnosticSource in anything from an ASP.NET Core cloud-native microservice to a WPF desktop application, and it's a Microsoft package with no 3rd-party dependencies, so this talk should be interesting and useful for any .NET developer.", 1, new DateTimeOffset(new DateTime(2019, 1, 31, 17, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 31, 16, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "DiagnosticSourcery 101", 2775 },
                    { 69345, "C# 8.0 is coming up! Not just nullable reference types and asynchronous streams, which will get much coverage elsewhere in the conference, but also recursive patterns, switch expressions, ranges, default interface member implementations and more. We’ll look at all of those, and also at some of the things being worked on for future versions of the language.", 1, new DateTimeOffset(new DateTime(2019, 1, 31, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 31, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Where is C# headed?", 2775 },
                    { 69052, @"Today, nearly all browser-based apps are written in JavaScript (or similar languages that transpile to it). That’s fine, but there’s no good reason to limit our industry to basically one language when so many powerful and mature alternate languages and programming platforms exist. Starting now, WebAssembly opens the floodgates to new choices, and one of the first realistic options may be .NET.
                 
                Blazor is a new experimental web UI framework from the ASP.NET team that aims to brings .NET applications into all browsers (including mobile) via WebAssembly. It allows you to build true full-stack .NET applications, sharing code across server and client, with no need for transpilation or plugins.
                 
                In this talk I’ll demonstrate what you can do with Blazor today and how it works on the underlying WebAssembly runtime behind the scenes. You’ll see its modern, component-based architecture (inspired by modern SPA frameworks) at work as we use it to build a responsive client-side UI. I’ll cover both basic and advanced scenarios using Blazor’s components, router, DI system, JavaScript interop, and more.", 1, new DateTimeOffset(new DateTime(2019, 1, 31, 14, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 31, 13, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Blazor, a new framework for browser-based .NET apps", 2775 },
                    { 68994, @"When I started in IT the roles were clearly separated. Business Analysts wrote requirements, Architects designed them, Programmers wrote the code, Testers tested the software.

                Over the last decade or so we have seen a shift towards “generalising specialists” who can cut code, understand a business domain, design a user interface, participate in and automate some of the testing and deployment activities, and who are sometimes even responsible for the health and wellbeing of their own systems in production.

                To succeed in this new world requires more than “3 years of Java”. The modern developer needs to be constantly reinventing themselves, learning, and helping others to do the same. In this session, Dan explores some of the skills and characteristics of the modern developer, and suggests some ways you can grow them for yourself.", 1, new DateTimeOffset(new DateTime(2019, 1, 31, 12, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 31, 11, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Beyond Developer", 2775 },
                    { 69344, @"Throw a line of code into many codebases and it's sure to hit one or more testing frameworks. There's no shortage of frameworks for testing, each with their particular spin and set of conventions, but that glut is not always matched by a clear vision of how to structure and use tests — a framework is a vehicle, but you still need to know how to drive.

                This talk takes a deep dive into testing, with a strong focus on unit testing, looking at examples and counterexamples in different languages and frameworks, from naming to nesting, exploring the benefits of data-driven testing, the trade-offs between example-based and property-based testing, how to get the most out of the common given–when–then refrain and knowing how far to follow it.", 1, new DateTimeOffset(new DateTime(2019, 1, 31, 11, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 31, 10, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Structure and Interpretation of Test Cases", 2775 },
                    { 69333, @"The Internet existed before the Web, but the Web redefined the Internet - what started out as a protocol for helping scientists share documents and references has turned into one of the most important forces in the 21st century. But how did we get here?

                Join Richard Campbell as he tells the story of the World Wide Web and the web development tools and techniques that made it all possible. From the early versions of HTML where you laid out web pages with tables (GeoCities anyone?) and simple scripting languages to CSS, JavaScript and HTML 5, leading to Single Page Applications, Progressive Web Apps and Web Assembly! We've come a long way, and the story is continuing!", 1, new DateTimeOffset(new DateTime(2019, 1, 31, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 31, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "How We Got Here - The History of Web Development", 2775 },
                    { 69174, @"Infosec is a continual game of one-upmanship; we build a defence and someone breaks it so we build another one then they break that and the cycle continues. Because of this, the security controls we have at our disposal are rapidly changing and the ones we used yesterday are very often useless today.

                This talk focuses on what the threats look like *today*. What are we getting wrong, how do we fix it and how do we stay on top in an environment which will be different again tomorrow to what it is today. It's a real-world look at modern defences that everyone building online applications will want to see.", 1, new DateTimeOffset(new DateTime(2019, 1, 30, 18, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 30, 17, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Hack to the Future", 2775 },
                    { 68804, @"Over a decade ago, Pat Helland authored his paper, ""Life Beyond Distributed Transactions: An Apostate's Opinion"" describing a means to coordinate activities between entities in databases when a transaction encompassing those entities wasn't feasible or possible. While the paper and subsequent talks provided great insight in the challenges of coordinating activities across entities in a single database, implementations were left as an exercise to the reader!

                Fast forward to today, and now we have NoSQL databases, microservices, message queues and brokers, HTTP web services and more that don't (and shouldn't) support any kind of distributed transaction.

                In this session, we'll look at how to implement coordination between non-transactional resources using Pat's paper as a guide, with examples in Azure Cosmos DB, Azure Service Bus, and Azure SQL Server. We'll look at a real-world example where a codebase assumed everything would be transactional and always succeed, but production proved us wrong! Finally, we'll look at advanced coordination workflows such as Sagas to achieve robust, scalable coordination across the enterprise.", 1, new DateTimeOffset(new DateTime(2019, 1, 30, 17, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 30, 16, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Life Beyond Distributed Transactions: An Apostate's Implementation", 2775 },
                    { 69301, @"A deep dive into some of the technical challenges and solutions to securing a microservice architecture.

                Microservices are great, and they offer us lots of options for how we can build, scale and evolve our applications. On the face of it, they should also help us create much more secure applications - the ability to protect in depth is a key part of protecting systems, and microservices make this much easier. On the other hand, information that used to flow within single processes, now flows over our networks, giving us a real headache. How do we make sure our shiny new microservices architectures aren’t less secure than their monolithic predecessor.

                In this talk, I outline some of the key challenges associated with microservice architectures with respect to security, and then looks at approaches to address these issues. From secret stores, time-limited credentials and better backups, to confused deputy problems, JWT tokens and service meshes, this talk looks at the state of the art for building secure microservice architectures.", 1, new DateTimeOffset(new DateTime(2019, 1, 30, 14, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 30, 13, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Insecure Transit - Microservice Security", 2775 },
                    { 66592, @"Resolve that tension by learning to love that strategic shift and put the new understanding into practice.

                Learn how nullable reference types affects your design decisions and how you express those decisions. Learn how to migrate an existing code base by discovering the original intent and expressing that intent in new syntax. The exciting conclusion to a world without null.", 1, new DateTimeOffset(new DateTime(2019, 1, 30, 12, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 30, 11, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Much Ado about Nothing: A C# play in two acts. Act 2, starring Bill Wagner", 2775 },
                    { 66591, @"Understand the history and motivation behind introducing nullable types into an existing language.
                This opening act is a deep design dive where you see the twists and turns of designing such a major feature that introduces potentially breaking changes into mountains of existing code. The stage is set for a major strategic shift in how you write C# code.", 1, new DateTimeOffset(new DateTime(2019, 1, 30, 11, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 30, 10, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Much Ado about Nothing: A C# play in two acts - Act 1, starring Mads Torgersen", 2775 },
                    { 66448, "Together for C#, F# will be incorporating nullability as a concept for .NET reference types. From the F# perspective, this fits with the default non-nullness of other F# types. But compatibility with existing code makes designing this a wild ride indeed! In this talk, we'll briefly explain what nullability means for F#, some existing mitigations for null in the language, and how we must consider compatibility with everything in mind. This deep dive into language design should give you an idea about what it is like designing a nontrivial feature that improves existing code while remaining compatible with it.", 1, new DateTimeOffset(new DateTime(2019, 1, 30, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 30, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Designing Nullable Reference Types in F#", 2776 },
                    { 68940, @"We are entering an incredible new era of digital product development where users expect a seamless experience across all of their touchable, wearable, and voice-activated devices. How can we learn to develop software effectively in this new digital-by-default world? 

                What if the answers are hidden away as secret messages in a 15 year old book?  

                Are bounded contexts really used to design loosely coupled code, or are they one of the most powerful organisation design tools used to enable autonomous, self-organising teams? Are core domains just academic jargon that get in the way of shiny technical practices like event sourcing, or is understanding business core domains one of the key differentiators between high-performing delivery teams and the rest of us?

                Let’s go on an adventure and see if the big blue big and can help us in this brave new world.", 1, new DateTimeOffset(new DateTime(2019, 1, 30, 17, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 30, 16, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Domain-Driven Design: Hidden Lessons from the Big Blue Book", 2776 },
                    { 61516, @"Panel discussion with four experts in the field on the current state of the art and the where .NET and related technologies are heading.

                We will discuss cross platform development, new features, performance, versioning issues of .NET Core, what’s going to happen with full framework, Blazor, how .NET stands up against competing technologies and where it is all going. 

                You won't cram more info into a session than this, come spend a great hour with us.", 1, new DateTimeOffset(new DateTime(2019, 1, 30, 18, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 30, 17, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Panel discussion on the future of .NET", 2776 },
                    { 69266, @"4 years ago I had a vague idea about Big-O notation and absolutely no clue about combinatorial problems. I knew what a SHA256 hash was (sort of) but I didn't know how it was created, nor that it didn't completely protect some of my data. I knew these things were important, but I never understood how they could apply to the types of applications I was building at the time. All of this changed as I put together the first two volumes of The Imposter's Handbook.

                I get to build a lot of fun things in my new position at Microsoft and I've been surprised at how often I use the things I've learned. Avoiding an obvious performance pitfall with Redis, for instance, because I understood the Big-O implications of the data structure I chose. Going back to ensure that a salt was added to a hash which stored sensitive data for an old client and, most importantly, discouraging a friend from trying to solve a problem that was very clearly NP-Complete.

                In this talk I'll show you some of the fun things I've learned (like mod(%) and remainder being different things) and how I've applied them to the applications I create for my day job. You might know some of these concepts, or maybe you don't - either way: hopefully you'll leave with a few more tools under your belt to help you do your job better.has grown exponentially over the years, in both market size and developer frustration.
                 
                In this talk I will walk you through my first few months as an Azure Cloud Developer Engineer, tasked with getting to know Azure, from scratch, while building compelling applications with it. My job is two-fold: I get to show you why Azure is interesting and I then get to tell the Azure product team why it's not. This can be stressful. It can also be quite fun. I'll show you what I've come up with and then you get to decide.", 1, new DateTimeOffset(new DateTime(2019, 1, 31, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 31, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "CompSci and My Day Job", 2776 },
                    { 56795, @"You can be faced with a nightmare of Xcode, Android Studio, Swift, Objective C, Swift and other options. This means not only learning multiple languages and frameworks but also having to support two different codebases for the same application. But Xamarin Native and Xamarin.Forms offer a powerful, cross-platform development solution for .NET developers looking to target smartphones, tablets, TV’s, computers and IoT devices.

                In this talk, Luce shares what Xamarin is including Native and Xamarin.Forms for both C# and F#, how to get started creating a simple HelloWorld app from scratch and a more complex example (will involve at least one Azure service including Cognitive Services for facial recognition). Also how to use Visual Studio Team Services for Continuous Integration and some awesome examples of apps written using Xamarin including ones used to save lives!

                Luce will take examples from xamarin.com/customers as well as show this demo about how Xamarin was used alongside other technologies to aid with Skin Cancer prediction.

                This talk will include slides, demos, code samples, live coding and the audience will walk away feeling like they too can create a mobile app in just a few minutes and carry their work around with them in their pocket or backpack!", 1, new DateTimeOffset(new DateTime(2019, 1, 31, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 31, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Zero to Mobile Hero - Intro to Xamarin and Visual Studio Team Services", 2777 },
                    { 61211, @"It’s a great time to be in technology. And yet despite the almost constant improvement in our tools, we somehow don’t spend time talking about how to maintain our most important tool - the one between our ears.

                Constantly feeling worn down, experiencing anxiety over making decisions, and burning out are *not* just facts of a developer’s life! They’re challenges that can be dealt with. In this talk we’ll cover the most common mental health challenges facing developers, and then learn about some techniques to supercharge your brain by improving your mental hygiene (whether you have a psychological disorder or not). Most importantly, you’ll learn how to have a conversation with your coworkers (and other people in your life) about supporting each other and finding your best selves.
                ", 1, new DateTimeOffset(new DateTime(2019, 1, 31, 14, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 31, 13, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Let’s Talk About Mental Health", 2777 },
                    { 67996, @"The SAFE stack is an open source stack of libraries and tools which simplify the process of building type safe web applications which run on the cloud almost entirely in F#. 

                In this talk we'll explore the components of the SAFE stack and how they can be used to write web services and web sites in idiomatic F#. We'll see how we can manage this without needing to compromise and use object oriented frameworks whilst also still integrating with the existing ASP.Net, JavaScript and React ecosystems. We'll consider how we can write backend applications using Saturn on top of ASP.Net, we'll look at how to run F# in the web browser with Fable and we'll cover how we can develop interactive web applications leveraging the benefits of functional programming. This talk is aimed at developers who are looking to understand how they can use F# to effectively build full stack web applications.", 1, new DateTimeOffset(new DateTime(2019, 1, 31, 12, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 31, 11, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Functional Web Programming in .Net with the SAFE Stack", 2777 },
                    { 67965, "When you build a serverless app, you either tie yourself to a cloud provider, or you end up building your own serverless stack. Knative provides a better choice. Knative extends Kubernetes to provide a set of middleware components (build, serving, events) for modern, source-centric, and container-based apps that can run anywhere. In this talk, we’ll see how we can use Knative primitives to build a serverless app that utilizes the Machine Learning magic of the cloud.   ", 1, new DateTimeOffset(new DateTime(2019, 1, 31, 11, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 31, 10, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Serverless with Knative", 2777 },
                    { 68887, "The “out of the box” template has some lowest common denominator / simplicity tradeoffs that make it easy to understand and work with in a variety of scenarios, but there are lots of performance and deployment tweaks that experienced developers should make before deploying. If you had one hour to tweak a new project, what would you do? I'll include some top open source libraries, best practices from ASP.NET Community Standup links, recommendations from the ASP.NET Core team, etc.", 1, new DateTimeOffset(new DateTime(2019, 1, 31, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 31, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "ASP.NET Core: The One Hour Makeover", 2777 },
                    { 62178, "We have traditionally built robust software systems by trying to avoid mistakes and by dodging failures when they occur in production or by testing parts of the system in isolation from one another. Modern methods and techniques take a very different approach based on resiliency, which promotes embracing failure instead of trying to avoid it. Resilient architectures enhance observability, leverage well-known patterns such as graceful degradation, timeouts and circuit breakers and embrace chaos engineering, a discipline that promotes breaking things on purpose in order to learn how to build more resilient systems. In this session, will review the most useful patterns for building resilient software systems and I will introduce chaos engineering methodology and especially show the audience how they can benefit from breaking things on purpose.", 1, new DateTimeOffset(new DateTime(2019, 1, 30, 18, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 30, 17, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Patterns for Resilient Architecture", 2777 },
                    { 68493, "By 2020, there will be 4 times more devices connected to the Internet around the world. While technology impacts our everyday life in almost every way, the solutions we create fails to reflect our society or the world we live in. Instead, they often reinforce stereotypes, prejudice, and differences. In this talk, we will look into the lack of diversity and how diversity will make us more suited to solve problems and meet the needs of our society. We will address the culture in our communities, the reasons why minorities quit, and the importance of diversity in tech.", 1, new DateTimeOffset(new DateTime(2019, 1, 30, 17, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 30, 16, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "The tech future is diverse", 2777 },
                    { 68734, @"For almost a decade ""Infrastructure as Code"" has been a DevOps buzzword - but the myriad tools in share a dirty little secret... there's no actual code! Few people like ""programming"" YAML or JSON (even the human-friendly variants!), and even fewer like having to reverse-engineer ways to apply known good development practices to tools which resist it at all cost.

                So, what if things were different,and programming infrastructure was more like real programming, with real programming languages like TypeScript? What if you defined Lambda functions by actually writing lambdas, created abstractions using complex types, and could take advantage of existing tools for modularity, linting, refactoring and testing?

                Enter Pulumi, an open-source deployment engine which enables all these things using TypeScript, Python or Go!

                In this talk, we'll look at how you can write TypeScript code using Pulumi to provision traditional cloud infrastructure, manage Kubernetes and build portable ""serverless"" applications - all with minimal YAML in sight! We'll look at deploying to multiple regions of the same cloud, and how to build abstractions allowing multi-cloud to be a reality.", 1, new DateTimeOffset(new DateTime(2019, 1, 30, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 30, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Infrastructure as TypeScript", 2777 },
                    { 58654, "Icons have been a staple of software for decades, and come in as many varieties as the tools used to make them. From humble beginnings as precisely-pixelated pictograms, icons are now entering a renaissance of high-density displays, vector formats, and an almost cult-like following. In this session, you'll learn the inner workings of modern icon design, explore various techniques for adding symbology to your web apps, and discover how to bring your interfaces into the modern age!", 1, new DateTimeOffset(new DateTime(2019, 1, 30, 14, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 30, 13, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Icons and the Web: Symbols of the Modern Age", 2777 },
                    { 68745, @"As more and more developers move to distributed architectures such as micro services, distributed actor systems, and so forth it becomes increasingly complex to understand, debug, and diagnose.

                In this talk we're going to introduce the emerging OpenTracing standard and talk about how you can instrument your applications to help visualize every operation, even across process and service boundaries. We'll also introduce Zipkin, one of the most popular implementations of the OpenTracing standard. ", 1, new DateTimeOffset(new DateTime(2019, 1, 30, 12, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 30, 11, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Distributed Tracing: How the Pros Debug Concurrent and Distributed Systems", 2777 },
                    { 69938, @"The prominent trends in software a distributed programs powered by cooperating microservices, each operating independently. These distributed systems are asynchronous by their very nature. You will use asynchronous programming paradigms to build these systesms.

                In this session, you'll see the most common mistakes developers make using async and await in C#. You'll see the practices you should use instead. This session also provides a deep dive into async streams, a new feature introduced in C# 8.

                You're building asynchronous programs now. Make sure you're building them for the future.", 1, new DateTimeOffset(new DateTime(2019, 2, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "The promise of an async future awaits", 2780 },
                    { 68546, @"Historically, monitoring has been thought of as an afterthought of the software development cycle: something owned by the ops side of the room. But instead of trying to predict the various ways something might go sideways right before release and crafting dashboards to prepare, what might it look like to use answers about our system to figure out what to build, and how to build it, and whom for?

                Observability is the practice of understanding the internal state of a system via knowledge of its external outputs -- and is something that should be built into the process of crafting software from the very beginning.

                In this talk, we'll discuss what this might look like in practice by using Honeycomb as a case study: how we rely on visibility into our system to inform planning during the development process, to observe the impact of new changes during and after release, and, of course, debug. We'll start by describing the problems faced by a SaaS platform like ours, then run through some specific instrumentation practices that we love and have used successfully to gain the visibility we need into our system’s day-to-day operations.", 1, new DateTimeOffset(new DateTime(2019, 1, 30, 11, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 30, 10, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Observability and the Development Process", 2777 },
                    { 69307, "In data science, sometimes you stumble across an intriguing property in the data. I will tell you a story of a mysterious correlation - from the StackOverflow developer survey it seems that developers who use spaces have higher salaries than those who use tabs. Correlation doesn't mean causation: using spaces won't suddenly increase your salary. But what does it all mean? Follow me into a detective investigation that will show you how to approach complex data science problems. I will show you some of the perils of correlation, model fitting and biases - how they can be dangerous and how to avoid these traps. And you'll also find how profitable your indentation style really is.", 1, new DateTimeOffset(new DateTime(2019, 2, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Tabs, spaces and salaries: a data science detective story", 2776 },
                    { 69230, @"Software engineers are fond of casually mentioning how their work changes the world. But have you thought about what you want the world to look like after you've changed it? Do you want to smash the patriarchy [1]? Save the planet? Make Furbies cool again? Is technology really the only tool at your disposal?
                This session is a call to both discovery and action. You already care about Furbies, but what do you not know you don't know about them? Have you looked at Furbies from someone else's perspective? Once your eyes are wide open, what's the next step? How would a Furby smash the patriarchy? Let's learn to be better together, and make a difference in the world today.

                Footnote 1: Our system of society norms which puts everyone in boxes that are hard to escape [2]. The boxes surrounding straight white men can be extremely comfortable ones, but more limiting than you might realize.

                Footnote 2: Furbies are pretty easy to get out of boxes; humans, not so much.", 1, new DateTimeOffset(new DateTime(2019, 2, 1, 14, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 1, 13, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Society (n+1).0: smashing the patriarchy and other ways of changing the world", 2776 },
                    { 67993, @"The functional programming community has a number of patterns with strange names such as monads, monoids, functors, and catamorphisms.
                 
                In this beginner-friendly talk, we'll demystify these techniques and see how they all fit together into a small but versatile ""tool kit"". 

                We'll then see how the tools in this tool kit can be applied to a wide variety of programming problems, such as handling missing data, working with lists, and implementing the functional equivalent of dependency injection. ", 1, new DateTimeOffset(new DateTime(2019, 2, 1, 12, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 1, 11, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "The Functional Programmer's Toolkit", 2776 },
                    { 69239, @"The world runs on legacy code. For every greenfield progressive web app with 100% test coverage, there are literally hundreds of archaic line-of-business applications running in production - systems with no tests, no documentation, built using out-of-date tools, languages and platforms. It’s the code developers love to hate: it’s not exciting, it’s not shiny, and it won’t look good on your CV - but the world runs on legacy code, and, as developers, if we’re going to work on anything that actually matters, we’re going to end up dealing with legacy. To work effectively with this kind of system, we need to answer some fundamental questions: why was it built this way in the first place? What's happened over the years it's been running in production? And, most importantly, how can we develop our understanding of legacy codebases to the point where we're confident that we can add features, fix bugs and improve performance without making things worse?

                Dylan worked on the web application stack at Spotlight (www.spotlight.com) from 2000 until 2018 - first as a supplier, then as webmaster, then as systems architect. Working on the same codebase for nearly two decades has given him an unusual perspective on how applications go from being cutting-edge to being 'legacy'. In this talk, he'll share tips, patterns and techniques that he's learned from helping new developers work with a large and unfamiliar codebase. We'll talk about virtualisation, refactoring tools, and how to bring legacy code under control using continuous integration and managed deployments. We'll explore creative ways to use common technologies like DNS to create more productive development environments. We'll talk about how to bridge the gap between automated testing and systems monitoring, how to improve visibility and transparency of your production systems - and why good old Ctrl-Alt-Del might be the secret to unlocking the potential of your legacy codebase.", 1, new DateTimeOffset(new DateTime(2019, 2, 1, 11, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 1, 10, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Ctrl-Alt-Del: Learning to Love Legacy Code", 2776 },
                    { 69332, @"Join Carl and Richard from .NET Rocks as they chat with Christine Yen from Honeycomb about how you select features to build in your applications.

                After the first version of software is out the door, what do you choose nest? Christine has a background in instrumenting applications to understand what people use – is that the best way to pick features? What about the vision of your own designers? What about asking the users? Bring your questions and come to this live recording of .NET Rocks!", 1, new DateTimeOffset(new DateTime(2019, 1, 31, 18, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 31, 17, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), ".NET Rocks Live on Software Feature Selection with Christine Yen", 2776 },
                    { 68608, @"Machine Learning is one of the fastest growing areas of computer science, and Deep Learning (neural networks) is growing even faster, with lots of data and computing power at our fingertips. 
                This talk is a practical (very little math) guide to computer vision and deep learning.

                We will look at a deep learning project from start to finish, look at how to program and train a neural network and gradually refine it using some tips and tricks that you can steal for your future deep learning projects.", 1, new DateTimeOffset(new DateTime(2019, 1, 31, 17, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 31, 16, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "A practical guide to deep learning", 2776 },
                    { 68814, @"When you design and build applications at scale, you deal with two significant challenges: scalability & robustness. You should design your service so that even if it is subject to intermittent heavy loads, it continues to operate reliably. But how do you build such applications? And how do you deploy an application that scales dynamically? Kubernetes has a feature called autoscaler where instances of your applications are increased or decreased automatically based on metrics that you define.

                In this talk, you’ll learn how to design, package & deploy reliable .NET applications to Kubernetes & decouple several components using a message broker. You will also learn how to set autoscaling rules to cope with an increasing influx of messages in the queue.", 1, new DateTimeOffset(new DateTime(2019, 1, 31, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 31, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Scaling microservices with Message queues, .NET and Kubernetes", 2776 },
                    { 69240, @"On July 20th, 1969, Neil Armstrong and Buzz Aldrin became the first humans to set foot on another world. Billions of people tuned in live to watch Apollo 11 land on the moon, but behind Armstrong’s ‘one small step’ lay a decade of astonishing innovation. The Apollo programme wasn’t just about aerospace engineering; it was also responsible for revolutionary new approaches in project management and quality control; new ways of thinking about testing strategies and communications - not to mention delivering a completely bespoke set of hardware and software components that would play a vital role at every stage of the programme.

                As we celebrate the fiftieth anniversary of the moon landings, let’s take a look back at the technology, processes and practises behind the Apollo programme - and how many of those techniques are still relevant today. What is ‘all-up testing’, and how does it apply to modern software development? Who was the CAPCOM - and what can they teach us about product ownership? How do you manage a distributed team of nearly half a million people? How do you manage scope creep when you’re working to a hard deadline with the whole world watching you? And how DO you fly to the moon and back using a computer with less processing power than an Apple II?", 1, new DateTimeOffset(new DateTime(2019, 1, 31, 14, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 31, 13, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Small Steps, Giant Leaps: Engineering Lessons from Apollo", 2776 },
                    { 63675, @"One of the most popular programming language on the market is getting even better. With every iteration of C# we get more and more features that are meant to make our lives as developers a lot easier. Support for writing (hopefully) better and more readable asynchronous code, being able to do pattern matching, tuples, deconstruction and much more. These are just a few of the many additions to C# that we’ve seen lately.

                Join me in this session to explore what you’ve missed in one of the most fun to work with programming language on the market; C#!", 1, new DateTimeOffset(new DateTime(2019, 1, 31, 12, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 31, 11, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "The State of C# - What Have I Missed?", 2776 },
                    { 68440, @"Regardless of the technology you know, regardless of the job title you have, you have amazing potential to impact your workplace, community, and beyond.

                In this talk, I’ll share a few candid stories of my career failures… I mean… learning opportunities. We’ll start by debunking the myth that leadership == management. Next, we’ll talk about some the attributes, behaviors and skills of good leaders. Last, we’ll cover some practical steps and resources to accelerate your journey.

                You’ll walk away with some essential leadership skills I believe anyone can develop, and a good dose of encouragement to be more awesome!", 1, new DateTimeOffset(new DateTime(2019, 1, 31, 11, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 31, 10, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Leadership Guide for the Reluctant Leader", 2776 },
                    { 67994, @"The 1970's were a golden age for new programming languages, but do they have any relevance to programming today? Can we still learn from them?

                In this talk, we'll look at four languages designed over forty years ago --  SQL, Prolog, ML, and Smalltalk -- and discuss their philosophy and approach to programming, which is very different from most popular languages today.

                We'll come away with some practical principles that are still very applicable to modern development. And you might discover your new favorite programming paradigm!
                ", 1, new DateTimeOffset(new DateTime(2019, 2, 1, 17, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 1, 16, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Four Languages from Forty Years Ago", 2776 },
                    { 68532, @"You use Git, and maybe you even know the internals: all those blobs, trees, commits and refs make it look like Git is sane, well-designed and organized system.  But is it, really?

                After all, why are there three different kinds of rebase?  What makes merge recursive?  And what's the deal with line ending normalization?  Edward Thomson shows off some of the weirder idiosyncrasies in Git and why it works the way it does.", 1, new DateTimeOffset(new DateTime(2019, 2, 1, 17, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 1, 16, 20, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "A Piece of Git", 2780 }
                });

            migrationBuilder.InsertData(
                table: "SessionSpeaker",
                columns: new[] { "SessionId", "SpeakerId" },
                values: new object[,]
                {
                    { 69229, 1 },
                    { 68894, 82 },
                    { 62532, 81 },
                    { 58161, 76 },
                    { 64248, 59 },
                    { 68212, 58 },
                    { 68161, 57 },
                    { 68736, 56 },
                    { 57079, 55 },
                    { 67271, 54 },
                    { 66632, 53 },
                    { 68826, 27 },
                    { 68882, 83 },
                    { 59857, 26 },
                    { 63252, 24 },
                    { 66715, 23 },
                    { 67138, 80 },
                    { 66814, 79 },
                    { 69366, 78 },
                    { 67078, 62 },
                    { 69231, 75 },
                    { 69228, 52 },
                    { 57812, 51 },
                    { 56795, 50 },
                    { 61211, 49 },
                    { 66433, 25 },
                    { 67872, 84 },
                    { 67422, 28 },
                    { 66768, 29 },
                    { 76427, 90 },
                    { 68611, 69 },
                    { 58551, 12 },
                    { 66322, 68 },
                    { 59563, 67 },
                    { 69354, 66 },
                    { 69255, 31 },
                    { 66459, 34 },
                    { 67163, 21 },
                    { 67163, 33 },
                    { 66791, 89 },
                    { 67372, 88 },
                    { 58138, 87 },
                    { 68282, 86 },
                    { 67087, 85 },
                    { 68009, 65 },
                    { 66866, 64 },
                    { 66437, 15 },
                    { 65854, 63 },
                    { 67079, 62 },
                    { 68678, 61 },
                    { 68607, 60 },
                    { 67909, 32 },
                    { 69253, 31 },
                    { 58982, 30 },
                    { 67996, 48 },
                    { 69938, 3 },
                    { 67965, 47 },
                    { 62178, 22 },
                    { 68939, 9 },
                    { 68938, 9 },
                    { 69170, 8 },
                    { 69170, 7 },
                    { 66952, 13 },
                    { 69010, 73 },
                    { 69233, 70 },
                    { 68521, 72 },
                    { 69004, 71 },
                    { 69232, 70 },
                    { 63671, 39 },
                    { 66448, 10 },
                    { 66795, 13 },
                    { 69052, 38 },
                    { 68994, 37 },
                    { 69344, 36 },
                    { 69333, 35 },
                    { 69174, 6 },
                    { 68804, 5 },
                    { 69301, 4 },
                    { 66592, 2 },
                    { 66592, 3 },
                    { 66591, 3 },
                    { 66591, 2 },
                    { 69345, 2 },
                    { 68940, 11 },
                    { 61516, 12 },
                    { 61516, 13 },
                    { 68493, 21 },
                    { 68493, 20 },
                    { 68734, 19 },
                    { 58654, 18 },
                    { 68745, 17 },
                    { 68546, 16 },
                    { 67994, 74 },
                    { 69307, 77 },
                    { 69230, 76 },
                    { 69230, 75 },
                    { 67993, 74 },
                    { 69239, 43 },
                    { 69332, 16 },
                    { 69332, 45 },
                    { 69332, 35 },
                    { 68608, 14 },
                    { 68814, 44 },
                    { 69240, 36 },
                    { 69240, 43 },
                    { 63675, 42 },
                    { 68440, 41 },
                    { 69266, 40 },
                    { 61516, 2 },
                    { 61516, 15 },
                    { 61516, 14 },
                    { 68887, 46 },
                    { 68532, 91 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SessionAttendee_AttendeeID",
                table: "SessionAttendee",
                column: "AttendeeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SessionAttendee");

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 56795, 50 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 57079, 55 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 57812, 51 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 58138, 87 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 58161, 76 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 58551, 12 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 58654, 18 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 58982, 30 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 59563, 67 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 59857, 26 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 61211, 49 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 61516, 2 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 61516, 12 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 61516, 13 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 61516, 14 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 61516, 15 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 62178, 22 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 62532, 81 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 63252, 24 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 63671, 39 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 63675, 42 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 64248, 59 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 65854, 63 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 66322, 68 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 66433, 25 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 66437, 15 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 66448, 10 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 66459, 34 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 66591, 2 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 66591, 3 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 66592, 2 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 66592, 3 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 66632, 53 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 66715, 23 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 66768, 29 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 66791, 89 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 66795, 13 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 66814, 79 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 66866, 64 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 66952, 13 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 67078, 62 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 67079, 62 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 67087, 85 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 67138, 80 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 67163, 21 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 67163, 33 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 67271, 54 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 67372, 88 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 67422, 28 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 67872, 84 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 67909, 32 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 67965, 47 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 67993, 74 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 67994, 74 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 67996, 48 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 68009, 65 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 68161, 57 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 68212, 58 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 68282, 86 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 68440, 41 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 68493, 20 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 68493, 21 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 68521, 72 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 68532, 91 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 68546, 16 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 68607, 60 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 68608, 14 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 68611, 69 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 68678, 61 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 68734, 19 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 68736, 56 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 68745, 17 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 68804, 5 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 68814, 44 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 68826, 27 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 68882, 83 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 68887, 46 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 68894, 82 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 68938, 9 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 68939, 9 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 68940, 11 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 68994, 37 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 69004, 71 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 69010, 73 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 69052, 38 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 69170, 7 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 69170, 8 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 69174, 6 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 69228, 52 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 69229, 1 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 69230, 75 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 69230, 76 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 69231, 75 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 69232, 70 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 69233, 70 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 69239, 43 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 69240, 36 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 69240, 43 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 69253, 31 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 69255, 31 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 69266, 40 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 69301, 4 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 69307, 77 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 69332, 16 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 69332, 35 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 69332, 45 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 69333, 35 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 69344, 36 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 69345, 2 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 69354, 66 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 69366, 78 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 69938, 3 });

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 76427, 90 });

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 2223);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 56795);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 57079);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 57812);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 58138);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 58161);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 58551);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 58654);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 58982);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 59563);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 59857);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 61211);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 61516);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 62178);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 62532);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 63252);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 63671);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 63675);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 64248);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 65854);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 66322);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 66433);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 66437);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 66448);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 66459);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 66591);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 66592);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 66632);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 66715);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 66768);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 66791);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 66795);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 66814);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 66866);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 66952);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 67078);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 67079);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 67087);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 67138);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 67163);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 67271);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 67372);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 67422);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 67872);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 67909);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 67965);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 67993);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 67994);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 67996);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 68009);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 68161);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 68212);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 68282);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 68440);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 68493);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 68521);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 68532);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 68546);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 68607);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 68608);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 68611);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 68678);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 68734);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 68736);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 68745);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 68804);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 68814);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 68826);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 68882);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 68887);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 68894);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 68938);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 68939);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 68940);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 68994);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 69004);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 69010);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 69052);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 69170);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 69174);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 69228);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 69229);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 69230);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 69231);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 69232);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 69233);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 69239);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 69240);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 69253);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 69255);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 69266);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 69301);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 69307);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 69332);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 69333);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 69344);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 69345);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 69354);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 69366);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 69938);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 76427);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Tracks",
                keyColumn: "TrackID",
                keyValue: 2775);

            migrationBuilder.DeleteData(
                table: "Tracks",
                keyColumn: "TrackID",
                keyValue: 2776);

            migrationBuilder.DeleteData(
                table: "Tracks",
                keyColumn: "TrackID",
                keyValue: 2777);

            migrationBuilder.DeleteData(
                table: "Tracks",
                keyColumn: "TrackID",
                keyValue: 2778);

            migrationBuilder.DeleteData(
                table: "Tracks",
                keyColumn: "TrackID",
                keyValue: 2779);

            migrationBuilder.DeleteData(
                table: "Tracks",
                keyColumn: "TrackID",
                keyValue: 2780);

            migrationBuilder.DeleteData(
                table: "Conferences",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "AttendeeID",
                table: "Sessions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_AttendeeID",
                table: "Sessions",
                column: "AttendeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Attendees_AttendeeID",
                table: "Sessions",
                column: "AttendeeID",
                principalTable: "Attendees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
