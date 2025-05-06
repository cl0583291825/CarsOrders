using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.Drawing.Imaging;
using Microsoft.Data.SqlClient;
using System.Xml;
using static CarsOrders.Form1;
using System.Xml.Linq;
using System.Globalization;
using System;
using static Azure.Core.HttpHeader;

namespace CarsOrders
{
    public partial class Form1 : Form
    {

        public class Car
        {
            public string CarNumber { get; set; }

            public string CarModel { get; set; }

            public string CarColor { get; set; }

            public Car(string carNumber, string carModel, string carColor)
            {
                CarNumber = carNumber;
                CarModel = carModel;
                CarColor = carColor;
            }
        }

        public class CarOrder
        {
            public int Id { get; set; }

            public string CompanyName { get; set; }

            public string CompanyHp { get; set; }

            public List<Car> Cars { get; set; }
        }

        public CarOrder Order { get; set; }

        public readonly string ConnectionString = "Server=localhost\\LSQL;Database=CarsTest;Trusted_Connection=True;TrustServerCertificate=True;";

        public string PathFile = $"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\\Downloads";

        public Form1()
        {
            InitializeComponent();
            Order = new CarOrder();
            Order.Cars = new List<Car>();
        }

        private void m_AddCarBtn_Click(object sender, EventArgs e)
        {
            Order.Cars.Add(new Car(m_CarNumber.Text, m_CarModel.Text, m_CarColor.Text));
            m_CarNumber.Clear();
            m_CarModel.Clear();
            m_CarColor.Clear();
        }

        private void m_SaveOrderBtn_Click(object sender, EventArgs e)
        {
            Order.CompanyName = m_CompanyNameTB.Text;
            Order.CompanyHp = m_CompanyHpTB.Text;
            if (!string.IsNullOrEmpty(m_CarNumber.Text) || !string.IsNullOrEmpty(m_CarModel.Text) || !string.IsNullOrEmpty(m_CarColor.Text))
            {
                Order.Cars.Add(new Car(m_CarNumber.Text, m_CarModel.Text, m_CarColor.Text));
                m_CarNumber.Clear();
                m_CarModel.Clear();
                m_CarColor.Clear();
            }
            SaveOrderOnDB();
        }

        private void SaveOrderOnDB()
        {
            try
            {
                using SqlConnection conn = new(ConnectionString);
                conn.Open();
                using SqlCommand cmdOrder = new("INSERT INTO Orders (CompanyName, CompanyHp, Date) OUTPUT INSERTED.Id VALUES (@name, @number, @date)", conn);
                cmdOrder.Parameters.AddWithValue("@name", Order.CompanyName);
                cmdOrder.Parameters.AddWithValue("@number", Order.CompanyHp);
                cmdOrder.Parameters.AddWithValue("@date", DateTime.Now);
                Order.Id = (int)cmdOrder.ExecuteScalar();


                string insertCarQuery = "INSERT INTO Cars (OrderId, CarNumber, Model, Color) VALUES (@id, @number, @model, @color)";
                using SqlCommand cmdCar = new(insertCarQuery, conn);

                cmdCar.Parameters.Add("@id", SqlDbType.Int);
                cmdCar.Parameters.Add("@number", SqlDbType.NVarChar);
                cmdCar.Parameters.Add("@model", SqlDbType.NVarChar);
                cmdCar.Parameters.Add("@color", SqlDbType.NVarChar);
                foreach (var c in Order.Cars)
                {
                    cmdCar.Parameters["@id"].Value = Order.Id;
                    cmdCar.Parameters["@number"].Value = c.CarNumber;
                    cmdCar.Parameters["@model"].Value = c.CarModel;
                    cmdCar.Parameters["@color"].Value = c.CarColor;

                    cmdCar.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                m_CompanyNameTB.Clear();
                m_CompanyHpTB.Clear();
                m_CarNumber.Clear();
                m_CarModel.Clear();
                m_CarColor.Clear();
            }

            ShowSaveToXmlBtn();
        }

        private void ShowSaveToXmlBtn()
        {
            Button saveToXmlBtn = new Button();
            saveToXmlBtn.Text = "הנפק קובץ Xml";
            saveToXmlBtn.Visible = true;
            saveToXmlBtn.Width = 200;
            saveToXmlBtn.Height = m_SaveOrderBtn.Height;
            saveToXmlBtn.Location = new Point(m_SaveOrderBtn.Location.X, m_SaveOrderBtn.Location.Y + 80);
            saveToXmlBtn.Click += SaveToXmlBtn_Click;
            this.Controls.Add(saveToXmlBtn);
        }

        private void SaveToXmlBtn_Click(object? sender, EventArgs e) => SaveOrderToXml();

        private void SaveOrderToXml()
        {
            var order = Order;

            XmlDocument doc = new XmlDocument();

            XmlElement orderRequest = doc.CreateElement("OrderRequest");

            XmlElement idElement = doc.CreateElement("OrderID");
            idElement.InnerText = order.Id.ToString();
            orderRequest.AppendChild(idElement);

            XmlElement dateElement = doc.CreateElement("OrderDate");
            dateElement.InnerText = DateTime.Now.ToString();
            orderRequest.AppendChild(dateElement);

            XmlElement descElement = doc.CreateElement("OrderDescription");
            descElement.InnerText = order.CompanyName;
            orderRequest.AppendChild(descElement);

            XmlElement companyElement = doc.CreateElement("CompanyHp");
            companyElement.InnerText = order.CompanyHp;
            orderRequest.AppendChild(companyElement);

            XmlElement carsElement = doc.CreateElement("Cars");

            foreach (var c in order.Cars)
            {
                XmlElement carElement = doc.CreateElement("Car");

                XmlElement numberElement = doc.CreateElement("CarNumber");
                numberElement.InnerText = c.CarNumber;
                carElement.AppendChild(numberElement);

                XmlElement modelElement = doc.CreateElement("Model");
                modelElement.InnerText = c.CarModel;
                carElement.AppendChild(modelElement);

                XmlElement colorElement = doc.CreateElement("Color");
                colorElement.InnerText = c.CarColor;
                carElement.AppendChild(colorElement);

                carsElement.AppendChild(carElement);
            }

            orderRequest.AppendChild(carsElement);
            doc.AppendChild(orderRequest);

            var filePath = Path.Combine(PathFile, $"Order_{order.Id}.xml");
            doc.Save(filePath);
            System.Diagnostics.Process.Start("explorer.exe", $"/select,\"{filePath}\"");

            ShowBtnDisplayFeedbackXml();
        }

        public async void ShowBtnDisplayFeedbackXml()
        {
            await Task.Delay(20000);
            DisplayFeedbakXml.Visible = true;
            DisplayFeedbakXml.Click += DisplayFeedbakXmlBtn_Click;
        }

        public void DisplayFeedbakXmlBtn_Click(object sender, EventArgs e)
        {
            var filePath = Path.Combine(PathFile, $"CarsRequestFeedback (2).xml");
            ReadAndSaveOnDBFeedbackXml(filePath);
            DisplayFeedbakXml.Visible = false;
        }

        public void ReadAndSaveOnDBFeedbackXml(string xmlFilePath)
        {
            try
            {
                XDocument doc = XDocument.Load(xmlFilePath);

                var orderResponse = doc.Descendants("OrderResponse").FirstOrDefault();

                int orderId = int.Parse(orderResponse.Element("Order")?.Value ?? "0");
                DateTime feedbackDate;
                string feedbackDatestr = orderResponse.Element("FeedbackDate")?.Value;
                var success = DateTime.TryParseExact(
                    feedbackDatestr,
                    "dd-MM-yyyy'T'HH:mm",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None,
                    out feedbackDate
                );
                feedbackDate = success ? feedbackDate : DateTime.Now;

                int feedbackType = int.Parse(orderResponse.Element("FeedbackType")?.Value ?? "0");
                string comment = orderResponse.Element("Comment")?.Value ?? "";

                string message = $"מספר הזמנה: {orderId}\r\n" +
                                 $"תאריך משוב: {feedbackDate}\r\n" +
                                 $"סוג משוב: {feedbackType}\r\n" +
                                 $"הערה: {comment}";

                MessageBox.Show(message, "פרטי ההזמנה", MessageBoxButtons.OK, MessageBoxIcon.Information);

                using SqlConnection conn = new(ConnectionString);
                conn.Open();

                string insertQuery = @"INSERT INTO Feedback (OrderId, FeedbackDate, FeedbackType, Comment)
                       VALUES (@OrderId, @FeedbackDate, @FeedbackType, @Comment)";

                using SqlCommand cmd = new SqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@OrderId", orderId);
                cmd.Parameters.AddWithValue("@FeedbackDate", feedbackDate);
                cmd.Parameters.AddWithValue("@FeedbackType", feedbackType);
                cmd.Parameters.AddWithValue("@Comment", comment);

                cmd.ExecuteNonQuery();

                insertQuery = @"INSERT INTO FeedbackType (Type, Description)
                       VALUES (@type, @description)";

                using SqlCommand cmdFeedbackType = new SqlCommand(insertQuery, conn);
                cmdFeedbackType.Parameters.AddWithValue("@type", feedbackType);
                cmdFeedbackType.Parameters.AddWithValue("@description", comment);

                cmdFeedbackType.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void m_SearchBtn_Click(object sender, EventArgs e)
        {
            var input = m_SearchCarTB.Text;
            if (string.IsNullOrEmpty(input))
                MessageBox.Show("נא הזן טקסט לחיפוש", "אזהרה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                DoSearchCarOnDBAndDisplayDetailse(input);
        }

        private void DoSearchCarOnDBAndDisplayDetailse(string text)
        {
            using SqlConnection conn = new(ConnectionString);
            conn.Open();

            string searchQuery = @"SELECT c.CarNumber, c.OrderId, c.Model, c.Color, o.CompanyName, o.CompanyHp, o.Date
                                 FROM Cars c
                                 LEFT JOIN Orders o ON c.OrderId = o.Id
                                 WHERE c.CarNumber = @CarNumber";

            using SqlCommand cmd = new SqlCommand(searchQuery, conn);
            cmd.Parameters.AddWithValue("@CarNumber", text);

            using SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string message = $"מספר רכב: {reader["CarNumber"]}";

                if (reader["OrderId"] != DBNull.Value)
                {
                    message +=
                        $"\nמקושר להזמנה: {reader["OrderId"]}" +
                        $"\nחברה: {reader["CompanyName"]}" +
                        $"\nטלפון: {reader["CompanyHp"]}" +
                        $"\nתאריך: {Convert.ToDateTime(reader["Date"]).ToString("dd/MM/yyyy HH:mm")}";
                }
                else
                {
                    message += "\nאין הזמנה מקושרת לרכב זה.";
                }

                MessageBox.Show(message, "פרטי רכב:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("הרכב לא קיים במערכת");
            }
        }
    }
}
