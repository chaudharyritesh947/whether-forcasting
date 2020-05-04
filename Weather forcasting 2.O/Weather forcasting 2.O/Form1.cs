using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Weather_forcasting_2.O
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


         /*   if (e.KeyCode == Keys.Enter)
            {

                //  string urlPart1 = "https://api.openweathermap.org/data/2.5/weather?id=";//2643743
                //string urlPart2 = "&APPID=eee03b946c5ce4fb877804104b4aeb26";
                string urlPart111 = "https://api.openweathermap.org/data/2.5/weather?q=";//CITY,COUNTRY.
                string urlPart21 = "&APPID=eee03b946c5ce4fb877804104b4aeb26";
                //Console.Clear();
                Console.Write("City,Country: ");
                var city1= textBox1.Text;//Console.ReadLine();
                var country1= textBox2.Text;//Console.ReadLine();
                Console.WriteLine();
                string furl1 = urlPart111 + "" + city1 + "," + country1 + "" + urlPart21;
                String url1 = furl1;
                //Program p = new Program();
                String res1 = GET(url1);
                //Console.WriteLine("in formality function ");
                var details1 = JObject.Parse(res1);
                PrintDetails(details1); ;
            }
            */
            //  string urlPart1 = "https://api.openweathermap.org/data/2.5/weather?id=";//2643743
            //string urlPart2 = "&APPID=eee03b946c5ce4fb877804104b4aeb26";
            string urlPart1 = "https://api.openweathermap.org/data/2.5/weather?q=";//CITY,COUNTRY.
            string urlPart2 = "&APPID=eee03b946c5ce4fb877804104b4aeb26";
            //Console.Clear();
            Console.Write("City,Country: ");
            var city = textBox1.Text;//Console.ReadLine();
            var country = textBox2.Text;//Console.ReadLine();
            Console.WriteLine();
            string furl = urlPart1 + "" + city + "," + country + "" + urlPart2;
            String url = furl;
            //Program p = new Program();
            String res = GET(url);
            //Console.WriteLine("in formality function ");
            var details = JObject.Parse(res);
            PrintDetails(details);
        }

        public  void PrintDetails(Newtonsoft.Json.Linq.JObject details)
        {//This function accepts the Json Object as parameter, and it prints the corresponding output.
            try
            {
                // Here the Key value pair thing of json is manipulated.
                //     Console.WriteLine("direct 1 ");
                var latitude = details["coord"]["lon"];
                //   Console.WriteLine("direct 2 ");
                var longitude = details["coord"]["let"];
                // Console.WriteLine("direct 3 ");
                string cord1 = (string)latitude + "" + "" + (string)longitude + "";
                //Console.WriteLine("direct 4 ");
                //   int cord = Int32.Parse(cord1); 
                var temp = details["main"]["temp"] + " in Fahrenheit ";
                //Console.WriteLine("direct 5 ");
                //Console.WriteLine("temperature: " + temp);
              
                var press = details["main"]["pressure"] + " in Pascals";
                // Console.WriteLine("Pressure: " + press);
                
                var min_temp = details["main"]["temp_min"];
                var humid = details["main"]["humidity"];
                //Console.WriteLine("Humidity: " + humid + "( unit for humidity is Grams of water vapour per cubic meter)");
               
                //Console.WriteLine("Minimum Temperature: " + min_temp + " in Fahrenheit ");
             
                var max_temp = details["main"]["temp_max"];
                //Console.WriteLine("Maximum temperature: " + max_temp + " in Fahrenheit ");
                
                var visiblity = details["visibility"];
                //Console.WriteLine("Visiblity: " + visiblity);
            
                var windy = details["wind"]["speed"] + " in km/h";
                // Console.WriteLine("wind Speed: " + windy);
               
                var country_name = details["sys"]["country"];
                //  Console.WriteLine("Country Code: " + country_name);
                label11.Text = "Country Code: " + country_name;
                var city_name = details["name"];
                //Console.WriteLine("City: " + city_name);

                // Console.WriteLine("out of the printdetails");

                label4.Text = "Temperature: " + temp;
                label5.Text = "Pressure: " + press;
                label6.Text = "Humidity: " + humid + " unit for humidity is Grams of water vapour per cubic meter ";
                label8.Text = "Maximum temperature: " + max_temp + " in Fahrenheit ";
                label7.Text = "Minimum Temperature: " + min_temp + " in Fahrenheit ";
                label9.Text = "Visiblity: " + visiblity;
                label10.Text = "wind Speed: " + windy;
                label13.Text = "City: " + city_name;


            }
            catch (Exception e1)
            {
                //Sometimes when desired attribut is missing for some keys, That kind of exception will be handled at this point.

                label4.Text = "";
                label5.Text = "";
                label6.Text = "";
                label8.Text = "";
                label7.Text = "";
                label9.Text = "";
                label10.Text = "";
                label13.Text = "";
                  label11.Text = "";




                //Console.WriteLine( + e.Message);
                label7.Text = "No matches found against the given input, please refer to the \n CountryCodes.txt file (Provided with app).";
            }

        }
        string GET(string url)
        {
            System.Net.HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
                    return reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                    return errorText;

                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
/*
 
     using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using System.Threading;


/*
 * Utne bade file ko read krna console me possible nhi hai, so we can provide the txt file with this app. 
 and user can search the city and country, By typing the ctrl+F, and after that  the user can easily use the app to 
 its fullest.
 

namespace Whether_Forecasting
{
    class Program
    {
        public static void PrintDetails(Newtonsoft.Json.Linq.JObject details)
        {//This function accepts the Json Object as parameter, and it prints the corresponding output.
            try
            {
                // Here the Key value pair thing of json is manipulated.
                //     Console.WriteLine("direct 1 ");
                var latitude = details["coord"]["lon"];
                //   Console.WriteLine("direct 2 ");
                var longitude = details["coord"]["let"];
                // Console.WriteLine("direct 3 ");
                string cord1 = (string)latitude + "" + "" + (string)longitude + "";
                //Console.WriteLine("direct 4 ");
                //   int cord = Int32.Parse(cord1); 
                var temp = details["main"]["temp"] + " in Fahrenheit ";
                //Console.WriteLine("direct 5 ");
                Console.WriteLine("temperature: " + temp);
                var press = details["main"]["pressure"] + " in Pascals";
                Console.WriteLine("Pressure: " + press);
                var humid = details["main"]["humidity"];
                Console.WriteLine("Humidity: " + humid + "( unit for humidity is Grams of water vapour per cubic meter)");
                var min_temp = details["main"]["temp_min"];
                Console.WriteLine("Minimum Temperature: " + min_temp + " in Fahrenheit ");
                var max_temp = details["main"]["temp_max"];
                Console.WriteLine("Maximum temperature: " + max_temp + " in Fahrenheit ");
                var visiblity = details["visibility"];
                Console.WriteLine("Visiblity: " + visiblity);
                var windy = details["wind"]["speed"] + " in km/h";
                Console.WriteLine("wind Speed: " + windy);
                var country_name = details["sys"]["country"];
                Console.WriteLine("Country Code: " + country_name);
                var city_name = details["name"];
                Console.WriteLine("City: " + city_name);
                // Console.WriteLine("out of the printdetails");

            }
            catch (Exception e)
            {
                //Sometimes when desired attribut is missing for some keys, That kind of exception will be handled at this point.
                Console.WriteLine("direct " + e.Message);
            }

        }

        public void Instructions()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine();
            Console.WriteLine(" \t \t Do you know the City and Country? Please Answer in Y/N.(Y-> Yes, N-> No)");
            Console.WriteLine("\t \t Enter 5 to exit");
            Console.Write("\n Option: ");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
        }
        public void FormalityFunction()
        {
            //  string urlPart1 = "https://api.openweathermap.org/data/2.5/weather?id=";//2643743
            //string urlPart2 = "&APPID=eee03b946c5ce4fb877804104b4aeb26";
            string urlPart1 = "https://api.openweathermap.org/data/2.5/weather?q=";//CITY,COUNTRY.
            string urlPart2 = "&APPID=eee03b946c5ce4fb877804104b4aeb26";
            Console.Clear();
            Console.Write("City,Country: ");
            var city = Console.ReadLine();
            var country = Console.ReadLine();
            Console.WriteLine();
            string furl = urlPart1 + "" + city + "," + country + "" + urlPart2;
            String url = furl;
            //Program p = new Program();
            String res = GET(url);
            //Console.WriteLine("in formality function ");
            var details = JObject.Parse(res);
            PrintDetails(details);
        }

        public void Welcome()
        {

            Console.WriteLine("\n \n \n \n \n");
            Console.Write("\t \t \t \t \t");
            Console.WriteLine("Welcome, to our weather App");
            Thread.Sleep(1500);
            return;

        }
        static void Main(string[] args)
        {

            Program p = new Program();
            p.Welcome();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkBlue;



            Console.Clear();
            while (true)
            {
                p.Instructions();//It contains all the initial instructions 
                string desc = Console.ReadLine();
                if (desc.Equals("Y") || desc.Equals("y"))
                {
                    Console.Clear();
                    p.FormalityFunction();
                }
                else if (desc.Equals("N") || desc.Equals("n"))
                {
                    Console.Clear();
                    Console.WriteLine("Please visit the documentation of the software, inorder to utillise it to the fullest");
                    //Console.ReadKey();
                }
                else if (desc.Equals("5"))
                {
                    Console.Clear();
                    Console.WriteLine("\t \t Are you sure?");
                    Console.WriteLine("\t \t Y/N");
                    string choice = Console.ReadLine();
                    if (choice.Equals("y") || choice.Equals("Y"))
                    {
                        Console.Clear();
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine("\t \t \t \t \t Thank you");

                        Thread.Sleep(2000);

                        Environment.Exit(0);
                    }
                    //  else if (choice.Equals("n") || choice.Equals("N")) {

                    //}
                }
                else
                {
                    Console.WriteLine("\t \tPlease enter the correct option: choose among Y and N. Y for yes, and N for No.");
                    // Console.ReadKey();
                }

            }
            // Console.WriteLine(details["weather"]);



            Console.WriteLine(); Console.WriteLine();
            Console.WriteLine(); Console.WriteLine();
            Console.WriteLine(); Console.WriteLine();

            //var dt = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(Math.Round(1486220400 / 1000d)).ToLocalTime();
            //Console.WriteLine(dt);
            Console.ReadLine();
        }

        string GET(string url)
        {
            System.Net.HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
                    return reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                    return errorText;

                }
            }
        }
    }
}



     */