using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA
{

    class Recristalization
    {
        public void algorithm(double[] ro, Cell[,] tablePop, int height, int width)
        {
            Random rnd = new Random();
            int amount = 35;
            double deltaP = 0;
            double limit;
            int actEnergry = 0;
            for (int i = 1; i < amount; i++)
            {
                deltaP += (ro[i]-ro[i-1]);
            }
            deltaP /= (height * width);
            limit = deltaP;
            deltaP = deltaP * 0.1;
            for (int i = 1; i < height; i++)
            {
                for (int j = 1; j < width; j++)
                {
                    tablePop[i, j].density = deltaP;
                }
            }
            deltaP = 0;
            double tmp1;
            int x, y;
            for (int i = amount; i < amount + 45; i++)
            {
                deltaP = ro[i] - ro[i - 1];
                tmp1 = deltaP / 20;
                for (int j = 0; j < 20; j++)
                {
                    do
                    {
                        x = rnd.Next(1, height);
                        y = rnd.Next(1, width);
                        if (tablePop[x, y].isBorder != true)
                        {
                            tablePop[x, y].density += tmp1;
                            break;
                        }
                    } while (true);
                }
            }
            for (int i = 1; i < height-1; i++)
            {
                for (int j = 1; j < width-1; j++)
                {
                    if (tablePop[i - 1, j - 1].Qi == tablePop[i, j].Qi)
                        actEnergry++;
                    if (tablePop[i - 1, j].Qi == tablePop[i, j].Qi)
                        actEnergry++;
                    if (tablePop[i - 1, j + 1].Qi == tablePop[i, j].Qi)
                        actEnergry++;
                    if (tablePop[i, j - 1].Qi == tablePop[i, j].Qi)
                        actEnergry++;
                    if (tablePop[i, j + 1].Qi == tablePop[i, j].Qi)
                        actEnergry++;
                    if (tablePop[i + 1, j - 1].Qi == tablePop[i, j].Qi)
                        actEnergry++;
                    if (tablePop[i + 1, j].Qi == tablePop[i, j].Qi)
                        actEnergry++;
                    if (tablePop[i + 1, j + 1].Qi == tablePop[i, j].Qi)
                        actEnergry++;
                    if (actEnergry < 8)
                    {
                        Console.WriteLine(actEnergry);
                        //tablePop[i, j].isBorder = true;
                        if (tablePop[i, j].density > limit)
                        {
                            tablePop[i, j].Qi *= -1; 
                            tablePop[i, j].isRecrystallized = true;
                        }

                    }
                    actEnergry = 0;
                }
            }
        }
        public Cell[,] simulation1(Cell[,] tablePop, int height, int width)
        {
            double[] ro = {1,
                   86304155065,
                    1.718E+11,
                    2.56494E+11,
                    3.40396E+11,
                    4.23511E+11,
                    5.05847E+11,
                    5.87412E+11,
                    6.68213E+11,
                    7.48257E+11,
                    8.27551E+11,
                    9.06103E+11,
                    9.83918E+11,
                    1.061E+12,
                    1.13737E+12,
                    1.21302E+12,
                    1.28796E+12,
                    1.36219E+12,
                    1.43574E+12,
                    1.50859E+12,
                    1.58076E+12,
                    1.65226E+12,
                    1.72308E+12,
                    1.79324E+12,
                    1.86275E+12,
                    1.9316E+12,
                    1.99981E+12,
                    2.06738E+12,
                    2.13431E+12,
                    2.20062E+12,
                    2.26631E+12,
                    2.33138E+12,
                    2.39584E+12,
                    2.4597E+12,
                    2.52296E+12,
                    2.58563E+12,
                    2.64771E+12,
                    2.70921E+12,
                    2.77013E+12,
                    2.83049E+12,
                    2.89027E+12,
                    2.9495E+12,
                    3.00817E+12,
                    3.06629E+12,
                    3.12387E+12,
                    3.18091E+12,
                    3.23741E+12,
                    3.29339E+12,
                    3.34884E+12,
                    3.40377E+12,
                    3.45818E+12,
                    3.51209E+12,
                    3.56549E+12,
                    3.61839E+12,
                    3.6708E+12,
                    3.72271E+12,
                    3.77414E+12,
                    3.82508E+12,
                    3.87555E+12,
                    3.92555E+12,
                    3.97508E+12,
                    4.02414E+12,
                    4.07274E+12,
                    4.12089E+12,
                    4.16859E+12,
                    4.21584E+12,
                    4.26265E+12,
                    4.30902E+12,
                    4.35495E+12,
                    4.40046E+12,
                    4.44554E+12,
                    4.49019E+12,
                    4.53443E+12,
                    4.57825E+12,
                    4.62167E+12,
                    4.66467E+12,
                    4.70727E+12,
                    4.74948E+12,
                    4.79129E+12,
                    4.8327E+12,
                    4.87373E+12,
                    4.91438E+12,
                    4.95464E+12,
                    4.99453E+12,
                    5.03404E+12,
                    5.07318E+12,
                    5.11196E+12,
                    5.15037E+12,
                    5.18842E+12,
                    5.22612E+12,
                    5.26346E+12,
                    5.30046E+12,
                    5.3371E+12,
                    5.37341E+12,
                    5.40937E+12,
                    5.445E+12,
                    5.48029E+12,
                    5.51525E+12,
                    5.54989E+12,
                    5.5842E+12,
                    5.61818E+12,
                    5.65185E+12,
                    5.68521E+12,
                    5.71825E+12,
                    5.75098E+12,
                    5.78341E+12,
                    5.81553E+12,
                    5.84735E+12,
                    5.87888E+12,
                    5.9101E+12,
                    5.94104E+12,
                    5.97168E+12,
                    6.00204E+12,
                    6.03212E+12,
                    6.06191E+12,
                    6.09142E+12,
                    6.12066E+12,
                    6.14962E+12,
                    6.17831E+12,
                    6.20673E+12,
                    6.23489E+12,
                    6.26278E+12,
                    6.29041E+12,
                    6.31779E+12,
                    6.3449E+12,
                    6.37176E+12,
                    6.39837E+12,
                    6.42474E+12,
                    6.45085E+12,
                    6.47672E+12,
                    6.50235E+12,
                    6.52773E+12,
                    6.55288E+12,
                    6.57779E+12,
                    6.60247E+12,
                    6.62692E+12,
                    6.65114E+12,
                    6.67514E+12,
                    6.6989E+12,
                    6.72245E+12,
                    6.74577E+12,
                    6.76888E+12,
                    6.79177E+12,
                    6.81445E+12,
                    6.83691E+12,
                    6.85916E+12,
                    6.8812E+12,
                    6.90304E+12,
                    6.92467E+12,
                    6.9461E+12,
                    6.96733E+12,
                    6.98836E+12,
                    7.0092E+12,
                    7.02984E+12,
                    7.05028E+12,
                    7.07054E+12,
                    7.0906E+12,
                    7.11047E+12,
                    7.13016E+12,
                    7.14967E+12,
                    7.16899E+12,
                    7.18813E+12,
                    7.20709E+12,
                    7.22588E+12,
                    7.24449E+12,
                    7.26292E+12,
                    7.28118E+12,
                    7.29927E+12,
                    7.31719E+12,
                    7.33495E+12,
                    7.35253E+12,
                    7.36995E+12,
                    7.38721E+12,
                    7.40431E+12,
                    7.42125E+12,
                    7.43803E+12,
                    7.45465E+12,
                    7.47111E+12,
                    7.48742E+12,
                    7.50358E+12,
                    7.51959E+12,
                    7.53544E+12,
                    7.55115E+12,
                    7.56671E+12,
                    7.58213E+12,
                    7.5974E+12,
                    7.61253E+12,
                    7.62751E+12,
                    7.64236E+12,
                    7.65706E+12,
                    7.67163E+12,
                    7.68607E+12,
                    7.70036E+12,
                    7.71453E+12,
                    7.72856E+12,
                    7.74246E+12,
                    7.75622E+12,
                    7.76986E+12,
                    7.78338E+12,
                    7.79676E+12,
                    7.81002E+12,
                    };
            algorithm(ro, tablePop, height, width);
            return tablePop;    
            }
    }
}
