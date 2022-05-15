using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base64EncoderDecoder
{
    public class Base64_Encoder
    {
        byte[] plaintext;
        int length, length2;
        int block;
        int padding;
        public Base64_Encoder(byte[] input)
        {
            plaintext = input;    //vendosja e plain-tekstit
            length = input.Length;  //gjatesia e plain-tekstit
            if ((length % 3) == 0)
            {
                padding = 0;
                block = length / 3;
            }
            else
            {
                padding = 3 - (length % 3);
                block = (length + padding) / 3;
            }
            length2 = length + padding;
          }

        public char[] Encode()
        {
            byte[] plaintext2;
            plaintext2 = new byte[length2];
        
            switch (padding)
            {
                case 0: break;
                case 1: ciphertext[block * 4 - 1] = '='; break;
                case 2:
                    ciphertext[block * 4 - 1] = '=';
                    ciphertext[block * 4 - 2] = '=';
                    break;
                default: break;
            }
            return ciphertext;
        }

        private char block6btochar(byte b)
        {
            char[] Characters = new char[64]
                    {   'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
                        'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
                        '0','1','2','3','4','5','6','7','8','9','+','/'};

            if ((b >= 0) && (b <= 63))
            {
                return Characters[(int)b];
            }
            else
            {

                return ' ';
            }
        }
    }
}


            for (int i = 0; i < length2; i++)
            {
                if (i < length)
                {
                    plaintext2[i] = plaintext[i];
                }
                else
                {
                    plaintext2[i] = 0;
                }
            }

            byte b1, b2, b3;
            byte j, j1, j2, j3, j4;
            byte[] block6b = new byte[block * 4];
            char[] ciphertext = new char[block * 4];
             for (int i = 0; i < block; i++)
            {
                b1 = plaintext2[i * 3];
                b2 = plaintext2[i * 3 + 1];
                b3 = plaintext2[i * 3 + 2];

                j1 = (byte)((b1 & 252) >> 2);

                j = (byte)((b1 & 3) << 4);
                j2 = (byte)((b2 & 240) >> 4);
                j2 += j;

                j = (byte)((b2 & 15) << 2);
                j3 = (byte)((b3 & 192) >> 6);
                j3 += j;

                j4 = (byte)(b3 & 63);

                block6b[i * 4] = j1;
                block6b[i * 4 + 1] = j2;
                block6b[i * 4 + 2] = j3;
                block6b[i * 4 + 3] = j4;

            }

            for (int i = 0; i < block * 4; i++)
            {
                ciphertext[i] = block6btochar(block6b[i]);
            }

            
