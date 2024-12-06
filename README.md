Event Management Application
An event management system built with ASP.NET Core (backend), Angular (frontend), and MSSQL (database). This app allows users to create events, purchase tickets, and manage orders.

Prerequisites
Before running the application, ensure the following software is installed on your machine:

.NET SDK (8.0 or above)
Node.js (16.x or above)
Angular CLI (15.x or above)
MSSQL Server
Git
Setup and Launch Instructions
1. Clone the Repository
bash
Copy code
git clone <repository-url>
cd EventManagementApp
2. Configure the Backend
Navigate to the backend project folder:

bash
Copy code
cd EventManagementBackend
Create a database in MSSQL Server and update the connection string in appsettings.json:

json
Copy code
"ConnectionStrings": {
  "DefaultConnection": "Server=<your-server>;Database=EventManagementDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}
Run database migrations to set up the schema:

bash
Copy code
dotnet ef database update
Launch the backend API:

bash
Copy code
dotnet run
The API will be available at: http://localhost:5000.

3. Configure the Frontend
Navigate to the Angular project folder:

bash
Copy code
cd EventManagementFrontend
Install dependencies:

bash
Copy code
npm install
Update the API endpoint in the environment file (src/environments/environment.ts):

typescript
Copy code
export const environment = {
  production: false,
  apiUrl: 'http://localhost:5000/api'
};
Run the Angular app:

bash
Copy code
ng serve
The app will be accessible at: http://localhost:4200.
