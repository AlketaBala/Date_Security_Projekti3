using Base64EncoderDecoder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base64EncoderDecoder_Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Shtypni E per procesin e enkodimit ose D per procesin e Dekodimit");

                var key = Console.ReadKey();
                Console.WriteLine();

                Console.WriteLine("Jepni tekstin: ");
                var text = Console.ReadLine();

                Console.WriteLine();

                switch (key.KeyChar)
                {
                    case 'E':
                    case 'e':
                        Console.WriteLine("Teksti i enkoduar: ");
                        Console.WriteLine(EncodeText(text));
                        continue;
                    case 'D':
                    case 'd':
                        Console.WriteLine("Teksti i dekoduar: ");
                        Console.WriteLine(DecodeText(text));
                        continue;
                    default:
                        Console.WriteLine("Ju lutem shtypni E,e ose D,d per te vazhduar!");
                        break;
                }

                Console.WriteLine();
            }
        }

        private static string EncodeText(string text)
        {
            byte[] data = System.Text.Encoding.UTF8.GetBytes(text);
            Base64_Encoder myEncoder = new Base64_Encoder(data);
            StringBuilder sb = new StringBuilder();

            sb.Append(myEncoder.Encode());

            return sb.ToString();
        }

        private static string DecodeText(string text)
        {
            char[] data = text.ToCharArray();
            Base64_Decoder myDecoder = new Base64_Decoder(data);
            StringBuilder sb = new StringBuilder();

            byte[] temp = myDecoder.Decode();
            sb.Append(System.Text.UTF8Encoding.UTF8.GetChars(temp));

            return sb.ToString();
        }
    }
}