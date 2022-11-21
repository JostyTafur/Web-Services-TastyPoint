Feature: OrderServiceTests
    As a developer
    I want to add new Order through API
    In order to make it available for applications.
    
    Background: 
        Given the Endpoint https://localhost:7070/api/v1/orders is available
        @order-adding
        Scenario: Add Order With Unique Name
            When a Post Request is sent
            | Delivery || paymentMethod || status    | userProfileId |
            | Rice     || cash          || Preparing | 1             |
            Then A Response is received with Status 200
            And a Order Resource is included in Response Body
            | id| Delivery || paymentMethod || status    | userProfileId |
            | 1 | Rice     || cash          || Preparing | 1             |