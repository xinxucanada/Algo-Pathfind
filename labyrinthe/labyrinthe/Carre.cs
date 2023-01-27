using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labyrinthe
{
    public enum Status
    {
        vide,
        visited,
        essay,
        mort,
        meilleur
    }
    public class Carre
    {
        public int x;
        public int y;
        public int step;
        public Carre pre;
        public int distanceTobe;
        public int totalDistance;
        public Status status;
       

        public Carre(int x, int y, int step, Carre pre, int distanceTobe, Status status)
        {
            this.x = x;
            this.y = y;
            this.step = step;
            this.pre = pre;
            this.distanceTobe = distanceTobe;
            this.totalDistance = step + distanceTobe;
            this.status = status;
         
        }

        public Carre(int x, int y, int step, Carre pre)
        {
            this.x = x;
            this.y = y;
            this.step = step;
            this.pre = pre;
        }
        public Carre copy()
        {
            return new Carre(this.x, this.y, this.step, this.pre);
        }
       public override string ToString()
        {
            return $"x: {x}, y: {y}, step: {step}";
        }



    }
}
