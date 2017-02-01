\ board definitions for special homemade board

eraseflash    \ erase flash above always
compiletoflash

\ ... lots of definitions: pins/buttons/LEDs, main h/w interfaces ...
\
\

: init-board		\	board initialisation
  -jtag                     					\ disable JTAG, we only need SWD
  72MHz                     					\ set clock to 72 MHz
  cr ." flash memory: " flash-kb . ." KB"		\ print flash memory size 
  cr ." chip ID: " hwid hex.					\ print chip ID
  1000 systick-hz           					\ systick every 1 ms to enable us en ms words
;

\ ... end of definitions

cornerstone <<board>>
compiletoram