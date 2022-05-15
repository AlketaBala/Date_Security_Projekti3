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
            
