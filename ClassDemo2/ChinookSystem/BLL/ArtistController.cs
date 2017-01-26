using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Chinook.Data.Entities;
using ChinookSystem.DAL;
using System.ComponentModel;
using Chinook.Data.POCOs;
#endregion
namespace ChinookSystem.BLL
{
    [DataObject]
    public class ArtistController
    {
        //dump all the instances of the eentity.
        //Dump Using the 
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<Artist> Artist_ListAll()
        {
            using(var context = new ChinookContext())
                {
                //THis is not using the Linq
                return context.Artists.ToList();
            }
        }

        //Dump Using the entity vis primary Key.
        public  Artist Artist_Get (int artistid)
        {
            using (var context = new ChinookContext())
            {
                //THis is not using the Linq
                return context.Artists.Find(artistid);
            }
        }

    }
}
