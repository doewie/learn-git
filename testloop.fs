( testloop.fs )

reset				\ remove everything from RAM

0 variable counter1

( inc counter1 and return new value )
: inc-counter1 ( -- u )
	counter1 @ 1+ dup counter1 !
;

( inc counter1 and print new value )
: countloop
	inc-counter1
	CR .
;

: send.counter1
		RF:M_TX rf!mode		\ set in transmit mode and wait for ready
		counter1 @ 0 <# #s #> 0 rf-send
		RF:M_STDBY rf!mode		\ set in standby mode again
;

: run
	init-board
	
	RF69.INIT
	RF:M_STDBY rf!mode		\ start in standby mode
	
	CR rf69.
	CR spi.
		
	( print counter every 1000 ms or wait for key pressed )
	begin
		countloop
		send.counter1
		1000 ms 
		
		KEY?
	until
;