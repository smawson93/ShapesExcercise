using System.Data.SQLite;

class Program
{

    static void Main(string[] args)
    {
        //Database connection string 
        string connectionString = "Data Source = shapes.db;Version=3;";

        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();

            string createTable = @"
            CREATE TABLE IF NOT EXISTS Shapes (
                id INTEGER PRIMARY KEY AUTOINCREMENT, 
                Name TEXT,
                Error TEXT );";

            using (var command = new SQLiteCommand(createTable, connection))
            {
                command.ExecuteNonQuery();
            }

        }

        var lines = File.ReadLines("shapes.txt");
        int i = 1; int triangles = 0; int rectangles = 0;
        foreach (var line in lines)
        {
            string[] split = line.Split(';');

            if (split.Length == 3)
            {

                int j = 1;
                int x1 = 0, x2 = 0, x3 = 0;
                int y1 = 0, y2 = 0, y3 = 0;
                foreach (var s in split)
                {

                    try
                    {
                        string[] coor = s.Split(",");
                        if (j == 1)
                        {
                            x1 = int.Parse(coor[0]);
                            y1 = int.Parse(coor[1]);
                        }
                        else if (j == 2)
                        {
                            x2 = int.Parse(coor[0]);
                            y2 = int.Parse(coor[1]);
                        }
                        else if (j == 3)
                        {
                            x3 = int.Parse(coor[0]);
                            y3 = int.Parse(coor[1]);
                        }

                    }
                    catch (FormatException)
                    {

                    }

                    j++;

                }

                int area = x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2);
                if (area == 0)
                {

                    Console.WriteLine("Line " + i + ": is an invalid triangle");
                }
                else
                {
                    triangles = triangles + 1;
                    Console.WriteLine("Line " + i + ": is a valid triangle");
                }
            
        }
            else if (split.Length == 4)
            {

                int k = 1;
                int x1 = 0, x2 = 0, x3 = 0, x4 = 0;
                int y1 = 0, y2 = 0, y3 = 0, y4 = 0;
                Boolean isRectangle = false;
                foreach (var s in split)
                {

                    try
                    {
                        string[] coor = s.Split(",");
                        if (k == 1)
                        {
                            x1 = int.Parse(coor[0]);
                            y1 = int.Parse(coor[1]);
                        }
                        else if (k == 2)
                        {
                            x2 = int.Parse(coor[0]);
                            y2 = int.Parse(coor[1]);
                        }
                        else if (k == 3)
                        {
                            x3 = int.Parse(coor[0]);
                            y3 = int.Parse(coor[1]);
                        }
                        else if (k == 4)
                        {
                            x4 = int.Parse(coor[0]);
                            y4 = int.Parse(coor[1]);
                        }
                    }
                    catch (FormatException)
                    {

                    }
                    k++;
                }

                if ((x1 == x2 && y1 != y2) || (x1 != x2 && y1 == y2))
                {
                    if ((x2 == x3 && y2 != y3) || (x2 != x3 && y2 == y3))
                    {
                        if ((x3 == x4 && y3 != y4) || (x3 != x4 && y3 == y4))
                        {
                            if ((x4 == x1 && y4 != y1) || (x4 != x1 && y4 == y1))
                                isRectangle = true;
                        }
                    }
                }
                if (isRectangle)
                {

                    rectangles = rectangles + 1;
                    Console.WriteLine("Line " + i + ": is a rectangle");
                }
                else
                {
                    Console.WriteLine("Line " + i + ": is an invalid rectangle");
                }

            }
            else
            {

                Console.WriteLine("Line " + i + ": is an invalid shape");
            }

            i++;

        }

        Console.WriteLine("Number of Triangles: " + triangles);
        Console.WriteLine("Number of Rectangles: " + rectangles);

    }     
}

