﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Editor_de_Texto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }
        
        static void Menu() 

        {
            Console.WriteLine("O que voce deseja fazer?");
            Console.WriteLine("1 - Abrir arquivo");
            Console.WriteLine("2 - Criar um arquivo");
            Console.WriteLine("0 - Sair");
            short options = short.Parse(Console.ReadLine());

            switch (options) 
            {
                case 0: System.Environment.Exit(0); break;
                case 1: Abrir(); break;
                case 2: Editar(); break;
                default: Menu(); break; 
            }
        }

        static void Abrir()
        {
            Console.Clear();
            Console.WriteLine("Qual o caminho do arquivo?");
            string path = Console.ReadLine();

            using (var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);   
            }
            Console.WriteLine("");
            Console.ReadLine();
            Menu();
        }

        static void Editar() 
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo ");
            Console.WriteLine("Digite ESC para sair");
            Console.WriteLine("---------------------");
            string text = "";

            do 
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            Salvar(text);

           
        }

        static void Salvar(string text)
        {
            Console.WriteLine("Qual caminho para salvar o arquivo?");
            var path = Console.ReadLine();

            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }
            Console.WriteLine($"Arquivo {path} salvo com sucesso!");
            Console.ReadLine();
            Menu();
        }
    }

}
