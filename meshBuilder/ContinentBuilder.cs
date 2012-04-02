using System;
using System.IO;
using meshDatabase;
using meshReader.Game;

namespace meshBuilder
{
    
    public enum TileEventType
    {
        StartedBuild,
        CompletedBuild,
        FailedBuild,
    }

    public class TileEvent : EventArgs
    {
        public string Continent { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public TileEventType Type { get; private set; }

        public TileEvent(string continent, int x, int y, TileEventType type)
        {
            Continent = continent;
            X = x;
            Y = y;
            Type = type;
        }
    }

    public class ContinentBuilder
    {
        public string Continent { get; private set; }
        public WDT TileMap { get; private set; }

        public int StartX { get; private set; }
        public int StartY { get; private set; }
        public int CountX { get; private set; }
        public int CountY { get; private set; }

        public event EventHandler<TileEvent> OnTileEvent;

        public ContinentBuilder(string continent)
            : this (continent, 0, 0, 64, 64)
        {
        }

        public ContinentBuilder(string continent, int startX, int startY, int countX, int countY)
        {
            StartX = startX;
            StartY = startY;
            CountX = countX;
            CountY = countY;

            Continent = continent;
            TileMap = new WDT("World\\Maps\\" + continent + "\\" + continent + ".wdt");
        }

        private string GetTilePath(int x, int y, int phaseId)
        {
            return Continent + "\\" + Continent + "_" + x + "_" + y + "_" + phaseId + ".tile";
        }

        private string GetTilePath(int x, int y)
        {
            return Continent + "\\" + Continent + "_" + x + "_" + y + ".tile";
        }
        
        private void SaveTile(int x, int y, byte[] data)
        {
            File.WriteAllBytes(Continent + "\\" + Continent + "_" + x + "_" + y + ".tile", data);
        }

        private void Report(int x, int y, TileEventType type)
        {
            if (OnTileEvent != null)
                OnTileEvent(this, new TileEvent(Continent, x, y, type));
        }

        public void Build()
        {
            if (Directory.Exists(Continent))
                Directory.Delete(Continent, true);

            Directory.CreateDirectory(Continent);

            for (int y = StartY; y < (StartY+CountY); y++)
            {
                for (int x = StartX; x < (StartX+CountX); x++)
                {
                    if (!TileMap.HasTile(x, y))
                        continue;

                    if (File.Exists(GetTilePath(x, y)))
                    {
                        Report(x, y, TileEventType.CompletedBuild);
                        continue;
                    }

                    Report(x, y, TileEventType.StartedBuild);

                    var builder = new TileBuilder(Continent, x, y);
                    byte[] data = null;

                    try
                    {
                        data = builder.Build(new MemoryLog());
                    }
                    catch (Exception)
                    {
                    }

                    if (data == null)
                        Report(x, y, TileEventType.FailedBuild);
                    else
                    {
                        SaveTile(x, y, data);
                        Report(x, y, TileEventType.CompletedBuild);
                    }

                    if (builder.Log is MemoryLog)
                        (builder.Log as MemoryLog).WriteToFile(Continent + "\\" + Continent + "_" + x + "_" + y + ".log");
                }
            }
        }
    }

}