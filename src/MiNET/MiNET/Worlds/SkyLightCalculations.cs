#region LICENSE

// The contents of this file are subject to the Common Public Attribution
// License Version 1.0. (the "License"); you may not use this file except in
// compliance with the License. You may obtain a copy of the License at
// https://github.com/NiclasOlofsson/MiNET/blob/master/LICENSE.
// The License is based on the Mozilla Public License Version 1.1, but Sections 14
// and 15 have been added to cover use of software over a computer network and
// provide for limited attribution for the Original Developer. In addition, Exhibit A has
// been modified to be consistent with Exhibit B.
// 
// Software distributed under the License is distributed on an "AS IS" basis,
// WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for
// the specific language governing rights and limitations under the License.
// 
// The Original Code is MiNET.
// 
// The Original Developer is the Initial Developer.  The Initial Developer of
// the Original Code is Niclas Olofsson.
// 
// All portions of the code written by Niclas Olofsson are Copyright (c) 2014-2020 Niclas Olofsson.
// All Rights Reserved.

#endregion

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using log4net;
using MiNET.Blocks;
using MiNET.Utils.Vectors;

using Color = System.Drawing.Color;

namespace MiNET.Worlds
{
	public class SkyLightBlockAccess : IBlockAccess
	{
		private readonly IWorldProvider _worldProvider;
		private readonly int _heightForUnloadedChunk;
		private readonly ChunkCoordinates _coord = ChunkCoordinates.None;
		private readonly ChunkColumn _chunk = null;

		public SkyLightBlockAccess(IWorldProvider worldProvider, int heightForUnloadedChunk = 255)
		{
			_worldProvider = worldProvider;
			_heightForUnloadedChunk = heightForUnloadedChunk;
		}

		public SkyLightBlockAccess(IWorldProvider worldProvider, ChunkColumn chunk) : this(worldProvider, -1)
		{
			_chunk = chunk;
			_coord = new ChunkCoordinates(chunk.X, chunk.Z);
		}

		public ChunkColumn GetChunk(BlockCoordinates coordinates, bool cacheOnly = false)
		{
			return GetChunk((ChunkCoordinates) coordinates, cacheOnly);
		}

		public ChunkColumn GetChunk(ChunkCoordinates coordinates, bool cacheOnly = false)
		{
			if (coordinates == _coord) return _chunk;

			if (_coord != ChunkCoordinates.None)
				if (coordinates != _coord)
					if (coordinates != _coord + ChunkCoordinates.Backward)
						if (coordinates != _coord + ChunkCoordinates.Forward)
							if (coordinates != _coord + ChunkCoordinates.Left)
								if (coordinates != _coord + ChunkCoordinates.Right)
									if (coordinates != _coord + ChunkCoordinates.Backward + ChunkCoordinates.Left)
										if (coordinates != _coord + ChunkCoordinates.Backward + ChunkCoordinates.Right)
											if (coordinates != _coord + ChunkCoordinates.Forward + ChunkCoordinates.Left)
												if (coordinates != _coord + ChunkCoordinates.Forward + ChunkCoordinates.Right)
													return null;
			return _worldProvider.GenerateChunkColumn(coordinates, true);
		}

		public void SetSkyLight(BlockCoordinates coordinates, byte skyLight)
		{
			ChunkColumn chunk = GetChunk(coordinates, true);
			chunk?.SetSkyLight(coordinates.X & 0x0f, coordinates.Y, coordinates.Z & 0x0f, skyLight);
		}

		public int GetHeight(BlockCoordinates coordinates)
		{
			ChunkColumn chunk = GetChunk(coordinates, true);
			if (chunk == null) return _heightForUnloadedChunk;

			return chunk.GetHeight(coordinates.X & 0x0f, coordinates.Z & 0x0f);
		}

		public Block GetBlock(BlockCoordinates coord, ChunkColumn tryChunk = null)
		{
			return null;
		}

		public void SetBlock(int x, int y, int z, int blockId, int metadata = 0, bool broadcast = true, bool applyPhysics = true, bool calculateLight = true)
		{
		}

		public void SetBlock(Block block, bool broadcast = true, bool applyPhysics = true, bool calculateLight = true, ChunkColumn possibleChunk = null)
		{
		}
	}

	public class SkyLightCalculations
	{

		static SkyLightCalculations()
		{
		}
		
		private static readonly ILog Log = LogManager.GetLogger(typeof(SkyLightCalculations));

		// Debug tracking, don't enable unless you really need to "see it".

		public bool TrackResults { get; }
		public ConcurrentDictionary<BlockCoordinates, int> Visits { get; } = new ConcurrentDictionary<BlockCoordinates, int>();
		public long StartTimeInMilliseconds { get; set; }

		ConcurrentDictionary<ChunkColumn, bool> _visitedColumns = new ConcurrentDictionary<ChunkColumn, bool>();

		public long visits = 0;

		public SkyLightCalculations(bool trackResults = false)
		{
			TrackResults = trackResults;
		}

		public int CalculateSkyLights(IBlockAccess level, ChunkColumn[] chunks)
		{
			int calcCount = 0;
			var calcTime = new Stopwatch();

			foreach (var chunk in chunks)
			{
				if (!_visitedColumns.TryAdd(chunk, true)) continue;

				if (chunk.IsAllAir) continue;

				calcTime.Restart();
				if (RecalcSkyLight(chunk, level))
				{
					//calcCount++;

					//var elapsedMilliseconds = calcTime.ElapsedMilliseconds;
					//var c = Visits.Sum(pair => pair.Value);
					//if (elapsedMilliseconds > 0) Log.Debug($"Recalc skylight chunk {chunk.x}, {chunk.z}, count #{calcCount} (air={chunk.isAllAir}) chunks. Time {elapsedMilliseconds}ms and {c - lastCount} visits");
					//lastCount = c;
					//PrintVisits();
				}
			}

			//Log.Debug($"Recalc skylight for #{calcCount} chunk. Made {lastCount} visits.");

			return calcCount;
		}

		public bool RecalcSkyLight(ChunkColumn chunk, IBlockAccess level)
		{
			if (chunk == null) return false;

			var lightBfQueue = new Queue<BlockCoordinates>();
			var lightBfSet = new HashSet<BlockCoordinates>();
			for (int x = 0; x < 16; x++)
			{
				for (int z = 0; z < 16; z++)
				{
					if (chunk.IsAllAir && !IsOnChunkBorder(x, z))
					{
						continue;
					}

					int height = GetHigestSurrounding(x, z, chunk, level);
					if (height == 0)
					{
						continue;
					}

					//var skyLight = chunk.GetSkylight(x, height, z);
					//if (skyLight == 15)
					{
						//Block block = level.GetBlockId(new BlockCoordinates(x + (chunk.x*16), height, z + (chunk.z*16)), chunk);
						//Calculate(level, block);
						//Calculate(level, new BlockCoordinates(x + (chunk.x*16), height, z + (chunk.z*16)), lightBfQueue);
						var coordinates = new BlockCoordinates(x + (chunk.X * 16), height, z + (chunk.Z * 16));
						lightBfQueue.Enqueue(coordinates);
						lightBfSet.Add(coordinates);
					}
					//else
					//{
					//	Log.Error($"Block with wrong light level. Expected 15 but was {skyLight}");
					//}
				}
			}

			Calculate(level, lightBfQueue, lightBfSet);

			return true;
		}

		public void Calculate(Level level, BlockCoordinates coordinates)
		{
			int currentLight = level.GetSkyLight(coordinates);

			var chunk = level.GetChunk(coordinates);
			var height = chunk.GetRecalatedHeight(coordinates.X & 0x0f, coordinates.Z & 0x0f);

			Queue<BlockCoordinates> sourceQueue = new Queue<BlockCoordinates>();
			sourceQueue.Enqueue(coordinates);
			if (currentLight != 0)
			{
				Queue<BlockCoordinates> resetQueue = new Queue<BlockCoordinates>();
				HashSet<BlockCoordinates> visits = new HashSet<BlockCoordinates>();

				// Reset all lights that potentially derive from this
				resetQueue.Enqueue(coordinates);

				Queue<BlockCoordinates> deleteQueue = new Queue<BlockCoordinates>();
				while (resetQueue.Count > 0)
				{
					var coord = resetQueue.Dequeue();
					if (visits.Contains(coord))
					{
						continue;
					}

					visits.Add(coord);

					if (coord.DistanceTo(coordinates) > 16) continue;

					ResetLight(level, resetQueue, sourceQueue, coord);
					if (!sourceQueue.Contains(coord))
					{
						deleteQueue.Enqueue(coord);
					}
				}

				level.SetSkyLight(coordinates, 0);

				foreach (var delete in deleteQueue)
				{
					level.SetSkyLight(delete, 0);
				}
			}
			else
			{
				sourceQueue.Enqueue(coordinates);
				sourceQueue.Enqueue(coordinates.BlockUp());
				sourceQueue.Enqueue(coordinates.BlockDown());
				sourceQueue.Enqueue(coordinates.BlockWest());
				sourceQueue.Enqueue(coordinates.BlockEast());
				sourceQueue.Enqueue(coordinates.BlockNorth());
				sourceQueue.Enqueue(coordinates.BlockSouth());
			}

			chunk.SetHeight(coordinates.X & 0x0f, coordinates.Z & 0x0f, (short) height);

			// Recalc
			Queue<BlockCoordinates> lightBfQueue = new Queue<BlockCoordinates>(sourceQueue);
			HashSet<BlockCoordinates> lightBfSet = new HashSet<BlockCoordinates>(sourceQueue);

			SkyLightBlockAccess blockAccess = new SkyLightBlockAccess(level.WorldProvider);
			Calculate(blockAccess, lightBfQueue, lightBfSet);
		}

		public void ResetLight(Level level, Queue<BlockCoordinates> resetQueue, Queue<BlockCoordinates> sourceQueue, BlockCoordinates coordinates)
		{
			int currentLight = level.GetSkyLight(coordinates);

			if (coordinates.Y < 255)
				TestForSource(level, resetQueue, sourceQueue, coordinates.BlockUp(), currentLight);
			if (coordinates.Y > 0)
				TestForSource(level, resetQueue, sourceQueue, coordinates.BlockDown(), currentLight, true);
			TestForSource(level, resetQueue, sourceQueue, coordinates.BlockWest(), currentLight);
			TestForSource(level, resetQueue, sourceQueue, coordinates.BlockEast(), currentLight);
			TestForSource(level, resetQueue, sourceQueue, coordinates.BlockNorth(), currentLight);
			TestForSource(level, resetQueue, sourceQueue, coordinates.BlockSouth(), currentLight);
		}

		private void TestForSource(Level level, Queue<BlockCoordinates> resetQueue, Queue<BlockCoordinates> sourceQueue, BlockCoordinates coordinates, int currentLight, bool down = false)
		{
			int light = level.GetSkyLight(coordinates);
			if (light == 0) return;

			if (light > currentLight || (light == 15 && !down))
			{
				if (!sourceQueue.Contains(coordinates)) sourceQueue.Enqueue(coordinates);
				return;
			}

			if (!resetQueue.Contains(coordinates)) resetQueue.Enqueue(coordinates);
		}

		public void Calculate(IBlockAccess level, Queue<BlockCoordinates> lightBfQueue, HashSet<BlockCoordinates> lightBfSet)
		{
			try
			{
				//if (block.SkyLight != 15)
				//{
				//	Log.Error($"Block at {block.Coordinates} had unexpected light level. Expected 15 but was {block.SkyLight}");
				//}

				while (lightBfQueue.Count > 0)
				{
					var coordinates = lightBfQueue.Dequeue();
					lightBfSet.Remove(coordinates);
					if (coordinates.Y < 0 || coordinates.Y > 255)
					{
						Log.Warn($"Y coord out of bounce {coordinates.Y}");
						continue;
					}

					ChunkColumn chunk = level.GetChunk(coordinates);
					if (chunk == null)
					{
						Log.Warn($"Chunk was null");
						continue;
					}

					var newChunkCoord = (ChunkCoordinates) coordinates;
					if (chunk.X != newChunkCoord.X || chunk.Z != newChunkCoord.Z)
					{
						chunk = level.GetChunk(newChunkCoord);
						if (chunk == null)
						{
							Log.Warn($"Chunk with new coords was null");
							continue;
						}
					}

					ProcessNode(level, chunk, coordinates, lightBfQueue, lightBfSet);
				}
			}
			catch (Exception e)
			{
				Log.Error("Calculation", e);
			}
		}

		private void ProcessNode(IBlockAccess level, ChunkColumn chunk, BlockCoordinates coordinates, Queue<BlockCoordinates> lightBfsQueue, HashSet<BlockCoordinates> lightBfSet)
		{
			//if (section.IsAllAir())

			byte currentSkyLight = GetSkyLight(coordinates, chunk);

			int sectionIdx = coordinates.Y >> 4;
			SubChunk subChunk = chunk.GetSubChunk(coordinates.Y);

			byte maxSkyLight = currentSkyLight;
			if (coordinates.Y < 255)
			{
				var up = coordinates.BlockUp();
				maxSkyLight = Math.Max(maxSkyLight, SetLightLevel(level, chunk, subChunk, sectionIdx, lightBfsQueue, lightBfSet, up, currentSkyLight, up: true));
			}

			if (coordinates.Y > 0)
			{
				var down = coordinates.BlockDown();
				maxSkyLight = Math.Max(maxSkyLight, SetLightLevel(level, chunk, subChunk, sectionIdx, lightBfsQueue, lightBfSet, down, currentSkyLight, down: true));
			}

			var west = coordinates.BlockWest();
			maxSkyLight = Math.Max(maxSkyLight, SetLightLevel(level, chunk, subChunk, sectionIdx, lightBfsQueue, lightBfSet, west, currentSkyLight));


			var east = coordinates.BlockEast();
			maxSkyLight = Math.Max(maxSkyLight, SetLightLevel(level, chunk, subChunk, sectionIdx, lightBfsQueue, lightBfSet, east, currentSkyLight));


			var south = coordinates.BlockSouth();
			maxSkyLight = Math.Max(maxSkyLight, SetLightLevel(level, chunk, subChunk, sectionIdx, lightBfsQueue, lightBfSet, south, currentSkyLight));

			var north = coordinates.BlockNorth();
			maxSkyLight = Math.Max(maxSkyLight, SetLightLevel(level, chunk, subChunk, sectionIdx, lightBfsQueue, lightBfSet, north, currentSkyLight));

			if (IsTransparent(coordinates, subChunk) && currentSkyLight != 15)
			{
				int diffuseLevel = GetDiffuseLevel(coordinates, subChunk);
				maxSkyLight = (byte) Math.Max(currentSkyLight, maxSkyLight - diffuseLevel);

				if (maxSkyLight > currentSkyLight)
				{
					level.SetSkyLight(coordinates, maxSkyLight);

					if (!lightBfSet.Contains(coordinates))
					{
						lightBfsQueue.Enqueue(coordinates);
						lightBfSet.Add(coordinates);
					}
				}
			}
		}

		private byte SetLightLevel(IBlockAccess level, ChunkColumn chunk, SubChunk subChunk, int sectionIdx, Queue<BlockCoordinates> lightBfsQueue, HashSet<BlockCoordinates> lightBfSet, BlockCoordinates coordinates, byte lightLevel, bool down = false, bool up = false)
		{
			//Interlocked.Add(ref visits, 1);

			if (TrackResults) MakeVisit(coordinates);

			if (!(up || down) && (chunk.X != coordinates.X >> 4 || chunk.Z != coordinates.Z >> 4))
			{
				chunk = level.GetChunk((ChunkCoordinates) coordinates);
				subChunk = null;
			}
			else
			{
				if ((up || down) && coordinates.Y >> 4 != sectionIdx)
				{
					subChunk = null;
				}
			}

			if (chunk == null /* || chunk.chunks == null*/) return lightLevel;

			if (!down && !up && coordinates.Y >= GetHeight(coordinates, chunk))
			{
				if (GetSkyLight(coordinates, subChunk) != 15)
				{
					SetSkyLight(coordinates, 15, chunk);

					if (!lightBfSet.Contains(coordinates))
					{
						lightBfsQueue.Enqueue(coordinates);
						lightBfSet.Add(coordinates);
					}
				}

				return 15;
			}

			if (subChunk == null) subChunk = chunk.GetSubChunk(coordinates.Y);

			bool isTransparent = IsTransparent(coordinates, subChunk);
			byte skyLight = GetSkyLight(coordinates, subChunk);

			if (down && isTransparent && lightLevel == 15)
			{
				if (IsNotBlockingSkylight(coordinates, chunk))
				{
					if (skyLight != 15)
					{
						SetSkyLight(coordinates, 15, chunk);
					}

					if (!lightBfSet.Contains(coordinates))
					{
						lightBfsQueue.Enqueue(coordinates);
						lightBfSet.Add(coordinates);
					}

					return 15;
				}
			}

			if (isTransparent)
			{
				int diffuseLevel = GetDiffuseLevel(coordinates, subChunk);
				if (skyLight + 1 + diffuseLevel <= lightLevel)
				{
					byte newLevel = (byte) (lightLevel - diffuseLevel);
					SetSkyLight(coordinates, newLevel, chunk);

					if (!lightBfSet.Contains(coordinates))
					{
						lightBfsQueue.Enqueue(coordinates);
						lightBfSet.Add(coordinates);
					}

					return newLevel;
				}
			}

			return skyLight;
		}

		public static void SetSkyLight(BlockCoordinates coordinates, byte skyLight, ChunkColumn chunk)
		{
			chunk?.SetSkyLight(coordinates.X & 0x0f, coordinates.Y, coordinates.Z & 0x0f, skyLight);
		}

		public static bool IsNotBlockingSkylight(BlockCoordinates blockCoordinates, ChunkColumn chunk)
		{
			if (chunk == null) return true;

			int bid = chunk.GetBlockId(blockCoordinates.X & 0x0f, blockCoordinates.Y, blockCoordinates.Z & 0x0f);
			return bid == 0 || (BlockFactory.TransparentBlocks[bid] == 1 && bid != 18 && bid != 161 && bid != 30 && bid != 8 && bid != 9);
		}

		public static int GetDiffuseLevel(BlockCoordinates blockCoordinates, SubChunk section)
		{
			//TODO: Figure out if this is really correct. Perhaps should be zero.
			if (section == null) return 15;

			int bx = blockCoordinates.X & 0x0f;
			int by = blockCoordinates.Y;
			int bz = blockCoordinates.Z & 0x0f;

			int bid = section.GetBlockId(bx, by - 16 * (by >> 4), bz);
			return bid == 8 || bid == 9 ? 3 : bid == 18 || bid == 161 || bid == 30 ? 2 : 1;
		}

		public static bool IsTransparent(BlockCoordinates blockCoordinates, SubChunk section)
		{
			if (section == null) return true;

			int bx = blockCoordinates.X & 0x0f;
			int by = blockCoordinates.Y;
			int bz = blockCoordinates.Z & 0x0f;

			int bid = section.GetBlockId(bx, by - 16 * (by >> 4), bz);
			return bid == 0 || BlockFactory.TransparentBlocks[bid] == 1;
		}

		public static byte GetSkyLight(BlockCoordinates blockCoordinates, SubChunk chunk)
		{
			if (chunk == null) return 15;

			int bx = blockCoordinates.X & 0x0f;
			int by = blockCoordinates.Y;
			int bz = blockCoordinates.Z & 0x0f;

			return chunk.GetSkylight(bx, by - 16 * (by >> 4), bz);
		}

		public static byte GetSkyLight(BlockCoordinates blockCoordinates, ChunkColumn chunk)
		{
			if (chunk == null) return 15;

			return chunk.GetSkylight(blockCoordinates.X & 0x0f, blockCoordinates.Y, blockCoordinates.Z & 0x0f);
		}

		public static int GetHeight(BlockCoordinates blockCoordinates, ChunkColumn chunk)
		{
			if (chunk == null) return 256;

			return chunk.GetHeight(blockCoordinates.X & 0x0f, blockCoordinates.Z & 0x0f);
		}

		private void MakeVisit(BlockCoordinates inc)
		{
			BlockCoordinates coordinates = new BlockCoordinates(inc.X, 0, inc.Z);
			if (Visits.ContainsKey(coordinates))
			{
				Visits[coordinates] = Visits[coordinates] + 1;
			}
			else
			{
				Visits.TryAdd(coordinates, 1);
			}
		}

		public static void CheckIfSpawnIsMiddle(IOrderedEnumerable<ChunkColumn> chunks, Vector3 spawnPoint)
		{
			int xMin = chunks.OrderBy(kvp => kvp.X).First().X;
			int xMax = chunks.OrderByDescending(kvp => kvp.X).First().X;
			int xd = Math.Abs(xMax - xMin);

			int zMin = chunks.OrderBy(kvp => kvp.Z).First().Z;
			int zMax = chunks.OrderByDescending(kvp => kvp.Z).First().Z;
			int zd = Math.Abs(zMax - zMin);

			int xm = (int) ((xd / 2f) + xMin);
			int zm = (int) ((zd / 2f) + zMin);

			if (xm != (int) spawnPoint.X >> 4) Log.Warn($"Wrong spawn X={xm}, {(int) spawnPoint.X >> 4}");
			if (zm != (int) spawnPoint.Z >> 4) Log.Warn($"Wrong spawn Z={zm}, {(int) spawnPoint.Z >> 4}");

			if (zm == (int) spawnPoint.Z >> 4 && xm == (int) spawnPoint.X >> 4) Log.Warn($"Spawn correct {xm}, {zm} and {(int) spawnPoint.X >> 4}, {(int) spawnPoint.Z >> 4}");
		}

		private int GetMidX(ChunkColumn[] chunks)
		{
			if (!TrackResults) return 0;

			var visits = chunks.ToArray();

			int xMin = visits.OrderBy(kvp => kvp.X).First().X;
			int xMax = visits.OrderByDescending(kvp => kvp.X).First().X;
			int xd = Math.Abs(xMax - xMin);

			return xMin + xd / 2;
		}

		private int GetWidth(ChunkColumn[] chunks)
		{
			if (!TrackResults) return 0;

			var visits = chunks.ToArray();

			int xMin = visits.OrderBy(kvp => kvp.X).First().X;
			int xMax = visits.OrderByDescending(kvp => kvp.X).First().X;
			int xd = Math.Abs(xMax - xMin);

			return xd;
		}

		private int GetWidth()
		{
			if (!TrackResults) return 0;

			var visits = Visits.ToArray();

			int xMin = visits.OrderBy(kvp => kvp.Key.X).First().Key.X;
			int xMax = visits.OrderByDescending(kvp => kvp.Key.X).First().Key.X;
			int xd = Math.Abs(xMax - xMin);

			return xd + 1;
		}

		private int GetHeight()
		{
			if (!TrackResults) return 0;

			var visits = Visits.ToArray();

			int zMin = visits.OrderBy(kvp => kvp.Key.Z).First().Key.Z;
			int zMax = visits.OrderByDescending(kvp => kvp.Key.Z).First().Key.Z;
			int zd = Math.Abs(zMax - zMin);

			return zd + 1;
		}


		static Color CreateHeatColor(double value, double max)
		{
			//if (value < 0) value = 0;

			//Log.Debug($"Before Value={value}, min={min}, max={max}");

			double pct = value / max;
			if (pct < 0) pct = 0;

			//Log.Debug($"Value={v :F2}, max={m:F2}, pct={pct:F2}");

			return Color.FromArgb(255, (byte) (255.0f * pct), (byte) (255.0f * (1 - pct)), 0);

			//int A = 255;
			//int R;
			//int G;
			//int B;
			//if (pct < 0.34d)
			//{
			//	R = 255;
			//	G = (byte) (255*Math.Min(3*(pct - 0.333333d), 1d));
			//	B = 0;
			//}
			//else if (pct < 0.67d)
			//{
			//	R = (byte) (255*Math.Min(3*(1d - pct), 1d));
			//	G = 255;
			//	B = 0;
			//}
			//else
			//{
			//	R = (byte) (128 + (127*Math.Min(3*pct, 1d)));
			//	G = 0;
			//	B = 0;
			//}

			//return Color.FromArgb(A, R, G, B);
		}

		private static bool IsOnChunkBorder(int x, int z)
		{
			return !(x > 0 && x < 15 && z > 0 && z < 15);
		}

		private static int GetHigestSurrounding(int x, int z, ChunkColumn chunk, IBlockAccess level)
		{
			int h = chunk.GetHeight(x, z);
			if (h == 255) return h;

			if (x == 0 || x == 15 || z == 0 || z == 15)
			{
				var coords = new BlockCoordinates(x + (chunk.X * 16), h, z + (chunk.Z * 16));

				//h = Math.Max(h, level.GetHeight(coords + BlockCoordinates.Up));
				h = Math.Max(h, level.GetHeight(coords.BlockWest()));
				h = Math.Max(h, level.GetHeight(coords.BlockEast()));
				h = Math.Max(h, level.GetHeight(coords.BlockNorth()));
				h = Math.Max(h, level.GetHeight(coords.BlockSouth()));
				if (h > 255) h = 255;
				if (h < 0) h = 0;
				return h;
			}

			//if (z < 15) h = Math.Max(h, chunk.GetHeight(x, z + 1));
			//if (z > 0) h = Math.Max(h, chunk.GetHeight(x, z - 1));
			//if (x < 15) h = Math.Max(h, chunk.GetHeight(x + 1, z));
			//if (x < 15 && z > 0) h = Math.Max(h, chunk.GetHeight(x + 1, z - 1));
			//if (x < 15 && z < 15) h = Math.Max(h, chunk.GetHeight(x + 1, z + 1));
			//if (x > 0) h = Math.Max(h, chunk.GetHeight(x - 1, z));
			//if (x > 0 && z > 0) h = Math.Max(h, chunk.GetHeight(x - 1, z - 1));
			//if (x > 0 && z < 15) h = Math.Max(h, chunk.GetHeight(x - 1, z + 1));

			h = Math.Max(h, chunk.GetHeight(x, z + 1));
			h = Math.Max(h, chunk.GetHeight(x, z - 1));
			h = Math.Max(h, chunk.GetHeight(x + 1, z));
			//h = Math.Max(h, chunk.GetHeight(x + 1, z - 1));
			//h = Math.Max(h, chunk.GetHeight(x + 1, z + 1));
			h = Math.Max(h, chunk.GetHeight(x - 1, z));
			//h = Math.Max(h, chunk.GetHeight(x - 1, z - 1));
			//h = Math.Max(h, chunk.GetHeight(x - 1, z + 1));

			return h;
		}

		public void ShowHeights(ChunkColumn chunk)
		{
			if (chunk == null) return;

			for (int x = 0; x < 16; x++)
			{
				for (int z = 0; z < 16; z++)
				{
					var y = chunk.GetHeight(x, z);
					chunk.SetBlock(x, y, z, new GoldBlock());
					//for (byte y = 255; y > 0; y--)
					//{
					//	if (chunk.GetSkylight(x, y, z) == 0)
					//	{
					//		chunk.SetBlock(x, y, z, 41);
					//		break;
					//	}
					//}
				}
			}
		}
	}
}