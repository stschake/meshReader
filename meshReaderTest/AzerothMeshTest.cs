using System;
using System.Linq;
using meshPather;
using Microsoft.Xna.Framework;
using NUnit.Framework;
using RecastLayer;

namespace meshReaderTest
{
    
    [TestFixture]
    public class AzerothMeshTest : MeshTest
    {

        [TestFixtureSetUp]
        public void Initialize()
        {
            Initialize("S:\\meshReader\\Meshes\\Azeroth");
        }

        [Test]
        public void LongTest()
        {
            TryPath(new Vector3(-22, -918, 54), new Vector3(1699, 1706, 135));
        }

        [Test]
        public void HumanStartingArea01()
        {
            TryPath(new Vector3(-8949.918f, -133.572f, 83.589f), new Vector3(-8929f, -195f, 80f));
        }

        [Test]
        public void HumanStartingArea02()
        {
            TryPath(new Vector3(-8949.918f, -133.572f, 83.589f), new Vector3(-8903f, -159f, 81.9f));
        }

        [Test]
        public void HumanStartingArea03()
        {
            TryPath(new Vector3(-8949.918f, -133.572f, 83.589f), new Vector3(-8898f, -173f, 81.5f));
        }

        [Test]
        public void HumanStartingArea04()
        {
            TryPath(new Vector3(-8949.918f, -133.572f, 83.589f), new Vector3(-8916f, -214f, 82.1f));
        }

        [Test]
        public void HumanStartingArea05()
        {
            TryPath(new Vector3(-8949.918f, -133.572f, 83.589f), new Vector3(-8909f, -216f, 89.1f));
        }

        [Test]
        public void HumanStartingArea06()
        {
            TryPath(new Vector3(-8949.918f, -133.572f, 83.589f), new Vector3(-8900f, -181f, 113.1f));
        }

        [Test]
        public void HumanStartingArea07()
        {
            TryPath(new Vector3(-8949.918f, -133.572f, 83.589f), new Vector3(-8897f, -174f, 115.7f));
        }

        [Test]
        public void TileCrossing()
        {
            TryPath(new Vector3(-9467.8f, 64.2f, 55.9f), new Vector3(-9248.9f, -93.35f, 70.3f));
        }

        [Test]
        public void StormwindToDocks()
        {
            TryPath(new Vector3(-8957.4f, 517.3f, 96.3f), new Vector3(-8476.375f, 1257.56f, 5.238828f));
        }

        [Test]
        public void GoldhainToStormwind()
        {
            TryPath(new Vector3(-9447.5f, 55.4f, 56.2f), new Vector3(-8957.4f, 517.3f, 96.3f));
        }

        [Test(Description = "A longer path to test dynamic tile loading")]
        public void HumanStartToStormwind()
        {
            TryPath(new Vector3(-8949.918f, -133.572f, 83.589f), new Vector3(-8957.4f, 517.3f, 96.3f));
        }

        [Test(Description = "Test the difference between ground pathing and using flightpathes")]
        public void TestFlightpathes()
        {
            System.Collections.Generic.List<Hop> roadHops;
            Pather.Filter.ExcludeFlags = (ushort) (PolyFlag.FlightMaster);
            TryPath(new Vector3(-9447.5f, 55.4f, 56.2f), new Vector3(-8957.4f, 517.3f, 96.3f), out roadHops, false);

            Pather = new Pather("S:\\meshReader\\Meshes\\Azeroth", MockConnectionHandler);
            System.Collections.Generic.List<Hop> flightHops;
            TryPath(new Vector3(-9447.5f, 55.4f, 56.2f), new Vector3(-8957.4f, 517.3f, 96.3f), out flightHops, false);

            Console.WriteLine("Ground path: " + roadHops.Count + " hops, Flight path: " + flightHops.Count + " hops");
            Assert.Less(flightHops.Count, roadHops.Count);
            Assert.IsTrue(flightHops.Any(hop => hop.Type == HopType.Flightmaster && hop.FlightTarget != null));
        }

        private static bool MockConnectionHandler(ConnectionData data)
        {
            if (!data.Alliance)
                return false;
            return true;
        }

        [Test]
        public void TestRoadPriorization()
        {
            Pather.Filter.SetAreaCost((int)PolyArea.Water, 1);
            Pather.Filter.SetAreaCost((int)PolyArea.Terrain, 10);
            Pather.Filter.SetAreaCost((int)PolyArea.Road, 1);
            var roadLength = TryPath(new Vector3(-8949.918f, -133.572f, 83.589f), new Vector3(-8957.4f, 517.3f, 96.3f));
            Console.WriteLine("Path length on road: " + roadLength);

            Pather.Filter.SetAreaCost((int)PolyArea.Water, 1);
            Pather.Filter.SetAreaCost((int)PolyArea.Terrain, 1);
            Pather.Filter.SetAreaCost((int)PolyArea.Road, 1);
            var normalLength = TryPath(new Vector3(-8949.918f, -133.572f, 83.589f), new Vector3(-8957.4f, 517.3f, 96.3f));
            Console.WriteLine("Shortest possible path: " + normalLength);
            
            Assert.IsTrue(roadLength > normalLength);
        }

        [Test]
        public void UndeadStartingArea01()
        {
            TryPath(new Vector3(1676.7f, 1678.1f, 121.6f), new Vector3(1680.3f, 1664.9f, 135.2f));
        }

        [Test]
        public void UndeadStartingArea02()
        {
            TryPath(new Vector3(1676.7f, 1678.1f, 121.6f), new Vector3(1843.5f, 1641.2f, 97.6f));
        }
    }

}