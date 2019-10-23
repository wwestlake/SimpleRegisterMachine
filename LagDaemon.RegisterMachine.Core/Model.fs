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
        | NOP = 000x0
        | PUSH = 100x0
        | POP = 20
        | ADD = 30
        | SUB = 40
        | MUL = 50
        | DIV = 60
        | JMP = 70
        | JLE = 80
        | JGE = 90
        | JL = 100
        | JG = 110
        | JNE = 120
        | JZ  = 130
        | JNZ = 140
        | LOAD = 150
        | STORE = 160
        | MOVE = 170
        | AND = 180
        | OR = 190
        | NOT = 200
        | XOR = 210
        
