using System;
using Common;
using Mzto.DAL;

namespace MztoClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MztoUploader.Settings.ConnectionString);
        }
    }
}
