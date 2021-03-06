# CheckoutPaymentGateway

Purpose 


	• Process a Payment request from a Merchant and stores the Information in a Local Database and then send to a Bank to get the Status of the payment whether it is successful or Unsuccessful
	• Merchant is able to request the payment via Merchant Id and Payment Id
	• The API is captures the Data in a Json Response using the Endpoints



Request Format - Json
Payment request Example [HTTP POST]

	http://localhost:5002/api/ProcessPaymentRequestapi


	{
	    "amount": 100,
	    "currency": "123",
	    "description": "second",
	    "Card": {
	        "cvv": "GPB",
	        "card_number": "1234123412341234",
	        "expiry_month": 1,
	        "expiry_year": 2020
	    },
	    "merchantid": 1
	}
		
	Response 

	If Amount is not valid - 	404 Bad Request
	If MerchantId does not exist -	404 Not Found
	Payment Successfully Process -	200 Ok



Get From Payment History [HTTP GET]

	http://localhost:5002/api/PaymentHistory/{merchantId}/payment/{paymentId}"


	Response

	If either or neither MerchantId or PaymentRequestId exist -	404 Not Found
	If Successful -	200 Ok
 


Unit Test

	I created an In Memory DB to test the Controller and Moq the Bank Response for the request
	The unit test test the Status Code and some of the Content of the Response to ensure that it is doing what is required

Postman

	I used Postman to test Endpoints request and receive Reponses.
	I also used it whilst I was programming for reassurance that my model states validations and error messages


Given Extra Time I'd would

	• Add a Dbset of Bank Response for the merchant
	• Add Unit testing  for also Model State 
	• Test on other devices, currently I am using a Mac book, my connection strings for my Local DB may not work for other devices.
	• Add Authentication and Authorization for the Merchant to limit what access to the data they had (Tokens)
	• To have it reviewed by another developer
	• Improve my naming conventions and method names
	• Encrypt vulnerable data to increase security
   	• Add Middleware to log exceptions I may have missed
    	• Refactor and polish my code to make it more readable
	• Improve the effiency by considering Big O Notation
    
