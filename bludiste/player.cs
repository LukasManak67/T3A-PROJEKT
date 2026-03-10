using System;
using System.Collections.Generic;
using System.Text;

namespace bludiste
{
    public class Player
    {
        public float X;
        public float Y;
        private bool isDashing = false;
        private int dashTimer = 0;
        private int dashDuration = 10;
        public float NSpeed = 5f;
        public float DSpeed = 20f;
        public int Size = 40;

        public Player(int startX, int startY)
        {
            X = startX;
            Y = startY;
        }

        public void Update(bool up, bool down, bool left, bool right, Map map)
        {
            float currentSpeed = NSpeed;

            if (isDashing)
            {
                currentSpeed = DSpeed;
                dashTimer--;

                if (dashTimer <= 0)
                    isDashing = false;
            }

            float newX = X;
            float newY = Y;

            if (up) newY -= currentSpeed;
            if (down) newY += currentSpeed;
            if (left) newX -= currentSpeed;
            if (right) newX += currentSpeed;

            if (!map.IsColliding(newX, Y, Size))
            {
                X = newX;
            }

            if (!map.IsColliding(X, newY, Size))
            {
                Y = newY;
            }
        }

        public void Draw(Graphics g, int cameraX, int cameraY)
        {
            g.FillRectangle(Brushes.Blue,X - cameraX,Y - cameraY,Size,Size);

        }
        public void StartDash()
        {
            if (!isDashing)
            {
                isDashing = true;
                dashTimer = dashDuration;
            }
        }

    }
}
