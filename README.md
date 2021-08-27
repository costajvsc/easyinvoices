<p align="center">
  <a href="https://github.com/costajvsc/dailytasks">
    <img src="./public/images/logo.png" alt="Logo" width="80" height="80">
  </a>

  <h3 align="center">Easyinvoices</h3>

  <p align="center">
    Manager your customers, plans and invoices.
    <br />
    <a href="#">View Demo</a>
    ·
    <a href="https://github.com/costajvsc/easyinvoces/issues">Report Bug</a>
    ·
    <a href="https://github.com/costajvsc/easyinvoces/issues">Request Feature</a>
  </p>
</p>

<details open="open">
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
    </li>
    <li><a href="#features">Features</a></li>
        <ul>
            <li><a href="#back-end">Back-end</a></li>
            <li><a href="#front-end">Front-end</a></li>
        </ul>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#knowledge">Knowledge</a></li>
  </ol>
</details>

## About The Project

Easyinvoces is a project to help you manage your customers invoices. With easyinvoices you can save all your customers and create invoices based on plans.  

### Here's why:
* Code a API project using .NET Framework.
* Understand full cycle to schedule, implement, publish and improve a web application.
* Use this to show my abilities with programming and software development.

### Built With

Easyinvoces was built with those frameworks and library. 
* [.Net 5](https://dotnet.microsoft.com/download/dotnet/5.0)

## Getting Started

To get a local copy up and running follow these simple example steps. You need install `.NET 5`, `Sql Server` and `npm` in your environment setup. 

1. Clone the repository
   ```sh
   git clone https://github.com/costajvsc/easyinvoces.git
   ```

### API
2. Configure your API and `appsettings.json` 

  ```sh
    cd api
    mv appsettings.Development.json appsettings.json
  ```

3. Configure connection string on `appsettings.json` 
  ```json
    {
        "Logging": {
            "LogLevel": {
            "Default": "Information",
            "Microsoft": "Warning",
            "Microsoft.Hosting.Lifetime": "Information"
            }
        },
        "AllowedHosts": "*",
        "ConnectionStrings": {
            "connection": "Server=localhost;database=easyinvoice;user=SA;password=" 
        }
    }
  ```

4. Update your database

  ```sh
    dotnet ef database update
  ```

5. Start your API

  ```sh
    dotnet watch run
  ```

## Features

### Back-end
- [X] CRUD Invoices
- [X] CRUD Customers
- [X] CRUD Plans
- [X] Docker file to deploy
- [ ] List data with filter and pagination 
- [ ] Implement HATEOAS API
- [ ] Unit testing

### Front-end 
- [ ] Implement a lading page.
- [ ] Interface to access CRUDs entities.
- [ ] Using `alerts` to show response content from API.

## Contributing

Contributions are what make the open source community such an amazing place to be learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## License 
This project is licensed under the [MIT license](https://opensource.org/licenses/MIT)

## Contact

João Victor - [LinkedIn](https://www.linkedin.com/in/victor-costa-jvsc/) - costa.jvsc@gmail.com

Project Link: [https://github.com/costajvsc/easyinvoces](https://github.com/costajvsc/easyinvoces)

## Knowledge
* MVC Architecture to build a API
* Use migrations and code-first to model Db application
* Full cycle development and deploy app with Docker 
