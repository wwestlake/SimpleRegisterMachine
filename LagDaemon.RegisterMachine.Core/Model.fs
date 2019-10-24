namespace LagDaemon.RegisterMachine.Core

module Model =


    type Machine = {
        IP: int
        BP: int
        SP: int
        R: int array
        CF: bool
        Z: bool
        Eq: int
        Memory: int array
        Ports: int array
    }
        with 
            static member Init size ports = 
                {
                    IP = 0
                    BP = 0
                    SP = 0
                    CF = false
                    Z = false
                    Eq = 0
                    R = [|0;0;0;0;0;0;0;0;0;0;0;0;0;0;0|]
                    Memory = [| for i in [0..size] -> 0 |]
                    Ports = [| for i in [0..ports] -> 0 |]
                }
    
            member this.incrementIP () =
                {
                    this with IP = this.IP + 2
                }

            member this.jump addr =
                {
                    this with IP = addr
                }

            member this.incrementSP () =
                {
                    this with SP = this.SP + 1
                }

            member this.decrementSP () =
                {
                    this with SP = this.SP - 1
                }

            member this.setBasePointer addr =
                {
                    this with BP = addr
                }

            member this.setRegister r value =
                Array.set this.R r value

            member this.setMemory addr value =
                Array.set this.Memory addr value

            member this.fetch () =
                this.Memory.[this.IP]

            member this.fetchData () =
                this.Memory.[this.IP + 1]

            member this.readPort port =
                this.Ports.[port]

            member this.writePort port value =
                this.Ports.[port] = value

    type OpCodes =
        | NOP   = 0x0000
        | PUSH  = 0x0100
        | POP   = 0x0200
        | ADD   = 0x0300
        | SUB   = 0x0400
        | MUL   = 0x0500
        | DIV   = 0x0600
        | JMP   = 0x0700
        | JLE   = 0x0800
        | JGE   = 0x0900
        | JL    = 0x1000
        | JG    = 0x1100
        | JNE   = 0x1200
        | JZ    = 0x1300
        | JNZ   = 0x1400
        | LOAD  = 0x1500
        | STORE = 0x1600
        | MOVE  = 0x1700
        | AND   = 0x1800
        | OR    = 0x1900
        | NOT   = 0x2000
        | XOR   = 0x2100
        
