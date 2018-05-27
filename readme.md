# Technical Document


####  A Bad REST API

A Client needs us to pull 2 years of ultra-cool curated tweets they have collected and stored themselves. We need to make sure that we get all tweets from 2016 and 2017. The only way to get this data is to use the client's REST API. However, it is not a well-designed API.

##  Environment: 

+	Windows 10,
+	Visual Studio 2015 Update 3
+	DOT NET Framework 4.5.2
+	ASP.NET MVC 5.2.3.0
+	NuGet package manager


## Requirements:

1.	Application should be written in C# or JavaScript
2.	Submit app via a public GitHub repository 
3.	We must be able to build and run your app
4.	The final results should contain all records with no duplicates
5.	The results should be output in a way that allows us to validate records
6.	The operation should complete in a reasonable amount of time
7.	Application should make actual calls to our actual pretend REST API (https://badapi.xxxx.io/swagger/) to get the tweets.


## Development: 

A part from the default NuGet packages given my Microsoft at the time create MVC project template, the below Additional packages used.

#### NuGet Packages used in application: 

**Unity.MVC:** 
		used for dependency resolving in controller’s, injecting service for achieve loosely couple 

**Microsoft.AspNet.WebApi.Client:** 
		This package adds support for formatting and content negotiation to System.Net.Http. It includes support for JSON, XML, and form URL encoded data.

**JavaScript library Used in application:**

**Datatables**, version 1.10.16, downloaded from https://datatables.net/, used for display Restful API result in table format.
You can see the actual source code in the below files:


##Find the actual source code in the below files:


1.	**Model:** `TweetModel.cs`, A class used for get and set data to controller and view
			
		Model Path: "/TweetsAPI/Controllers/ TweetModel.cs”
	
2.	**View:**  `ViewTweets.csthml`, consists of html and JavaScript code
		
		View Path: “/TweetsAPI/Views/tweets/ViewTweets.cshtml”
	
3.	**Controller:** `TweetsController.cs`, Gets the data from the service and send it to view 

		Controller Path: “/TweetsAPI/Controllers/ TweetsController.cs”
	
4. 	**Interface:** `ITweetService.cs`, this interface is passed as a parameter into constructor of controller, to achieve loosely coupled, if any new method added in this interface, the controller does not required to implementing newly added function. You can find the dependency resolving in  code in location “/TweetsAPI/App_Start/UnityConfig.cs” 
		
		Interface Path: “/TweetsAPI/Interface/ITweetService.cs”

5.	**Service:** `TweetService.cs`, make calls to (//badapi.XXXX.io/swagger/) API returns response in JSON, which gets 100 records. By using Distinct method in LINQ, we eliminated duplicate records. 
			
		Service Path: “/TweetsAPI/Interface/TweetService.cs”


## Running Application: 

1.	Download the source code from https://github.com/ravitejacore/TweetsAPI 
	Alternatively, use command `“git clone https://github.com/ravitejacore/ExamAPI.git”`
	From command prompt
	
2.	 Open the `TweetsAPI.sln` , with visual studio 2015, or later

3.	The project will be opened  and then Hit F5 

4.	After hitting the F5 you can see NuGet Restoring packages, please do not cancel it.

5.	Then you can see the result browser, please hit  **`Get Tweets`** button , you will get tweets without duplicate tweets.

	![alt text](https://raw.githubusercontent.com/ravitejacore/LeaveMe/master/images/screen1.jpg "click on Get Tweets button")
	
	![alt text](https://raw.githubusercontent.com/ravitejacore/LeaveMe/master/images/screen2.jpg "Displaying REST API result")

## Unit Testing: 

##### Case 1: 	
 When we enters startDate as 2016-03-20T04:07:56.271Z and end Date as 2017-03-20T04:07:56.271Z the API returns 100 results, and Http Status code is 200 OK
	
	Status: Pass

##### Case 2:
 When we enters startDate as AAAA-03-20T04:07:56.271Z and End Date as BBBB-03-20T04:07:56.271Z the API returns 0 results, and Http Status code is 200 OK
	
	Status: Fail
**Expected Result:** The API should return Http Status Code 400 Bad Request, “Invalid StartDate and/or EndDate”
	

## Conclusion:

1.	Application was written C#, and used third party JavaScript libraries display result
2.	You can download the application from GitHub from the below location https://github.com/ravitejacore/TweetsAPI 
3.	Verified that the final result had no duplicate results 
4.	We can validate your results from the search feature in the result table
	![alt text](https://raw.githubusercontent.com/ravitejacore/LeaveMe/master/images/search.jpg "You can serach for contents, it displays search results")
 
5.	All the result are fetched from the pretend REST API (https://badapi.xxxxx.io/swagger/)to get tweets 

6. You can find the Technical document in the location https://github.com/ravitejacore/ExamAPI/blob/master/Document_v1.0.doc
