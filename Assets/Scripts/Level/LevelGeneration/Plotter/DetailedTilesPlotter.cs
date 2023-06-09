﻿using DungeonDraws.Scripts.Systems.LevelGeneration.Domain;

namespace DungeonDraws.Scripts.Systems.LevelGeneration.Plotters
{
    public class DetailedTilesPlotter : IBoardPlotter
    {
        public void applyOnCorridor(Corridor corridor, int[,] map)
        {
            for (int row = 0; row < corridor.height(); row++)
            {
                for (int col = 0; col < corridor.width(); col++)
                {
                    Cell pos = corridor.topLeftVertex().plusCell(row, col);
                    int rowPos = pos.row();
                    int colPos = pos.col();

                    if (pos.isEqual(corridor.topLeftVertex()))
                    {
                        map[rowPos, colPos] = corridor.isVertical()
                            ? (int)DetailedTileType.Corner_OUT_NW
                            : (int)DetailedTileType.Corner_OUT_SE;
                    }
                    else if (pos.isEqual(corridor.topRightVertex()))
                    {
                        map[rowPos, colPos] = corridor.isVertical()
                            ? (int)DetailedTileType.Corner_OUT_SW
                            : (int)DetailedTileType.Corner_OUT_NE;
                    }
                    else if (pos.isEqual(corridor.bottomRightVertex()))
                    {
                        map[rowPos, colPos] = corridor.isVertical()
                            ? (int)DetailedTileType.Corner_OUT_SE
                            : (int)DetailedTileType.Corner_OUT_NW;
                    }
                    else if (pos.isEqual(corridor.bottomLeftVertex()))
                    {
                        map[rowPos, colPos] = corridor.isVertical()
                            ? (int)DetailedTileType.Corner_OUT_NE
                            : (int)DetailedTileType.Corner_OUT_SW;
                    }
                    else if (pos.isWithin(corridor.topLeftVertex(), corridor.topRightVertex()) &&
                             corridor.isOrizontal())
                    {
                        map[rowPos, colPos] = (int)DetailedTileType.Wall_N;
                    }
                    else if (pos.isWithin(corridor.topRightVertex(), corridor.bottomRightVertex()) &&
                             corridor.isVertical())
                    {
                        map[rowPos, colPos] = (int)DetailedTileType.Wall_E;
                    }
                    else if (pos.isWithin(corridor.bottomLeftVertex(), corridor.bottomRightVertex()) &&
                             corridor.isOrizontal())
                    {
                        map[rowPos, colPos] = (int)DetailedTileType.Wall_S;
                    }
                    else if (pos.isWithin(corridor.topLeftVertex(), corridor.bottomLeftVertex()) &&
                             corridor.isVertical())
                    {
                        map[rowPos, colPos] = (int)DetailedTileType.Wall_W;
                    }
                    else
                    {
                        map[rowPos, colPos] = (int)DetailedTileType.Floor;
                    }
                }
            }

            // Check if corridor shares vertexes with Source Room and Destination Room
            if (corridor.isSharingBottomLeftVertexWithSourceRoom())
            {
                map[corridor.bottomLeftVertex().row(),
                    corridor.bottomLeftVertex().col()] = corridor.isVertical()
                    ? (int)DetailedTileType.Wall_W
                    : (int)DetailedTileType.Wall_S;
            }

            if (corridor.isSharingTopRightVertexWithSourceRoom())
            {
                map[corridor.topRightVertex().row(), corridor.topRightVertex().col()] = corridor.isVertical()
                    ? (int)DetailedTileType.Wall_E
                    : (int)DetailedTileType.Wall_N;
            }

            if (corridor.isSharingTopLeftVertexWithSourceRoom())
            {
                map[corridor.topLeftVertex().row(), corridor.topLeftVertex().col()] = corridor.isVertical()
                    ? (int)DetailedTileType.Wall_W
                    : (int)DetailedTileType.Wall_N;
            }

            if (corridor.isSharingBottomRightVertexWithSourceRoom())
            {
                map[corridor.bottomRightVertex().row(), corridor.bottomRightVertex().col()] = corridor.isVertical()
                    ? (int)DetailedTileType.Wall_E
                    : (int)DetailedTileType.Wall_S;
            }

            if (corridor.isSharingBottomLeftVertexWithDestRoom())
            {
                map[corridor.bottomLeftVertex().row(), corridor.bottomLeftVertex().col()] = corridor.isVertical()
                    ? (int)DetailedTileType.Wall_W
                    : (int)DetailedTileType.Wall_S;
            }

            if (corridor.isSharingTopRightVertexWithDestRoom())
            {
                map[corridor.topRightVertex().row(), corridor.topRightVertex().col()] = corridor.isVertical()
                    ? (int)DetailedTileType.Wall_E
                    : (int)DetailedTileType.Wall_N;
            }

            if (corridor.isSharingTopLeftVertexWithDestRoom())
            {
                map[corridor.topLeftVertex().row(), corridor.topLeftVertex().col()] = corridor.isVertical()
                    ? (int)DetailedTileType.Wall_W
                    : (int)DetailedTileType.Wall_N;
            }

            if (corridor.isSharingBottomRightVertexWithDestRoom())
            {
                map[corridor.bottomRightVertex().row(), corridor.bottomRightVertex().col()] = corridor.isVertical()
                    ? (int)DetailedTileType.Wall_E
                    : (int)DetailedTileType.Wall_S;
            }
        }

        public void applyOnRoom(Room room, int[,] map)
        {
            for (int row = 0; row < room.height(); row++)
            {
                for (int col = 0; col < room.width(); col++)
                {
                    Cell pos = room.topLeftVertex().plusCell(row, col);
                    int rowPos = pos.row();
                    int colPos = pos.col();

                    if (pos.isEqual(room.topLeftVertex()))
                    {
                        map[rowPos, colPos] = (int)DetailedTileType.Corner_INN_SW;
                    }
                    else if (pos.isEqual(room.topRightVertex()))
                    {
                        map[rowPos, colPos] = (int)DetailedTileType.Corner_INN_SE;
                    }
                    else if (pos.isEqual(room.bottomRightVertex()))
                    {
                        map[rowPos, colPos] = (int)DetailedTileType.Corner_INN_NE;
                    }
                    else if (pos.isEqual(room.bottomLeftVertex()))
                    {
                        map[rowPos, colPos] = (int)DetailedTileType.Corner_INN_NW;
                    }
                    else if (pos.isWithin(room.topLeftVertex(), room.topRightVertex()))
                    {
                        map[rowPos, colPos] = (int)DetailedTileType.Wall_N;
                    }
                    else if (pos.isWithin(room.topRightVertex(), room.bottomRightVertex()))
                    {
                        map[rowPos, colPos] = (int)DetailedTileType.Wall_E;
                    }
                    else if (pos.isWithin(room.bottomLeftVertex(), room.bottomRightVertex()))
                    {
                        map[rowPos, colPos] = (int)DetailedTileType.Wall_S;
                    }
                    else if (pos.isWithin(room.topLeftVertex(), room.bottomLeftVertex()))
                    {
                        map[rowPos, colPos] = (int)DetailedTileType.Wall_W;
                    }
                    else
                    {
                        map[rowPos, colPos] = (int)DetailedTileType.Floor;
                    }
                }
            }
        }
    }

    public enum DetailedTileType
    {
        Empty,
        Floor,
        Wall_N,
        Wall_E,
        Wall_S,
        Wall_W,
        Corner_INN_NW,
        Corner_INN_NE,
        Corner_INN_SE,
        Corner_INN_SW,
        Corner_OUT_NE,
        Corner_OUT_NW,
        Corner_OUT_SW,
        Corner_OUT_SE
    }
}