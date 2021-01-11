# Hahn.ApplicatonProcess.December2020

## for Back-End

Net 5.0 Rest Api Application 

- Swagger UI,
- EF Core 5.0,
- EF InMemory Database,
- Repository Pattern,
- UnitOfWork Pattern,
- Auto MapperFluend Validation,
- Serilog 


## for Front-End

- Aurelia Framework
- Webpack
- Typescript
- Bootstrap

Running The App


To run the app locally, follow these steps:

    Ensure that NodeJS is installed. This provides the platform on which the build tooling runs.
    From the project folder, execute the following command:

  npm install

##  Build the app in production mode

  npm run build
  
It builds all files to dist folder. To deploy to production server, copy all the `dist/*` files to production root folder.

## Unit Tests

    npm run test

Run unit tests in watch mode.

    npm run test:watch


## Analyze webpack bundle

    npm run analyze
