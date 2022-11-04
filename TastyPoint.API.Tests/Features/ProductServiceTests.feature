Feature: ProductsServiceTests
    As a developer
    I want to add new Product through API
    In order to make it available for applications.
    
    Background: 
        Given the Endpoint https://localhost:7070/api/v1/products is available
    
        @product-adding
        Scenario: Add Product With Unique Name
            When a Post Request is sent
            | name || type   || PackId |
            | Rice || supply || 1      |
            Then A Response is received with Status 200
            And a Product Resource is included in Response Body
            | id | name || type   || PackId |
            | 3  | Rice || supply || 1      |
            
        @product-adding
        Scenario: Add Product with existing Name
            Given a Product is already stored
            | id || name     | type   | PackId |
            | 1  || Potatoes | supply | 1      |
            When a Post Request is sent
            | name     | type   | PackId |
            | Potatoes | supply | 1      |
            Then A Response is received with Status 400
            And An Error Message is returned with value "Product name already exists"