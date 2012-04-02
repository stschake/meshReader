using System;
using meshReader.Game;

namespace meshBuilder
{
    
    public class RecastConfig
    {
        public int BorderSize { get; set; }
        public float CellSize { get; set; }
        public float CellHeight { get; set; }
        public float WalkableSlopeAngle { get; set; }
        public int WalkableHeight { get; set; }
        public float WorldWalkableHeight { get; set; }
        public float WorldWalkableRadius { get; set; }
        public float WorldWalkableClimb { get; set; }
        public int WalkableClimb { get; set; }
        public int WalkableRadius { get; set; }
        public int MaxEdgeLength { get; set; }
        public float MaxSimplificationError { get; set; }
        public int MinRegionArea { get; set; }
        public int MergeRegionArea { get; set; }
        public int MaxVertsPerPoly { get; set; }
        public float DetailSampleDistance { get; set; }
        public float DetailSampleMaxError { get; set; }
        public int TileWidth { get; set; }

        public static RecastConfig Default
        {
            get
            {
                var ret = new RecastConfig();
                const float tileSize = Constant.TileSize;
                const int tileVoxelSize = 1800;
                ret.CellSize = tileSize / tileVoxelSize;
                ret.CellHeight = 0.3f;
                ret.MinRegionArea = (int)Math.Pow(6, 2);
                ret.MergeRegionArea = (int) Math.Pow(12, 2);
                ret.WalkableSlopeAngle = 50f;
                ret.DetailSampleDistance = 3f;
                ret.DetailSampleMaxError = 1.25f;
                ret.WorldWalkableClimb = 1f;
                ret.WorldWalkableHeight = 2.1f;
                ret.WorldWalkableRadius = 0.6f;
                ret.WalkableClimb = (int) Math.Round(ret.WorldWalkableClimb/ret.CellHeight);
                ret.WalkableHeight = (int) Math.Round(ret.WorldWalkableHeight/ret.CellHeight);
                ret.WalkableRadius = (int) Math.Round(ret.WorldWalkableRadius/ret.CellSize);
                ret.MaxEdgeLength = ret.WalkableRadius*8;
                ret.BorderSize = ret.WalkableRadius + 8;
                ret.TileWidth = tileVoxelSize;
                ret.MaxVertsPerPoly = 6;
                ret.MaxSimplificationError = 1.3f;
                return ret;
            }
        }

        public static RecastConfig Dungeon
        {
            get
            {
                var ret = new RecastConfig();
                ret.CellSize = 0.2f;
                ret.CellHeight = 0.3f;
                ret.MinRegionArea = (int) Math.Pow(5, 2);
                ret.MergeRegionArea = (int) Math.Pow(10, 2);
                ret.WalkableSlopeAngle = 50f;
                ret.DetailSampleDistance = 3f;
                ret.DetailSampleMaxError = 1.25f;
                ret.WorldWalkableClimb = 1f;
                ret.WorldWalkableHeight = 2.1f;
                ret.WorldWalkableRadius = 0.6f;
                ret.WalkableClimb = (int)Math.Round(ret.WorldWalkableClimb / ret.CellHeight);
                ret.WalkableHeight = (int)Math.Round(ret.WorldWalkableHeight / ret.CellHeight);
                ret.WalkableRadius = (int)Math.Round(ret.WorldWalkableRadius / ret.CellSize);
                ret.MaxEdgeLength = ret.WalkableRadius*8;
                ret.MaxVertsPerPoly = 6;
                ret.MaxSimplificationError = 1.25f;
                ret.BorderSize = 0;
                return ret;
            }
        }
    }

}