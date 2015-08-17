#company Mashup Readme


This document contains information required to support the company Mashup.  

The MashupJS portions of the application is documented here:
http://mashupjs.github.io/
https://github.com/MashupJS/MashupJS

This file is easily located in source control in the root of companyPaper.Mashup.
Within the Visual Studio solution you'll find it at root/Solution Items/company.Mashup.Readme.md


----------


##Fundamentals


The company Mashup is based on the open source project MashupJS.  The purpose of the MashupJS is to give enterprises a seed project for building large JavaScript Front-End applications.  The ability to create composite applications can reduce the impact of technical debt by reducing the divergence in component versioning and libraries.

Angular is the JavaScript framework used to implement the SPA architecture while other libraries supplement features not available with Angular alone.


##Development Environment

We use everything but the DevOps section of this link.
https://github.com/MashupJS/MashupJS/blob/master/docs/mashupWorkflow/tools/tools.md


##Application Setup

###Web Sites
Setting up the web sites manually

####Create a webApi site

- Create a folder under, `D:\WebApi`, with the same name as your webapi in source control.  Example: `Mashup.Api.Quality`
 
- In IIS Mgr create a new application pool.  All webapi(s) will be named after their subject + Api.  Example: `QualityApi`.  Name your new application pool the same.   

> Note: You want to **create your app pool first** so the application can
> grant it the proper permissions to your api(s) root.
> 
> Select .NET Framework v4.0.x - The webapi should be based on v4.5 but the 4.x reference in Windows 2008 might actually be 4.5.  Not sure how this works exactly.

- Under `Services` create a web site for the webapi.  Point it toward the new folder created earlier and select the app pool created earlier.
- Go into the new web sites config and change the `Authentication` module.  Set `Anonymous Authentication` to **Disabled** and `Windows Authentication` to **Enabled**.

- Deploy the application directory to the root of the new folder created earlier using Visual Studio's publish option.  Use the file transfer option.  In this case we are deploying to `\\sptcpweb55\d$\WebApi\Mashup.Api.Quality` .

##Workflow

StackEdit stores your documents in your browser, which means all your documents are automatically saved locally and are accessible **offline!**

###Development in the company Mashup


###Deploying the company Mashup
Deployment of the company Mashup is currently manual but will become automation from a command line switch in Gulp.
To create a production version of the Mashup use the following Gulp command

    gulp --env prod

This will use the `env.config.prod.json` file to replace environment variables.  At this point you can run the application locally but only production webapi(s) will be used.  

To deploy the application copy the contents of the dist folder to 
`\\sptcpweb55\d$\websites\mashup`

###Keeping the company Mashup current

###Configuring webapi for publish
This is for manually deploying a single webapi.  We should always retain this ability so whatever DevOps automated deployment we adopt should support deploying webapi(s) individually and manually.