CrossOver-Test Assignment
-------------------------

It is a web base application which allows users to demand books from their libraries and browse available books.


Getting Started
---------------


These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.


Prerequisites
-------------


Install the following software/tools:


Visual Studio 2015
Net Framework 4.6+
Mongo DB server 3.2
MongoDbCSharp Driver (latest)
StructureMap for web api
Angular Js 1.5+ (not 2.0) ( for UI project)
Typescript 2.1 ( for UI project)
Automapper (latest)
 MongoChef Core (free) Mongo Tool
Moq (for testing)


Configure Mongodb Server
-----------------------

Create the following folder structure (on D: if available)
D:\LocalMongoDB
	\Bin
	\Data
	\Logs

Copy content of bin folder (installed folder of mongodb server e.g. C:\Program Files\MongoDB\Server\3.2\bin).

Paste the content to D:\LocalMongoDB\bin folder.

Open command prompt with administrator rights

Go to D:\LocalMongoDB\bin

Run the following command to make mongo as windows service
D:\LocalMongoDB\bin> mongod --install --dbpath= D:\LocalMongoDB\Data
        --logpath= D:\LocalMongoDB\Logs\log.txt

Goto C: drive run the command to start the windows service
C:\ net start Mongodb (if you don’t mention the service name in the above command. The service gets created with default name (MongoDB)

Go to D:\LocalMongoDB\bin

Run the command to check whether the install works properly
D:\LocalMongoDB\bin> mongo
Db (it shows test)


Import required project’s data
------------------------------

Open MongoChef tool
Got to Connect -> create new connection on port 27017 (default)
On connecting left side, it shows local database.
Right click on (localhost:27017 server) and select add database option.
And enter CrossOver for the database name.
Right click on the newly created database (crossover) and select import collections option
Select json -mongoshell option
Select book collection from the downloaded and extracted script folder(the script is available at MakrandVichare_SoftwareEngineer_DotNet\SourceCode\7.DBScripts\SoftwareEngineerGeneric_PublishedBooks) 
or 
from the online url https://techtrial.s3.amazonaws.com/System/SoftwareEngineerGeneric_PublishedBooks.zip)
On importing, you can see book collection under the database crossover


Execute the source code in the visual studio 2015
-------------------------------------------------


Exact the folder MakrandVichare_SoftwareEngineer_DotNet.zip
Open the solution SlnCrossOverAssignment from the SourceCode folder.
If you get a warning for tfs collection select no option to disconnect from the TFS.
The studio will install the missing packages automatically on build (if any package is missing)
If the project builds successfully.
Run the project check on which port the web api project run
Accordingly update BaseWebApiUrl() variable for the web api url at the path 1.UI\CrossOver.MVC.Angular.UI\MiniSpas\Common\AppConstants.ts 


Assumptions
-----------

Missing or Not clear requirement :- 

What are actions users(students) can take while maintaining the demanded books (assumed only can view the request history).
Roles to update the request is missing (e.g. librarian who can approve the or reject request)
Missing Books stock info so assumed unlimited books request.
No limit of how many books can be demanded  
If the book is already demanded, the book is not allowed to demand again.


Authors
-------

Makrand Vichare
Full stack developer (asp.net mvc, angularjs, web api,android)
Makv1975@hotmail.com

