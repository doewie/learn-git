\	this file must be loaded on top of a pristine Mecrisp image

( clear flash above  Mecrisp image )
$5000 eraseflashfrom
( basic definitions, compiled to flash )
compiletoflash

\	include common stuff
include ../../common/registers_memory_map.fs
include ../../common/io.fs 
include ../../common/base.fs
include ../../common/doewie.fs
  
( define cornerstone for eraseflash )
cornerstone eraseflash

compiletoram






