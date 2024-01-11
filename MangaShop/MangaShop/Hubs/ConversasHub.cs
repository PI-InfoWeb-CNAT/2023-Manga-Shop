using MangaShop.Data;
using MangaShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace MangaShop.Hubs
{
    public class ConversasHub : Hub
    {
        private readonly BancoContext _bancoContext;

        public ConversasHub(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        
        public async Task SendMessage(string message, UserModel user)
        {
            var userId = user.UserId;
            await Clients.All.SendAsync("ReceiveMessage", userId, message);
        }
    }
}
