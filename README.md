# TopTenAPI
Covid Cases API

-Steps to run API in VS:
1. Open VS and select solution TopTenAPI.sln
2. Verify properties under web path and should run under https://localhost:44362/
   2.1 This url is registered under web.config from project Top10Covid19 indicating our Rest API solution target to https://rapidapi.com/axisbits-axisbits-default/api/covid-19-statistics API for exercise.
3. Click run project and API is ready to be accesed by Web projects or Unit Test


Configs defined in Top10Covid19
1. web.config into Top10Covid19 allocates follow parameters used by our Client created in TopTenService project

 1.1 Api KEY (Used to authenticate covid-19-statistics API for exercise)

1.2 Method: Method used to get results information (regions and provinces) 

1.3 protocol (by default will be set to https)  corresponding to covid-19-statistics API ["https://covid-19-statistics.p.rapidapi.com]

1.4 Server ("covid-19-statistics.p.rapidapi.com") defined in definition covid-19-statistics API

Main project is Top10Covid19, UI interface (grid defined, searchs and data export formats), complementary is created a project named TopTenService assigned to a Client for TopTenAPI. 
When project is lanuched please verify starts in path: https://localhost:44321/

- Unit test
-   Created two choices:
-     1. Postman collection called TopTen.postman_collection
-     2. Under TopTenAPI project
