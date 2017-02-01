reset 				\ remove everything from RAM

( ... more definitions: work in progress, debug words ... )

\ save git hash
include version.fs
include ../../common/version.fs

: handle.rf69.intB
		rf-recv dup >r
		CR delta-millis . ." RX " .
		packet-counter-in @ 1+ dup packet-counter-in !
		\ ." bytes at packet-in nr: " .
		." in: " .
		
		r>
		
\		dup 0 > if
\		0 do
\			rf.buf i + c@ h.2
\			i 1 = if 2- h.2 space then
\		loop cr
\		else
\			." buffer empty"
\		then
;

\ : send.package
\		RF:M_TX rf!mode		\ set in transmit mode and wait for ready
\		packet-counter-in @ 0 <# #s #> 0 rf-send
\		CR delta-millis . ." TX current packet-counter-in " packet-counter-in @ .
\		packet-counter-out @ 1+ dup packet-counter-out !
\		." at packet-out nr: " .
\		RF:M_RX rf!mode		\ set in listen mode again and wait for ready
\ ;

: handle.rf.TX

	\ handle incoming packet
	handle.rf69.intB
	
	\ handle outgoing packet
	\ send.package
	\ RFBUF.INIT
	\ s" c=" RFBUF.ADDS
	\ packet-counter-in @ 0 <# #s #> RFBUF.ADDS
	\ RFBUF.RFSEND	
;

: inc-counter ( -- newval) \ inc counter and return new value
	packet-counter-in @ 1+ dup packet-counter-in !
;

: handle.switch ( -- )
	CR delta-millis . inc-counter .
	rf-recv drop	\ empty FIFO buffer on RFM69 module no data handling
	pb7 ioc!
	100 ms
	pb7 ios!
	
	\ RBUF.INIT
	
	\ 0 <# #s #> RFBUF.adds			\	add an 64-bits integer
	\ RFBUF.							\	report buffer status
	\ RFBUF.rfsend					\ 	send buffer content
	\ RF:M_STDBY rf!mode	\ set in standby mode to force clearing flags
	\ RF:M_RX rf!mode		\ set in listen mode again
;
