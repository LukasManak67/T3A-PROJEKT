namespace bludiste
{
    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer gameTimer;
        Map map;
        Player player;

        int cameraX;
        int cameraY;

        bool up, down, left, right;

        List<Key> keys = new List<Key>();
        int collectedKeys = 0;

        public Form1()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.DoubleBuffered = true;
            this.KeyPreview = true;

            gameTimer = new System.Windows.Forms.Timer();
            gameTimer.Interval = 16;
            gameTimer.Tick += GameLoop;
            gameTimer.Start();

            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;

            map = new Map();

            Point spawn = map.GetSpawnPosition();

            player = new Player(spawn.X, spawn.Y);

            SpawnKeys();


        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void GameLoop(object sender, EventArgs e)
        {
            player.Update(up, down, left, right, map);
            Invalidate();
            // hranice mapy
            int mapWidthPx = map.Width * map.TileSize;
            int mapHeightPx = map.Height * map.TileSize;

            // levá hrana
            if (player.X < 0)
                player.X = 0;

            // horní hrana
            if (player.Y < 0)
                player.Y = 0;

            // pravá hrana
            if (player.X + player.Size > mapWidthPx)
                player.X = mapWidthPx - player.Size;

            // dolní hrana
            if (player.Y + player.Size > mapHeightPx)
                player.Y = mapHeightPx - player.Size;

            cameraX = (int)(player.X - this.ClientSize.Width / 2);
            cameraY = (int)(player.Y - this.ClientSize.Height / 2);

            foreach (var key in keys)
            {
                if (!key.Collected && key.CheckCollision(player))
                {
                    key.Collected = true;
                    collectedKeys++;
                }
            }

            if (collectedKeys == 4)
            {
                gameTimer.Stop();
                MessageBox.Show("Vyhrál jsi!");
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.Clear(Color.Black);

            e.Graphics.DrawString(
                "Funguje to",
                this.Font,
                Brushes.White,
                20, 20
            );

            map.Draw(e.Graphics, cameraX, cameraY);

            player.Draw(e.Graphics, cameraX, cameraY);

            foreach (var key in keys)
            {
                key.Draw(e.Graphics, cameraX, cameraY);
            }

            e.Graphics.DrawString(
            $"Klíče: {collectedKeys}/4",
            this.Font,
            Brushes.Yellow,
            20,
            50
            );



        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) up = true;
            if (e.KeyCode == Keys.S) down = true;
            if (e.KeyCode == Keys.A) left = true;
            if (e.KeyCode == Keys.D) right = true;
            if (e.KeyCode == Keys.Space)
            {
                player.StartDash();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) up = false;
            if (e.KeyCode == Keys.S) down = false;
            if (e.KeyCode == Keys.A) left = false;
            if (e.KeyCode == Keys.D) right = false;
        }

        private void SpawnKeys()
        {
            var rooms = map.GetRooms();
            Random rnd = new Random();

            for (int i = 0; i < 4; i++)
            {
                Rectangle room = rooms[rnd.Next(rooms.Count)];

                float x = (room.X + room.Width / 2) * map.TileSize;
                float y = (room.Y + room.Height / 2) * map.TileSize;

                keys.Add(new Key(x, y));
            }
        }

    }
}
