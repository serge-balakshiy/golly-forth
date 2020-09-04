include config.cxxf.fs
include stc.cxxf.fs
include tlb.cxxf.fs
( snn = Generic Single Linked List Node )
( The snn module implements a node in a generic single linked list <a href='snl.html'>snl</a>. )


1 constant snn.version


( Node structure )

begin-structure snn%
	field: snn>next
end-structure

( Node creation, initialisation and destruction )

: snn-init     ( snn -- = Initialise the node )
  snn>next nil!
;

: snn-new      (  -- snn = Create a new node on the heap )
  snn% allocate  ( throw ) drop  dup snn-init
;


: snn-free     ( snn -- = Free the node from the heap )
  free \ throw
;

( Member words )

: snn-next@    ( snn1 -- snn2 = Get the next node snn2 from the node snn1 )
  snn>next @
;


: snn-next!    ( snn1 snn2 -- = Set for the node snn1 the next node to snn2 )
  snn>next !
;


( Inspection )

: snn-dump     ( snn -- = Dump the single list node )
  ." snn:" dup . cr
  ."  next :"     snn>next  ?  cr
;

