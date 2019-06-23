using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA
{
    class Population
    {
        public int height;
        public int width;
        public Cell[,] tablePop;
        public int amountNucleos;

        public void setZeros()
        {
            int counter = 0;
            tablePop = new Cell[height,width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    tablePop[i, j] = new Cell();
                    tablePop[i,j].ID = counter;
                    tablePop[i,j].Qi = 0;
                    tablePop[i, j].isBorder = false;
                    ++counter;
                }
            }
        }
        public void setCell(int state, int i, int j)
        {
            tablePop[i, j].Qi = state;
        }
        public void homogenousNucleation(int amountRow, int amountColumn)
        {
            int intervalR = width / amountRow;
            int intervalC = height / amountColumn;
            amountNucleos = 1;
            for (int i = 1; i < height-1; i+=intervalC)
            {
                for (int j = 1; j < width-1; j+=intervalR)
                {
                    tablePop[i, j].Qi = amountNucleos;
                    ++amountNucleos;
                }
            }
            
            /*for (int i = 1; i < height - 1; i++)
            {
                for (int j = 1; j < width - 1; j++)
                {
                    Console.Write(tablePop[i, j].Qi);
                }
                Console.WriteLine();
            }*/
        }
        public void randomNucleation(int amount)
        {
            Random rnd = new Random();
            int x;
            int y;
            amountNucleos = 1;
            for (int i = 1; i <=amount; i++)
            {
                x = rnd.Next(1, height);
                y = rnd.Next(1, width);
                tablePop[x, y].Qi = amountNucleos;
                ++amountNucleos;
            }
        }
    }
}
