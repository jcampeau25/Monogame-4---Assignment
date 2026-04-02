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

        public Star(Texture2D texture, Rectangle location, Vector2 speed)
        {
            _location = location;
            _texture = texture;
            _speed = speed;

        }

        public void Update()
        {
            _location.Offset(_speed);
        }

        public void Draw(SpriteBatch spritebach)
        {
            spritebach.Draw(_texture, _location, Color.White);
        }
    }
}
