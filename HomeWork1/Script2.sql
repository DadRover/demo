DO $$
DECLARE 
v_flight_id int = 8525;
v_ticket_no bpchar(13) = '_000000000001';
BEGIN
IF EXISTS (SELECT FROM bookings.tickets WHERE ticket_no = v_ticket_no) 
THEN
	IF EXISTS (SELECT FROM bookings.flights WHERE flight_id = v_flight_id )
	THEN
		INSERT INTO bookings.boarding_passes(ticket_no, flight_id, boarding_no, seat_no)
		VALUES (v_ticket_no, v_flight_id, 96, '40A');
	ELSE
		RAISE NOTICE 'Самолёт нет';
	END IF;
ELSE
	RAISE NOTICE 'Билет нет';
END IF;
--ROLLBACK;
COMMIT;
END	$$