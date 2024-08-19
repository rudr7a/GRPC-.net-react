GRPC .NET React Service


Overview

   This project combines a .NET gRPC service with a React application to provide a simple demo of gRPC communication between a client and server. The gRPC service is designed to handle specific tasks, and the React app serves as a user interface to interact with the service.

Purpose

  The purpose of this service is to demonstrate how gRPC services can be integrated into a web application using .NET on the server side and React on the client side. This setup is ideal for scenarios where you need high-performance, reliable communication           between different parts of your application.

How to Run Locally

  To run this project on your local machine, follow these steps:

1. Clone the Repository
 
       git clone https://github.com/rudr7a/GRPC-.net-react.git
       cd GRPC-.net-react

2. Set Up the .NET gRPC Service
 
   Navigate to the directory containing the gRPC service.   

Update the appsettings.json file with your PostgreSQL connection string:

      {
        "ConnectionStrings": {
          "DefaultConnection": "Your-PostgreSQL-Connection-String"
        }
      }

Run the service

3. Set Up the React App
   
      The React app is located in a different branch named react-app. To access and run it:

Switch to the react-app branch:

      git checkout react-app

Navigate to the React app directory.

  Install the dependencies:

      npm install

Start the React development server:

      npm start

The React app should now be running at http://localhost:3000 and should be able to communicate with the gRPC service running on https://localhost:5001.

Live Demo

     https://rudr7a.github.io/GrpcHost/

Branch Information

  The main branch contains the .NET gRPC service.
  The react-app branch contains the React application.


Cheers :)))
