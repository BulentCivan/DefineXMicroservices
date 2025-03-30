using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Security.Claims;
using System.Threading.Tasks;

[Authorize]
public class ChatHub : Hub
{
    // Kullanıcı bağlantılarını tutmak için bir sözlük
    private static ConcurrentDictionary<string, string> _userConnections = new ConcurrentDictionary<string, string>();

    private const string AdminUserId = "1"; // Admin kullanıcı ID'si

    // Kullanıcı bağlandığında
    public override async Task OnConnectedAsync()
    {
        var userId = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (!string.IsNullOrEmpty(userId))
        {
            // Kullanıcı bağlantısını kaydet
            _userConnections[userId] = Context.ConnectionId;

            // Admin'e kullanıcı bağlandığını bildir
            if (userId != AdminUserId)
            {
                await Clients.User(AdminUserId).SendAsync("UserConnected", userId);
            }
        }

        await base.OnConnectedAsync();
    }

    // Kullanıcı bağlantısı kesildiğinde
    public override async Task OnDisconnectedAsync(Exception exception)
    {
        var userId = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (!string.IsNullOrEmpty(userId))
        {
            // Kullanıcı bağlantısını kaldır
            _userConnections.TryRemove(userId, out _);

            // Admin'e kullanıcı bağlantısının kesildiğini bildir
            if (userId != AdminUserId)
            {
                await Clients.User(AdminUserId).SendAsync("UserDisconnected", userId);
            }
        }

        await base.OnDisconnectedAsync(exception);
    }

    // Mesaj gönderme
    public async Task SendMessage(string receiverUserId, string message)
    {
        var senderUserId = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (!string.IsNullOrEmpty(senderUserId))
        {
            if (receiverUserId == AdminUserId)
            {
                // Kullanıcı admin'e mesaj gönderiyor
                await Clients.User(AdminUserId).SendAsync("ReceiveMessage", senderUserId, message);
            }
            else if (senderUserId == AdminUserId)
            {
                // Admin kullanıcıya mesaj gönderiyor
                if (_userConnections.TryGetValue(receiverUserId, out string connectionId))
                {
                    await Clients.Client(connectionId).SendAsync("ReceiveMessage", "admin", message);
                }
            }
        }
    }
}