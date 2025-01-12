﻿namespace _365Architect.Demo.Query.Domain.Exceptions
{
    /// <summary>
    /// Exception for failure when trying to create instance of generic repository
    /// </summary>
    public class CreateGenericRepositoryFailedException() : Exception("Failed to create generic repository")
    {
    }
}