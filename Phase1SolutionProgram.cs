


using System;

using System.Collections.Generic;

using System.IO;

using System.Linq;

using System.Text;

namespace DoverConsoleApp

{

    class TeacherModel

    {

        public int TeacherId { get; set; }

        public string TeacherName { get; set; }

        public string Class { get; set; }

        public string Section { get; set; }

        public string Subject { get; set; }

    }



    namespace DoverConsoleApp

    {

        class Program

        {

            static void Main(string[] args)

            {

                int Id; string Name, Class, Section, Subject;

                string filename = @"C:\Users\11035900\Documents\tt.txt";



                List<TeacherModel> teachers = new List<TeacherModel>();

                System.IO.StreamReader file = new System.IO.StreamReader(filename);

                string line;

                int counter = 0;

                while ((line = file.ReadLine()) != null)

                {

                    string[] stringlist = line.Split(",");

                    teachers.Add(item: new TeacherModel() { TeacherName = stringlist[1], TeacherId = int.Parse(stringlist[0]), Class = stringlist[2], Section = stringlist[3], Subject = stringlist[4] });

                    counter++;

                }

                file.Close();

                Console.WriteLine("Hello, Welcome to Rainbow School!!");

                Console.WriteLine("--------------TeacherRecords Text File Detils--------------");

            start:
                Console.WriteLine("*****************************");

                Console.WriteLine("1. Add Teacher Details \n2. Retrieve all Teacher Details \n3. Retrieve Teacher by ID \n4. Update Teacher \n5. Delete Teacher  \n6. Exit");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)

                {

                    case 1:

                        Console.WriteLine("Enter number of records to be stored");

                        int number = Convert.ToInt32(Console.ReadLine());

                        for (int i = 0; i < number; i++)

                        {

                            Console.WriteLine("Enter Teacher Details");

                            Console.WriteLine("Enter Teacher Id");

                            Id = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter Teacher Name");

                            Name = Console.ReadLine();

                            Console.WriteLine("Enter Teacher Class");

                            Class = Console.ReadLine();

                            Console.WriteLine("Enter Teacher Section");

                            Section = Console.ReadLine();

                            Console.WriteLine("Enter the Subject that the Teacher handles");

                            Subject = Console.ReadLine();

                            teachers.Add(new TeacherModel() { TeacherName = Name, TeacherId = Id, Class = Class, Section = Section, Subject = Subject });

                            using (StreamWriter wrt = File.AppendText(filename))

                            {

                                wrt.WriteLine(Id + ", " +

                                                  Name + ", " +

                                                  Class + ", " +

                                                  Section + ", " +

                                                  Subject);

                            }

                        }

                        goto start;

                    case 2:

                        Console.WriteLine("Displaying Teacher Records");

                        foreach (var item in teachers)

                        {

                            Console.WriteLine(item.TeacherId + "," + item.TeacherName + "," + item.Class + "," + item.Section + "," + item.Subject);

                        }

                        goto start;

                    case 3:

                        Console.WriteLine("Enter Id of teacher to display");

                        int id = Convert.ToInt32(Console.ReadLine());

                        TeacherModel teach2 = new TeacherModel();

                        //teach2 = context.GetTeacherByid(id); 



                        int found = -1;

                        foreach (var item in teachers)

                        {

                            if (item.TeacherId == id)

                            {

                                Console.WriteLine("Id found");

                                found = 1;

                                Console.WriteLine(item.TeacherId + "," + item.TeacherName + " ," + item.Class + "," + item.Section + " ," + item.Subject);

                            }

                        }

                        if (found == -1)

                        {

                            Console.WriteLine("ID Not found");

                        }

                        goto start;

                    case 4:

                        Console.WriteLine("Enter Id of teacher you want to update");

                        Id = Convert.ToInt32(Console.ReadLine());

                        int count = 0;

                        found = -1;

                        //teach2 = context.UpdateTeacher(Idnum, teachers); 

                        foreach (var item in teachers)

                        {

                            if (item.TeacherId == Id)

                            {

                                found = count;

                            }

                            count++;

                        }

                        if (found == -1)

                        {

                            Console.WriteLine("ID Not found");

                        }

                        else

                        {

                            teachers.RemoveAt(found);

                            Console.WriteLine("Enter Teacher Details");

                            Console.WriteLine("Enter Teacher Name");

                            Name = Console.ReadLine();

                            Console.WriteLine("Enter Teacher Class");

                            Class = Console.ReadLine();

                            Console.WriteLine("Enter Teacher Section");

                            Section = Console.ReadLine();

                            Console.WriteLine("Enter the Subject that the Teacher handles");

                            Subject = Console.ReadLine();

                            teachers.Add(new TeacherModel() { TeacherName = Name, TeacherId = Id, Class = Class, Section = Section, Subject = Subject });



                            using (StreamWriter wrt = File.CreateText(filename))

                            {

                                foreach (TeacherModel t1 in teachers)

                                {

                                    wrt.WriteLine(t1.TeacherId + "," +

                                                  t1.TeacherName + "," +

                                                  t1.Class + "," +

                                                  t1.Section + "," +

                                                  t1.Subject);

                                }

                            }

                        }





                        goto start;

                    case 5:

                        Console.WriteLine("Enter Id of teacher you want to delete");



                        Id = Convert.ToInt32(Console.ReadLine());

                        count = 0;

                        found = -1;

                        //teach2 = context.UpdateTeacher(Idnum, teachers); 

                        foreach (var item in teachers)

                        {

                            if (item.TeacherId == Id)

                            {

                                found = count;

                            }

                            count++;

                        }

                        if (found == -1)

                        {

                            Console.WriteLine("ID Not found");

                        }

                        else

                        {

                            teachers.RemoveAt(found);

                            Console.WriteLine("Deleted record\n");

                            using (StreamWriter wrt = File.CreateText(filename))

                            {

                                foreach (TeacherModel t1 in teachers)

                                {

                                    wrt.WriteLine(t1.TeacherId + "," +

                                                  t1.TeacherName + "," +

                                                  t1.Class + "," +

                                                  t1.Section + "," +

                                                  t1.Subject);

                                }

                            }

                        }

                        goto start;

                    case 6:

                        Console.WriteLine("Exit");

                        break;

                    default:

                        Console.WriteLine("Invalid Choice");

                        goto start;

                }

            }

        }

    }

}