/*Задача 53: Задайте двумерный массив. Напишите программу, 
которая поменяет местами первую и последнюю строку массива.
*/
int[,] Generate2DArray(int lengthRow, int lengthCol, int deviation)
{
    int[,] array = new int[lengthRow, lengthCol];
    for (int i = 0; i < lengthRow; i++)
    {
        for (int j  = 0; j < lengthCol; j++)
        {
            array[i, j] = new Random().Next(- deviation, deviation + 1);
        }
    }
    return array;
}
void printColor(string information, ConsoleColor color, bool newLine = false)
{
    Console.ForegroundColor = color;
    Console.Write(information);
    Console.ResetColor();
    if(newLine)
    {
        Console.WriteLine();
    }
}
void print2dArray(int[,] array, string Name ="")
{
    printColor(Name, ConsoleColor.DarkCyan, true);
    Console.Write("\t");
    for (int i = 0; i < array.GetLength(1); i++)
    {
        printColor(i + "\t", ConsoleColor.DarkYellow, (i >= array.GetLength(1) - 1));
    }
    for (int i = 0; i < array.GetLength(0); i++)
    {
        printColor(i + "\t", ConsoleColor.DarkYellow);
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(array[i, j] + "\t");
        }
        Console.WriteLine();
    }
}
int[,] changeLinesOfArray(int[,] array, int line1, int line2)
{
    for (int i = 0; i < array.GetLength(1); i++)
    {
        int buf = array[line1, i];
        array[line1, i] = array[line2, i];
        array[line2, i] = buf;
    }
    return array;
}

int[,] generatedArray = Generate2DArray(7,8,10);
print2dArray(generatedArray, "Изначальный массив");
int[,] changedArray = changeLinesOfArray(generatedArray, 0 , generatedArray.GetLength(0) - 1);
print2dArray(changedArray, "Измененный массив");
