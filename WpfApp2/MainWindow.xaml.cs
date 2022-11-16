using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string namecity;
        string selectedCity;


        public MainWindow()
        {
            
            InitializeComponent();

            
        }

        public void city1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            selectedCity = city1.SelectedValue.ToString();
            switch (selectedCity)
            {
                case "Погода во Владимире":
                    namecity = "vo-vladimire/";
                    Window_Loaded(sender, e);
                    break;
                case "Погода в Кольчугино":
                    namecity = "v-kolchugino/ ";
                    Window_Loaded(sender, e);
                    break;
                case "Погода в Сочи":
                    namecity = "v-sochi/";
                    Window_Loaded(sender, e);
                    break;
                case "Погода в Палане":
                    namecity = "v-palane/";
                    Window_Loaded(sender, e);
                    break;
                case "Погода в Киншасе":
                    namecity = "v-kinshase/";
                    Window_Loaded(sender, e);
                    break;
                case "Погода в Дубае":
                    namecity = "v-dubae/";
                    Window_Loaded(sender, e);
                    break;
                case "Погода в Амундсен-Скотте":
                    namecity = "v-amundsen-skotte/";
                    Window_Loaded(sender, e);
                    break;

            }

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string pageContent = LoadPage(url: @"https://weather.rambler.ru/" + namecity);
            var document = new HtmlDocument();
            document.LoadHtml(pageContent);

            #region Pars

            HtmlNodeCollection links = document.DocumentNode.SelectNodes(".//div[@class='HhSR MBvM']");
            temperature.Text = links.Last().InnerText;

            HtmlNodeCollection city = document.DocumentNode.SelectNodes(".//div[@class='wkAo']//div[@class='rICO']");
            city1.Text = city.Last().InnerText;

            HtmlNodeCollection data = document.DocumentNode.SelectNodes(".//div[@class='w4bT']");
            dt.Text = data.Last().InnerText;

            HtmlNodeCollection now_feels = document.DocumentNode.SelectNodes(".//span[@class='iO0y']");
            feels.Text = now_feels.Last().InnerText;

            HtmlNodeCollection desc = document.DocumentNode.SelectNodes(".//div[@class='TWnE']");
            descrip.Text = desc.Last().InnerText;

            HtmlNodeCollection windNode = document.DocumentNode.SelectNodes(".//div[@class='hjtR wind hC8A iBF1']//span[@class='VaOz PB4k']");
            wind.Text = windNode.Last().InnerText;

            HtmlNodeCollection pressureNode = document.DocumentNode.SelectNodes(".//div[@class='hjtR pressure hC8A iBF1']//span[@class='VaOz PB4k']");
            pressure.Text = pressureNode.Last().InnerText;

            HtmlNodeCollection moonNode = document.DocumentNode.SelectNodes(".//div[@class='hjtR hC8A iBF1']//span[@class='VaOz PB4k']");
            moon.Text = moonNode.Last().InnerText;

            //Таблица погоды(День 1)

            HtmlNodeCollection tomorowNode = document.DocumentNode.SelectNodes("/html/body/div[1]/div[9]/div[1]/div[1]/div[1]/div[2]/div/table/tbody/tr[1]/td[1]/a/span[1]");
            tomorow.Text = tomorowNode.Last().InnerText;

            HtmlNodeCollection tomorowDtNode = document.DocumentNode.SelectNodes("/html/body/div[1]/div[9]/div[1]/div[1]/div[1]/div[2]/div/table/tbody/tr[1]/td[1]/a/span[2]");
            tomorowDt.Text = tomorowDtNode.Last().InnerText;

            HtmlNodeCollection tomorowTmNode = document.DocumentNode.SelectNodes("/html/body/div[1]/div[9]/div[1]/div[1]/div[1]/div[2]/div/table/tbody/tr[1]/td[2]/a/span[1]");
            tomorowTm.Text = tomorowTmNode.Last().InnerText;

            HtmlNodeCollection tomorowTm2Node = document.DocumentNode.SelectNodes("/html/body/div[1]/div[9]/div[1]/div[1]/div[1]/div[2]/div/table/tbody/tr[1]/td[2]/a/span[2]");
            tomorowTm2.Text = tomorowTm2Node.Last().InnerText;

            HtmlNodeCollection precipitationNode = document.DocumentNode.SelectNodes("/html/body/div[1]/div[9]/div[1]/div[1]/div[1]/div[2]/div/table/tbody/tr[1]/td[3]/a/span");
            precipitation.Text = precipitationNode.Last().InnerText;

            HtmlNodeCollection windWeekNode = document.DocumentNode.SelectNodes("/html/body/div[1]/div[9]/div[1]/div[1]/div[1]/div[2]/div/table/tbody/tr[1]/td[4]/a/div/span");
            windWeek.Text = windWeekNode.Last().InnerText;

            //День 2

            HtmlNodeCollection weekDayOneNode = document.DocumentNode.SelectNodes("/html/body/div[1]/div[9]/div[1]/div[1]/div[1]/div[2]/div/table/tbody/tr[2]/td[1]/a/span[1]");
            weekDayOne.Text = weekDayOneNode.Last().InnerText;

            HtmlNodeCollection weekDayOneDtNode = document.DocumentNode.SelectNodes("/html/body/div[1]/div[9]/div[1]/div[1]/div[1]/div[2]/div/table/tbody/tr[2]/td[1]/a/span[2]");
            weekDayOneDt.Text = weekDayOneDtNode.Last().InnerText;

            HtmlNodeCollection weekDayOneTmNode = document.DocumentNode.SelectNodes("/html/body/div[1]/div[9]/div[1]/div[1]/div[1]/div[2]/div/table/tbody/tr[2]/td[2]/a/span[1]");
            weekDayOneTm.Text = weekDayOneTmNode.Last().InnerText;

            HtmlNodeCollection weekDayOneTm2Node = document.DocumentNode.SelectNodes("/html/body/div[1]/div[9]/div[1]/div[1]/div[1]/div[2]/div/table/tbody/tr[2]/td[2]/a/span[2]");
            weekDayOneTm2.Text = weekDayOneTm2Node.Last().InnerText;

            HtmlNodeCollection weekDayOnePrecipitationNode = document.DocumentNode.SelectNodes("/html/body/div[1]/div[9]/div[1]/div[1]/div[1]/div[2]/div/table/tbody/tr[2]/td[3]/a/span");
            weekDayOnePrecipitation.Text = weekDayOnePrecipitationNode.Last().InnerText;

            HtmlNodeCollection weekDayOneWindWeekNode = document.DocumentNode.SelectNodes("/html/body/div[1]/div[9]/div[1]/div[1]/div[1]/div[2]/div/table/tbody/tr[2]/td[4]/a/div/span");
            weekDayOneWindWeek.Text = weekDayOneWindWeekNode.Last().InnerText;

            //День 3

            HtmlNodeCollection weekDayTwoNode = document.DocumentNode.SelectNodes("/html/body/div[1]/div[9]/div[1]/div[1]/div[1]/div[2]/div/table/tbody/tr[3]/td[1]/a/span[1]");
            weekDayTwo.Text = weekDayTwoNode.Last().InnerText;

            HtmlNodeCollection weekDayTwoDtNode = document.DocumentNode.SelectNodes("/html/body/div[1]/div[9]/div[1]/div[1]/div[1]/div[2]/div/table/tbody/tr[3]/td[1]/a/span[2]");
            weekDayTwoDt.Text = weekDayTwoDtNode.Last().InnerText;

            HtmlNodeCollection weekDayTwoTmNode = document.DocumentNode.SelectNodes("/html/body/div[1]/div[9]/div[1]/div[1]/div[1]/div[2]/div/table/tbody/tr[3]/td[2]/a/span[1]");
            weekDayTwoTm.Text = weekDayTwoTmNode.Last().InnerText;

            HtmlNodeCollection weekDayTwoTm2Node = document.DocumentNode.SelectNodes("/html/body/div[1]/div[9]/div[1]/div[1]/div[1]/div[2]/div/table/tbody/tr[3]/td[2]/a/span[2]");
            weekDayTwoTm2.Text = weekDayTwoTm2Node.Last().InnerText;

            HtmlNodeCollection weekDayTwoPrecipitationNode = document.DocumentNode.SelectNodes("/html/body/div[1]/div[9]/div[1]/div[1]/div[1]/div[2]/div/table/tbody/tr[3]/td[3]/a/span");
            weekDayTwoPrecipitation.Text = weekDayTwoPrecipitationNode.Last().InnerText;

            HtmlNodeCollection weekDayTwoWindWeekNode = document.DocumentNode.SelectNodes("/html/body/div[1]/div[9]/div[1]/div[1]/div[1]/div[2]/div/table/tbody/tr[3]/td[4]/a/div/span");
            weekDayTwoWindWeek.Text = weekDayTwoWindWeekNode.Last().InnerText;

            //День 4

            HtmlNodeCollection weekDayTreeNode = document.DocumentNode.SelectNodes("/html/body/div[1]/div[9]/div[1]/div[1]/div[1]/div[2]/div/table/tbody/tr[4]/td[1]/a/span[1]");
            weekDayTree.Text = weekDayTreeNode.Last().InnerText;

            HtmlNodeCollection weekDayTreeDtNode = document.DocumentNode.SelectNodes("/html/body/div[1]/div[9]/div[1]/div[1]/div[1]/div[2]/div/table/tbody/tr[4]/td[1]/a/span[2]");
            weekDayTreeDt.Text = weekDayTreeDtNode.Last().InnerText;

            HtmlNodeCollection weekDayTreeTmNode = document.DocumentNode.SelectNodes("/html/body/div[1]/div[9]/div[1]/div[1]/div[1]/div[2]/div/table/tbody/tr[4]/td[2]/a/span[1]");
            weekDayTreeTm.Text = weekDayTreeTmNode.Last().InnerText;

            HtmlNodeCollection weekDayTreeTm2Node = document.DocumentNode.SelectNodes("/html/body/div[1]/div[9]/div[1]/div[1]/div[1]/div[2]/div/table/tbody/tr[4]/td[2]/a/span[2]");
            weekDayTreeTm2.Text = weekDayTreeTm2Node.Last().InnerText;

            HtmlNodeCollection weekDayTreePrecipitationNode = document.DocumentNode.SelectNodes("/html/body/div[1]/div[9]/div[1]/div[1]/div[1]/div[2]/div/table/tbody/tr[4]/td[3]/a/span");
            weekDayTreePrecipitation.Text = weekDayTreePrecipitationNode.Last().InnerText;

            HtmlNodeCollection weekDayTreeWindWeekNode = document.DocumentNode.SelectNodes("/html/body/div[1]/div[9]/div[1]/div[1]/div[1]/div[2]/div/table/tbody/tr[4]/td[4]/a/div/span");
            weekDayTreeWindWeek.Text = weekDayTreeWindWeekNode.Last().InnerText;

            //День 5

            HtmlNodeCollection weekDayFourNode = document.DocumentNode.SelectNodes("/html/body/div[1]/div[9]/div[1]/div[1]/div[1]/div[2]/div/table/tbody/tr[5]/td[1]/a/span[1]");
            weekDayFour.Text = weekDayFourNode.Last().InnerText;

            HtmlNodeCollection weekDayFourDtNode = document.DocumentNode.SelectNodes("/html/body/div[1]/div[9]/div[1]/div[1]/div[1]/div[2]/div/table/tbody/tr[5]/td[1]/a/span[2]");
            weekDayFourDt.Text = weekDayFourDtNode.Last().InnerText;

            HtmlNodeCollection weekDayFourTmNode = document.DocumentNode.SelectNodes("/html/body/div[1]/div[9]/div[1]/div[1]/div[1]/div[2]/div/table/tbody/tr[5]/td[2]/a/span[1]");
            weekDayFourTm.Text = weekDayFourTmNode.Last().InnerText;

            HtmlNodeCollection weekDayFourTm2Node = document.DocumentNode.SelectNodes("/html/body/div[1]/div[9]/div[1]/div[1]/div[1]/div[2]/div/table/tbody/tr[5]/td[2]/a/span[2]");
            weekDayFourTm2.Text = weekDayFourTm2Node.Last().InnerText;

            HtmlNodeCollection weekDayFourPrecipitationNode = document.DocumentNode.SelectNodes("/html/body/div[1]/div[9]/div[1]/div[1]/div[1]/div[2]/div/table/tbody/tr[5]/td[3]/a/span");
            weekDayFourPrecipitation.Text = weekDayFourPrecipitationNode.Last().InnerText;

            HtmlNodeCollection weekDayFourWindWeekNode = document.DocumentNode.SelectNodes("/html/body/div[1]/div[9]/div[1]/div[1]/div[1]/div[2]/div/table/tbody/tr[5]/td[4]/a/div/span");
            weekDayFourWindWeek.Text = weekDayFourWindWeekNode.Last().InnerText;

            //День 6

            HtmlNodeCollection weekDayFiveNode = document.DocumentNode.SelectNodes("/html/body/div[1]/div[9]/div[1]/div[1]/div[1]/div[2]/div/table/tbody/tr[6]/td[1]/a/span[1]");
            weekDayFive.Text = weekDayFiveNode.Last().InnerText;

            HtmlNodeCollection weekDayFiveDtNode = document.DocumentNode.SelectNodes("/html/body/div[1]/div[9]/div[1]/div[1]/div[1]/div[2]/div/table/tbody/tr[6]/td[1]/a/span[2]");
            weekDayFiveDt.Text = weekDayFiveDtNode.Last().InnerText;

            HtmlNodeCollection weekDayFiveTmNode = document.DocumentNode.SelectNodes("/html/body/div[1]/div[9]/div[1]/div[1]/div[1]/div[2]/div/table/tbody/tr[6]/td[2]/a/span[1]");
            weekDayFiveTm.Text = weekDayFiveTmNode.Last().InnerText;

            HtmlNodeCollection weekDayFiveTm2Node = document.DocumentNode.SelectNodes("/html/body/div[1]/div[9]/div[1]/div[1]/div[1]/div[2]/div/table/tbody/tr[6]/td[2]/a/span[2]");
            weekDayFiveTm2.Text = weekDayFiveTm2Node.Last().InnerText;

            HtmlNodeCollection weekDayFivePrecipitationNode = document.DocumentNode.SelectNodes("/html/body/div[1]/div[9]/div[1]/div[1]/div[1]/div[2]/div/table/tbody/tr[6]/td[3]/a/span");
            weekDayFivePrecipitation.Text = weekDayFivePrecipitationNode.Last().InnerText;

            HtmlNodeCollection weekDayFiveWindWeekNode = document.DocumentNode.SelectNodes("/html/body/div[1]/div[9]/div[1]/div[1]/div[1]/div[2]/div/table/tbody/tr[6]/td[4]/a/div/span");
            weekDayFiveWindWeek.Text = weekDayFiveWindWeekNode.Last().InnerText;

            //День 7

            HtmlNodeCollection weekDaySixNode = document.DocumentNode.SelectNodes("/html/body/div[1]/div[9]/div[1]/div[1]/div[1]/div[2]/div/table/tbody/tr[7]/td[1]/a/span[1]");
            weekDaySix.Text = weekDaySixNode.Last().InnerText;

            HtmlNodeCollection weekDaySixDtNode = document.DocumentNode.SelectNodes("/html/body/div[1]/div[9]/div[1]/div[1]/div[1]/div[2]/div/table/tbody/tr[7]/td[1]/a/span[2]");
            weekDaySixDt.Text = weekDaySixDtNode.Last().InnerText;

            HtmlNodeCollection weekDaySixTmNode = document.DocumentNode.SelectNodes("/html/body/div[1]/div[9]/div[1]/div[1]/div[1]/div[2]/div/table/tbody/tr[7]/td[2]/a/span[1]");
            weekDaySixTm.Text = weekDaySixTmNode.Last().InnerText;

            HtmlNodeCollection weekDaySixTm2Node = document.DocumentNode.SelectNodes("/html/body/div[1]/div[9]/div[1]/div[1]/div[1]/div[2]/div/table/tbody/tr[7]/td[2]/a/span[2]");
            weekDaySixTm2.Text = weekDaySixTm2Node.Last().InnerText;

            HtmlNodeCollection weekDaySixPrecipitationNode = document.DocumentNode.SelectNodes("/html/body/div[1]/div[9]/div[1]/div[1]/div[1]/div[2]/div/table/tbody/tr[7]/td[3]/a/span");
            weekDaySixPrecipitation.Text = weekDaySixPrecipitationNode.Last().InnerText;

            HtmlNodeCollection weekDaySixWindWeekNode = document.DocumentNode.SelectNodes("/html/body/div[1]/div[9]/div[1]/div[1]/div[1]/div[2]/div/table/tbody/tr[7]/td[4]/a/div/span");
            weekDaySixWindWeek.Text = weekDaySixWindWeekNode.Last().InnerText;

            #endregion

            string[] textImage = descrip.Text.Split( ',', ' ' );
            string imageText = textImage[textImage.Length - 1];
            switch (imageText)
            {
                case "облачно":
                    Back.Source = new BitmapImage(new Uri(@"/Pictures/BackCloud.jpg", UriKind.Relative));
                    Icon.Source = new BitmapImage(new Uri(@"/IconsForProject/Cloud1.png", UriKind.Relative));
                    break;

                case "ясно":
                    Back.Source = new BitmapImage(new Uri(@"/Pictures/BackSunny.jpg", UriKind.Relative));
                    Icon.Source = new BitmapImage(new Uri(@"/IconsForProject/Sun1.png", UriKind.Relative));
                    break;

                case "снег":
                    Back.Source = new BitmapImage(new Uri(@"/Pictures/BackSnow.jpg", UriKind.Relative));
                    Icon.Source = new BitmapImage(new Uri(@"/IconsForProject/Snow1.png", UriKind.Relative));
                    break;

                case "дождь":
                    Back.Source = new BitmapImage(new Uri(@"/Pictures/BackRain.jpg", UriKind.Relative));
                    Icon.Source = new BitmapImage(new Uri(@"/IconsForProject/Rain1.png", UriKind.Relative));
                    break;
            }
        }

        static string LoadPage(string url)
        {
            var result = "";
            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var receiveStream = response.GetResponseStream();
                if (receiveStream != null)
                {
                    StreamReader readStream;
                    if (response.CharacterSet == null)
                        readStream = new StreamReader(receiveStream);
                    else
                        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                    result = readStream.ReadToEnd();
                    readStream.Close();
                }
                response.Close();
            }
            return result;

        }

    }
}
