using System.Text;

namespace VernonHack
{
    public class Program
    {
        private static Random random = new Random();
        private static string alf = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯАБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        private static void Main(string[] args)
        {
            Console.WriteLine("Введите строку для шифрования:");
            string? text = Console.ReadLine();

            char[] key = KeyGenerator();

            string? shifr = Encryption(text, key);

            Console.WriteLine(shifr);
            Console.WriteLine("Generated key: " + new string(key));
            Console.WriteLine("Введите ваш ключ:");
            char[] personkey = Console.ReadLine().ToCharArray();
            Console.WriteLine(Encryption(text, personkey));
        }

        private static char[] KeyGenerator()
        {
            char[] key = ['0', '0', '0', '0', '0'];

            for (int i = 0; i < 5; i++)
            {
                if (random.Next(2) == 1)
                {
                    key[i] = '1';
                }
            }

            return key;
        }

        private static char[] SymbalToBinary(char a)
        {
            Char[] binary = ['0', '0', '0', '0', '0'];
            int index = alf.IndexOf(a);
            for (int i = 0; index != 0; i++)
            {
                if (index % 2 != 0)
                {
                    binary[4 - i] = '1';
                }
                index /= 2;
            }

            return binary;
        }

        private static char BinaryToSymbal(char[] binary)
        {
            int sum = 0;
            for (int i = 0, k = 1; i < binary.Length; i++, k *= 2)
            {
                if (binary[4 - i] == '1')
                {
                    sum += k;
                }
            }

            return alf[sum];
        }

        private static string Encryption(string? text, char[] key)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < text?.Length; i++)
            {
                char[] symBinary = SymbalToBinary(text[i]);
                for (int j = 0; j < key.Length; j++)
                {
                    if (key[j] == '1')
                    {
                        if (symBinary[j] == '1')
                        {
                            symBinary[j] = '0';
                        }
                        else symBinary[j] = '1';
                    }
                }
                sb.Append(BinaryToSymbal(symBinary));
            }
            return sb.ToString();
        }

    }
}
