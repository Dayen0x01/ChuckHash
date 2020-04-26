using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Chuck_s_Hash
{
    class Program
    {
        // Const
        static string MSG_CONST = "\nSelecione uma opção: ";
        static string MSG_CONST_OPEN_FILE = "\nSelecione o arquivo que deseja abrir: ";
        static string MSG_CONST_FILE_NOT_EXIST = "\nO arquivo {0} não foi encontrado.";
        static string MSG_CONST_FILE_NULL = "\nCaminho inválido.";
        static string MSG_CONST_HASH = "\nSua hash {0} é: {1}";
        static string MSG_CONST_HASH_COMPARE = "\nInforme a hash que deseja verificar: ";

        static void SelectCryptograph(string type)
        {
            Console.WriteLine(MSG_CONST_OPEN_FILE);
            string PathFile = Console.ReadLine();

            if (PathFile != "" || PathFile != null)
            {
                if (File.Exists(PathFile))
                {
                    if (type == "1")
                    {
                        var Hash = Cryptograph.CalcularHashMD5(PathFile);
                        var HashString = BitConverter.ToString(Hash).Replace("-", "").ToLower();
                        Console.WriteLine(MSG_CONST_HASH, "MD5", HashString);
                    }
                    else
                    {
                        var Hash = Cryptograph.CalcularHashSHA256(PathFile);
                        var HashString = BitConverter.ToString(Hash).Replace("-", "").ToLower();
                        Console.WriteLine(MSG_CONST_HASH, "SHA256", HashString);
                    }
                }
                else
                {
                    Console.Write(MSG_CONST_FILE_NOT_EXIST, PathFile);
                }
            }
            else
            {
                Console.WriteLine(MSG_CONST_FILE_NULL);
            }
        }
        static void GerarHash()
        {
            string[] GerarHashOptions = { "\n1) MD5", "2) SHA 256" };
            for (int i = 0; i < GerarHashOptions.Count(); i++)
            {
                Console.WriteLine(GerarHashOptions[i]);
            }

            Console.Write(MSG_CONST);

            string OptionSelected = Console.ReadLine();

            SelectCryptograph(OptionSelected);

        }
        static void VerificarHash()
        {
            Console.WriteLine(MSG_CONST_HASH_COMPARE);
            string CompareHash = Console.ReadLine();

            Console.WriteLine(MSG_CONST_OPEN_FILE);
            string FileCompare = Console.ReadLine();

            if (FileCompare != "" && File.Exists(FileCompare))
            {
                var HashMD5 = BitConverter.ToString(Cryptograph.CalcularHashMD5(FileCompare)).Replace("-", "").ToLower();
                var HashSHA256 = BitConverter.ToString(Cryptograph.CalcularHashSHA256(FileCompare)).Replace("-", "").ToLower();

                if (string.Compare(CompareHash, HashMD5, StringComparison.InvariantCulture) == 0)
                {
                    Console.Write("\nMD5: True");
                }
                else
                {
                    Console.Write("\nMD5: False");
                }
                if (string.Compare(CompareHash, HashSHA256, StringComparison.InvariantCulture) == 0)
                {
                    Console.Write("\nSHA256: True");
                }
                else
                {
                    Console.Write("\nSHA256: False");
                }
            }


            }
            static void Main(string[] args)
            {
                Console.Title = "Chuck's Hash";

                string[] Options = { "1) Gerar Hash", "2) Verificar Hash", "3) Sair" };

                for (int i = 0; i < Options.Count(); i++)
                {
                    Console.WriteLine(Options[i]);
                }

                Console.Write(MSG_CONST);

                string OptionSelect = Console.ReadLine();

                switch (OptionSelect)
                {
                    case "1":
                        GerarHash();
                        break;
                    case "2":
                        VerificarHash();
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;

                }

                Console.Read();
            }
        }

}
