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

( ANS Structure syntax words )

: begin-structure   ( "<spaces>name" -- structure-sys ; -- n = Start definition of a named structure, return the structure size )
  create
    here 0 , 0
  does>
    @
;

: end-structure   ( structure-sys -- = End a structure definition )
  swap !
;

( ANS field definition words )

: +field   ( structure-sys n "<spaces>name" -- structure-sys ; addr1 -- addr2 = Create a structure field of size n bytes, return the field address )
  create
    over , +
  does>
    @ +
;

: cfield:   ( structure-sys "<spaces>name" -- structure-sys ; addr1 -- addr2 = Create a structure field of 1 char, return the field address )
  1 chars +field
;

: field:   ( structure-sys "<spaces>name" -- structure-sys ; addr1 -- addr2 = Create a structure field of 1 cell, return the field address )
  aligned 1 cells +field
;

: dfield:   ( structure-sys "<spaces>name" -- structure-sys ; addr1 -- addr2 = Create a structure field of 1 double, return the field address )
  aligned 2 cells +field
;

( Array field definition words )

: cfields:   ( structure-sys n "<spaces>name" -- structure-sys ; addr1 -- addr2 = Create a structure field of n chars, return the field address )
  chars +field
;

: fields:   ( structure-sys n "<spaces>name" -- structure-sys ; addr1 -- addr2 = Create a structure field of n cells, return the field address )
  swap aligned swap cells +field
;

: dfields:   ( structure-sys n "<spaces>name" -- structure-sys ; addr1 -- addr2 = Create a structure field of n doubles, return the field address )
  swap aligned swap 2* cells +field
;

\ ==============================================================================
