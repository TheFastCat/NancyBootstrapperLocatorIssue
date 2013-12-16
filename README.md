NancyBootstrapperLocatorIssue
=======================================

This stub project is useful for reproing an issue with Nancy's BootstrapperLocator class; namely a scenario that causes a Nancy internal server error while viewing _Nancy diagnostics info.

POSITIVE CASE REPRO:

	To repro:
	
		F5 the website project (SystemWeb OWIN hosting) 
		From your browser navigat to /_Nancy
		Enter the password "hi" to access Nancy's diagnostics
		Select the "Info" image to navigate to /_Nancy/Info
	
	Expected: output of Nancy's diagnostics data
	
	Actual Result: output of Nancy's diagnostics data


NEGATIVE CASE REPRO:

	To repro:
	
		within Core.CustomBootstrapper uncomment the non-default ctor taking a string as argument:
		
		        //public CustomBootstrapper(string str)
		        //{
		
		        //}		
	
		within Startup.Startup : replace app.UseNancy() in order to stipulate an explicit CustomBootstrapper
		for Nancy to use (with a ctor argument): 
		
			app.UseNancy(new NancyOptions() { Bootstrapper = new CustomBootstrapper(str: "hi") });
	
		F5 the website project (SystemWeb OWIN hosting) 
		From your browser navigat to /_Nancy
		Enter the password "hi" to access Nancy's diagnostics
		Select the "Info" image to navigate to /_Nancy/Info
	
	Expected: output of Nancy's diagnostics data
	
	Actual Result: 
	Internal server error. Firebug magic eventually shows that the BootstrapperLocator class expects a default ctor for a loaded bootstrapper.
	
Remarks: Nancy will function normally with an explicit Bootstrapper passed to it from OWIN that uses a non-default ctor; however _Nancy/Info will raise an internal server error 500 that is hard to track down and debug.


