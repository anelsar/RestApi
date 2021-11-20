This app uses the Facebook API (Graph API) to get data about a user. After you click on the "Get some info about yourself on facebook" link, a facebook log in page will apear. You can log in with the test account provided by Facebook. By entering the credentials and authenticating the user, an access token is sent and we will use that access token to get the information about the currently logged in user. Some of the information will appear in text boxes, which you can modify and save the modified (or not modified) information to a local .json file.

For this app to work, you will need to clone or download this project to you computer. You need to have Visual studio '19 installed. In the project's appsettings.json file, you will need to paste your url encoded localhost link

"MyConfiguration": { "RedirectUri": "your localhost urlencoded link" }

To get the URL encoded link, you have online encoders like this page: https://www.urlencoder.org/

The Facebook test data used here is:

email: open_pfpeeod_user@tfbnwt.net

password: test12345

------
After you log in with these data, the "https://graph.facebook.com/me?access_token=ACCESS-TOKEN" API is called and you get some information about the logged in user.

This app is built in asp.net core version 5.0.3

This project follows the MVC pattern.

Bootstrap is used for page styling.

Dependency injection is used for providing objects to other objects who consume them.
