using System.Numerics;
using static System.Console;

WriteLine("Working with big INTS: ");
ulong big = ulong.MaxValue;
WriteLine($"{big,40:N0}");

BigInteger bigger = BigInteger.Parse("123456789012345678901234567890");
WriteLine($"{bigger,40:N0}");
WriteLine();

// Complex Numbers
WriteLine("Working with complex numbers: ");
Complex c1 = new(real: 3, imaginary: 2);
Complex c2 = new(real: 5, imaginary: 7);
Complex c3 = c1 + c2;

WriteLine(c3);
WriteLine($"({c1.Real} + {c1.Imaginary}i) + ({c2.Real} + {c2.Imaginary}i) = ({c3.Real} + {c3.Imaginary}i)");
