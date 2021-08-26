# Customer Api
REST API created as part of NVR's interview process.

Performs Inserts and allows retrieval of customer records.

## Endpoints
* api/customer/get - GET request to get all customer information, no parameters needed.
* api/customer/add - POST request to add a new Customer, body of request defined as json the JSON section below.

## JSON POST Request body
```
{
    "FirstName": "string",
    "LastName": "string",
    "EmailAddress": "string",
    "PhoneNumber": "string"
}
```

## Constraints
* Email is a required field in the add endpoint.

## Useability
* In dev/debug, starts up loading swagger to allow for better visual representation of endpoints and ability to hit endpoints from browser.
* Any api tool (Postman,...) and hitting endpoints as described in the Endpoints section, with the localhost url.

## Functionality
* Stores data in customer.txt file within solution, data stored as json.

## Future ideas
* Unit Tests
* Configuration, remove hardcoded values
* Provide better validation
* Authorization
