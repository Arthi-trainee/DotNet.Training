CREATE DATABASE TrainReservation;
USE TrainReservation;
--------------------------------------------------------------------------------------
 CREATE TABLE Trains (
    TrainNo INT PRIMARY KEY, 
    TrainName VARCHAR(50) NOT NULL,
    Total1A INT , 
    Available1A int ,
    Total2A INT,  
    Available2A INT , 
    Total3A INT,
    Available3A INT , 
    TotalSleeper INT , 
    AvailableSleeper INT ,
    TotalFirstClass INT , 
    AvailableFirstClass INT, 
    Source VARCHAR(50) NOT NULL, 
    Destination VARCHAR(50) NOT NULL, 
    IsActive BIT DEFAULT 1 
);

ALTER TABLE Trains
ADD TicketPrice1A DECIMAL(10, 2),
    TicketPrice2A DECIMAL(10, 2),
    TicketPrice3A DECIMAL(10, 2),
    TicketPriceFirstClass DECIMAL(10, 2),
    TicketPriceSleeper DECIMAL(10, 2);

ALTER TABLE Trains
ADD TrainDate DATE ,
    TrainTime TIME ;

	
INSERT INTO Trains
VALUES
(12755, 'Chennai Express', 10, 10, 20, 20, 30, 30, 40, 40, 5, 5,
'Chennai', 'Delhi', 1, 3500.00, 2500.00, 1500.00, 4000.00, 800.00,
'2024-12-25', '18:00:00');
 INSERT INTO Trains
VALUES
(1806331, 'Delhi Express', 12, 12, 18, 18, 25, 25, 50, 50, 6, 6,
'Delhi', 'Banglore', 1, 3600.00, 2600.00, 1600.00, 4200.00, 850.00,
'2024-12-27', '11:00:00');



select*from trains
select*from bookings



drop table trains
drop table bookings
------------------------------------------------------------------------------------------------------------------------
 CREATE TABLE Bookings (
    BookingID INT IDENTITY PRIMARY KEY,        
    TrainNo INT NOT NULL,                      
    PassengerName VARCHAR(50) NOT NULL,        
    Class VARCHAR(20) NOT NULL CHECK (Class IN ('1A', '2A', '3A', 'First Class', 'Sleeper')),
    BerthsBooked INT NOT NULL,               
    JourneyDate DATE NOT NULL,                 
    Status VARCHAR(20) DEFAULT 'Booked' CHECK (Status IN ('Booked', 'Cancelled')),
    TotalCost DECIMAL(10, 2) NULL,             
    TrainDate DATE,                            
    TrainTime TIME,                           
    FOREIGN KEY (TrainNo) REFERENCES Trains(TrainNo) 
);
 
 

select  * from trains
 select * from bookings
-------------------------------------------------------------------------------------------------------------------------------------------------------
 CREATE TABLE AdminTable (
    AdminID INT PRIMARY KEY IDENTITY,
    Username VARCHAR(50) NOT NULL UNIQUE,
    Password VARCHAR(50) NOT NULL
);

INSERT INTO AdminTable (Username, Password)
VALUES ('Arthi', '1806354');

select *from AdminTable

CREATE or alter  PROCEDURE ValidateAdmin
    @Username VARCHAR(50),
    @Password VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
 
    IF EXISTS (
        SELECT 1
        FROM AdminTable
        WHERE Username = @Username AND Password = @Password
    )
    BEGIN
        SELECT 'Valid' AS Status;
    END
    ELSE
    BEGIN
        SELECT 'Invalid' AS Status;
    END
END;
--------------------------------------------------------------------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE AddTrain
    @TrainNo INT,
    @TrainName VARCHAR(50),
    @Total1A INT,
    @Total2A INT,
    @Total3A INT,
    @TotalFirstClass INT,
    @TotalSleeper INT,
    @Source VARCHAR(50),
    @Destination VARCHAR(50),
    @TicketPrice1A DECIMAL(10, 2),
    @TicketPrice2A DECIMAL(10, 2),
    @TicketPrice3A DECIMAL(10, 2),
    @TicketPriceFirstClass DECIMAL(10, 2),
    @TicketPriceSleeper DECIMAL(10, 2),
    @TrainDate DATE,
    @TrainTime TIME 
AS
BEGIN

    INSERT INTO Trains 
    (
        TrainNo, 
        TrainName, 
        Total1A, 
        Total2A, 
        Total3A, 
        TotalFirstClass, 
        TotalSleeper, 
        Available1A, 
        Available2A, 
        Available3A, 
        AvailableFirstClass, 
        AvailableSleeper, 
        Source, 
        Destination, 
        TicketPrice1A, 
        TicketPrice2A, 
        TicketPrice3A, 
        TicketPriceFirstClass, 
        TicketPriceSleeper, 
        TrainDate, 
        TrainTime, 
        IsActive
    )
    VALUES 
    (
        @TrainNo, 
        @TrainName, 
        @Total1A, 
        @Total2A, 
        @Total3A, 
        @TotalFirstClass, 
        @TotalSleeper, 
        @Total1A,  
        @Total2A, 
        @Total3A, 
        @TotalFirstClass,
        @TotalSleeper,   
        @Source, 
        @Destination, 
        @TicketPrice1A, 
        @TicketPrice2A, 
        @TicketPrice3A, 
        @TicketPriceFirstClass, 
        @TicketPriceSleeper, 
        @TrainDate, 
        @TrainTime, 
        1 
    );
END;
 
--------------------------------------------------------------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE ModifyTrain
    @TrainNo INT,
    @TrainName VARCHAR(50),
    @Source VARCHAR(50),
    @Destination VARCHAR(50),
    @TicketPrice1A DECIMAL(10, 2),
    @TicketPrice2A DECIMAL(10, 2),
    @TicketPrice3A DECIMAL(10, 2),
    @TicketPriceFirstClass DECIMAL(10, 2),
    @TicketPriceSleeper DECIMAL(10, 2)
AS
BEGIN
    UPDATE Trains
    SET TrainName = @TrainName,
        Source = @Source,
        Destination = @Destination,
        TicketPrice1A = @TicketPrice1A,
        TicketPrice2A = @TicketPrice2A,
        TicketPrice3A = @TicketPrice3A,
        TicketPriceFirstClass = @TicketPriceFirstClass,
        TicketPriceSleeper = @TicketPriceSleeper
    WHERE TrainNo = @TrainNo AND IsActive = 1;
END;
--------------------------------------------------------------------------------------------------------------------------------------------

CREATE or alter PROCEDURE DeleteTrain
    @TrainNo INT
AS
BEGIN
    UPDATE Trains 
    SET IsActive = 0
    WHERE TrainNo = @TrainNo;
END;
---------------------------------------------------------------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE BookTicket 
    @TrainNo INT, 
    @PassengerName VARCHAR(100), 
    @Class VARCHAR(20), 
    @BerthsBooked INT, 
    @JourneyDate DATE, 
    @TrainDate DATE, 
    @TrainTime TIME, 
    @TotalCost DECIMAL(10, 2) OUTPUT
AS
BEGIN
    
    IF @TrainDate < CAST(GETDATE() AS DATE)
    BEGIN
        PRINT 'Error: Cannot book ticket for a past train date.';
        RETURN;
    END
 
    DECLARE @TicketPrice DECIMAL(10, 2), 
            @AvailableBerths INT;
 
   
    SELECT 
        @TicketPrice = CASE 
                            WHEN @Class = '1A' THEN TicketPrice1A 
                            WHEN @Class = '2A' THEN TicketPrice2A 
                            WHEN @Class = '3A' THEN TicketPrice3A 
                            WHEN @Class = 'First Class' THEN TicketPriceFirstClass 
                            WHEN @Class = 'Sleeper' THEN TicketPriceSleeper 
                        END,
        @AvailableBerths = CASE 
                                WHEN @Class = '1A' THEN Available1A 
                                WHEN @Class = '2A' THEN Available2A 
                                WHEN @Class = '3A' THEN Available3A 
                                WHEN @Class = 'First Class' THEN AvailableFirstClass 
                                WHEN @Class = 'Sleeper' THEN AvailableSleeper 
                            END
    FROM Trains 
    WHERE TrainNo = @TrainNo AND TrainDate = @TrainDate AND TrainTime = @TrainTime;
 
   
    IF @AvailableBerths IS NULL
    BEGIN
        PRINT 'Train not found or invalid class.';
        RETURN;
    END
 
    
    IF @AvailableBerths < @BerthsBooked
    BEGIN
        PRINT 'Not enough berths available.';
        RETURN;
    END
 
    
    SET @TotalCost = @TicketPrice * @BerthsBooked;
 
  
    INSERT INTO Bookings (TrainNo, PassengerName, Class, BerthsBooked, JourneyDate, TrainDate, TrainTime, TotalCost, Status)
    VALUES (@TrainNo, @PassengerName, @Class, @BerthsBooked, @JourneyDate, @TrainDate, @TrainTime, @TotalCost, 'Booked');
 
   
    IF @Class = '1A'
        UPDATE Trains SET Available1A = Available1A - @BerthsBooked WHERE TrainNo = @TrainNo;
    ELSE IF @Class = '2A'
        UPDATE Trains SET Available2A = Available2A - @BerthsBooked WHERE TrainNo = @TrainNo;
    ELSE IF @Class = '3A'
        UPDATE Trains SET Available3A = Available3A - @BerthsBooked WHERE TrainNo = @TrainNo;
    ELSE IF @Class = 'First Class'
        UPDATE Trains SET AvailableFirstClass = AvailableFirstClass - @BerthsBooked WHERE TrainNo = @TrainNo;
    ELSE IF @Class = 'Sleeper'
        UPDATE Trains SET AvailableSleeper = AvailableSleeper - @BerthsBooked WHERE TrainNo = @TrainNo;
 
   
    PRINT 'Booking successful. Total ticket cost: ' + CAST(@TotalCost AS VARCHAR(50));
END;
 
 
------------------------------------------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE CancelTicket 
    @BookingID INT, 
    @RefundAmount DECIMAL OUTPUT
AS
BEGIN
    DECLARE @TrainNo INT, 
            @Class VARCHAR(20), 
            @BerthsBooked INT, 
            @Status VARCHAR(20), 
            @TotalCost DECIMAL;
 
    
    SELECT @TrainNo = TrainNo, 
           @Class = Class, 
           @BerthsBooked = BerthsBooked, 
           @Status = Status, 
           @TotalCost = TotalCost
    FROM Bookings 
    WHERE BookingID = @BookingID;
 
   
    IF @Status = 'Booked'
    BEGIN
        
        IF @Class = '1A' 
        BEGIN 
            UPDATE Trains 
            SET Available1A = Available1A + @BerthsBooked 
            WHERE TrainNo = @TrainNo; 
        END
        ELSE IF @Class = '2A' 
        BEGIN 
            UPDATE Trains 
            SET Available2A = Available2A + @BerthsBooked 
            WHERE TrainNo = @TrainNo; 
        END
        ELSE IF @Class = '3A' 
        BEGIN 
            UPDATE Trains 
            SET Available3A = Available3A + @BerthsBooked 
            WHERE TrainNo = @TrainNo; 
        END
        ELSE IF @Class = 'First Class' 
        BEGIN 
            UPDATE Trains 
            SET AvailableFirstClass = AvailableFirstClass + @BerthsBooked 
            WHERE TrainNo = @TrainNo; 
        END
        ELSE IF @Class = 'Sleeper' 
        BEGIN 
            UPDATE Trains 
            SET AvailableSleeper = AvailableSleeper + @BerthsBooked 
            WHERE TrainNo = @TrainNo; 
        END
 
        
        UPDATE Bookings 
        SET Status = 'Cancelled' 
        WHERE BookingID = @BookingID;
 
        
        SET @RefundAmount = @TotalCost * 0.85;
 
        PRINT 'Cancellation successful.';
    END
    ELSE
    BEGIN
        PRINT 'Cancellation failed. Booking not found or already cancelled.';
        SET @RefundAmount = 0;
    END
END;
 
--------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE ShowAllTrains
AS
BEGIN
    SELECT
        TrainNo,
        TrainName,
        Source,
        Destination,
        Available1A,
        Available2A,
        Available3A,
        AvailableFirstClass,
        AvailableSleeper,
        TrainDate,  
        FORMAT(TrainTime, 'hh:mm tt') AS TrainTimeInAMPM  
    FROM
        Trains
    WHERE
        IsActive = 1 
    ORDER BY
        TrainNo;  
END;

exec   ShowAllTrains;
----------------------------------------------------------------------------------------------------------------------
CREATE or alter PROCEDURE ShowAllBookings

AS

BEGIN

    SELECT BookingID, TrainNo, PassengerName, Class, BerthsBooked, JourneyDate, Status

    FROM Bookings

    ORDER BY JourneyDate DESC;

END
 
exec ShowBookings



select * from Bookings;
