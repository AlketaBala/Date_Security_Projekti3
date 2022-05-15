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
