using System.Drawing;

namespace bludiste
{
    public enum KeyType
    {
        Yellow,
        Red
    }
    public class Key
    {
        public float X;
        public float Y;
        public int Size = 40;
        public bool Collected = false;
        public KeyType Type;

        public Key(float x, float y, KeyType type)
        {
            X = x;
            Y = y;
            Type = type;
        }

        public void Draw(Graphics g, int cameraX, int cameraY)
        {
            if (!Collected)
            {
                Brush color = Type == KeyType.Yellow ? Brushes.Gold : Brushes.Red;

                g.FillEllipse(
                    color,
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