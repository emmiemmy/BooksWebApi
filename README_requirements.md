## Assignemnt - Emma Shakespeare - for Nexer Group

### README 
I have in this solution set up a database in microsoft sql server, combined with docker and azure data studio. EF Core and migrations to setup table structure and content for table Books. Data is sedded to database in '''OnModelCreating''' in '''BooksApiDbContent.cs'''. 

Connectionstring is to be found in '''appsettings.json'''. The password is in clear text, I am aware of that this is not a suitable way to store passwords.

I  used DTO to limit client model access to, although, it it exactly the same as the model itself, but interesting to use :-). I did have a service layer as well but thought it overkill in this case. I use Automapper extension to map model to Dto. 

I have not created an API in .NET before so this was interesting! I did lookup some unit tests but I have not implemented any in this solution. 

I used postman to test all endpoints provided in assignment description. 







Requirements Books API:
----------------------- 
The API should be written in NET Core > 2.2. 
The API doesn't have to be able to add or update the books.
The API should always return a collection of books in json format. 
By default it should return all books without any specific sorting. 
If a specific field is searched it should return the result sorted on that field. 
It should be possible to search on any field.
Field "published_date" should be a datetime. 
Field "price" should be a double. 
Rest of the fields could be plain strings. 

Use cases: 
---------- 
Whatever field I ask for, it should return the result sorted by that field. 
I should be able to ask for an author, a title, a genre or a description. It should perform the search "case insensitive" and with partial strings. So if I ask for "/api/books/author/kim" it should return only the book by "Ralls, Kim". 
I should be able to ask for a price range or a specific price. 
I should be able to ask for published_date or part of it, that means all books, books from a certain year, books from a certain year-month or books from a certain year-month-day. 

Use case examples:
https://host:port/api/books returns all unsorted (B1-B13)
https://host:port/api/books/id returns all sorted by id (B1-B13)
https://host:port/api/books/id/b returns all with id containing 'b' sorted by id (B1-B13)
https://host:port/api/books/id/1 returns all with id containing '1' sorted by id (B1, B10-13)

https://host:port/api/books/author returns all sorted by author (B1-B13)
https://host:port/api/books/author/joe returns all with author containing 'joe' sorted by author (B1)
https://host:port/api/books/author/kut returns all with author containing 'kut' sorted by author (B1)

https://host:port/api/books/title returns all sorted by title (B1-B13)
https://host:port/api/books/title/deploy returns all with title containing 'deploy' sorted by title (B1)
https://host:port/api/books/title/jruby returns all with title containing 'jruby' sorted by title (B1)

https://host:port/api/books/genre returns all sorted by genre (B1-B13)
https://host:port/api/books/genre/com returns all with genre containing 'com' sorted by genre (B1, B10-13)
https://host:port/api/books/genre/ter returns all with genre containing 'ter' sorted by genre (B1, B10-13)

https://host:port/api/books/price returns all sorted by price (B1-B13)
https://host:port/api/books/price/33.0 returns all with price '30.0' (B1)
https://host:port/api/books/price/30.0&35.0 returns all with price between '30.0' och '35.0' sorted by price (B1, B11)

https://host:port/api/books/published returns all sorted by published_date (B1-B13)
https://host:port/api/books/published/2012 returns all from '2012' sorted by published_date (B13, B1)
https://host:port/api/books/published/2012/8 returns all from '2012-08' sorted by published_date (B1)
https://host:port/api/books/published/2012/8/15 returns all from '2012-08-15' sorted by published_date (B1)

https://host:port/api/books/description returns all sorted by description (B1-B13)
https://host:port/api/books/description/deploy returns all with description containing 'deploy' sorted by description (B1, B13)
https://host:port/api/books/description/applications returns all with description containing 'applications' sorted by description (B1)

Hints: 
------ 
Divide the solution into what you think is architectural suitable parts. 
Refactor the code to make it as easy as possible to read and maintain. 
Use coding techniques like fx well known patterns and practices and naming conventions. 
Make use of abstractions, dependency injections, extensions, expressions, attributes etc.
Make use of different routes in the controller. 
Try to think of the data context as a reusable service. 
If you are familiar with testing we would really like to see some unit tests :) 
Don't worry if you think it seems like a tough test! Just do your best. As long as the requirements and use cases are covered you are safe. The rest is only to judge the maturity of your skills.

Deliverables: 
------------- 
First of all! Make sure everything works before handover! 
The code should be documented, add comments where you feel the need, try to explain how you were thinking.
Add a brief description of how you were thinking when you created the solution or any additional information how to make it compile/execute if needed. 
Once you have finished your solution then run a clean on it, you don't have to deliver the binaries, we are only interested in all the source code. 
Make sure everything needed is included in the solution folder and then zip it. 