<Query Kind="Program">
  <Connection>
    <ID>feebcedd-8c25-4c1f-a5e8-07016c18afd6</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

void Main()
{
   //find artist who havwe a C in their name, order Alphabetically
   
   //Assume that the user enrterd a partial name of an artist on aweb form
   //or a web page and submitted the string to my controller as a parameter.
   var partialname = "c";
   

	var results = from x in Artists
				   where x.Name.Contains(partialname)
	orderby x.Name
	select new ArtistList
	{
	ArtistId = x.ArtistId,
	Name = x.Name
    };
    results.Dump("Artist List");
	//Scince the subquery is defined in the dto class as a List<T> we must cast the subquery with .ToList
var resultsDTO = from x in Artists  
			select new DTOClass{
			Artist = x.Name,
			Albums = (from y in x.Albums 
			select new POCOClass{
					Title = y.Title,
					Year = y.ReleaseYear
			}).ToList() 
};
results.Dump("Artist Albums");
}

// Define other methods and classes here
public class ArtistList
{
	public int ArtistId{get;set;}
	public string Name{get;set;}
}

public class DTOClass
{//Can have the flat fields and  the plane fields and collection typs
	public string Artist {get;set;}
	public List<POCOClass> Albums {get;set;}
}
public class POCOClass
{
//Can have plain or flat fields
   public string Title {get; set;}
   public int Year {get;set;} 
}