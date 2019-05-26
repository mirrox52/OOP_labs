using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using OOPforms.plugin;

namespace Zip
{
    public class Zip : IArchive
    {
        public string Name { get; } = "Zip";

        public string Format { get; } = ".zip";

        public string inputFile;


        public void Compress(string inputFile, string outputFile)
        {
            using (FileStream input = File.OpenRead(inputFile))
            using (FileStream output = File.Create(outputFile))
            using (ZipArchive zip = new ZipArchive(output, ZipArchiveMode.Create))
            {
                ZipArchiveEntry entry = zip.CreateEntry(Path.GetFileName(inputFile));
                using (Stream stream = entry.Open())
                {
                    input.CopyTo(stream);
                }
            }

        }

        public void Decompress(string inputFile, string outputFile)
        {
            try
            {
                ZipFile.ExtractToDirectory(inputFile, Path.GetDirectoryName(outputFile));
            }
            catch
            {
                return;
            }

        }
    }
}
