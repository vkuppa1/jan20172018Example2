﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Chinook.Data.Entities;
using ChinookSystem.DAL;
using System.ComponentModel;
using Chinook.Data.POCOs;
using Chinook.Data.DTOs;
#endregion

namespace ChinookSystem.BLL
{
    [DataObject]
    public class AlbumController
    {
    

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<AlbumArtist> ListAlbumsbyArtist()
        {
            using (var context = new ChinookContext())
            {
                var results = from x in context.Albums
                              orderby x.Artist.Name
                              select new AlbumArtist
                              {
                                  Artist = x.Artist.Name,
                                  Title = x.Title,
                                  ReleaseYear = x.ReleaseYear,
                                  ReleaseLabel = x.ReleaseLabel
                              };
                return results.ToList();
            }
        }//EOM


        [DataObjectMethod(DataObjectMethodType.Select, false)]


        //This is using the Linq
        public List<Album> Albums_GetForArtistbyName(string name)
        {
            using (var context = new ChinookContext())
            {

                var results = context.Albums.Where(x => x.Artist.Name.Contains(name))
                                .OrderByDescending(x => x.ReleaseYear);
                return results.ToList();
            }
        }   //EOM
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<AlbumArtistReleases> AlbumArtistRelease_List()
        {
            using (var context = new ChinookContext())
            {
                var results = from x in context.Albums
                              group x by x.Artist.Name into result
                              select new AlbumArtistReleases
                              {
                                  Artist = result.Key,
                                  Albums = (from y in result
                                            select new AlbumRelease
                                            {
                                                Title = y.Title,
                                                RYear = y.ReleaseYear,
                                                Label = y.ReleaseLabel
                                            }).ToList()
                              };
                return results.ToList();
            }


        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Album> Albums_GetbyTitle(string title)
        {
            using (var context = new ChinookContext())
            {
                var results = from x in context.Albums
                              where x.Title.Contains(title)
                              select x;
                return results.ToList();
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]

        public List<Album> Albums_List()
        {
            using (var context = new ChinookContext())
            {
                return context.Albums.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]

    public Album Albums_Get(int albumid)
        {
            using (var context = new ChinookContext())
            {
                return context.Albums.Find(albumid);
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public void Albums_Add(Album item)
        {
            using (var context = new ChinookContext())
            {
                context.Albums.Add(item);
                context.SaveChanges();

            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]

        public void Albums_Update(Album item)
        {
            using (var context = new ChinookContext())
            {
                context.Albums.Attach(item);
                item.ReleaseLabel = string.IsNullOrEmpty(item.ReleaseLabel) ? null : item.ReleaseLabel;

                context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                //Use this to update the command for selected fields.
                //context.Entry(instacevariablename).Property(y=>y.columnname)
                context.SaveChanges();

            }
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public void Albums_Delete(Album item)
        {
            Albums_Delete(item.AlbumId);
        }

       

        public void Albums_Delete(int albumid)
        {
            using (var context = new ChinookContext())
            {
                //Use any business rules.
                var existing = context.Albums.Find(albumid);
                if (existing == null)
                {
                    throw new Exception("It does not exists.");
                }
                context.Albums.Remove(existing);
                context.SaveChanges();
            }
        }

        
    }
}





