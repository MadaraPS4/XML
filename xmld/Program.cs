using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace xmld
{
    class Program
    {
        static void Main(string[] args)
        {

            //a)...Первое задание 

            XmlDocument document = new XmlDocument();
            document.Load("https://habrahabr.ru/rss/interesting/");
            XmlElement xRoot = document.DocumentElement;

            List<Item> item = new List<Item>();
            string first = "";
            string second = "";
            string third = "";
            string fourth = "";

            ArrayList f=new ArrayList();
            ArrayList s=new ArrayList();
            ArrayList t=new ArrayList();
            ArrayList fo=new ArrayList();

            foreach (XmlNode x in xRoot)
            {
                foreach(XmlNode y in x.ChildNodes)
                {
                    if (y.Name == "title")
                    {

                        first = y.InnerText;
                    }
                    if (y.Name == "link")
                    {
                        second = y.InnerText;
                    }
                    if (y.Name == "description")
                    {
                        third = y.InnerText;
                    }
                    if (y.Name == "pubDate")
                    {
                        fourth = y.InnerText;
                        item.Add(new Item { title = first, link = second, description = third, pubDate = fourth });
                    }
                    if (y.Name == "item")
                    {
                        foreach(XmlNode z in y.ChildNodes)
                        {
                            if (z.Name == "title")
                            {
                                f.Add(z.InnerText);
                            }
                            if (z.Name == "link")
                            {
                                s.Add(z.InnerText);
                            }
                            if (z.Name == "description")
                            {
                                t.Add(z.InnerText);
                            }
                            if (z.Name == "pubDate")
                            {
                                fo.Add(z.InnerText);
                            }                  
                        }
                    }       
                }
            }
            for (int i = 0; i < f.Count; i++)
            {
                item.Add(new Item { title = f[i].ToString(), link = s[i].ToString(), description = t[i].ToString(), pubDate = fo[i].ToString() });
            }

            foreach (var q in item)
            {
                Console.WriteLine("Title= " + q.title);
                Console.WriteLine("Link = " + q.link);
                Console.WriteLine("Description= " + q.description);
                Console.WriteLine("Data =" +q.pubDate);
                Console.WriteLine(new string('-',120));
                Console.WriteLine();
            }


            //б)...Второе задание


            document.Load("XMLFile1.xml");
            XmlElement root = document.DocumentElement;     
            List<Student> students = new List<Student>();

            foreach(XmlNode node in root)
            {
                students.Add(new Student { Name = node["Name"].InnerText, Ocenka = node["Ocenka"].InnerText });
            }

            foreach(var student in students)
            {
                Console.WriteLine("Name=" +student.Name+", "+"Ocenka="+student.Ocenka);
                
            }

            Console.ReadKey();
        }
    }
}
