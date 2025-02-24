﻿namespace _365Beauty.Query.Persistence.DependencyInjection.Options
{
    /// <summary>
    /// Options for connection string
    /// </summary>
    public class ConnectionStringOptions
    {
        public const string ConnectionStrings = "ConnectionStrings";
        public string SqlServer { get; set; } = string.Empty;
    }
}