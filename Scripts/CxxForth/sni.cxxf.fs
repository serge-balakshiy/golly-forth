include config.cxxf.fs

include stc.cxxf.fs
include snl.cxxf.fs
include snn.cxxf.fs

( sni = Generic Single Linked List Iterator )
( The sni module implements an iterator on the generic single linked list <a href='snl.html'>snl</a>. )

( Iterator structure )

begin-structure sni%       ( -- n = Get the required space for a sni variable )
  field: sni>snl
  field: sni>walk
end-structure 

( Iterator creation, initialisation and destruction )

: sni-init     ( snl sni -- = Initialise the iterator with a snl list )
	tuck sni>snl !
	sni>walk  nil!
;

: sni-create   ( snl "<spaces>name" -- ; -- sni = Create a named iterator in the dictionary on the snl list )
  create 
    here  sni% allot  sni-init
;

: sni-new      ( snl -- sni = Create an iterator on the snl list on the heap )
  sni% allocate  exp-invalid-memory throw? tuck sni-init
;

: sni-free     ( sni -- = Free the iterator from the heap )
  free ( throw )
;

( Member words )

: sni-get      ( sni -- snn | nil = Get the current node )
  sni>walk @
;

( Iterator words )

: sni-first    ( sni -- snn | nil  = Move the iterator to the first node, return this node )
  dup sni>snl @
  snl-first@
  dup rot sni>walk !         \ walk = snl.first
;

: sni-next     ( sni -- snn | nil = Move the iterator to the next node, return this node )
	sni>walk
	dup @
	nil<>? IF                  \ if walk <> nil then
		snn-next@                \   walk = walk.next
		dup rot !
	ELSE                       \ else
		dup if  exp-invalid-state throw? then \   exception
	THEN
;

: sni-first?   ( sni -- flag = Check if the iterator is on the first node )
  dup sni>snl @
  snl-first@
  dup nil= IF
    2drop
    false
  ELSE
    swap sni-get =
  THEN
;

: sni-last?    ( sni -- flag = Check if the iterator is on the last node )
  dup sni>snl @
  snl-last@
  dup nil= IF
    2drop
    false
  ELSE
    swap sni-get =
  THEN
;

( Inspection )

: sni-dump     ( sni -- = Dump the iterator )
  ." sni:" dup . cr
  ."  snl :" dup sni>snl  ?  cr
  ."  walk:"     sni>walk  ?  cr
;

