\ ==============================================================================
\
\             snn - the generic single linked node in the ffl
\
\               Copyright (C) 2007  Dick van Oudheusden
\  
\ This library is free software; you can redistribute it and/or
\ modify it under the terms of the GNU Lesser General Public
\ License as published by the Free Software Foundation; either
\ version 3 of the License, or (at your option) any later version.
\
\ This library is distributed in the hope that it will be useful,
\ but WITHOUT ANY WARRANTY; without even the implied warranty of
\ MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
\ Lesser General Public License for more details.
\
\ You should have received a copy of the GNU Lesser General Public
\ License along with this library; if not, write to the Free
\ Software Foundation, Inc., 675 Mass Ave, Cambridge, MA 02139, USA.
\
\ ==============================================================================
\ 
\  $Date: 2008-01-09 19:30:48 $ $Revision: 1.3 $
\
\ ==============================================================================

\ include ffl/config.fs

\ include ffl.atl/stc.fs
\ include ffl.atl/tlb.fs
"snn: " type 2 step
1 constant snn.version
"snn: " type 4 step
( Node structure )

begin-structure snn%       ( - n = Get the required space for a snn node )
  field: snn>next
end-structure

( Node creation, initialisation and destruction )

: snn-init     ( snn -- = Initialise the node )
  snn>next nil!
;

2 step
: snn-new      (  -- snn = Create a new node on the heap )
  snn% allocate  exp-invalid-memory throw? dup snn-init
;
4 step

: snn-free     ( snn -- = Free the node from the heap )
  free exp-invalid-memory throw?
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
  ." "snn: " dup . cr
  ."  "next: "     snn>next  ? cr
;

\ ==============================================================================
