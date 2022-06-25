using Microsoft.AspNetCore.SignalR;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRServerExample.Hubs
{
    public class MessageHub : Hub
    {
        //public async Task SendMessageAsync(string message, IEnumerable<string> connectionIds)
        //public async Task SendMessageAsync(string message, string groupName, IEnumerable<string> connectionIds)
        //public async Task SendMessageAsync(string message, IEnumerable<string> groups)
        public async Task SendMessageAsync(string message, string groupName)
        {
            // Sadece server'a bildirim gönderen client'la iletişim kurar
            // await Clients.Caller.SendAsync("receiveMessage", message);

            // Server'a bağlı olan tüm client'lar ile bağlantı kurar
            // await Clients.All.SendAsync("receiveMessage", message);

            // Sadece server'a bildirim gönderen client dışında server'a bağlı olan tüm clientlara mesaj gönderir
            // await Clients.Others.SendAsync("receiveMessage", message);


            #region AllExcept
            // Belirtilen clientlar hariç server'a bağlı olan tüm clieantlara bildiride bulunur.
            // await Clients.AllExcept(connectionIds).SendAsync("receiveMessage", message);
            #endregion

            #region Client
            // Sadece belirtilen clientlara bildiride bulunmayı sağlar
            // await Clients.Client(connectionIds.First()).SendAsync("receiveMessage", message);
            #endregion

            #region Clients
            // Server'a bağlı olan clientlara arasından sadece belirtilenlere bildiride bulunur.
            // await Clients.Clients(connectionIds).SendAsync("receiveMessage", message);
            #endregion

            #region Group
            // Belirtilen gruptaki tüm clientlara bildiride bulunur.
            // await Clients.Group(groupName).SendAsync("receiveMessage", message);
            #endregion

            #region GroupExpect
            // Belirtilen gruptaki belirtilen clientlar dışındaki tüm clientlara mesaj iletmeye yarayan fonksiyondur
            // await Clients.GroupExcept(groupName, connectionIds).SendAsync("receiveMessage", message);
            #endregion

            #region Groups
            // Birden çok gruptaki clientlara bildiride bulunmamızı sağlayan fonksiyondur.
            // await Clients.Groups(groups).SendAsync("receiveMessage", message);
            #endregion

            #region OthersInGroup
            // Bildiride bulunan client haricindeki gruptaki diğer tüm clientlara bildiride bulunur
            // await Clients.OthersInGroup(groupName).SendAsync("receiveMessage", message);
            #endregion


        }
        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("getConnectionId", Context.ConnectionId);
        }

        public async Task addGroup(string connectionId, string groupName)
        {
            await Groups.AddToGroupAsync(connectionId, groupName);
        }
    }
}

