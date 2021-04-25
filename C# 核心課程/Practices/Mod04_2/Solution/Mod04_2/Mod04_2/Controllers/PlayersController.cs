using Mod04_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Mod04_2.Controllers
{
    public class PlayersController : ApiController
    {
        Player[] players = new Player[] {
            new Player{ ID=1, Name="Mary"},
            new Player{ ID=2, Name="Jerry"},
            new Player{ ID=3, Name="Lisa"}
        };
        public IEnumerable<Player> GetAllPlayer()
        {
            return players;
        }
        public IHttpActionResult GetPlayer(int id)
        {
            var player = players.FirstOrDefault((p) => p.ID == id);
            if (player == null)
            {
                return NotFound();
            }
            return Ok(player);
        }

    }
}
