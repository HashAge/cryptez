using System;

namespace cryptez
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            lib_of_cpt lib = new lib_of_cpt();

            Console.WriteLine("Cryptez");
            Console.WriteLine("1.Ceaser cipher");
            Console.WriteLine("2.Vigenere vipher\n");
            string ch = Console.ReadLine();
            Console.Clear();
            lib.choice(Int32.Parse(ch));

        }
        public class lib_of_cpt
        {
            public void choice(int choice)
            {
                if (choice == 1)
                {
                    Console.WriteLine("Enter the plain text");
                    string mes = Console.ReadLine();
                    Console.WriteLine("Enter the code(number)");
                    string code = Console.ReadLine();
                    if (Int32.TryParse(code, out int a) == false) return;
                    Console.WriteLine("Choose(type the number)");
                    Console.WriteLine("1.Encode");
                    Console.WriteLine("2.Decode");
                    string des = Console.ReadLine();
                    cesaer(mes, Int32.Parse(code), Int32.Parse(des));
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Enter the plain text");
                    string mes = Console.ReadLine();
                    Console.WriteLine("Enter the code");
                    string code = Console.ReadLine();
                    Console.WriteLine("Choose");
                    Console.WriteLine("1.Encode");
                    Console.WriteLine("2.Decode");
                    string des = Console.ReadLine();
                    vigenere(mes, code, Int32.Parse(des));
                }
                else return;
            }
            public void vigenere(string message, string code,int choice)
            {
                char[] mes_char = message.ToCharArray();
                char[] code_char = code.ToCharArray();
                char[] code_map = new char[message.Length];
                int[] int_code_map = new int[message.Length];
                for (int x = 0, i = 0; x < message.Length; x++)
                {
                    if (i < code.Length)
                    {
                        code_map[x] = code_char[i];
                        i++;
                    }
                    else
                    {
                        i = 0;
                        code_map[x] += code_char[i];
                        i++;
                    }
                    int_code_map[x] = Convert.ToInt32(code_map[x] - 97);
                }
                if (choice == 1)
                {
                    for (int i = 0; i < message.Length; i++)
                    {
                        if (Convert.ToChar(mes_char[i] + int_code_map[i]) > 122)
                        {
                            int div = mes_char[i] + int_code_map[i] - 123;
                            mes_char[i] = Convert.ToChar(97 + div);
                        }
                        else mes_char[i] = Convert.ToChar(mes_char[i] + int_code_map[i]);

                    }
                    Console.WriteLine(mes_char);
                }
                if(choice >= 2)
                {
                    for (int i = 0; i < message.Length; i++)
                    {
                        if (mes_char[i] - int_code_map[i] < 97)
                        {
                            int div = (mes_char[i] - int_code_map[i]) - 97;
                            mes_char[i] = Convert.ToChar(123 + div);
                        }
                        else mes_char[i] = Convert.ToChar(mes_char[i] - int_code_map[i]);
                    }
                    Console.WriteLine(mes_char);
                }
            }
            public void cesaer(string message, int code, int choice)
            {
                if(choice == 1)
                {
                    char[] chr = message.ToCharArray();
                    message.ToLower();
                    for (int i = 0; i < chr.Length; i++)
                    {
                        if (chr[i] + code > 122)
                        {
                            int div = chr[i] + code - 123;
                            chr[i] = Convert.ToChar(97 + div);
                        }
                        else chr[i] = Convert.ToChar(chr[i] + code);
                    }
                    Console.WriteLine(chr);
                }
                if (choice >= 2)
                {
                    char[] chr = message.ToCharArray();
                    message.ToLower();
                    for (int i = 0; i < chr.Length; i++)
                    {
                        if (chr[i] - code < 97)
                        {
                            int div = (chr[i] -code) - 97;
                            chr[i] = Convert.ToChar(123 + div);
                        }
                        else chr[i] = Convert.ToChar(chr[i] - code);
                    }
                    Console.WriteLine(chr);
                }
            }
        }
    }
}
