# WGU C# Capstone Project
## Plant Locator Tool

This capstone project was created to solve a real life work issue at my previous job.

The job was at a call center for a large food and beverage company. The company used an internal knowledge base system to maintain information that all of the call center representatives would use during consumer contacts. This information also included plant/warehouse details so the reps could see where products were produced/distributed from. 

# The Problem

The company also used the Google Earth Desktop application to store plant/warehouse information so that the reps could search for the closest plants/warehouses to a given area by zip code. 

Maintaining information in both places led to a duplication of work as well as possible outdated information being stored in either the knowledge base system or Google Earth. 

# The Solution
This project aimed to solve this issue by combining the features of Google Earth as well as being able to easily store plant/warehouse information in a single application. 

The application was creating using C# and WPF. Instead of Google Earth/Maps it used Bing Maps as the map service. For data storage it used a MySQL database. 

The application also handled creating users with different access types (Admin or User). Admins are able to create other users, update their account information and add/delete/update any plant/warehouse information. 

When adding a new plant/warehouse, after entering the information the application will make a request to the Bing Maps Rest Services to geocode the location and return a lattitude/longitude. With this information returned a pin would be created on the map with all of the information and then added to the database. Now whenever a user clicked on the pin it would load the associated plant/warehouse information on a sidebar within the app. This information includes the name, address, phone number, and products. 

When updating the information the application would update the plant/warehouse information, as well as send a new geocode location request and update the pin location.

