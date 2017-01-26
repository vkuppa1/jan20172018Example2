using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Chinook.Data.POCOs;
namespace Chinook.Data.DTOs
{
    public class AlbumArtistReleases
    {
        public string Artist { get; set; }
        public List<AlbumRelease> Albums { get; set; }
    }
}
