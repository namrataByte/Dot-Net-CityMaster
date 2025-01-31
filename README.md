# CityMaster

*CityMaster* is a web application built during my internship to manage and display city information. The project features basic CRUD (Create, Read, Update, Delete) operations and introduces a unique left-right column swap operation to organize city data.

## Features
- **City List Display**: The app displays a list of city records, including the city code, city name, and options to edit or delete each entry.
- **Left and Right Columns**: City records are initially added to the right column by default.
- **Move City Between Columns**: Each city record has an action button labeled "Move to Left" when it’s in the right column. Clicking this button moves the city to the left column, and the button changes to "Move to Right." The reverse happens for cities in the left column.
- **Move All Records**: There are two buttons at the top of the table: "Move All to Left" and "Move All to Right," which allow users to move all records between the left and right columns at once.
- **CRUD Operations**: Users can add new cities, update existing ones, or delete them.
- **Responsive UI**: Designed with a simple, user-friendly interface that enhances the management of city records.

## Technologies Used
- **ASP.NET Core MVC**: Used for building the backend with the Model-View-Controller architecture.
- **SQL Server**: Used for storing city data in a relational database.
- **HTML/CSS**: Used for structuring and styling the front-end.
- **JavaScript**: Used for dynamic interactions, such as handling the column swaps and updating the UI.
- **Bootstrap**: Used for styling and ensuring the application is responsive and looks good on various devices.

## How It Works
- **City Record Layout**: The city records are displayed in two columns:
  - **Left Column**: Initially empty or contains selected city records moved from the right.
  - **Right Column**: Contains new city records by default.
  
  Each city record has an action button:
  - **"Move to Left"**: Moves the city from the right column to the left column and changes the button to **"Move to Right"**.
  - **"Move to Right"**: Moves the city from the left column to the right column and changes the button to **"Move to Left"**.

- **"Move All to Left"**: Moves all city records from the right column to the left column.
- **"Move All to Right"**: Moves all city records from the left column to the right column.

## Database Schema
The following tables are used in the database:

- **City**: Stores information about cities.
  - `cityId` (Primary Key)
  - `cityName`
