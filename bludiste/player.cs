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

        public void Update(bool up, bool down, bool left, bool right)
        {
            float currentSpeed = NSpeed;

            if (isDashing)
            {
                currentSpeed = DSpeed;
                dashTimer--;

                if (dashTimer <= 0)
                {
                    isDashing = false;
                }
            }

            if (up) Y -= currentSpeed;
            if (down) Y += currentSpeed;
            if (left) X -= currentSpeed;
            if (right) X += currentSpeed;
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
