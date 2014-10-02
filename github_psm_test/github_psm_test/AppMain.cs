using System;
using System.Collections.Generic;

using Sce.Pss.Core;
using Sce.Pss.Core.Environment;
using Sce.Pss.Core.Graphics;
using Sce.Pss.Core.Input;

using Sce.Pss.HighLevel.GameEngine2D;
using Sce.Pss.HighLevel.GameEngine2D.Base;

using Sce.Pss.Core.Imaging;

namespace HelloWorld
{
 public class AppMain
 {
  public static void Main (string[] args)
  {
   Director.Initialize();
   
   Scene scene = new Scene();
   scene.Camera.SetViewFromViewport();
   
   var width = Director.Instance.GL.Context.GetViewport().Width;
   var height = Director.Instance.GL.Context.GetViewport().Height;
   
   Image img = new Image(ImageMode.Rgba, new ImageSize(width,height),
                         new ImageColor(255,0,0,0));
   img.DrawText("Hello World", 
                new ImageColor(255,0,0,255),
                new Font(FontAlias.System,170,FontStyle.Regular),
                new ImagePosition(0,150));
  
   Texture2D texture = new Texture2D(width,height,false,
                                     PixelFormat.Rgba);
   texture.SetPixels(0,img.ToBuffer());
   img.Dispose();                                  
   
   TextureInfo ti = new TextureInfo();
   ti.Texture = texture;
   
   SpriteUV sprite = new SpriteUV();
   sprite.TextureInfo = ti;
   
   sprite.Quad.S = ti.TextureSizef;
   sprite.CenterSprite();
   sprite.Position = scene.Camera.CalcBounds().Center;
   
   scene.AddChild(sprite);
   
   Director.Instance.RunWithScene(scene);
  }
 }
}