using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;

namespace Secret_Santa
{

    class Rtc
    {
        public Rtc(string Name, string mail)
        {
            ime = Name;
            email = mail;
        }
        public string ime { get; set; }
        public string email { get; set; }


    }
    class Program
    {
        

        static void Main(string[] args)
        {
            List<Rtc> people = new List<Rtc>();
            int n = 11; //17
            List<int> brojevi = new List<int>();

            for (int i = 0; i < n; i++)
            {
                string mail = Console.ReadLine();
                string name = Console.ReadLine();
                
                
                Rtc a = new Rtc(name, mail);

                people.Add(a);
                brojevi.Add(i);
                
            }

            List<int> randomList = new List<int>();

            Random r = new Random();
            int randomIndex = 0;
            while (brojevi.Count > 0)
            {
                randomIndex = r.Next(0, brojevi.Count); //Choose a random object in the list
                randomList.Add(brojevi[randomIndex]); //add it to the new, random list
                brojevi.RemoveAt(randomIndex); //remove to avoid duplicates
            }

            for(int i = 0; i < n; i++)
            {
                try
                {
                    int next = i + 1;

                    if (i == n - 1)
                    {
                        next = 0;
                    }
                    MailAddress myemail = new MailAddress("aleksandarlk@gmail.com", "SECRET SANTA");
                    //MailAddress mail_to = new MailAddress("aleksa@lukac.rs", "Receiver");
                    MailAddress mail_to = new MailAddress(people[randomList[i]].email, people[randomList[i]].ime);

                    string password = "19081998al";

                    SmtpClient client_smtp = new SmtpClient("smtp.gmail.com", 587);
                    client_smtp.EnableSsl = true;
                    client_smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client_smtp.UseDefaultCredentials = false;
                    client_smtp.Credentials = new NetworkCredential(myemail.Address, password);

                    MailMessage message = new MailMessage(myemail, mail_to);
                    message.Subject = "Tvoj secret santa!";
                    message.Body = "Tvoj secret santa je: " + people[randomList[next]].ime + "!\n Kupi mu/joj nesto lepo :) \n";

                    client_smtp.Send(message);


                    Console.WriteLine("Uspesno");
                    /*int next = i + 1;
                    if (i % 2 == 1)
                        next = i - 1;

                    MailAddress myemail = new MailAddress("aleksandarlk@gmail.com", "ASOCIJACIJE");
                    //MailAddress mail_to = new MailAddress("aleksa@lukac.rs", "Receiver");
                    MailAddress mail_to = new MailAddress(people[randomList[i]].email, people[randomList[i]].ime);

                    string password = "19081998al";

                    SmtpClient client_smtp = new SmtpClient("smtp.gmail.com", 587);
                    client_smtp.EnableSsl = true;
                    client_smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client_smtp.UseDefaultCredentials = false;
                    client_smtp.Credentials = new NetworkCredential(myemail.Address, password);

                    MailMessage message = new MailMessage(myemail, mail_to);
                    message.Subject = "Par za asocijacije";
                    message.Body = "Tvoj par za asocijacije je " + people[randomList[next]].ime + "!\n";

                    client_smtp.Send(message);


                    Console.WriteLine("Uspesno");*/

                    /*int next = i + 1;

                    if(i == n-1)
                    {
                        next = 0;
                    }
                    MailAddress myemail = new MailAddress("aleksandarlk@gmail.com", "SECRET SANTA");
                    //MailAddress mail_to = new MailAddress("aleksa@lukac.rs", "Receiver");
                    MailAddress mail_to = new MailAddress(people[randomList[i]].email, people[randomList[i]].ime);

                    string password = "santa";

                    SmtpClient client_smtp = new SmtpClient("smtp.gmail.com", 587);
                    client_smtp.EnableSsl = true;
                    client_smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client_smtp.UseDefaultCredentials = false;
                    client_smtp.Credentials = new NetworkCredential(myemail.Address, password);

                    MailMessage message = new MailMessage(myemail, mail_to);
                    message.Subject = "Tvoj PRAVI secret santa!";
                    message.Body = "Tvoj (PRAVI) secret santa je: " + people[randomList[next]].ime + "!\n Kupi mu/joj nesto lepo za 27.12! :) \n PS Izvinite na prethodnoj gresci";

                    client_smtp.Send(message);


                    Console.WriteLine("Uspesno");*/
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            Console.ReadLine();
        }
    }
}
