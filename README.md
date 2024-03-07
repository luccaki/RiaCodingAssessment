
# Coding Assessemnt for Ria Money Transfer

## REST Server:

### GET api/v1/customer

Reponse Body:

    [
      {
        "lastName": "string",
        "firstName": "string",
        "age": 0,
        "id": 0
      }
    ]

### POST api/v1/customer

Request Body:

    [
      {
        "lastName": "string",
        "firstName": "string",
        "age": 0,
        "id": 0
      }
    ]

Response Body:

    {
      "arrayLength": 1,
      "failedCustomers": [
        {
          "failedCustomer": {
            "lastName": "string",
            "firstName": "string",
            "age": 0,
            "id": 0
          },
          "error": "Id 0 is already been used!"
        }
      ]
    }


## Test Simulator:
Solution inside RiaMoneyTransfer.TestSimulator folder
