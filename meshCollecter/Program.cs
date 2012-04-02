using System.IO;
using System.Linq;
using meshReader.Game;

namespace meshCollecter
{
    class Program
    {
        static int[] GetFileXy(string path)
        {
            var ret = new int[2];
            path = path.Substring(path.IndexOf('_') + 1);
            path = path.Substring(0, path.IndexOf('.'));
            var tokens = path.Split('_');
            ret[0] = int.Parse(tokens[0]);
            ret[1] = int.Parse(tokens[1]);
            return ret;
        }

        // collects tiles into the old format .nmesh
        static void CollectOldFormat(string continent, BinaryWriter output)
        {
            var files = Directory.GetFiles(continent + "\\").Where(f => f.EndsWith(".tile"));
            
            // header
            const int magic = 'M' << 24 | 'S' << 16 | 'E' << 8 | 'T';
            const int version = 1;
            int numTiles = files.Count();
            output.Write(magic);
            output.Write(version);
            output.Write(numTiles);
            // nav mesh params
            var origin = World.Origin;
            output.Write(origin[0]);
            output.Write(origin[1]);
            output.Write(origin[2]);
            const float tileWidth = Constant.TileSize;
            output.Write(tileWidth);
            output.Write(tileWidth);
            output.Write(32); // max tiles
            output.Write(32768); // max polys

            // lookup table
            int offset = 10 /*header*/ + (numTiles*6) /*lookup*/;
            foreach (var file in files)
            {
                var coords = GetFileXy(file);
                // xy
                output.Write((byte) coords[0]);
                output.Write((byte) coords[1]);
                output.Write(offset);
                using (var stream = File.OpenRead(file))
                {
                    offset += (int)stream.Length + 4;
                }
            }

            // actual tile data
            foreach (var file in files)
            {
                var data = File.ReadAllBytes(file);
                output.Write(data.Length);
                output.Write(data);
            }

            // all done
            output.Flush();
            output.Close();
        }

        static void Main()
        {
            const string continent = "Azeroth";
            CollectOldFormat(continent, new BinaryWriter(File.Create(continent + ".nmesh")));
        }
    }
}
