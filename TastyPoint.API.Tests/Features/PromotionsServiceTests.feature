Feature: PromotionsServiceTests
As a Business
I want to create promotions for the Packs I created
In order to be able to sell the most to my clients.

    Background:
        Given the Endpoint https://localhost:7070/api/v1/promotions is available

    @promotions-adding
    Scenario: Add Promotion with unique Title
        When a Post Request is sent
          | Title        | SubTitle                                     | Description                                         | Image                 | PackId |
          | Family combo | Share this fast food combo with your family. | 4 hamburgers + 4 personal drinks + 4 ice cream cups | FamiliarFastCombo.jpg | 1      |
        Then A Response is received with Status 200
        And A Promotion Resource is included in Response Body
          | id | Title        | SubTitle                                     | Description                                         | Image                 | PackId |
          | 1  | Family combo | Share this fast food combo with your family. | 4 hamburgers + 4 personal drinks + 4 ice cream cups | FamiliarFastCombo.jpg | 1      |
          
