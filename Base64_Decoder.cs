using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Base64EncoderDecoder
{
    public class Base64_Decoder
    {
        char[] ciphertext;
        int length, length2, length3, block6b, padding;
        public Base64_Decoder(char[] input)
        {
            padding = 0;
            ciphertext = input;
            length = input.Length;
            
            try {
                for (int i = 0; i < 2; i++)
                {
                    if (input[length - i - 1] == '=')
                        padding++;
                }
            }
            catch(IndexOutOfRangeException)
            {
                MessageBox.Show("Ju lutem kryeni procesin e Enkodimit.");
            }            

            

            block6b = length / 4;
            length2 = block6b * 3;
            
        }
         public byte[] Decode()
        {
            byte[] block = new byte[length];
            byte[] block2 = new byte[length2];

            for (int i = 0; i < length; i++)
            {
                block[i] = chartoblock(ciphertext[i]);
            }
             byte b, b1, b2, b3;
            byte j1, j2, j3, j4;

            for (int i = 0; i < block6b; i++)
            {
                j1 = block[i * 4];
                j2 = block[i * 4 + 1];
                j3 = block[i * 4 + 2];
                j4 = block[i * 4 + 3];

                b = (byte)(j1 << 2);
                b1 = (byte)((j2 & 48) >> 4);
                b1 += b;

                b = (byte)((j2 & 15) << 4);
                b2 = (byte)((j3 & 60) >> 2);
                b2 += b;

                b = (byte)((j3 & 3) << 6);
                b3 = j4;
                b3 += b;

                block2[i * 3] = b1;
                block2[i * 3 + 1] = b2;
                block2[i * 3 + 2] = b3;
            }

            length3 = length2 - padding;
            byte[] plaintext = new byte[length3];

            for (int i = 0; i < length3; i++)
            {
                plaintext[i] = block2[i];
            }

            return plaintext;
        }
       private byte chartoblock(char a)
        {
            char[] Characters = new char[64]
                    {   'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
                        'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
                        '0','1','2','3','4','5','6','7','8','9','+','/'};
            if (a == '=')
                return 0;
            else
            {
                for (int i = 0; i < 64; i++)
                {
                    if (Characters[i] == a)
                        return (byte)i;
                }

                return 0;
            }

        }
    }
}
