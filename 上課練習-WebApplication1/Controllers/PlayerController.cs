using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PlayerController : ApiController
    {
        public Player[] players = new Player[] {
        new Player{ ID=1, Name="Mary" },
        new Player{ ID=2, Name="jerry" },
        new Player{  ID=3, Name="lisa"}
        };
        public IEnumerable<Player> GetPlayers()
        {
            return players;
        }

        public IHttpActionResult PostPlayer(int id)
        {

            var player = players.FirstOrDefault(t => t.ID == id);
            if (player == null)
            {
                return NotFound();
            }
            return Ok(player);
        }
    }
}
