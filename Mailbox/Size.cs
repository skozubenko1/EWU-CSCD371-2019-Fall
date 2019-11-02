using System;
using System.Diagnostics.CodeAnalysis;

namespace Mailbox
{
    public static class SizeExt
    {
        public static bool IsPremium(this Size This)
        {
            return (This & Size.Premium) == Size.Premium;
        }
    }
    [Flags]
    public enum Size
    {
        Default = 0,
        Small = 1,       // 0x01
        Medium = 1 << 1, // 0x02
        Large = 1 << 2,   // 0x04
        Premium = 1 << 3, // 0x08
    }
}
