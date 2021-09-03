using System;
using System.Collections.Generic;
using System.IO;

namespace Rainbow_school
{
    class Teacher : IEquatable<Teacher>
    {
        public string TeacherName { get; set; }
        public int TeacherID { get; set; }
        public int Class { get; set; }
        public string Section { get; set; }
        public override string ToString()
        {
            return "Teacher ID: " + TeacherID + ", Teacher Name: " + TeacherName + ", Class: " + Class + " & Section: " + Section;
        }

        public bool Equals(Teacher other)
        {
            if (other == null) return false;
            return (this.TeacherID.Equals(other.TeacherID));
        }
    }
    class School
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t\t\tWelcome to Rainbow School\n");
            Console.ForegroundColor = ConsoleColor.White;
            List<Teacher> teacher = new List<Teacher>();
            string filename = "E:\\Rainbow school task\\RainbowSchool\\Teacher_details.txt";
            int counter = 0;
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(filename);
            while ((line = file.ReadLine()) != null)
            {
                string[] stringlist = line.Split(", ");
                teacher.Add(new Teacher() { TeacherName = stringlist[1], TeacherID = int.Parse(stringlist[0]), Class = int.Parse(stringlist[2]), Section = stringlist[3] });
                counter++;
            }
            file.Close();
            int choice;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t\t\tWelcome to Rainbow School\n");
            Console.ForegroundColor = ConsoleColor.White;
        start:
            Console.WriteLine("Enter the choice");
            Console.WriteLine("1.To Enter the details of new teacher");
            Console.WriteLine("2.Display details of all the teachers");
            Console.WriteLine("3.Delete the teacher details");
            Console.WriteLine("4.Display details of all teachers");
            Console.WriteLine("5.Update details of any teacher");
            Console.WriteLine("6.Exit\n");


            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    String tname, Section1;
                    int Class1, tid;
                    Console.WriteLine("\nEnter the Teacher Id");
                    tid = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the Teacher name");
                    tname = Console.ReadLine();
                    Console.WriteLine("Enter the Class which teacher teaches");
                    Class1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the Section Which teacher teaches");
                    Section1 = Console.ReadLine();
                    teacher.Add(new Teacher() { TeacherName = tname, TeacherID = tid, Class = Class1, Section = Section1 });
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\t\t\t\t Updated teacher details.");
                    Console.ForegroundColor = ConsoleColor.White;
                    using (StreamWriter wrt = File.AppendText(filename))
                    { 
                        wrt.WriteLine(tid + ", " +
                                          tname + ", " +
                                          Class1 + ", " +
                                          Section1);

                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\t\t\t\tUpdated details to the text file");
                    Console.ForegroundColor = ConsoleColor.White;
                    file.Close();
                    goto start;
                case 2:
                    int num;
                    Console.WriteLine("Enter the ID of the teacher to view details\n");
                    num = Convert.ToInt32(Console.ReadLine());
                    int found = -1;
                    foreach (Teacher t1 in teacher)
                    {
                        if (t1.TeacherID == num)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\n\t\t\t" + t1 + "\n");
                            Console.ForegroundColor = ConsoleColor.White;
                            found = 1;
                            break;
                        }
                        else
                            found = 0;
                    }
                    if (found == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\t\t\tTeacherID not found");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    goto start;
                case 3:

                    Console.WriteLine("Enter the ID of the teacher to delete details\n");
                    num = Convert.ToInt32(Console.ReadLine());
                    int count = 0, index = -1;
                    foreach (Teacher s in teacher)
                    {
                        if (s.TeacherID == num)
                        {
                            index = count;
                            teacher.RemoveAt(index);
                            break;
                        }// I found a match and I want to edit the item at this index
                        count++;
                    }
                    using (StreamWriter wrt = File.CreateText(filename))
                    {
                        foreach (Teacher t1 in teacher)
                        {
                            wrt.WriteLine(t1.TeacherID + ", " +
                                          t1.TeacherName + ", " +
                                          t1.Class + ", " +
                                          t1.Section);

                            //wrt.WriteLine(t1);
                        }
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\t\t\t\tUpdated details to the text file");
                        Console.ForegroundColor = ConsoleColor.White;


                    }
                    file.Close();
                    if (index == -1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\t\t\tTeacherID not found");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    goto start;
                case 4:
                    foreach (Teacher t1 in teacher)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n\t\t\t" + t1 + "");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    goto start;
                case 5:
                    Console.WriteLine("Enter the ID of the teacher to update details\n");
                    num = Convert.ToInt32(Console.ReadLine());
                    count = 0;
                    index = -1;
                    foreach (Teacher s in teacher)
                    {
                        if (s.TeacherID == num)
                            index = count; // I found a match and I want to edit the item at this index
                        count++;
                    }
                    if (index != -1)
                    {
                        Console.WriteLine("Enter the Teacher name");
                        tname = Console.ReadLine();
                        Console.WriteLine("Enter the Class which teacher teaches");
                        Class1 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the Section Which teacher teaches");
                        Section1 = Console.ReadLine();
                        teacher.RemoveAt(index);
                        teacher.Insert(index, new Teacher() { TeacherName = tname, TeacherID = num, Class = Class1, Section = Section1 });
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n\t\t\t\t Update Successful ");
                        Console.ForegroundColor = ConsoleColor.White;

                    }
                    goto start;
              
                case 6:

                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t\t\t\tEnter a valid Choice");
                    Console.ForegroundColor = ConsoleColor.White;
                    goto start;
            }
            Console.ReadKey();
        }
    }
}
