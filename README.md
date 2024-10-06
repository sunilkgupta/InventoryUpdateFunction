
<br/>
<div align="center">

<h3 align="center">Order change function</h3>
<p align="center">
Whenever there is update or create a new order in OrderService microservice. Then new entry or update happens to db. then immediately Azure order change function gets fired and updates the Inventory table column named quantity. It reduces the qty by new order received.


  


</p>
</div>

## About The Project

Very useful and prompt azure function which keeps awake and wait for any change to be happen in OrderService and update the Inventroy table.

Here's why:

- No waiting time
- Always warmed up
- Stored procedure handles all the business logic.
- Ado.net used for Azure SQL connection and data update.


### Built With

This section should list any major frameworks/libraries used to bootstrap your project. Leave any add-ons/plugins for the acknowledgements section. Here are a few examples.

- [C#](https://learn.microsoft.com/)
- [Azure Functions](www.portal.azure.com)
- [Ado.net](https://learn.microsoft.com/)
- [Json Serializer](https://learn.microsoft.com/)
- [Azure AppInsights](https://learn.microsoft.com/)
## Getting Started

Just run the application locally if you want to debug or make the any change here.
### Prerequisites

This is an example of how to list things you need to use the software and how to install them.

- Azure Subscription
### Installation

_Below is an example of how you can instruct your audience on installing and setting up your app. This template doesn't rely on any external dependencies or services._

1. Run the Order and Inventory microservices before.
2. Make sure, Inventory table is having some inventories before only.
3. Based on Inventroy data, make a fresh order.
4. Put the breakpoint at Azure Function and debug further.
5. Azure function updates the Inventory table.
6. Please get the db. logic details prior.
7. Azure SQL admin login details already shared over mail.
8. Please update the details in db connection
   
## Usage

Quick trunaround and async data between these tables and microservices

_For more examples, please refer to the [Documentation](https://portal.azure.com)_
## Contact

Your Name - [Sunil Kumar]

Project Link: [https://github.com/sunilkgupta/InventoryUpdateFunction](https://github.com/sunilkgupta)
