* ProductApplicationService needs to be modified in order to add a new IProduct type, violation of the open-closed prinicple, this class will very quickly get out of control as products are added and will be difficult to test.
* ProductApplicationTests does not appear to actually test production code but instead verifies that a mock IConfidentialInvoiceService is configured correctly
* If more time were available tests would be added for ExternalServiceRequest of ConfidentialInvoiceDiscount and SelectiveInvoiceDiscount
