using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Diagnostics.Backends.Console;

namespace LoggingLibrary
{
    public static class Logger
    {
        static Logger()
        {
            LoggingServices.DefaultBackend = new ConsoleLoggingBackend();
        }
    }
}
