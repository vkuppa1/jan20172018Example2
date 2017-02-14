using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Namespaces
using Chinook.Data;
using ChinookSystem.BLL;
using Chinook.UI;
using Chinook.Data.Entities;
#endregion

public partial class SamplePages_CRUDReview : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SelectedTitle.Text = "";
    }

    protected void Search_Click(object sender, EventArgs e)
    {
        //Clear out the old album information on the maintain tab.
        Clear_Click(sender, e);
        if (string.IsNullOrEmpty(SearchArg.Text))
        {
            MessageUserControl1.ShowInfo("Please Enter an Album Title or part of the title");
        }
        else
        {
            //Lookup of the data in the database.We are the controller all actions all the external to the 
            //web page should be done through a try catch. From a friendly error handling.
            //We will use the mesageusercotrol to handle error messages for this semester.
            MessageUserControl1.TryRun(() =>
            {
                //Coding block I wish message user control to try and run and check the checking for 
                //any errors catching the errors and displaying set errors sfor me in its error panel.
                //What is left for me to do is simply the logicc for me to do the event.

                //This is a standard lookup
                AlbumController sysmgr = new AlbumController();
                List<Album> albumlist = sysmgr.Albums_GetbyTitle(SearchArg.Text);
                if (albumlist.Count == 0)
                {
                    //Title String,message string
                    MessageUserControl.ShowInfo("Search Result",
                                                 "No data for the album title or the partial title  " + SearchArg.Text);
                    AlbumList.DataSource = null;
                    AlbumList.DataBind();

                }
                else
                {
                    MessageUserControl.ShowInfo("Using Instructions",
                                                 "Select the desired album for the maintenece.");
                    AlbumList.DataSource = albumlist;
                    AlbumList.DataBind();


                }
            }
            );
        }
    }



    protected void AlbumList_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Coming from tab Find and also displaying tab find .
        GridViewRow agvrow = AlbumList.Rows[AlbumList.SelectedIndex];
        string albumid = (agvrow.FindControl("AlbumID") as Label).Text;
        string albumtitle = (agvrow.FindControl("Title") as Label).Text;
        string albumyear = (agvrow.FindControl("Year") as Label).Text;
        string albumlabel = (agvrow.FindControl("AlbumLabel") as Label).Text;
        string artistid = (agvrow.FindControl("ArtistID") as Label).Text;

        SelectedTitle.Text = albumtitle + "release in" + albumyear + "by" + albumlabel;

        AlbumID.Text = albumid;
        AlbumTitle.Text = albumtitle;
        ArtistList.SelectedValue = artistid;
        AlbumReleaseYear.Text = albumyear;
        AlbumReleaseLabel.Text = albumlabel;

    }

    protected void AddAlbum_Click(object sender, EventArgs e)
    {
        //Re test the validation of the incoming data via the validation controls.
        if (IsValid)
        {
            //Any other business rules 
            MessageUserControl2.TryRun(() =>
            {
                AlbumController sysmgr = new AlbumController();
                Album newalbum = new Album();
                newalbum.Title = AlbumTitle.Text;
                newalbum.ArtistId = int.Parse(ArtistList.SelectedValue);
                newalbum.ReleaseYear = int.Parse(AlbumReleaseYear.Text);
                newalbum.ReleaseLabel = string.IsNullOrEmpty(AlbumReleaseLabel.Text) ? null : AlbumReleaseLabel.Text;
                sysmgr.Albums_Add(newalbum);

            }, "Add Album", "Album has been succesfully add!!");
        }

    }
    protected void UpdateAlbum_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(AlbumID.Text))
        {
            MessageUserControl2.ShowInfo("Missing Data", "ad");

        }
        else
        {

            //Any other business rules 

            int albumid = 0;
            if (int.TryParse(AlbumID.Text, out albumid))
            {

                MessageUserControl2.TryRun(() =>
                {
                    AlbumController sysmgr = new AlbumController();
                    Album newalbum = new Album();
                    newalbum.Title = AlbumTitle.Text;
                    newalbum.ArtistId = int.Parse(ArtistList.SelectedValue);
                    newalbum.ReleaseYear = int.Parse(AlbumReleaseYear.Text);
                    newalbum.ReleaseLabel = string.IsNullOrEmpty(AlbumReleaseLabel.Text) ? null : AlbumReleaseLabel.Text;
                    sysmgr.Albums_Update(newalbum);

                }, "Update Album", "Album has been succesfully updated!!");
            }
            else
            {
                MessageUserControl2.ShowInfo("Invalid Data", "Album Id. Use Find to locate the album.");
                                                                                                                
            }
        }

    }
    protected void DeleteAlbum_Click(object sender, EventArgs e)
    {

        if (string.IsNullOrEmpty(AlbumID.Text))
        {
            MessageUserControl2.ShowInfo("Missing Data", "Missing Album Id. Use Find to locate the album you wish to maintain.");
        }
        else
        {
            int albumid = 0;
            if (int.TryParse(AlbumID.Text, out albumid))
            {
                MessageUserControl2.TryRun(() =>
                {
                    AlbumController sysmgr = new AlbumController();

                    sysmgr.Albums_Delete(albumid);
                }, "Update Album", "Album has been successfuly update on the database.");
            }
            else
            {
                MessageUserControl2.ShowInfo("Invalid Data", "Album Id. Use Find to locate the album you wish to maintain.");
            }
        }

    }
    protected void Clear_Click(object sender, EventArgs e)
    {
        AlbumID.Text = "";
        AlbumTitle.Text = "";
        AlbumReleaseYear.Text = "";
        AlbumReleaseLabel.Text = "";
        ArtistList.SelectedIndex = 0;
    }

    protected void CheckForException(object sender, ObjectDataSourceStatusEventArgs e)
    {
        MessageUserControl.HandleDataBoundException(e);
    }

}