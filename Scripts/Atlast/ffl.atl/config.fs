\ ==============================================================================
\
\                  config - the config in the ffl
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
\  $Date: 2009-05-23 05:37:24 $ $Revision: 1.20 $
\
\ ==============================================================================
\
\ This file is for gforth.
\
\ ==============================================================================


( config = Forth system specific words )
( The config module contains the extension and missing words for a forth system.)


9 constant ffl.version

\ include ffl.atl/bdf.atl
( Private words )
  
variable ffl.endian   1 ffl.endian !

8 constant cell
( System Settings )

8  constant #bits/byte   ( -- n = Number of bits in a byte )
  
#bits/byte 1 chars *
  constant #bits/char   ( -- n = Number of bits in a char )
  
#bits/byte cell *
  constant #bits/cell   ( -- n = Number of bits in a cell )  

ffl.endian c@ 0=             
  constant bigendian?   ( -- flag = Check for bigendian hardware )


( Extension words )
begin-enumeration
  enum: exp-index-out-of-range
  enum: exp-invalid-state
  enum: exp-no-data
  enum: exp-invalid-parameters
  enum: exp-wrong-file-type
  enum: exp-wrong-file-version
  enum: exp-wrong-file-data
  enum: exp-wrong-checksum
  enum: exp-wrong-length
  enum: exp-invalid-data
  enum: exp-invalid-memory
end-enumeration

: throw ( n -- )
	dup exp-index-out-of-range -
	if dup exp-invalid-state -
		if dup exp-no-data -
			if dup exp-invalid-parameters -
				if dup exp-wrong-file-type
					if dup exp-wrong-file-version -
						if dup exp-wrong-file-data -
							if dup exp-wrong-checksum -
								if dup exp-wrong-length -
									if exp-invalid-data -
										if exp-invalid-memory -
											if else abort" "Invalid mempry allocated"  then
										else abort" "Invalid data" then
									else	abort" "Wrong length"  then
								else abort" "Wrong checksum"  then
							else abort" "Wrong file data" then
						else abort" "Wrong file version"  then
					else abort" "Wrong file abort-message"  then
				else abort" "Invalid parameters"  then
			else abort" "No data available"   then
		else abort" "Invalid state"  then
	else abort" "Index out of range"  then
	exit
;
: throw? ( n n -- )
	swap 0=
	if drop exit else throw then
;


\ Command line arguments in gforth 32-bit

( Toolbelt )

\ include ffl/tlb.fs

\ ==============================================================================

