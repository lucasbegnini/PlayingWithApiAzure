# PlayingWithApiAzure

# URL BASE - http://todoapi20180506035637.azurewebsites.net/api

#Get - /todo/
get all elements
Return: All elements in Json Format

#Get - /todo/{id}
get info about a {id} element
Return: A element info in Json Format

#Post /todo/
Create a new element
Paramenters:
{
	"name":"sing dog"
}
Return: All info about element that was add

#Put /todo/{id}
Update a {id} element info.
Return: 200 OK

#Delete /todo/{id}
Delete a {id} element info.
Return: 200 OK