\ ==============================================================================
\
\                   tlb - the toolbelt in the ffl
\
\              Copyright (C) 2015 Dick van Oudheusden
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
\  $Date: 2009-05-23 05:37:24 $ $Revision: 1.20 $
\
\ ==============================================================================
\
\ This toolbelt file contains general purpose forth words that are not always
\ present in forth engines. It is inspired by the toolbelt of Wil Baden.
\
\ ==============================================================================
\ include bdf.atl
\ : step ( n -- )
\ 	bl emit . ." ") " .s cr
\ ;


( tlb = Toolbelt forth words )
( The tlb module contains general purpose forth words. )

: true -1 ;
: false 0 ;

: cell             ( - n = Cell size)
  1 cells
;

: char/
  1 chars /
;

: 3dup    ( x1 x2 x3 -- x1 x2 x3 x1 x2 x3 = Duplicate the three cells on stack )
  dup 2over rot
;

: 4dup    ( x1 x2 x3 x4 -- x1 x2 x3 x4 x1 x2 x3 x4 = Duplicate the four cells on stack )
  2over 2over
;

: 3drop   ( x1 x2 x3 -- = Drop the three cells on stack )
  2drop drop
;

: 4drop   ( x1 x2 x3 x4 -- = Drop the four cells on stack )
  2drop 2drop
;

: 0!   ( a-addr -- = Set address to zero )
  0 swap !
;

: on               ( w - = Set boolean variable to true)
  true swap !
;

: off              ( w - = Set boolean variable to false)
  false swap !
;

: u<>              ( u u - f = Check for not equal )
  <>
;

: u> swap u< ;

: u<=              ( u u - f = Check for smaller and equal )
  u> 0=
;

: u>=
  u< 0=
;

: 0>=              ( n - f = Check for equal and greater zero )
  0< 0=
;

: 0<=
  0> 0=
;

\ : >=               ( n n - f = Check for greater equal )
\  < 0=
\ ;

\ : <=               ( n n - f = Check for smaller equal )
\   > 0=
\ ;

0 CONSTANT nil

: nil!   ( a-addr -- = Set address to nil )
  nil swap !
;

: nil=   ( addr -- flag = Check for nil )
  nil =
;

: nil<>   ( addr -- flag = Check for unequal to nil )
  nil <>
;

: nil<>?
  dup nil<> IF
    true
  ELSE
    drop
    false
  THEN
;

: ?free   ( addr -- ior = Free the address if not nil )
  dup nil<> IF
    free
  ELSE
    drop 0
  THEN
;

: 1+!   ( a-addr -- = Increase contents of address by 1 )
  1 swap +!
;

: 1-!   ( a-addr -- = Decrease contents of address by 1 )
  -1 swap +!
;

: @!   ( x1 a-addr -- x2 = First fetch the contents x2 and then store value x1 )
  dup @ -rot !
;

: sgn              ( n1 - n2 = Determine the sign of the number )
  -1 max 1 min
;

: toupper          ( char1 -- char2 = Convert the character to upper case )
  dup [char] a >= over [char] z <= AND IF
    [ char a char A - ] literal -
  THEN
;

: icompare   ( c-addr1 u1 c-addr2 u2 -- n = Compare case-insensitive two strings and return the result [-1,0,1] )
  rot swap 2swap 2over
  min 0 ?DO
    over c@ toupper over c@ toupper - sgn ?dup IF
      >r 2drop 2drop r>
\      unloop 
      exit
    THEN
    1 chars + swap 1 chars + swap
  LOOP
  2drop
  - sgn
;

: bounds           ( c-addr u - c-addr+u c-addr = Get end and start address for ?do )
  over + swap
;

\ : ud.              ( ud -- = Type the unsigned double number )
\	<# #s #> type
\ ;

: <=>   ( n1 n2 -- n = Compare the two numbers and return the compare result [-1,0,1] )
  2dup = IF 
    2drop 0 EXIT 
  THEN
  < 2* 1+
;

: index2offset   ( n1 n2 -- n3  )
	( = Convert the index n1 range [-n2..n2> into offset n3 range [0..n2>, negative values of n1 downward length n2 )
  over 0< IF
    +
  ELSE
    drop
  THEN
;

\ : rdrop            ( R: x -- = Drop the first cell on the return stack )
\  postpone r> postpone drop
\ ; immediate

\ : r'@              ( R: x1 x2 -- x1 x2; -- x1 = Fetch the second cell on the return stack )
\  postpone 2r@ postpone drop
\ ;  immediate

"tlb: " type 20 step
\ : defer       create ['] abort ,
\           does> @ execute ;

\ : defer@      >body @ ;
\ : defer!      >body 1 cells + * ! ;
"tlb: " type 21 step
\ : is          state @ if
\                  postpone ['] postpone defer!
\              else
\                  ' defer!
\              then ; immediate
"tlb: " type 22 step
: nip swap drop ;
: 2>r swap >r >r ;
: 2r> r> r> swap ;
: 2r@ r> r> 2dup >r >r swap ;
"tlb: " type 23 step
: rdrop postpone r> postpone drop ;
"tlb: " type 24 step
\ : r'@ postpone 2r@ postpone drop ; immediate
: r'@ 2r@ drop ;
"tlb: " type 26 step
( Float extension words )


\ ==============================================================================

