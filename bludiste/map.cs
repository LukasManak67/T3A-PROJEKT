using System.Drawing;

namespace bludiste
{
    public class Map
    {
        Random rnd = new Random();
        List<Rectangle> rooms = new List<Rectangle>();
        public int TileSize = 130;
        public int Width = 50;
        public int Height = 50;

        public int[,] grid;

        public Map()
        {
            grid = new int[Height, Width];

            FillWalls();
            GenerateRooms();
            ConnectRooms();
        }

        private void GenerateBorders()
        {
            for (int radek  = 0; radek < Height; radek++)
            {
                for (int sloupec = 0; sloupec < Width; sloupec++)
                {
                    if (radek == 0 || radek == Height - 1 ||
                        sloupec == 0 || sloupec == Width - 1)
                    {
                        grid[radek, sloupec] = 1; // zeď
                    }
                    else
                    {
                        grid[radek, sloupec] = 0; // volno
                    }
                }
            }
        }

        public void Draw(Graphics g, int cameraX, int cameraY)
        {
            for (int radek = 0; radek < Height; radek++)
            {
                for (int sloupec = 0; sloupec < Width; sloupec++)
                {
                    Brush brush = grid[radek, sloupec] == 1
                        ? Brushes.Black
                        : Brushes.White;

                    g.FillRectangle(
                        brush,
                        sloupec * TileSize - cameraX,
                        radek * TileSize - cameraY,
                        TileSize,
                        TileSize
                    );
                }
            }
        }

        public bool IsWall(float x, float y)
        {
            int col = (int)(x / TileSize);
            int row = (int)(y / TileSize);

            if (col < 0 || row < 0 || col >= Width || row >= Height)
                return true;

            return grid[row, col] == 1;
        }

        private void FillWalls()
        {
            for (int r = 0; r < Height; r++)
            {
                for (int c = 0; c < Width; c++)
                {
                    grid[r, c] = 1;
            }
        }
        }

        private void GenerateRooms()
        {
            int roomTarget = 12;       // pocet mistnosti
            int attempts = 0;

            while (rooms.Count < roomTarget && attempts < 100)
            {
                attempts++;

                int w = rnd.Next(4, 8);
                int h = rnd.Next(4, 8);

                int x = rnd.Next(1, Width - w - 1);
                int y = rnd.Next(1, Height - h - 1);

                Rectangle newRoom = new Rectangle(x, y, w, h);

                bool overlaps = false;

                foreach (Rectangle room in rooms)
                {
                    Rectangle expanded = new Rectangle(
                        room.X - 1,
                        room.Y - 1,
                        room.Width + 2,
                        room.Height + 2
                    );

                    if (expanded.IntersectsWith(newRoom))
                    {
                        overlaps = true;
                        break;
                    }
                }

                if (overlaps)
                    continue;

                rooms.Add(newRoom);

                for (int r = y; r < y + h; r++)
                {
                    for (int c = x; c < x + w; c++)
                    {
                        grid[r, c] = 0;
                    }
                }
            }
        }

        private void ConnectRooms()
        {
            for (int i = 1; i < rooms.Count; i++)
            {
                Point centerA = GetCenter(rooms[i - 1]);
                Point centerB = GetCenter(rooms[i]);

                CreateCorridor(centerA, centerB);
            }
        }

        private Point GetCenter(Rectangle room)
        {
            int x = room.X + room.Width / 2;
            int y = room.Y + room.Height / 2;

            return new Point(x, y);
        }

        private void CreateCorridor(Point a, Point b)
        {
            int x = a.X;
            int y = a.Y;

            while (x != b.X)
            {
                grid[y, x] = 0;
                x += Math.Sign(b.X - x);
            }

            while (y != b.Y)
                {
                grid[y, x] = 0;
                y += Math.Sign(b.Y - y);
                }
            }

        public Point GetSpawnPosition()
        {
            Rectangle firstRoom = rooms[0];

            int x = firstRoom.X + firstRoom.Width / 2;
            int y = firstRoom.Y + firstRoom.Height / 2;

            return new Point(x * TileSize, y * TileSize);
        }

        public bool IsColliding(float x, float y, int size)
        {
            int left = (int)(x / TileSize);
            int right = (int)((x + size - 1) / TileSize);
            int top = (int)(y / TileSize);
            int bottom = (int)((y + size - 1) / TileSize);

            if (grid[top, left] == 1) return true;
            if (grid[top, right] == 1) return true;
            if (grid[bottom, left] == 1) return true;
            if (grid[bottom, right] == 1) return true;

            return false;
        }

        public List<Rectangle> GetRooms()
        {
            return rooms;
        }
    }
}
