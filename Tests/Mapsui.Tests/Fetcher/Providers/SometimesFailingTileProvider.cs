﻿using System;
using System.Threading.Tasks;
using BruTile;

namespace Mapsui.Tests.Fetcher.Providers
{
    internal class SometimesFailingTileProvider : CountingTileProvider
    {
        private readonly Random _random = new Random(DateTime.Now.Millisecond);

        public override async Task<byte[]>? GetTileAsync(TileInfo tileInfo)
        {
            await base.GetTileAsync(tileInfo); // Just for counting

            if (_random.NextDouble() < 0.5)
            {
                if (_random.NextDouble() < 0.5)
                    throw new Exception("this provider sometimes fails");
                return null; // This means the tile is not available in the source
            }
            return await Task.FromResult(Array.Empty<byte>());
        }
    }
}
