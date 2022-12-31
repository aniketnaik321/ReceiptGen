using NodaTime;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBuilder.Service
{
    public class UtilityService
    {

        //        public void SetGradient() {         


        //        LinearGradientBrush gradientBrush = new LinearGradientBrush(
        //    new Point(0, 0),
        //    new Point(0, this.Height), // Vertical gradient.
        //    Color.Red,
        //    Color.Blue); // Red to blue gradient.

        //        Bitmap bmp = new Bitmap(this.Width, this.Height);
        //using (Graphics g = Graphics.FromImage(bmp))
        //{
        //    g.FillRectangle(gradientBrush, this.ClientRectangle);
        //    }

        //this.BackgroundImage = bmp;

        //    }


        public static string DataFormatInMonthAndYear(string dateTime) {
            
          //  string format = "MM/dd/yyyy";
            DateTime date = DateTime.Parse(dateTime);
           return date.ToString("MMM yyyy"); 
        }

        public static string DataFormatInMonthAndYear(DateTime dateTime)
        {
            return dateTime.ToString("MMM yyyy");
        }


        public static string DifferenceInTwoDates(LocalDateTime fromDate,LocalDateTime endDate) {           
            Period period = Period.Between(fromDate, endDate);
            return ($"{period.Years} years, {period.Months} months"); // Output: "7 years, 1 month"

        }
    }
}
