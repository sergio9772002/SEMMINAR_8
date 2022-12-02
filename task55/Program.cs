/* Задача 55: Задайте двумерный массив. Напишите программу, которая заменяет строки на столбцы.
 В случае, если это невозможно, программа должна вывести сообщение для пользователя.
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
void print2dArray(int[,] array, string Name = "")
{
    printColor(Name, ConsoleColor.DarkCyan, true);
    Console.Write("\t");
    for (int i = 0; i < array.GetLength(1); i++)
    {
        printColor(i + "\t", ConsoleColor.DarkYellow,(i >= array.GetLength(1) - 1));
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
int getFromUserInt(string message)
{
    Console.ForegroundColor = ConsoleColor.DarkMagenta;
    Console.WriteLine(message);
    Console.ResetColor();
    int userInt = Convert.ToInt32(Console.ReadLine());
    return userInt;
}
bool CanArrayMove(int rows, int cols)
{
    return (rows == cols);
}
int[,] rotateArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = i; j < array.GetLength(1); j++)
        {
            int buf = array[i, j];
            array[i, j] = array[j, i];
            array[j, i] = buf;
        }
    }
    return array;
}
int userLengthRow = getFromUserInt("Введите размер строк");
int userLengthCol = getFromUserInt("Введите размер колонок");
bool IsArrayMoves = CanArrayMove(userLengthRow, userLengthCol);
if(IsArrayMoves)
{
    int[,] generatedArray = Generate2DArray(userLengthRow, userLengthCol, 10);
    print2dArray(generatedArray, "Исходный массив");
    int[,] rotatedArray = rotateArray(generatedArray);
    print2dArray(generatedArray, "Развернутый массив");
}
else
{
    printColor($"Только квадратный массив можно перевернуть {userLengthRow}, {userLengthCol}", ConsoleColor.Red);
}

