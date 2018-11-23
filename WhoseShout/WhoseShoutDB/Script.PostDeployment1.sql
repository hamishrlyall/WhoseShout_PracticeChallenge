/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

IF '$(LoadTestData)' = 'true'

BEGIN

INSERT INTO Colleagues (ColleagueId, [name], email) VALUES
(1, 'Hamish', 'hamishrlyall@gmail.com'),
(2, 'Jim', 'jimbo@gmail.com'),
(3, 'Jam', 'marmelade@gmail.com');

INSERT INTO coffeeDate (coffeeDateID, [name], email, [dateTime], venue, SPENT) VALUES
(9, 'Hamish', 'hamishrlyall@gmail.com', '2018/11/23 09:59:20.999', 'deco', 0),
(8, 'Jim', 'jimbo@gmail.com', '2018/11/15 10:30:24.999', 'coffee House', 0),
(7, 'Jam', 'marmelade@gmail.com', '2018/11/10 11:24:32.999', 'Caffeine' , 0);

END;