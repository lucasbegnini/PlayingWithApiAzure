# PlayingWithApiAzure

# URL - http://todoapi20180506035637.azurewebsites.net

#GET - /todo/
get all elements
Return: All elements in Json Format

#GET - /todo/{id}
get info about a {id} element
Return: A element info in Json Format

#POST /todo/
Create a new element
Paramenters:
{
	"name":"sing dog"
}
Return: All info about element that was add

#PUT /todo/{id}
Update a {id} element info.
Return: 200 OK

#DELETE /todo/{id}
Delete a {id} element info.
Return: 200 OK