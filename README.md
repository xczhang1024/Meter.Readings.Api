# Api to accept meter readings

Endpoint POST /meter-reading-uploads processes a CSV of meter readings

Returns number of successful/failed readings

A reading is failed if

* It already exists in the database
* It is not associated with a valid account id
* It is not in the format of NNNNN

Limitation:

* If a row in the CSV contains more columns than is required, the CsvHelper CsvReader component does not reject that row
* There is a setting to reject the row, but it also throws an exception which stops the file reading completely
* This limitation could be mitigated, if there was more time