using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA
{
    class MonteCarlo
    {
        private Random rnd = new Random();
        public Cell[,] simulateMC(Cell[,] tablePop, int height, int width)
        {
            int size = height * width;
            List<int> list = new List<int>(size);
            for (int i = 0; i < size; i++)
            {
                list.Add(i);
            }
            //keep extracting from the list until it's depleted
            while (list.Count > 0)
            {
                int index = rnd.Next(0, list.Count);
                CalculateEnergy(tablePop, index, height, width);
                list.RemoveAt(index);
                //tu chyba trzeba zrobić jakiegoś diwnego ifa, ktory sprawdza czy id jest zywe czy jako ta cala granica, albo moze usunac je wczesniej
            }
            return tablePop;
        }
        private void CalculateEnergy(Cell[,] tablePop, int index, int height, int width)
        {
            int i = 1;
            int j = 1;
            int tmpi = 1;
            int tmpj = 1;
            int actEnergry = 0;
            int neighboor;
            int tmpQ = 0;
            for ( i = 1; i < height-1; i++)
            {
                for (j = 1; j < width - 1; j++)
                {
                    if (tablePop[i, j].ID == index)
                    {
                        tmpQ = tablePop[i, j].Qi;
                        if (tablePop[i - 1, j - 1].Qi != tablePop[i, j].Qi)
                            actEnergry++;
                        if (tablePop[i - 1, j].Qi != tablePop[i, j].Qi)
                            actEnergry++;
                        if (tablePop[i - 1, j + 1].Qi != tablePop[i, j].Qi)
                            actEnergry++;
                        if (tablePop[i, j - 1].Qi != tablePop[i, j].Qi)
                            actEnergry++;
                        if (tablePop[i, j + 1].Qi != tablePop[i, j].Qi)
                            actEnergry++;
                        if (tablePop[i + 1, j - 1].Qi != tablePop[i, j].Qi)
                            actEnergry++;
                        if (tablePop[i + 1, j].Qi != tablePop[i, j].Qi)
                            actEnergry++;
                        if (tablePop[i + 1, j + 1].Qi != tablePop[i, j].Qi)
                            actEnergry++;
                        if(actEnergry == 8)
                        {
                            tablePop[i, j].isBorder = true;
                        }
                        tablePop[i, j].oldState = actEnergry;
                        tmpi = i;
                        tmpj = j;
                        break;
                    }
                }
            }
            i = tmpi;
            j = tmpj;

            if (j == width - 1)
                --j;
            if (i == height - 1)
                --i;
            neighboor = rnd.Next(1, 9);
            switch (neighboor){
                case 1:
                    {
                        tablePop[i, j].Qi = tablePop[i-1, j-1].Qi;
                        break;
                    }
                case 2:
                    {
                        tablePop[i, j].Qi = tablePop[i - 1, j].Qi;
                        break;
                    }
                case 3:
                    {
                        tablePop[i, j].Qi = tablePop[i - 1, j + 1].Qi;
                        break;
                    }
                case 4:
                    {
                        tablePop[i, j].Qi = tablePop[i, j - 1].Qi;
                        break;
                    }
                case 5:
                    {
                        tablePop[i, j].Qi = tablePop[i, j + 1].Qi;
                        break;
                    }
                case 6:
                    {
                        tablePop[i, j].Qi = tablePop[i + 1, j - 1].Qi;
                        break;
                    }
                case 7:
                    {
                        tablePop[i, j].Qi = tablePop[i + 1, j].Qi;
                        break;
                    }
                case 8:
                    {
                        tablePop[i, j].Qi = tablePop[i + 1, j + 1].Qi;
                        break;
                    }
                default:
                    {
                        tablePop[i, j].Qi = tablePop[i - 1, j - 1].Qi;
                        break;
                    }
            }
            actEnergry = 0;
            if (tablePop[i - 1, j - 1].Qi != tablePop[i, j].Qi)
                actEnergry++;
            if (tablePop[i - 1, j].Qi != tablePop[i, j].Qi)
                actEnergry++;
            if (tablePop[i - 1, j + 1].Qi != tablePop[i, j].Qi)
                actEnergry++;
            if (tablePop[i, j - 1].Qi != tablePop[i, j].Qi)
                actEnergry++;
            if (tablePop[i, j + 1].Qi != tablePop[i, j].Qi)
                actEnergry++;
            if (tablePop[i + 1, j - 1].Qi != tablePop[i, j].Qi)
                actEnergry++;
            if (tablePop[i + 1, j].Qi != tablePop[i, j].Qi)
                actEnergry++;
            if (tablePop[i + 1, j + 1].Qi != tablePop[i, j].Qi)
                actEnergry++;
            tablePop[i, j].newState = actEnergry;
            actEnergry = tablePop[i, j].newState - tablePop[i, j].oldState;
            if (actEnergry > 0)
            {
                double p;
                p = Math.Exp(-(actEnergry = actEnergry / 1));
                if (p < 1)
                {
                    tablePop[i, j].Qi = tmpQ;

                }
            }
        }
    }
}
