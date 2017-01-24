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
    [Table("Track")]
    public class Track
    {
        public int Trackid { get; set; }
        public string Name { get; set; }
        public int AlbumId { get; set; }
        public int MediaTypeId { get; set; }
        public string GenreId { get; set; }
        public int Composer { get; set; }
        public string Millisecconds { get; set; }
        public int? Bytes { get; set; }
       
        public virtual  Album  Album{ get; set; }
        public virtual MediaType MediaType { get; set; }

        // public virtual Genre Genre { get; set; }
        // public virtual Icollection<PlaylikstTrack> PlaylikstTracks   { get; set; }
        // public virtual Icollection<InvoiceLine> InvoiceLines { get; set; }
    }
}
