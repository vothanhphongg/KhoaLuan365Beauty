﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace _365Beauty.Query.Presentation.Abstractions
{
    public static class EndpointRegistration
    {
        /// <summary>
        /// Map presentation layer endpoints
        /// </summary>
        /// <param name="app"></param>
        /// <returns>The endpoint route builder with mapped presentation layer endpoints</returns>
        public static IEndpointRouteBuilder MapPresentation(this IEndpointRouteBuilder app)
        {
            app.MapControllers();
            return app;
        }
    }
}