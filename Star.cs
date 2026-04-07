using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monogame_4___Assignment
{
    public class Star
    {
        private Rectangle _location;
        private Vector2 _speed;
        private Texture2D _texture;
        private Color _color;

        public Star(Texture2D texture, Rectangle location, Vector2 speed, Color color)
        {
            _location = location;
            _texture = texture;
            _speed = speed;
            _color = color;
        }

        public void Update()
        {
            _location.Offset(_speed);
        }

        public void Draw(SpriteBatch spritebach)
        {
            spritebach.Draw(_texture, _location, _color);
        }

        public Rectangle Location
        {
            get { return _location; }
            set { _location = value; }
        }
        public int Y
        {
            get { return _location.Y; }
            set { _location.Y = value; }
        }

        public int X
        {
            get { return _location.X; }
            set { _location.X = value; }
        }
    }
}
