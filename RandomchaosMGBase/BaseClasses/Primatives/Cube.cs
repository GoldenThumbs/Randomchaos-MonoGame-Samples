﻿using Microsoft.Xna.Framework;

namespace RandomchaosMGBase.BaseClasses.Primatives
{
    public class Cube : PrimativeBase
    {
        public Cube(Game game) : base(game) { }
        public Cube(Game game, string effectAsset) : base(game, effectAsset)
        {

        }

        protected override void BuildData()
        {
            VertexList.AddRange(new Vector3[]
            {
                new Vector3(.5f, -.5f, .5f), new Vector3(-.5f, -.5f, .5f), new Vector3(-.5f, .5f, .5f),new Vector3(.5f, .5f, .5f),
                new Vector3(.5f, -.5f, -.5f), new Vector3(-.5f, -.5f, -.5f), new Vector3(-.5f, .5f, -.5f), new Vector3(.5f, .5f, -.5f),
                new Vector3(.5f, .5f, -.5f), new Vector3(-.5f, .5f, -.5f), new Vector3(-.5f, .5f, .5f),new Vector3(.5f, .5f, .5f),
                new Vector3(.5f, -.5f, -.5f),new Vector3(-.5f, -.5f, -.5f),new Vector3(-.5f, -.5f, .5f),new Vector3(.5f, -.5f, .5f),
                new Vector3(-.5f, -.5f, .5f),new Vector3(-.5f, -.5f, -.5f),new Vector3(-.5f, .5f, -.5f),new Vector3(-.5f, .5f, .5f),
                new Vector3(.5f, -.5f, .5f),new Vector3(.5f, -.5f, -.5f),new Vector3(.5f, .5f, -.5f),new Vector3(.5f, .5f, .5f)
            });

            NormalList.AddRange(new Vector3[]
            {
                Vector3.Backward,Vector3.Backward,Vector3.Backward,Vector3.Backward,
                Vector3.Forward,Vector3.Forward,Vector3.Forward,Vector3.Forward,
                Vector3.Up,Vector3.Up,Vector3.Up,Vector3.Up,
                Vector3.Down,Vector3.Down,Vector3.Down,Vector3.Down,
                Vector3.Left,Vector3.Left,Vector3.Left,Vector3.Left,
                Vector3.Right,Vector3.Right,Vector3.Right,Vector3.Right,
            });

            TexCoordList.AddRange(new Vector2[]
            {
                new Vector2(1, 1),new Vector2(0, 1),new Vector2(0,0),new Vector2(1, 0),
                new Vector2(0, 1),new Vector2(1, 1),new Vector2(1,0),new Vector2(0, 0),
                new Vector2(0, 1),new Vector2(1, 1),new Vector2(1,0),new Vector2(0, 0),
                new Vector2(1, 1),new Vector2(0, 1),new Vector2(0,0),new Vector2(1, 0),
                new Vector2(1, 1),new Vector2(0, 1),new Vector2(0,0),new Vector2(1, 0),
                new Vector2(1, 1),new Vector2(0, 1),new Vector2(0,0),new Vector2(1, 0),
                new Vector2(0, 1),new Vector2(1, 1),new Vector2(1,0),new Vector2(0, 0),
            });

            ColorList.AddRange(new Color[]
            {
                Color.White,Color.White,Color.White,Color.White,
                Color.White,Color.White,Color.White,Color.White,
                Color.White,Color.White,Color.White,Color.White,
                Color.White,Color.White,Color.White,Color.White,
                Color.White,Color.White,Color.White,Color.White,
                Color.White,Color.White,Color.White,Color.White,
            });


            IndexList.AddRange(new int[]
            {
                0, 1, 2, 2, 3, 0, // Front
                4, 7, 6, 6, 5, 4, // Back
                8, 11, 10, 10, 9, 8, // Top
                12, 13, 14, 14, 15, 12, // Bottom
                16, 17, 18, 18, 19, 16, // Left
                20, 23, 22, 22, 21, 20, // Right
            });

            CalculateTangents();
        }
    }
}
