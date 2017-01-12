using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#region Additinal Namespaces
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#endregion

namespace Chinook.Data.Entities
{
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }

        public string Title { get; set; }

        public int ArtistId { get; set; }

        public int ReleaseYear { get; set; }
        public string ReleaseLabel { get; set; }
        
        //Navigational Properties
        public virtual Artist Artist { get; set; }
    }
}
