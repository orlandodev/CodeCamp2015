# CodeCamp2015
Info and samples from the Token-Based Authentication session at the 2015 Orlando Code Camp.

I've included code samples here that demonstrate a simple token-based authentication scenario.  A hybrid mobile app requests a token by collecting a user name and password then passing it to a Web API.  The API has a stub method to authenticate and returns a simple set of claims in Jwt format.

Three things to note about the IdentityProvider project:  

1) It's CORS-enabled via an attribute on the TokenController class.  For testing purposes, it has an origin pointing to the hybrid app in the same solution.  However, the port number will likely change each time the mobile app is run so you'll probably want to replace the origin with an asterik (for testing purposes only!) before running it.

2) It has a reference to an X.509 certificate created with SelfSSL7 which you can read about and download from here:  http://blogs.iis.net/thomad/archive/2010/04/16/setting-up-ssl-made-easy.aspx.  You'll need to generate your own certificate before attempting to run these samples.

3) It's currently configured to run inside a local instance of IIS.  However, you can easily change that via the project properties page.

As far as other sample code goes, one example related to the Simple Web Token came from MSDN and can be found here:  https://code.msdn.microsoft.com/Custom-Token-ddce2f55.  The other example related to sync tokens came directly from the Visual Studio 2012 template for a Single Page app.  

Although I didn't have time to show refresh tokens in action, there's a good article I referred to in the slide deck and the live demo app is located here:  http://ngauthenticationweb.azurewebsites.net/#/home.

Also, if you're interested in a copy of the slide deck from the session, you can find that here:  http://files.meetup.com/4084532/Token-based%20Authentication.pptx.
