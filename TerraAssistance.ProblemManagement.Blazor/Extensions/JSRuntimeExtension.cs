namespace TerraAssistance.ProblemManagement.Blazor.Extensions;

using Microsoft.JSInterop;
using TerraAssistance.ProblemManagement.Blazor.Data.Constants;

public static class JSRuntimeExtension
{
    public static async Task ShowMessage(this IJSRuntime jsRuntime, string message)
    {
        await jsRuntime.InvokeVoidAsync(JsFunctionName.Alert, message);
    }

    public static async Task ShowError(this IJSRuntime jsRuntime, Exception exception)
    {
        await jsRuntime.ShowMessage(exception.Message);
    }
}