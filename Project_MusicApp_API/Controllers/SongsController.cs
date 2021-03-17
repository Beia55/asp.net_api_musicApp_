using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_MusicApp_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_MusicApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private static List<Song> songsList = new List<Song>()
        {
            new Song(){ ID = Guid.NewGuid(), Name = "I'll Live in Glory",Composer = "Whisnants", Year = 2007},
            new Song(){ ID = Guid.NewGuid(), Name = "East to West",Composer = "Casting Crowns", Year = 2010},
            new Song(){ ID = Guid.NewGuid(), Name = "What Faith Can Do",Composer = "Kutless", Year = 2009},
        };

        [HttpGet]
        public Models.Song[] Get()
        {
            return songsList.ToArray();
        }

        [HttpPost]
        public void Post([FromBody] Models.Song song)
        {
            if (song.ID == Guid.Empty)
                song.ID = Guid.NewGuid();

            songsList.Add(song);
        }

        [HttpPut]
        public void Put([FromBody] Models.Song song)
        {
            Models.Song currentSong = songsList.FirstOrDefault(x => x.ID == song.ID);
            currentSong.Name = song.Name;
            currentSong.Composer = song.Composer;
            currentSong.Year = song.Year;
        }

        [HttpDelete]
        public void Delete(Guid id)
        {
            songsList.RemoveAll(song => song.ID == id);

            /*foreach (Models.Song song in songsList)
            {
                if (song.ID == id)
                {
                    songsList.Remove(song);
                }
            }*/

        }

    }
}
