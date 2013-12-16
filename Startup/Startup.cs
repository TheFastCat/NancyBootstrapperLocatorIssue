using Microsoft.Owin;
using Owin;
using Nancy.Owin;
using Microsoft.Owin.Extensions;
using System;
using Core;

namespace Startup
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseNancy();
            // todo: uncomment to invoke non-default Bootstrapper ctor
            //app.UseNancy(new NancyOptions() { Bootstrapper = new CustomBootstrapper(str: "hi") });
            app.UseStageMarker(PipelineStage.MapHandler);//required to display Nancy assets on IIS
        }
    }
}
