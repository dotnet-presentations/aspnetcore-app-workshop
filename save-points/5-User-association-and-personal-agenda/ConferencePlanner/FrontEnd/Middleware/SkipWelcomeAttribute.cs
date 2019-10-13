using System;

namespace FrontEnd
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class SkipWelcomeAttribute : Attribute
    {

    }
}