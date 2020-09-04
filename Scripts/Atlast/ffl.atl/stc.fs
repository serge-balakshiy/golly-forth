\ ==============================================================================
\
\                 stc - the struct module in the ffl
\
\             Copyright (C) 2005-2007  Dick van Oudheusden
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
\  $Date: 2008-05-24 11:01:18 $ $Revision: 1.8 $
\
\ ==============================================================================

\ include ffl.atl/config.fs

\ : step ( n -- )
\	bl emit . ." )" .s cr
\ ;

( stc = ANS Structure module )
( The stc module implements ANS structures. )

2 constant stc.version

( ANS Structure syntax words )

: begin-structure  
  create
    here 0 , 0
   does>
    @ 
;

: end-structure   ( structure-sys -- = End a structure definition )
  swap 1 cells + !
;

\ : flint create , does> @ float ;

\ 2 step
"stc: " type 2 step
( ANS field definition words )

: +field
	create  
	over , +
  does>
	@ + 
;

"stc: " type 4 step

: cfield:  
   1 chars +field
;

"stc: " type 6 step

: field: 
	\ aligned
 	1 cells +field
;

"stc: " type 8 step

: dfield:   
	\ aligned
	2 cells +field
;

( Array field definition words )

: cfields: 
  chars +field
;

\ ==============================================================================
"stc: " type 10 step

\ begin-structure tsn% 
\	field: tsn>n
\	field: tsn>m
\ end-structure
\ tsn% . cr
"stc: " type 12 step

