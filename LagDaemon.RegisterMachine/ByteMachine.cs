using System.IO;

namespace LagDaemon.RegisterMachine
{

    struct Arch
    {
        public ulong[] registers;
        public double[] floatRegisters;
        public byte[] memory;
        public ulong IP;
        public ulong SP;
        public ulong BP;
    }

    public class ByteMachine
    {
        private Arch _arch = new Arch();

        public unsafe ByteMachine(ulong memorySize, Stream bootimage)
        {
            _arch.registers = new ulong[16];
            _arch.memory = new byte[memorySize];
            if (bootimage != null)
            {
                bootimage.Read(_arch.memory, 0, (int)bootimage.Length);
            }
            _arch.IP = 0;
            _arch.BP = memorySize - 1;
            _arch.SP = 0;
        }



    }
}
