using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FrontEnd.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class SkipWelcomeAttribute : Attribute, IFilterMetadata
    {

    }
}