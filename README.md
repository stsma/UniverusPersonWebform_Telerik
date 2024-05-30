## Univerus Technical Exam - Telerik

This is a technical exam for **Univerus** company. It uses **Dotnet 9.0** for the API and webforms for the client utilizing **Telerik** as UI framework.

The API Provides the interface for accessing data for **Persons** using **Clean Architecture**. For the data storage I used **In-memory database** feature by **Entity Framework Core 8.0**. For the documentation of the api I used **Swagger**. The API is then consume by a **ASP Web form** client that uses **Telerik AJAX** for the interface. The Client will display on Page 1 the lists of Persons of type Teacher and Students using telerik **RadGrid** control. The Page 2 will display the graph using RadHtmlChart, for the Person api from the given json endpoint.

### Clone the repository from here: ###
```
https://github.com/stsma/UniverusPersonWebform_Telerik.git
```

### Project Setup ###
After cloning the Project, go inside the project folder(as in the address bar of the image)

<img src="https://github.com/stsma/UniverusPersonWebform_Telerik/assets/18629077/5f3fc06e-b8f7-409e-945d-dfab7b2fc30b" width="250">

Open the solution file (.sln) to Visual Studio and you should have the same structures as below:

<img src="https://github.com/stsma/UniverusPersonWebform_Telerik/assets/18629077/604aa5f5-25c9-46eb-987a-5d98ff2635ac" width="210">

### Running the Project ###
Right-click on the Solution and go to properties

<img src="https://github.com/stsma/UniverusPersonWebform_Telerik/assets/18629077/db0e1c28-d319-402e-8176-4cdeb37a8a7a" width="200" >

Select Multiple startup projects. Choose the **UniverusPersonAPI** and **FE_Telerik** projects then apply changes.
<img src="https://github.com/stsma/UniverusPersonWebform_Telerik/assets/18629077/2bccebb5-34c8-4d96-93fe-047e52632b1d" width="400">

Clean and Build the project. Now you are ready to run it.
