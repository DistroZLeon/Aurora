using Microsoft.AspNetCore.SignalR;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ILogger<ChatHub> _logger;
        public ChatHub(ILogger<ChatHub> logger)
        {
            _logger = logger;
        }
        // Metoda de conectare la grup
        public async Task JoinGroup(string groupId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupId);
        }

        // Metode de iesire din grup
        public async Task LeaveGroup(string groupId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupId);
        }
        // Metoda prin care se trimit mesaje
        public async Task SendMessageToGroup(string groupId,string message)
        {
            if(message!=null && groupId !=null)
            {
                await Clients.Group(groupId).SendAsync("ReceiveMessage", message);
            }
            
        }
    }
}