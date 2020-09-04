include ffl.atl/include-snl.fs
"tsnl: " 0 steps
variable vsnl
"tsnl: " 2 steps
snl-new "tsnl: " 18 steps
vsnl ! "tsnl: " 20 steps
snn-new vsnl @ snl-append "tsnl: " 24 steps
snn-new vsnl @ snl-append "tsnl: " 26 steps
snn-new vsnl @ snl-append "tsnl: " 28 steps
\ 0 vsnl @ snl-node . cr
\ 1 vsnl @ snl-node . cr
\ 2 vsnl @ snl-node . cr
"tsnl: " 6 steps
\ 0 vsnl @ snl-node snn-dump "tsnl: " 30 steps
\ 1 vsnl @ snl-node snn-dump "tsnl: " 32 steps
\ 2 vsnl @ snl-node snn-dump "tsnl: " 34 steps
vsnl @ snl-dump
"tsnl: " 8 steps
snl-new constant snlist
begin-structure anode%
	snn%
		+field anode>snn
		field: anode>num
		field: anode>x
		field: anode>y
		field: anode>drawstate
end-structure

: anode-init ( n -- )
	dup snn-init
	anode>drawstate !
;

: anode-new ( n -- snn-addr )
	anode% allocate exp-invalid-memory throw?
	tuck anode-init
;

: anode>x! ( n snn -- n = x coordinate )
	anode>x !
;
: anode>y! ( n snn -- n = y coordinate )
	anode>y !
;
: anode>drawstate! ( n snn -- n = drawstate )
	anode>drawstate !
;

: anode>x@ ( snn -- n = x coordinate )
	anode>x @
;
: anode>y@ ( snn -- n = y coordinate )
	anode>y @
;
: anode>drawstate@ ( snn -- n = drawstate )
	anode>drawstate @
;
: anode>cell@ ( snn -- n n n = drawstate y x )
	dup anode>drawstate @
	dup anode>y @
	anode>x @
;
"tsnl: " 10 steps
: anode-dump ( snn -- )
	dup snn-dump 300 step
	." "anode num: " dup anode>num ? cr
	." "anode x: " dup anode>x ? cr
	." "anode y: " dup anode>y ? cr	
	." "anode drawstate: " anode>drawstate ? cr
;

"tsnl: " 12 steps
: snl-anode-dump ( snl -- )
	dup snl-dump 400 step
	['] anode-dump swap snl-execute
;
"tsnl: " 14 steps

1 anode-new snlist snl-append
1 anode-new snlist snl-append
1 anode-new snlist snl-append
snlist snl-dump
snlist snl-anode-dump
snlist snl-free
"tsnl: snlist free" 14 steps
