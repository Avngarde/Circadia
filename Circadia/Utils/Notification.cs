using Microsoft.Toolkit.Uwp.Notifications;

namespace Circadia.Utils;

public static class Notification
{
    public static void ShowNotification(string text)
    {
        var toast = new ToastContentBuilder()
            .AddArgument("action", "viewConversation")
            .AddArgument("conversationId", 9813)
            .AddText("Circadia")
            .AddText(text);
        
        toast.Show();
    }
}