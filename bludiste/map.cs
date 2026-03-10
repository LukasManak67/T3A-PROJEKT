using System.Drawing;

namespace bludiste
{
    public class Map
    {
        public int TileSize = 50;
        public int Width = 50;
        public int Height = 50;

        public int[,] grid;

        public Map()
        {
            grid = new int[Height, Width];

            GenerateBorders();
            GenerateMaze();

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
                        ? Brushes.DarkGray
                        : Brushes.LightGray;

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
        private void GenerateMaze()
        {
            for (int radek = 2; radek < Height - 2; radek += 2)
            {
                for (int sloupec = 2; sloupec < Width - 2; sloupec += 2)
                {
                    grid[radek, sloupec] = 1;
                }
            }
        }

    }
}
