using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace SHM
{
    class Program
    {

        private static int countOfSensors = 2;

        private static int maxOfBattery = 3;




        static void Main(string[] args)
        {
            //createTransactions(args);
            runSimulation(args);
        }


        static void runSimulation(string[] args)
        {

            Dictionary<string, string> plan = new Dictionary<string, string>();

            plan.Add("1 1 0 1 0 1", "off0");
            plan.Add("0 X 2 1 1 3", "none");
            plan.Add("1 0 2 0 X 1", "none");
            plan.Add("0 X 0 1 0 2", "none");
            plan.Add("1 1 2 1 1 2", "off1");
            plan.Add("1 1 1 1 1 3", "off0");
            plan.Add("0 X 0 0 X 0", "none");
            plan.Add("0 X 1 1 0 1", "none");
            plan.Add("0 X 1 0 X 0", "none");
            plan.Add("1 0 3 1 1 3", "off1");
            plan.Add("1 0 0 1 0 0", "off0");
            plan.Add("0 X 1 0 X 1", "on1");
            plan.Add("1 1 1 1 0 1", "off1");
            plan.Add("0 X 0 1 1 2", "none");
            plan.Add("1 1 0 0 X 1", "off0");
            plan.Add("1 1 1 1 0 0", "off1");
            plan.Add("1 0 1 0 X 0", "none");
            plan.Add("1 0 1 1 1 2", "off0");
            plan.Add("1 0 1 1 1 3", "off0");
            plan.Add("0 X 3 1 0 2", "none");
            plan.Add("1 1 2 1 0 2", "off1");
            plan.Add("0 X 0 1 0 1", "none");
            plan.Add("1 0 2 1 1 1", "off1");
            plan.Add("0 X 1 1 1 2", "none");
            plan.Add("1 1 3 1 0 2", "off1");
            plan.Add("1 1 1 0 X 2", "none");
            plan.Add("1 0 2 0 X 3", "none");
            plan.Add("1 1 3 1 0 1", "off1");
            plan.Add("0 X 0 1 1 3", "none");
            plan.Add("0 X 2 0 X 3", "on0");
            plan.Add("0 X 0 0 X 2", "none");
            plan.Add("1 0 3 1 0 1", "off1");
            plan.Add("0 X 3 1 1 2", "none");
            plan.Add("0 X 2 1 0 1", "none");
            plan.Add("1 1 0 0 X 0", "off0");
            plan.Add("1 0 2 1 0 2", "off1");
            plan.Add("1 1 0 1 0 3", "off0");
            plan.Add("1 0 1 1 0 3", "off0");
            plan.Add("0 X 2 1 1 1", "none");
            plan.Add("0 X 0 1 0 3", "none");
            plan.Add("1 0 1 1 0 2", "off0");
            plan.Add("1 0 0 1 1 2", "off0");
            plan.Add("1 0 1 0 X 3", "none");
            plan.Add("0 X 1 1 0 0", "off1");
            plan.Add("1 1 1 1 1 0", "off1");
            plan.Add("0 X 3 1 0 1", "none");
            plan.Add("1 0 3 1 1 2", "off1");
            plan.Add("1 1 0 1 0 2", "off0");
            plan.Add("0 X 2 0 X 2", "on0");
            plan.Add("1 0 0 0 X 2", "off0");
            plan.Add("0 X 1 1 0 3", "none");
            plan.Add("1 1 0 1 1 2", "off0");
            plan.Add("0 X 3 0 X 0", "none");
            plan.Add("1 1 3 0 X 1", "none");
            plan.Add("1 1 2 1 0 3", "off1");
            plan.Add("1 0 3 0 X 0", "none");
            plan.Add("1 0 0 0 X 3", "off0");
            plan.Add("0 X 1 0 X 2", "on1");
            plan.Add("0 X 2 1 1 2", "none");
            plan.Add("0 X 1 1 1 3", "none");
            plan.Add("0 X 0 0 X 3", "none");
            plan.Add("1 0 2 1 1 2", "off1");
            plan.Add("1 0 2 1 0 1", "off1");
            plan.Add("1 0 0 1 1 3", "off0");
            plan.Add("1 1 2 1 1 1", "off1");
            plan.Add("0 X 3 1 1 3", "none");
            plan.Add("1 0 3 1 0 2", "off1");
            plan.Add("1 0 2 0 X 2", "none");
            plan.Add("1 0 3 0 X 3", "none");
            plan.Add("1 1 3 1 1 3", "off1");
            plan.Add("1 0 1 1 0 0", "off1");
            plan.Add("1 1 3 1 1 2", "off1");
            plan.Add("1 1 2 0 X 0", "none");
            plan.Add("1 0 2 1 1 0", "off1");
            plan.Add("1 0 1 0 X 2", "none");
            plan.Add("1 1 2 0 X 1", "none");
            plan.Add("1 1 1 1 1 1", "off1");
            plan.Add("0 X 0 1 1 1", "none");
            plan.Add("0 X 3 1 0 0", "off1");
            plan.Add("1 1 2 1 0 0", "off1");
            plan.Add("1 0 0 1 0 2", "off0");
            plan.Add("1 1 0 0 X 3", "off0");
            plan.Add("1 1 1 0 X 3", "none");
            plan.Add("1 0 1 1 1 1", "off1");
            plan.Add("1 1 2 1 1 0", "off1");
            plan.Add("1 0 3 1 0 3", "off1");
            plan.Add("0 X 3 0 X 1", "on1");
            plan.Add("1 1 0 1 1 1", "off0");
            plan.Add("1 1 3 0 X 2", "none");
            plan.Add("0 X 1 0 X 3", "on1");
            plan.Add("1 0 2 0 X 0", "none");
            plan.Add("0 X 0 0 X 1", "none");
            plan.Add("0 X 0 1 0 0", "off1");
            plan.Add("1 0 2 1 0 0", "off1");
            plan.Add("0 X 2 1 1 0", "off1");
            plan.Add("1 0 0 0 X 0", "off0");
            plan.Add("1 1 3 1 1 0", "off1");
            plan.Add("1 0 3 0 X 2", "none");
            plan.Add("1 0 0 1 1 0", "off0");
            plan.Add("1 0 0 1 0 1", "off0");
            plan.Add("1 1 3 1 0 0", "off1");
            plan.Add("1 1 0 1 1 0", "off0");
            plan.Add("0 X 3 0 X 2", "on1");
            plan.Add("0 X 2 1 0 3", "none");
            plan.Add("1 0 3 1 1 1", "off1");
            plan.Add("1 0 1 1 0 1", "off1");
            plan.Add("1 1 3 0 X 0", "none");
            plan.Add("0 X 2 0 X 1", "on1");
            plan.Add("1 1 2 0 X 3", "none");
            plan.Add("1 1 1 0 X 0", "none");
            plan.Add("0 X 3 1 1 0", "off1");
            plan.Add("1 0 2 1 1 3", "off1");
            plan.Add("0 X 1 1 1 0", "off1");
            plan.Add("1 1 2 1 0 1", "off1");
            plan.Add("0 X 3 1 0 3", "none");
            plan.Add("1 1 0 0 X 2", "off0");
            plan.Add("1 1 0 1 0 0", "off0");
            plan.Add("1 1 2 1 1 3", "off1");
            plan.Add("0 X 2 1 0 2", "none");
            plan.Add("0 X 1 1 0 2", "none");
            plan.Add("1 1 1 1 1 2", "off0");
            plan.Add("1 1 3 0 X 3", "none");
            plan.Add("1 1 1 1 0 2", "off0");
            plan.Add("1 0 0 0 X 1", "off0");
            plan.Add("1 0 0 1 0 3", "off0");
            plan.Add("1 1 1 1 0 3", "off0");
            plan.Add("1 1 1 0 X 1", "none");
            plan.Add("1 0 1 0 X 1", "none");
            plan.Add("1 1 3 1 1 1", "off1");
            plan.Add("1 0 0 1 1 1", "off0");
            plan.Add("0 X 0 1 1 0", "off1");
            plan.Add("0 X 3 0 X 3", "on1");
            plan.Add("1 1 3 1 0 3", "off1");
            plan.Add("1 0 3 1 1 0", "off1");
            plan.Add("1 0 1 1 1 0", "off1");
            plan.Add("0 X 2 0 X 0", "none");
            plan.Add("1 1 0 1 1 3", "off0");
            plan.Add("1 1 2 0 X 2", "none");
            plan.Add("1 0 3 0 X 1", "none");
            plan.Add("0 X 3 1 1 1", "none");
            plan.Add("1 0 3 1 0 0", "off1");
            plan.Add("0 X 1 1 1 1", "none");
            plan.Add("0 X 2 1 0 0", "off1");
            plan.Add("1 0 2 1 0 3", "off1");


            bool[] sensorsPower = new bool[countOfSensors];
            bool[] sensorsEnvDetect = new bool[countOfSensors];
            int[] sensorsBattery = new int[countOfSensors];

            for (int i = 0; i < countOfSensors; i++)
            {
                sensorsBattery[i] = maxOfBattery;
                sensorsEnvDetect[i] = false;
                sensorsPower[i] = false;
            }

            int lifeTime = 0;
            int hit = 0, miss = 0;


            while (!sensorsBattery.Any(e => e <= 0))
            {
                string currentStat = "";

                for (int i = 0; i < countOfSensors; i++)
                {
                    currentStat += (sensorsPower[i] ? "1" : "0") + " ";
                    currentStat += (sensorsPower[i] ? (sensorsEnvDetect[i] ? "1" : "0") : "x") + " ";
                    currentStat += sensorsBattery[i] + " ";
                }

                //for (int i = 0; i < countOfSensors; i++)
                //    currentStat += (sensorsPower[i] ? (sensorsEnvDetect[i] ? "1" : "0") : "x") + " ";

                currentStat = currentStat.Substring(0, currentStat.Length - 1);

                string action = plan[currentStat.ToUpper()];
                Console.WriteLine();
                Console.WriteLine("##################");
                Console.Write("In Time {0}, current State is ({1}) and i decied to {2}.", lifeTime, currentStat, action);


                switch (action)
                {
                    case "on0":
                        sensorsPower[0] = true;
                        break;

                    case "on1":
                        sensorsPower[1] = true;
                        break;

                    case "off0":
                        sensorsPower[0] = false;
                        break;

                    case "off1":
                        sensorsPower[1] = false;
                        break;
                }

                lifeTime++;

                for (int i = 0; i < countOfSensors; i++)
                    sensorsBattery[i] -= sensorsPower[i] ? 1 : 0;

                bool[] nowEnv = realEnv(lifeTime);

                for (int i = 0; i < countOfSensors; i++)
                {
                    Console.Write(" Sensor No{0} is {1} and Env of that is ", i + 1, sensorsPower[i] ? "on" : "off");
                    if (sensorsPower[i])
                    {
                        sensorsEnvDetect[i] = nowEnv[i];
                        Console.Write(nowEnv[i] ? "humid." : "dry.");
                    }
                    else
                        Console.Write("x.");
                }

                if (!sensorsPower.Any(e => e == true))
                {
                    miss++;
                    Console.Write(" So Missed.");
                }
                else
                {
                    bool isMiss = false;
                    for (int i = 0; i < countOfSensors; i++)
                    {
                        if (sensorsPower[i] && nowEnv[i])
                        {
                            hit++;
                            Console.Write(" So Hitted!");
                            break;
                        }
                        else if (sensorsPower[i] && !nowEnv[i])
                        {
                            isMiss = true;
                        }
                    }
                    if (isMiss)
                    {
                        miss++;
                        Console.Write(" So Missed.");
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Miss Rate: {0}", miss);
            Console.WriteLine("Hit Rate:  {0}", hit);
            Console.WriteLine("System life time:  {0}", lifeTime);
            Console.Read();
        }

        static bool[] realEnv(int lifeTime)
        {
            return new bool[] { new Random().Next(0, 1) == 1 ? true : false, new Random().Next(0, 1) == 1 ? true : false };
        }

        static void createTransactions(string[] args)
        {

            List<string> outputTransactions = new List<string>();

            StreamWriter tmp = new StreamWriter("transitions.csv");

            //tmp.Write("T,");

            //for (int i = 0; i < countOfSensors; i++)
            //{
            //    tmp.Write("s" + i + "," + "e" + i + "," + "c" + i + ",");
            //}

            //for (int i = 0; i < countOfSensors; i++)
            //{
            //    tmp.Write("s'" + i + "," + "e'" + i + "," + "c'" + i + ",");
            //}

            //tmp.Write("action");

            //tmp.WriteLine();




















            //var result = Parallel.For(1, (int)Math.Pow(2, countOfSensors * 2 * 2), (i, state) =>
            for (int i = 0; i < (int)Math.Pow(2, countOfSensors * 2 * 2); i++)
            {








                string binary = Convert.ToString(i, 2);
                while (binary.Length < countOfSensors * 2 * 2)
                    binary = "0" + binary;


                int diff = 0;

                for (int j = 0; j < 2 * countOfSensors; j += 2)
                {
                    if (binary[j] == '0')
                    {
                        StringBuilder sb = new StringBuilder(binary);
                        sb[j + 1] = 'X';
                        binary = sb.ToString();
                    }
                    if (binary[j + countOfSensors * 2] == '0')
                    {
                        StringBuilder sb = new StringBuilder(binary);
                        sb[j + countOfSensors * 2 + 1] = 'X';
                        binary = sb.ToString();
                    }

                    if (binary[j + countOfSensors * 2] != binary[j])
                        diff++;

                }

                if (diff > 1)
                    continue;

                string actionToDo = "none";

                for (int j = 0; j < 2 * countOfSensors; j += 2)
                {
                    if (binary[j + countOfSensors * 2] == '0' && binary[j] == '1')
                    {
                        actionToDo = "off" + (j / 2);
                    }
                    else
                        if (binary[j + countOfSensors * 2] == '1' && binary[j] == '0')
                    {
                        actionToDo = "on" + (j / 2);
                    }
                }



                for (long chargeCounter = (long)(Math.Pow(maxOfBattery + 1, countOfSensors * 2) - 1); chargeCounter >= 0; chargeCounter--)
                {
                    string toPrint = binary;

                    string a = (DecimalToArbitrarySystem(chargeCounter, maxOfBattery + 1));
                    while (a.Length < countOfSensors * 2) a = "0" + a;


                    bool skip = false;

                    for (int j = 0; j < countOfSensors; j++)
                    {
                        if (Convert.ToInt32(a[j + countOfSensors]) > Convert.ToInt32(a[j]))
                            skip = true;
                        if (Math.Abs(Convert.ToInt32(a[j + countOfSensors]) - Convert.ToInt32(a[j])) > 1)
                            skip = true;
                    }


                    if (diff == 0)
                    {
                        for (int j = 0; j < countOfSensors; j++)
                        {
                            if (binary[j * 2] == '0' && a[j + countOfSensors] != a[j] || binary[j * 2] == '1' && a[j + countOfSensors] == a[j])
                                skip = true;
                        }
                    }
                    else
                    {
                        for (int j = 0; j < countOfSensors; j++)
                        {
                            if (actionToDo.StartsWith("off"))
                            {
                                int offSensor = Convert.ToInt32(actionToDo.Substring(3));
                                if (Convert.ToInt32(a[offSensor + countOfSensors]) != Convert.ToInt32(a[offSensor]))
                                    skip = true;
                            }
                            else
                            {
                                if (Convert.ToInt32(a[j + countOfSensors]) == Convert.ToInt32(a[j]))
                                    skip = true;
                            }
                        }
                    }


                    if (skip)
                        continue;

                    for (int m = 0; m < countOfSensors * 2; m++)
                    {
                        toPrint = toPrint.Insert(m + 2 * (m + 1), a[m] + "");
                    }




                    string row = "";

                    double probab = 0;
                    for (int m = 0; m < countOfSensors; m++)
                    {
                        char before = toPrint[m * 3 + 1];
                        char after = toPrint[countOfSensors * 3 + (m * 3 + 1)];

                        switch ((before + "" + after).ToLower())
                        {
                            case "xx":
                                probab += 1;
                                break;
                            case "x1":
                                probab += 0.5;
                                break;
                            case "x0":
                                probab += 0.5;
                                break;
                            case "0x":
                                probab += 1;
                                break;
                            case "01":
                                probab += 0.4;
                                break;
                            case "00":
                                probab += 0.6;
                                break;
                            case "1x":
                                probab += 1;
                                break;
                            case "11":
                                probab += 0.4;
                                break;
                            case "10":
                                probab += 0.6;
                                break;
                        }
                    }

                    probab /= countOfSensors;

                    foreach (char t in toPrint)
                        row += t + " ";
                    row = "( " + row;
                    row = row.Insert(14, ")," + actionToDo + ",( ");
                    row = row + ")," + probab;



                    //Monitor.Enter(outputTransactions);
                    outputTransactions.Add(row);
                    //Console.WriteLine(row);
                    //Monitor.Exit(outputTransactions);
                }









            }























            outputTransactions = outputTransactions.Distinct().ToList();

            for (int i = 0; i < outputTransactions.Count; i++)
            {
                tmp.WriteLine(outputTransactions[i]);
            }

            tmp.Close();

            //tmp = new StreamWriter("rewards.csv");

            //for (int i = 0; i < (int)Math.Pow(2, countOfSensors * 2 * 2); i++)
            //{

            //}
            //tmp.Close();
        }




        public static string DecimalToArbitrarySystem(long decimalNumber, int radix)
        {
            const int BitsInLong = 64;
            const string Digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            if (radix < 2 || radix > Digits.Length)
                throw new ArgumentException("The radix must be >= 2 and <= " + Digits.Length.ToString());

            if (decimalNumber == 0)
                return "0";

            int index = BitsInLong - 1;
            long currentNumber = Math.Abs(decimalNumber);
            char[] charArray = new char[BitsInLong];

            while (currentNumber != 0)
            {
                int remainder = (int)(currentNumber % radix);
                charArray[index--] = Digits[remainder];
                currentNumber = currentNumber / radix;
            }

            string result = new String(charArray, index + 1, BitsInLong - index - 1);
            if (decimalNumber < 0)
            {
                result = "-" + result;
            }

            return result;
        }


    }
}
