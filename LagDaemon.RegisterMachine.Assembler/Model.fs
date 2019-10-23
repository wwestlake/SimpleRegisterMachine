namespace LagDaemon.RegisterMachine.Assembler

module Model =
    open FParsec

    type UserState = unit
    type Parser<'t> = Parser<'t, UserState>

    let ws = spaces
    let ws1 = spaces1
    let str = pstringCI

    let pnum : Parser<_> = pint64

    let pnop : Parser<_> = str "nop"
    let preg : Parser<_> = str "r" >>. pnum
    let ppush : Parser<_> = str "push" >>. ws1 >>. preg
    let ppop : Parser<_> = str "pop" >>. ws1 >>. preg
    let pload : Parser<_> = str "load" >>. ws1 >>. preg >>. pnum
