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
        if(string.IsNullOrEmpty(SearchArg.Text))
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
                if(albumlist.Count == 0)
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
       

    }

    protected void AddAlbum_Click(object sender, EventArgs e)
    {
       
       
    }
    protected void UpdateAlbum_Click(object sender, EventArgs e)
    {
       
    }
    protected void DeleteAlbum_Click(object sender, EventArgs e)
    {
       
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