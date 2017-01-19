<Query Kind="Expression">
  <Connection>
    <ID>feebcedd-8c25-4c1f-a5e8-07016c18afd6</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//Aggregate Methods are executed against collections.
//The many end of a navgation property is considered as a collection
//When using a sub query with the collection source being a navigation and property onluy the 
//Records from the navigationcollection (Collection) that 
//Belongs to the navigation(Employee) parent are considered 
from x in Employees
where x.SupportRepIdCustomers.Count() > 0
select new {
	Title = x.Title,
	Name = x.FirstName+" "+x.LastName, 
	Phone = x.Phone,
	Customers = from y in x.SupportRepIdCustomers
				orderby y.LastName , y.FirstName
				select new{
					Name = y.LastName + ","+ y.FirstName,
					Company = y.Company,
					Phone = y.Phone,
					email = y.Email
				}
	

}