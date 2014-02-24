﻿namespace FyodorDostoevskyRPG.GameObject.GameItems
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class Chest : Item
    {
        Random random = new Random();
        private Texture2D OpenedChest { get; set; }
        public ChestState ChestStatus { get; set; }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)this.Position.X, (int)this.Position.Y, this.Image.Width, this.Image.Height);
            }
        }
        public Chest(Vector2 position)
            :base(ScreenManagement.ScreenManager.Instance.screenManagerContent.Load<Texture2D>("ChestClosed"), position) 
        {
            ChestStatus = ChestState.Closed;
        }

        public Item RandomItem()
        {
            int whatToGet = random.Next(1, 4);
            ChestStatus = ChestState.Opened;
            if (whatToGet == 1)
            {
                OpenedChest = ScreenManagement.ScreenManager.Instance.screenManagerContent.Load<Texture2D>("sword");
                return new Sword(new Vector2(this.Position.X,this.Position.Y), 20, 40);
            }
            else if (whatToGet == 2)
            {
                OpenedChest = ScreenManagement.ScreenManager.Instance.screenManagerContent.Load<Texture2D>("flail");
                return new Flail(new Vector2(this.Position.X, this.Position.Y), 25, 50);
            }
            else
            {
                OpenedChest = ScreenManagement.ScreenManager.Instance.screenManagerContent.Load<Texture2D>("shield");
                return new Shield(new Vector2(this.Position.X, this.Position.Y), 10);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            switch (ChestStatus)
            {
                case ChestState.Closed:
                    spriteBatch.Draw(this.Image, this.Position, Color.White);
                    break;
                case ChestState.Opened:
                    spriteBatch.Draw(this.OpenedChest, this.Position, Color.White);
                    break;
            }
        }

    }
}
