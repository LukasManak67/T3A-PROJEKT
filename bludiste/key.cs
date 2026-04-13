using System.Drawing;

namespace bludiste
{
    public class Key
    {
        public float X;
        public float Y;
        public int Size = 20;
        public bool Collected = false;

        public Key(float x, float y)
        {
            X = x;
            Y = y;
        }

        public void Draw(Graphics g, int cameraX, int cameraY)
        {
            if (!Collected)
            {
                g.FillEllipse(
                    Brushes.Gold,
                    X - cameraX,
                    Y - cameraY,
                    Size,
                    Size
                );
            }
        }

        public bool CheckCollision(Player player)
        {
            Rectangle keyRect = new Rectangle((int)X, (int)Y, Size, Size);
            Rectangle playerRect = new Rectangle((int)player.X, (int)player.Y, player.Size, player.Size);

            return keyRect.IntersectsWith(playerRect);
        }
    }
}