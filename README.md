# Pizza Shop

---

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

## **Table of Contents**

- [Description](#Description)

- [Usage](#usage)

- [Technology](#technology)

- [Contribution](#contribution)

- [Questions](#questions)

---

## **Description**

An application that allows the user to manage a pizza shop menu. In it, they are able to view a list of their available pizza toppings, add new toppings, edit existing toppings, and also delete any toppings the user no longer uses. Once there are toppings availale, the user can then create pizzas from the available toppings. There are no limits to how many toppings they can add, other than they will not be able to duplicate any toppings on the pizza. In the pizza section, they will be able to view all the available pizzas created, add a new pizza, edit any of the current pizza by changing their name or updating their toppings, or even delete any pizza they no longer want to offer. There are fail safes when creating and editing the toppings and pizzas that will prevent the user from adding/editing toppings with the same name and adding/editing pizzas with the same name or toppings offerings.

The application uses the Angular framework as the frontend as this allows for compartmentalizing the different components, toppings and pizzas, that will allow for easier reusability in the application and a separation of concerns when debugging. Choosing to use SQL as the database was due to my familiarity of using it and the easy integration that C#.NET offers. The combination of Bootstrap and PrimeNg allowed quicker styling of the frontend for the user.

---

## Usage

See the deployed version here through Heroku! [Deployed link](https://polar-badlands-40466-0c324e863975.herokuapp.com/)

To run the application locally, perform the following steps.

- Open your terminal.
- cd to the root folder (../Pizza_Shop) and enter npm install to ensure you have all the dependencies installed.
- After all the dependencies are installed, enter ng build in the root folder (../Pizza_Shop) to build the appliation.
- To run the backend server, cd to the backend root folder (../PizzaShopApi) and enter dotnet run.
- To start the application, cd to the root folder (../Pizza_Shop) and enter ng serve.

There are no tests installed for the application.

---

## **Technology**

- Angular
- C#.NET
- Typescript
- SQL
- npm
- Node.js
- Bootstrap
- PrimeNg

---

## **Contribution**

If you are looking to contribute the Pizza Shop app, you can find its repo at https://github.com/JMan4342/Pizza_Shop.

---

## **Questions**

If you have any questions, please feel free to reach out to me at manning.joseph.4342@gmail.com.
