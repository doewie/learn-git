
include dev.fs                    

( ... yet more definitions, but also actual calls to start up things... )

: setport ( -- )
	omode-pp pb7 io-mode!	\ set pb7 as output
	pb7 ioc!
;

: run ( -- )
	
    init-board
		 
	cr HASH.
	cr LIB_HASH.
	
	RF69.INIT
	CR rf69.
	CR spi.
	
	setport
	0 packet-counter-in ! 
	
	cr ." testswitch started....."
	cr ." press key to stop"
	cr
	
	CR
	setport
	millis starttime !
	
	begin  
		\ ['] handle.rf.TX RF69.HANDLEINT
		['] handle.switch RF69.HANDLEINT
				
		KEY? 
	until 	
;