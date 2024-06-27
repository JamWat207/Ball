using System.Numerics;

namespace Ballbouncing
{
    class Mover
    {
        Vector2 distancefrommouse = new Vector2();
        Vector2 location;
        Vector2 velocity;
        Vector2 acceleration;
        Vector2 mouse = new Vector2();
        float topspeed;
        Form frm;
        int formwidth;
        int formheight;
        float number;
        static Random r = new Random();
        static Random rand = new Random();
        public Mover(int width, int hight, Form theform)
        {
            location = new Vector2(width / 2, hight / 2);
            velocity = new Vector2(0, 0);
            formwidth = width;
            formheight = hight;
            frm = theform;
            acceleration = new Vector2((float)-0.1, (float)0.1);
            topspeed = rand.Next(8, 20);




        }



        float Mag(Vector2 theVector)

        {

            return (float)Math.Sqrt(theVector.X * theVector.X + theVector.Y * theVector.Y);

        }


        public Vector2 Limit(float theLimit, Vector2 theVector)

        {



            if (Mag(theVector) > theLimit)

            {

                theVector.X = theVector.X * theLimit / Mag(theVector);

                theVector.Y = theVector.Y * theLimit / Mag(theVector);

            }

            return theVector;

        }
        public void Update()
        {
            Random rand = new Random();

            Point cp = frm.PointToClient(Cursor.Position);
            mouse.X = cp.X;
            mouse.Y = cp.Y;

            Vector2 dir = Vector2.Subtract(mouse, location);
            Vector2 distancefrommouse = Vector2.Subtract(mouse, location);
            dir = Vector2.Normalize(dir);
            distancefrommouse = Vector2.Normalize(distancefrommouse);
            dir = Vector2.Multiply(rand.NextSingle(), dir);
            acceleration = dir;
            velocity = Vector2.Add(velocity, acceleration);
            velocity = Limit(topspeed, velocity);
            location = Vector2.Add(location, velocity);

        }



        public void Display(Graphics e)
        {



            if (velocity.X < 1.8)
            {
                e.DrawRectangle(Pens.Red, location.X, location.Y, 10, 10);
            }

        }





    }
}
