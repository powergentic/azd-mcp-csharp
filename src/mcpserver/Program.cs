using System.ComponentModel;
using ModelContextProtocol.Server;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    // Add MCP server services
    .AddMcpServer()
    // Register Tools from the current assembly
    .WithToolsFromAssembly()
    // Register Prompts from the current assembly
    .WithPromptsFromAssembly();


var app = builder.Build();

// Add the MCP server endpoints
app.MapMcp();

// Add a default route for the web server with a "Hello World" message
app.MapGet("/", () => "Hello World! This is a Model Context Protocol server.");

// Run the web server
app.Run();


// ##################################################
// # MCP Server Tool and Prompt Examples
// ##################################################

/// <summary>
/// This is a simple tool that echoes the message back to the client.
/// </summary>
[McpServerToolType]
public static class EchoTool
{
    [McpServerTool, Description("Echoes the message back to the client.")]
    public static string Echo(string message) => $"hello {message}";
}

/// <summary>
/// This is a simple prompt that echoes the message back to the client.
/// </summary>
[McpServerPromptType]
public static class EchoPrompt
{
    [McpServerPrompt, Description("Echoes the message back to the client.")]
    public static string Echo(string message) => $"hello {message}";
}
