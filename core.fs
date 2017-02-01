<<board>>   \ erase flash above <<board>>

compiletoflash

\ ... lots of definitions: 
\     includes and tested application code ...

include ../../common/spi-stm32f1.fs
include ../../common/rf69.fs

\ ... end of definitions

cornerstone <<core>>
compiletoram
