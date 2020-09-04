include ffl.atl/bdf.atl

"tdfr: defer start test" 14 steps

defer t.defer
: tmy ( -- )
	t.defer
;
: t-defer ( -- )
	"test defer" type cr
;
' t-defer is t.defer
tmy cr
"tdfr: tdefer end test" 16 steps