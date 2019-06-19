# Algebra clone

This is a web app for an imaginary school where visitors can register for attending certain courses. Pages are generated using Razor with some bootstrap to look nice. The data on info, courses and employees is kept in a SQL database.


### Visitor pages

Visitors can see unfilled seminars, search them by the course name and register by filling an appropriate form.

![Visitor pages](https://i.imgur.com/uykzGNk.png)

### Employee pages

Employee pages are accessible after sign in. Upon signing in, a different navigation bar is rendered and the user is authorized to:
- See already filled seminars
- Edit seminars
- Add seminars
- Add new emplyoees 
- Edit (including approving and declining) registration requests

![Employee pages](https://i.imgur.com/MAVzcaZ.png)


##### Security
Employee passwords are hashed and salted before storing in a database. After a successful login, a cookie containing a JWT token valid for 30 minutes is issued. Authorization is handled within the controller using a customized [Authorize] attribute.

### Author's notes

The database with some test entries is included. There is also an admin/admin account included. The database has been constructed using the code-first approach and Entity Framework 6 was used. Dependency injection was handled using [Unity](https://github.com/unitycontainer). Appropriate custom 404, 401 and other error pages have been implemented.


License
----

MIT


**Free Software, Hell Yeah!**

