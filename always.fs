\	this file must be loaded on top of a pristine Mecrisp image

( clear flash above  Mecrisp image )
$5000 eraseflashfrom
( basic definitions, compiled to flash )
compiletoflash
  
( define cornerstone for eraseflash )
cornerstone eraseflash

compiletoram






