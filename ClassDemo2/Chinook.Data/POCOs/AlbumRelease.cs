using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Chinook.Data.DTOs;

namespace Chinook.Data.POCOs
{
    public class AlbumRelease
    {
        public string Title { get; set; }
        public int RYear { get; set; }
        public string Label { get; set; }
    }
}
