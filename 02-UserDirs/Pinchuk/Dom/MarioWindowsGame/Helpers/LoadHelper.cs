using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioWindowsGame.Helpers
{
    static class LoadHelper
    {
        public static Dictionary<TextureEnum, Texture2D> Textures;
        public static Dictionary<FontEnum, SpriteFont> Fonts;

        public static void Load(ContentManager content)
        {
            Textures = new Dictionary<TextureEnum, Texture2D>();
            Fonts = new Dictionary<FontEnum, SpriteFont>();

            Textures.Add(TextureEnum.Logo, content.Load<Texture2D>(@"Texture\Logo"));
            Textures.Add(TextureEnum.Exit, content.Load<Texture2D>(@"Texture\Exit"));
            Textures.Add(TextureEnum.Clouds, content.Load<Texture2D>(@"Texture\Clouds"));

            #region load fonts
            Fonts.Add(FontEnum.Arial22, content.Load<SpriteFont>(@"Fonts\wayoshi72"));
            Fonts.Add(FontEnum.Arial42, content.Load<SpriteFont>(@"Fonts\wayoshi72"));
            #endregion 
        }
    }

    public enum TextureEnum
    {
        Logo,
        Exit,
        Clouds
    }
    public enum FontEnum
    {
        Arial22,
        Arial42
    }

}
