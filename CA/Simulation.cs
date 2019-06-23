using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA
{
    class Simulation
    {
        private Random rnd = new Random();
        private const int resolutionWidth = 700;
        private const int resolutionHeight = 500;
        private int cellWidth;
        private int cellHeight;

        public void RozrostZiaren(Cell[,] tablePopActual, Cell[,] tablePopNew, int height, int width, System.Drawing.Graphics rectangle, int amountNucleos, string neighboor)
        {
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Gray);
            Color[] randomColour = new Color[amountNucleos]; // +1 becaouse we always need to have default gray

            setColours(randomColour, amountNucleos);
            switch (neighboor)
            {
                case "VonNeumann":
                    {
                        VonNeumann(tablePopActual, tablePopNew, height, width, rectangle, myBrush, randomColour);
                        break;
                    }
                case "Moore":
                    {
                        Moore(tablePopActual, tablePopNew, height, width, rectangle, myBrush, randomColour);
                        break;
                    }
                case "Pentagonal Random":
                    {
                        pentagonalRandom(tablePopActual, tablePopNew, height, width, rectangle, myBrush, randomColour);
                        break;
                    }
                case "Heksagonal Left":
                    {
                        //heksagonalRandom(tablePopActual, tablePopNew, height, width, rectangle, myBrush, randomColour, 2);
                        break;
                    }
                case "Heksagonal Right":
                    {
                        //heksagonalRandom(tablePopActual, tablePopNew, height, width, rectangle, myBrush, randomColour, 3);
                        break;
                    }
                case "Heksagonal Random":
                    {
                        //heksagonalRandom(tablePopActual, tablePopNew, height, width, rectangle, myBrush, randomColour, 1);
                        break;
                    }
                default:
                    {
                        VonNeumann(tablePopActual, tablePopNew, height, width, rectangle, myBrush, randomColour);
                        break;
                    }
            }
            MC(tablePopActual,tablePopNew, height, width, rectangle, myBrush, randomColour);
            DRX(tablePopActual, tablePopNew, height, width, rectangle, myBrush, randomColour);

        }
        private void setColours(Color[] randomColour, int amountNucleos)
        {
            randomColour[0] = Color.Gray;
            for (int i = 1; i < amountNucleos; i++)
            {
                randomColour[i] = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            }
        }
        private void VonNeumann(Cell[,] tablePopActual, Cell[,] tablePopNew, int height, int width, System.Drawing.Graphics rectangle, System.Drawing.SolidBrush myBrush, Color[] randomColour)
        {
            bool check = true;
            cellWidth = resolutionWidth / (width - 1);
            cellHeight = resolutionHeight / (height - 1);

            while (check)
            {
                check = false;
                for (int i = 1; i < height - 1; i++)
                {
                    for (int j = 1; j < width - 1; j++)
                    {
                        if (tablePopActual[i, j].Qi != 0)
                        {
                            if (tablePopNew[i - 1, j].Qi == 0)
                                tablePopNew[i - 1, j].Qi = tablePopActual[i, j].Qi;
                            if (tablePopNew[i, j - 1].Qi == 0)
                                tablePopNew[i, j - 1].Qi = tablePopActual[i, j].Qi;
                            if (tablePopNew[i, j].Qi == 0)
                                tablePopNew[i, j] = tablePopActual[i, j];
                            if (tablePopNew[i + 1, j].Qi == 0)
                                tablePopNew[i + 1, j].Qi = tablePopActual[i, j].Qi;
                            if (tablePopNew[i, j + 1].Qi == 0)
                                tablePopNew[i, j + 1].Qi = tablePopActual[i, j].Qi;
                        }
                        else
                        {
                            check = true;
                        }

                    }
                }

                for (int i = 1; i < height - 1; i++)
                {
                    for (int j = 1; j < width - 1; j++)
                    {
                        myBrush.Color = randomColour[tablePopActual[i, j].Qi];
                        rectangle.FillRectangle(myBrush, new Rectangle(cellWidth * j, cellHeight * i, cellWidth, cellHeight));
                        tablePopActual[i, j].Qi = tablePopNew[i, j].Qi;
                    }
                }
                //System.Threading.Thread.Sleep(100);
            }
        }
        private void Moore(Cell[,] tablePopActual, Cell[,] tablePopNew, int height, int width, System.Drawing.Graphics rectangle, System.Drawing.SolidBrush myBrush, Color[] randomColour)
        {
            bool check = true;
            cellWidth = resolutionWidth / (width - 1);
            cellHeight = resolutionHeight / (height - 1);
            while (check)
            {
                check = false;
                for (int i = 1; i < height - 1; i++)
                {
                    for (int j = 1; j < width - 1; j++)
                    {
                        if (tablePopActual[i, j].Qi != 0)
                        {
                            if (tablePopNew[i - 1, j - 1].Qi == 0)
                                tablePopNew[i - 1, j - 1].Qi = tablePopActual[i, j].Qi;
                            if (tablePopNew[i - 1, j].Qi == 0)
                                tablePopNew[i - 1, j].Qi = tablePopActual[i, j].Qi;
                            if (tablePopNew[i - 1, j + 1].Qi == 0)
                                tablePopNew[i - 1, j + 1].Qi = tablePopActual[i, j].Qi;
                            if (tablePopNew[i, j - 1].Qi == 0)
                                tablePopNew[i, j - 1].Qi = tablePopActual[i, j].Qi;
                            if (tablePopNew[i, j].Qi == 0)
                                tablePopNew[i, j].Qi = tablePopActual[i, j].Qi;
                            if (tablePopNew[i, j + 1].Qi == 0)
                                tablePopNew[i, j + 1].Qi = tablePopActual[i, j].Qi;
                            if (tablePopNew[i + 1, j - 1].Qi == 0)
                                tablePopNew[i + 1, j - 1].Qi = tablePopActual[i, j].Qi;
                            if (tablePopNew[i + 1, j].Qi == 0)
                                tablePopNew[i + 1, j].Qi = tablePopActual[i, j].Qi;
                            if (tablePopNew[i + 1, j + 1].Qi == 0)
                                tablePopNew[i + 1, j + 1].Qi = tablePopActual[i, j].Qi;
                        }
                        else
                        {
                            check = true;
                        }

                    }
                }

                for (int i = 1; i < height - 1; i++)
                {
                    for (int j = 1; j < width - 1; j++)
                    {
                        myBrush.Color = randomColour[tablePopActual[i, j].Qi];
                        rectangle.FillRectangle(myBrush, new Rectangle(cellWidth * j, cellHeight * i, cellWidth, cellHeight));
                        tablePopActual[i, j].Qi = tablePopNew[i, j].Qi;
                    }
                }
                //System.Threading.Thread.Sleep(100);
            }

        }
        private void pentagonalRandom(Cell[,] tablePopActual, Cell[,] tablePopNew, int height, int width, System.Drawing.Graphics rectangle, System.Drawing.SolidBrush myBrush, Color[] randomColour)
        {
            Random choosePent = new Random();
            int pent = choosePent.Next(1, 4);
            switch (pent)
            {
                case 1:
                    {
                        pentagonalLeft(tablePopActual, tablePopNew, height, width, rectangle, myBrush, randomColour);
                        break;
                    }
                case 2:
                    {
                        pentagonalRight(tablePopActual, tablePopNew, height, width, rectangle, myBrush, randomColour);
                        break;
                    }
                case 3:
                    {
                        pentagonalUp(tablePopActual, tablePopNew, height, width, rectangle, myBrush, randomColour);
                        break;
                    }
                case 4:
                    {
                        pentagonalDown(tablePopActual, tablePopNew, height, width, rectangle, myBrush, randomColour);
                        break;
                    }
                default:
                    break;
            }

        }
        private void pentagonalLeft(Cell[,] tablePopActual, Cell[,] tablePopNew, int height, int width, System.Drawing.Graphics rectangle, System.Drawing.SolidBrush myBrush, Color[] randomColour)
        {
            bool check = true;
            cellWidth = resolutionWidth / (width - 1);
            cellHeight = resolutionHeight / (height - 1);
            int limitOfUselessIterations = width * height * 2;
            int checkerCounter = limitOfUselessIterations;

            while (check && (checkerCounter > 0))
            {
                check = false;
                for (int i = 1; i < height - 1; i++)
                {
                    for (int j = 1; j < width - 1; j++)
                    {
                        if (tablePopActual[i, j].Qi != 0)
                        {
                            if (tablePopNew[i - 1, j - 1].Qi == 0)
                            {
                                checkerCounter = limitOfUselessIterations;
                                tablePopNew[i - 1, j - 1].Qi = tablePopActual[i, j].Qi;
                            }
                            if (tablePopNew[i - 1, j].Qi == 0)
                            {
                                checkerCounter = limitOfUselessIterations;
                                tablePopNew[i - 1, j].Qi = tablePopActual[i, j].Qi;
                            }
                            if (tablePopNew[i, j - 1].Qi == 0)
                            {
                                checkerCounter = limitOfUselessIterations;
                                tablePopNew[i, j - 1].Qi = tablePopActual[i, j].Qi;
                            }
                            if (tablePopNew[i, j].Qi == 0)
                            {
                                checkerCounter = limitOfUselessIterations;
                                tablePopNew[i, j].Qi = tablePopActual[i, j].Qi;
                            }
                            if (tablePopNew[i + 1, j - 1].Qi == 0)
                            {
                                checkerCounter = limitOfUselessIterations;
                                tablePopNew[i + 1, j - 1].Qi = tablePopActual[i, j].Qi;
                            }
                            if (tablePopNew[i + 1, j].Qi == 0)
                            {
                                checkerCounter = limitOfUselessIterations;
                                tablePopNew[i + 1, j].Qi = tablePopActual[i, j].Qi;
                            }
                        }
                        else
                        {
                            --checkerCounter;
                            check = true;
                        }

                    }
                }

                for (int i = 1; i < height - 1; i++)
                {
                    for (int j = 1; j < width - 1; j++)
                    {
                        myBrush.Color = randomColour[tablePopActual[i, j].Qi];
                        rectangle.FillRectangle(myBrush, new Rectangle(cellWidth * j, cellHeight * i, cellWidth, cellHeight));
                        tablePopActual[i, j].Qi = tablePopNew[i, j].Qi;
                    }
                }
                //System.Threading.Thread.Sleep(100);
            }
            myBrush.Dispose();
            rectangle.Dispose();

        }
        private void pentagonalRight(Cell[,] tablePopActual, Cell[,] tablePopNew, int height, int width, System.Drawing.Graphics rectangle, System.Drawing.SolidBrush myBrush, Color[] randomColour)
        {
            bool check = true;
            cellWidth = resolutionWidth / (width - 1);
            cellHeight = resolutionHeight / (height - 1);
            int limitOfUselessIterations = width * height * 2;
            int checkerCounter = limitOfUselessIterations;

            while (check && (checkerCounter > 0))
            {
                check = false;
                for (int i = 1; i < height - 1; i++)
                {
                    for (int j = 1; j < width - 1; j++)
                    {
                        if (tablePopActual[i, j].Qi != 0)
                        {
                            if (tablePopNew[i - 1, j].Qi == 0)
                            {
                                checkerCounter = limitOfUselessIterations;
                                tablePopNew[i - 1, j].Qi = tablePopActual[i, j].Qi;
                            }
                            if (tablePopNew[i - 1, j + 1].Qi == 0)
                            {
                                checkerCounter = limitOfUselessIterations;
                                tablePopNew[i - 1, j + 1].Qi = tablePopActual[i, j].Qi;
                            }
                            if (tablePopNew[i, j].Qi == 0)
                            {
                                checkerCounter = limitOfUselessIterations;
                                tablePopNew[i, j].Qi = tablePopActual[i, j].Qi;
                            }
                            if (tablePopNew[i, j + 1].Qi == 0)
                            {
                                checkerCounter = limitOfUselessIterations;
                                tablePopNew[i, j + 1].Qi = tablePopActual[i, j].Qi;
                            }
                            if (tablePopNew[i + 1, j].Qi == 0)
                            {
                                checkerCounter = limitOfUselessIterations;
                                tablePopNew[i + 1, j].Qi = tablePopActual[i, j].Qi;
                            }
                            if (tablePopNew[i + 1, j + 1].Qi == 0)
                            {
                                checkerCounter = limitOfUselessIterations;
                                tablePopNew[i + 1, j + 1].Qi = tablePopActual[i, j].Qi;
                            }
                        }
                        else
                        {
                            --checkerCounter;
                            check = true;
                        }

                    }
                }

                for (int i = 1; i < height - 1; i++)
                {
                    for (int j = 1; j < width - 1; j++)
                    {
                        myBrush.Color = randomColour[tablePopActual[i, j].Qi];
                        rectangle.FillRectangle(myBrush, new Rectangle(cellWidth * j, cellHeight * i, cellWidth, cellHeight));
                        tablePopActual[i, j].Qi = tablePopNew[i, j].Qi;
                    }
                }
                //System.Threading.Thread.Sleep(100);
            }
            myBrush.Dispose();
            rectangle.Dispose();

        }
        private void pentagonalUp(Cell[,] tablePopActual, Cell[,] tablePopNew, int height, int width, System.Drawing.Graphics rectangle, System.Drawing.SolidBrush myBrush, Color[] randomColour)
        {
            bool check = true;
            cellWidth = resolutionWidth / (width - 1);
            cellHeight = resolutionHeight / (height - 1);
            int limitOfUselessIterations = width * height * 2;
            int checkerCounter = limitOfUselessIterations;

            while (check && (checkerCounter > 0))
            {
                check = false;
                for (int i = 1; i < height - 1; i++)
                {
                    for (int j = 1; j < width - 1; j++)
                    {
                        if (tablePopActual[i, j].Qi != 0)
                        {
                            if (tablePopNew[i - 1, j - 1].Qi == 0)
                            {
                                checkerCounter = limitOfUselessIterations;
                                tablePopNew[i - 1, j - 1].Qi = tablePopActual[i, j].Qi;
                            }
                            if (tablePopNew[i - 1, j].Qi == 0)
                            {
                                checkerCounter = limitOfUselessIterations;
                                tablePopNew[i - 1, j].Qi = tablePopActual[i, j].Qi;
                            }
                            if (tablePopNew[i - 1, j + 1].Qi == 0)
                            {
                                checkerCounter = limitOfUselessIterations;
                                tablePopNew[i - 1, j + 1].Qi = tablePopActual[i, j].Qi;
                            }
                            if (tablePopNew[i, j - 1].Qi == 0)
                            {
                                checkerCounter = limitOfUselessIterations;
                                tablePopNew[i, j - 1].Qi = tablePopActual[i, j].Qi;
                            }
                            if (tablePopNew[i, j].Qi == 0)
                            {
                                checkerCounter = limitOfUselessIterations;
                                tablePopNew[i, j].Qi = tablePopActual[i, j].Qi;
                            }
                            if (tablePopNew[i, j + 1].Qi == 0)
                            {
                                checkerCounter = limitOfUselessIterations;
                                tablePopNew[i, j + 1].Qi = tablePopActual[i, j].Qi;
                            }

                        }
                        else
                        {
                            check = true;
                            --checkerCounter;
                        }

                    }
                }

                for (int i = 1; i < height - 1; i++)
                {
                    for (int j = 1; j < width - 1; j++)
                    {
                        myBrush.Color = randomColour[tablePopActual[i, j].Qi];
                        rectangle.FillRectangle(myBrush, new Rectangle(cellWidth * j, cellHeight * i, cellWidth, cellHeight));
                        tablePopActual[i, j].Qi = tablePopNew[i, j].Qi;
                    }
                }
                //System.Threading.Thread.Sleep(100);
            }
            myBrush.Dispose();
            rectangle.Dispose();

        }
        private void pentagonalDown(Cell[,] tablePopActual, Cell[,] tablePopNew, int height, int width, System.Drawing.Graphics rectangle, System.Drawing.SolidBrush myBrush, Color[] randomColour)
        {
            bool check = true;
            cellWidth = resolutionWidth / (width - 1);
            cellHeight = resolutionHeight / (height - 1);
            int limitOfUselessIterations = width * height * 2;
            int checkerCounter = limitOfUselessIterations;

            while (check && (checkerCounter > 0))
            {
                check = false;
                for (int i = 1; i < height - 1; i++)
                {
                    for (int j = 1; j < width - 1; j++)
                    {
                        if (tablePopActual[i, j].Qi != 0)
                        {
                            if (tablePopNew[i, j - 1].Qi == 0)
                            {
                                checkerCounter = limitOfUselessIterations;
                                tablePopNew[i, j - 1].Qi = tablePopActual[i, j].Qi;
                            }
                            if (tablePopNew[i, j].Qi == 0)
                            {
                                checkerCounter = limitOfUselessIterations;
                                tablePopNew[i, j].Qi = tablePopActual[i, j].Qi;
                            }
                            if (tablePopNew[i, j + 1].Qi == 0)
                            {
                                checkerCounter = limitOfUselessIterations;
                                tablePopNew[i, j + 1].Qi = tablePopActual[i, j].Qi;
                            }
                            if (tablePopNew[i + 1, j - 1].Qi == 0)
                            {
                                checkerCounter = limitOfUselessIterations;
                                tablePopNew[i + 1, j - 1].Qi = tablePopActual[i, j].Qi;
                            }
                            if (tablePopNew[i + 1, j].Qi == 0)
                            {
                                checkerCounter = limitOfUselessIterations;
                                tablePopNew[i + 1, j].Qi = tablePopActual[i, j].Qi;
                            }
                            if (tablePopNew[i + 1, j + 1].Qi == 0)
                            {
                                checkerCounter = limitOfUselessIterations;
                                tablePopNew[i + 1, j + 1].Qi = tablePopActual[i, j].Qi;
                            }
                        }
                        else
                        {
                            check = true;
                            --checkerCounter;
                        }

                    }
                }

                for (int i = 1; i < height - 1; i++)
                {
                    for (int j = 1; j < width - 1; j++)
                    {
                        myBrush.Color = randomColour[tablePopActual[i, j].Qi];
                        rectangle.FillRectangle(myBrush, new Rectangle(cellWidth * j, cellHeight * i, cellWidth, cellHeight));
                        tablePopActual[i, j].Qi = tablePopNew[i, j].Qi;
                    }
                }
                //System.Threading.Thread.Sleep(100);
            }
            myBrush.Dispose();
            rectangle.Dispose();

        }
        private void MC(Cell[,] tablePopActual, Cell[,] tablePopNew, int height, int width, System.Drawing.Graphics rectangle, System.Drawing.SolidBrush myBrush, Color[] randomColour)
        {
            cellWidth = resolutionWidth / (width - 1);
            cellHeight = resolutionHeight / (height - 1);
            MonteCarlo simMC = new MonteCarlo();
            tablePopActual = simMC.simulateMC(tablePopActual, height, width);
            for (int i = 1; i < height - 1; i++)
            {
                for (int j = 1; j < width - 1; j++)
                {
                    myBrush.Color = randomColour[tablePopActual[i, j].Qi];
                    rectangle.FillRectangle(myBrush, new Rectangle(cellWidth * j, cellHeight * i, cellWidth, cellHeight));
                    tablePopActual[i, j].Qi = tablePopNew[i, j].Qi;
                }
            }
            //System.Threading.Thread.Sleep(100);
        }
        private void DRX(Cell[,] tablePopActual, Cell[,] tablePopNew, int height, int width, System.Drawing.Graphics rectangle, System.Drawing.SolidBrush myBrush, Color[] randomColour)
        {
            cellWidth = resolutionWidth / (width - 1);
            cellHeight = resolutionHeight / (height - 1);
            Recristalization simMC = new Recristalization();
            tablePopActual = simMC.simulation1(tablePopActual, height, width);
            for (int i = 1; i < height - 1; i++)
            {
                for (int j = 1; j < width - 1; j++)
                {
                   // if(tablePopActual[i,j].isRecrystallized)
                       // myBrush.Color = Color.DarkRed;
                    if(tablePopActual[i,j].Qi < 0)
                    {
                        myBrush.Color = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));

                    }
                    else
                        myBrush.Color = randomColour[tablePopActual[i, j].Qi];
                    rectangle.FillRectangle(myBrush, new Rectangle(cellWidth * j, cellHeight * i, cellWidth, cellHeight));
                }
            }
            //System.Threading.Thread.Sleep(100);
            myBrush.Dispose();
            rectangle.Dispose();
        }
        /*private void heksagonalRandom(Cell[,] tablePopActual, Cell[,] tablePopNew, int height, int width, System.Drawing.Graphics rectangle, System.Drawing.SolidBrush myBrush, Color[] randomColour, int isRandom)
        {
            Random chooseHeksa = new Random();
            int heksa = 1;
            bool check = true;

            while (check)
            {
                if (isRandom == 1)
                {
                    heksa = chooseHeksa.Next(1, 3);
                    Console.Write(heksa);
                }
                else if(isRandom == 2)
                {
                    heksa = 1;
                }
                else
                {
                    heksa = 2;
                }

                switch (heksa)
                {
                    case 1:
                        {
                            check = heksagonalLeft(tablePopActual, tablePopNew, height, width, rectangle, myBrush, randomColour, check);
                            break;
                        }
                    case 2:
                        {
                            check = heksagonalRight(tablePopActual, tablePopNew, height, width, rectangle, myBrush, randomColour, check);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            myBrush.Dispose();
            rectangle.Dispose();


        }
        private bool heksagonalLeft(Cell[,] tablePopActual, Cell[,] tablePopNew, int height, int width, System.Drawing.Graphics rectangle, System.Drawing.SolidBrush myBrush, Color[] randomColour, bool check)
        {
            bool[] isHeksa = new bool[8];
            Random chooseHeksa = new Random();
            int heksa = 1;

            cellWidth = resolutionWidth / (width - 1);
            cellHeight = resolutionHeight / (height - 1);


                check = false;
                for (int i = 1; i < height - 1; i++)
                {
                    for (int j = 1; j < width - 1; j++)
                    {
                        if (tablePopActual[i, j] != 0)
                        {
                        heksa = chooseHeksa.Next(1, 3);

                        switch (heksa)
                        {
                            case 1:
                                {
                                    isHeksa[0] = true;
                                    isHeksa[7] = true;
                                    if (tablePopNew[i - 1, j - 1] == 0 && !isHeksa[0])
                                        tablePopNew[i - 1, j - 1] = tablePopActual[i, j];
                                    if (tablePopNew[i - 1, j] == 0 && !isHeksa[1])
                                        tablePopNew[i - 1, j] = tablePopActual[i, j];
                                    if (tablePopNew[i - 1, j + 1] == 0 && !isHeksa[2])
                                        tablePopNew[i - 1, j + 1] = tablePopActual[i, j];
                                    if (tablePopNew[i, j - 1] == 0 && !isHeksa[3])
                                        tablePopNew[i, j - 1] = tablePopActual[i, j];
                                    if (tablePopNew[i, j] == 0)
                                        tablePopNew[i, j] = tablePopActual[i, j];
                                    if (tablePopNew[i, j + 1] == 0 && !isHeksa[4])
                                        tablePopNew[i, j + 1] = tablePopActual[i, j];
                                    if (tablePopNew[i + 1, j - 1] == 0 && !isHeksa[5])
                                        tablePopNew[i + 1, j - 1] = tablePopActual[i, j];
                                    if (tablePopNew[i + 1, j] == 0 && !isHeksa[6])
                                        tablePopNew[i + 1, j] = tablePopActual[i, j];
                                    if (tablePopNew[i + 1, j + 1] == 0 && !isHeksa[7])
                                        tablePopNew[i + 1, j + 1] = tablePopActual[i, j];
                                    break;
                                }
                            case 2:
                                {
                                    isHeksa[2] = true;
                                    isHeksa[5] = true;
                                    if (tablePopNew[i - 1, j - 1] == 0 && !isHeksa[0])
                                        tablePopNew[i - 1, j - 1] = tablePopActual[i, j];
                                    if (tablePopNew[i - 1, j] == 0 && !isHeksa[1])
                                        tablePopNew[i - 1, j] = tablePopActual[i, j];
                                    if (tablePopNew[i - 1, j + 1] == 0 && !isHeksa[2])
                                        tablePopNew[i - 1, j + 1] = tablePopActual[i, j];
                                    if (tablePopNew[i, j - 1] == 0 && !isHeksa[3])
                                        tablePopNew[i, j - 1] = tablePopActual[i, j];
                                    if (tablePopNew[i, j] == 0)
                                        tablePopNew[i, j] = tablePopActual[i, j];
                                    if (tablePopNew[i, j + 1] == 0 && !isHeksa[4])
                                        tablePopNew[i, j + 1] = tablePopActual[i, j];
                                    if (tablePopNew[i + 1, j - 1] == 0 && !isHeksa[5])
                                        tablePopNew[i + 1, j - 1] = tablePopActual[i, j];
                                    if (tablePopNew[i + 1, j] == 0 && !isHeksa[6])
                                        tablePopNew[i + 1, j] = tablePopActual[i, j];
                                    if (tablePopNew[i + 1, j + 1] == 0 && !isHeksa[7])
                                        tablePopNew[i + 1, j + 1] = tablePopActual[i, j];
                                    break;
                                }
                            default:
                                {
                                    break;
                                }
                        }

                        }
                        else
                        {
                            check = true;
                        }

                    }
                }

                for (int i = 1; i < height - 1; i++)
                {
                    for (int j = 1; j < width - 1; j++)
                    {
                        myBrush.Color = randomColour[tablePopActual[i, j]];
                        rectangle.FillRectangle(myBrush, new Rectangle(cellWidth * j, cellHeight * i, cellWidth, cellHeight));
                        tablePopActual[i, j] = tablePopNew[i, j];
                    }
                }
                //System.Threading.Thread.Sleep(100);

            return check;
        }
        private bool heksagonalRight(Cell[,] tablePopActual, Cell[,] tablePopNew, int height, int width, System.Drawing.Graphics rectangle, System.Drawing.SolidBrush myBrush, Color[] randomColour, bool check)
        {
            bool[] isHeksa = new bool[8];

            cellWidth = resolutionWidth / (width - 1);
            cellHeight = resolutionHeight / (height - 1);
            isHeksa[2] = true;
            isHeksa[5] = true;

                check = false;
                for (int i = 1; i < height - 1; i++)
                {
                    for (int j = 1; j < width - 1; j++)
                    {
                        if (tablePopActual[i, j] != 0)
                        {
                            if (tablePopNew[i - 1, j - 1] == 0 && !isHeksa[0])
                                tablePopNew[i - 1, j - 1] = tablePopActual[i, j];
                            if (tablePopNew[i - 1, j] == 0 && !isHeksa[1])
                                tablePopNew[i - 1, j] = tablePopActual[i, j];
                            if (tablePopNew[i - 1, j + 1] == 0 && !isHeksa[2])
                                tablePopNew[i - 1, j + 1] = tablePopActual[i, j];
                            if (tablePopNew[i, j - 1] == 0 && !isHeksa[3])
                                tablePopNew[i, j - 1] = tablePopActual[i, j];
                            if (tablePopNew[i, j] == 0)
                                tablePopNew[i, j] = tablePopActual[i, j];
                            if (tablePopNew[i, j + 1] == 0 && !isHeksa[4])
                                tablePopNew[i, j + 1] = tablePopActual[i, j];
                            if (tablePopNew[i + 1, j - 1] == 0 && !isHeksa[5])
                                tablePopNew[i + 1, j - 1] = tablePopActual[i, j];
                            if (tablePopNew[i + 1, j] == 0 && !isHeksa[6])
                                tablePopNew[i + 1, j] = tablePopActual[i, j];
                            if (tablePopNew[i + 1, j + 1] == 0 && !isHeksa[7])
                                tablePopNew[i + 1, j + 1] = tablePopActual[i, j];
                        }
                        else
                        {
                            check = true;
                        }

                    }
                }

                for (int i = 1; i < height - 1; i++)
                {
                    for (int j = 1; j < width - 1; j++)
                    {
                        myBrush.Color = randomColour[tablePopActual[i, j]];
                        rectangle.FillRectangle(myBrush, new Rectangle(cellWidth * j, cellHeight * i, cellWidth, cellHeight));
                        tablePopActual[i, j] = tablePopNew[i, j];
                    }
                }
                //System.Threading.Thread.Sleep(100);
            return check;

        }
    */
    }
}
