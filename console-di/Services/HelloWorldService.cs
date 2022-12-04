using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWithDepencyInjection.Services;

public sealed class HelloWorldService : IHelloWorldService
{
    public void PrintHelloWorld()
    {
        Console.WriteLine("Hello World!");
    }
}
