# Ben

A .Net Core project using Entity Framework to create a database schema to show a list of members plus related products they have.
It uses the repo and interface approach. I set up two models for the database schema, one for members and the other for their products. There is a relationship between the tables using the MemberId.
It uses an In Memory database that is populated in the startup.cs
While running I used Postman to check the results. 
The URL to see the members list is https://localhost:(your port)/Member/SelectMember
To see the product related to that member the URL is
https://localhost:(your port)/Member/RelatedProducts?MemberId=(add a memberId)

Assumptions
This is the first time I have done anything with an API and returning Json. I tried to use my existing knowledge in creating a site using views and changed it to return Json instead of a razor view.
It was also the first time I used an in memory database AddTestData(Context) to add data. I would normally create a local db by adding a connection string and change the context to use Sql.  
I wanted to include some unit tests but I have never written any before, so I ran through a tutorial and asked a friend of mine the best approach. With his advice and with what I learnt in the tutorial I managed to put together a very simple test to check a member and product entry in the database. I am certainly no expert and need to learn a lot more about unit tests.
This was a great challenge and I enjoyed doing it as I feel I am learning something new and although I am sure there are better ways to achieve what the application does I am pleased to put forward what I have done.
